Module Cheat

    Public Function R(ByVal hwnd As UInteger, ByVal address As UInteger, ByVal nbyte As UInteger) As UInteger
        Dim value As IntPtr
        ReadProcessMemory(hwnd, address, value, nbyte, IntPtr.Zero)
        Return value
    End Function

    Public Sub W(ByVal hwnd As UInteger, ByVal address As UInteger, ByVal value As UInteger, ByVal nbyte As UInteger)
        WriteProcessMemory(hwnd, address, value, nbyte, IntPtr.Zero)
    End Sub

    Private Function digit(ByVal d As UInteger) As UInteger

        If 1 <= d And d <= 9 Then
            Return CDec(d)

        Else
            Return 0

        End If

    End Function

    Private Function isStage(ByVal Ly As UInteger()) As Boolean
        Dim res As Boolean = (0 <= Ly(0) And Ly(0) <= 9) Or Ly(0) = &HFF

        For i As Integer = 1 To 4
            If Not res Then Return False
            res = res And ((0 <= Ly(i) And Ly(i) <= 9) Or Ly(i) = &HFF)
        Next

        Return res
    End Function

    Public Function getStage(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Stage As UInteger) As Boolean

        Dim LayerOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        Dim LayerOffset2 As UInteger = R(hp, LayerOffset1 + &H97C, 4)
        Dim LayerOffset3 As UInteger = R(hp, LayerOffset2 + &H74, 4)

        Dim Layer(0 To 4) As UInteger

        Layer(0) = CDec(R(hp, LayerOffset3 + &H1C, 1))
        Layer(1) = CDec(R(hp, LayerOffset3 + &H20, 1))
        Layer(2) = CDec(R(hp, LayerOffset3 + &H24, 1))
        Layer(3) = CDec(R(hp, LayerOffset3 + &H28, 1))
        Layer(4) = CDec(R(hp, LayerOffset3 + &H2C, 1))

        Dim istage As Boolean = isStage(Layer)

        If istage Then
            Stage = Layer(0)

            For i As Integer = 1 To 4
                Stage += Math.Pow(10, i) * digit(Layer(i))
            Next

        Else
            Stage = 0

        End If

        Return (
            (LayerOffset1 > 0) And
            (LayerOffset2 > 0) And
            (LayerOffset3 > 0) And
            istage And
            (1 <= Stage) And
            (Stage <= 10000)
            )

    End Function

    Public Sub writeStage(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Stage As UInteger)
        Dim LayerOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        Dim LayerOffset2 As UInteger = R(hp, LayerOffset1 + &H97C, 4)
        Dim LayerOffset3 As UInteger = R(hp, LayerOffset2 + &H74, 4)
        Dim Layer(0 To 4) As UInteger

        For i As Integer = 4 To 0 Step -1
            Layer(i) = Math.Floor(Stage * Math.Pow(10, -i))
            For j As UInteger = i + 1 To 4
                Layer(i) -= Layer(j) * Math.Pow(10, j - i)
            Next
        Next

        W(hp, LayerOffset3 + &H1C, Hex(Layer(0)), 1)
        W(hp, LayerOffset3 + &H20, Hex(Layer(1)), 1)
        W(hp, LayerOffset3 + &H24, Hex(Layer(2)), 1)
        W(hp, LayerOffset3 + &H28, Hex(Layer(3)), 1)
        W(hp, LayerOffset3 + &H2C, Hex(Layer(4)), 1)
    End Sub

    Public Function getHP(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef HealthPoint As UInteger, ByRef HPUpper As UInteger) As Boolean
        Dim HPOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim HPOffset2 As UInteger = R(hp, HPOffset1 + &H2C, 4)

        HealthPoint = CDec(R(hp, HPOffset2 + &HF0, 2))
        HPUpper = CDec(R(hp, HPOffset2 + &HF2, 2))

        Return (
            (HPOffset1 > 0) And
            (HPOffset2 > 0) And
            (1 <= HealthPoint) And
            (HealthPoint <= HPUpper) And
            (HPUpper <= 65535) And
            (15 <= HPUpper)
            )

    End Function

    Public Sub writeHP(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger, ByVal upper As UInteger)
        Dim HPOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim HPOffset2 As UInteger = R(hp, HPOffset1 + &H2C, 4)
        W(hp, HPOffset2 + &HF0, n, 2)
        W(hp, HPOffset2 + &HF2, upper, 2)
        W(hp, HPOffset2 + &HF4, upper, 2)
    End Sub


    Public Function getCash(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Cash As UInteger) As Boolean

        Dim CashOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        Cash = CDec(R(hp, CashOffset1 + &H24, 4))

        'Return (
        '    (CashOffset1 > 0) And
        '    (0 <= Cash) And
        '    (Cash <= 999999999)
        '    )

        Return (CashOffset1 > 0) And (0 <= Cash)

    End Function

    Public Sub writeCash(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
        Dim CashOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        W(hp, CashOffset1 + &H24, n, 4)
    End Sub

    Public Function getStrength(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Strength As UInteger, ByRef StrengthUpper As UInteger) As Boolean

        Dim StrengthOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim StrengthOffset2 As UInteger = R(hp, StrengthOffset1 + &H28, 4)
        Dim StrengthOffset3 As UInteger = R(hp, StrengthOffset2 + &H10, 4)

        Strength = CDec(R(hp, StrengthOffset3 + &HFA, 1))
        StrengthUpper = CDec(R(hp, StrengthOffset3 + &HFB, 1))

        Return (
                (StrengthOffset1 > 0) And
                (StrengthOffset2 > 0) And
                (StrengthOffset3 > 0) And
                (0 <= Strength) And
                (Strength <= StrengthUpper) And
                (StrengthUpper <= 15)
                )

    End Function

    Public Sub writeStrength(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger, ByVal upper As UInteger)
        Dim StrengthOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim StrengthOffset2 As UInteger = R(hp, StrengthOffset1 + &H28, 4)
        Dim StrengthOffset3 As UInteger = R(hp, StrengthOffset2 + &H10, 4)

        W(hp, StrengthOffset3 + &HFA, n, 1)
        W(hp, StrengthOffset3 + &HFC, n, 1)
        W(hp, StrengthOffset3 + &HFB, upper, 1)
        W(hp, StrengthOffset3 + &HFD, upper, 1)
    End Sub

    Public Function getSatiety(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Satiety As UInteger, ByRef SatietyUpper As UInteger) As Boolean

        Dim FullOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        Dim FullOffset2 As UInteger = R(hp, FullOffset1 + &H97C, 4)
        Dim FullOffset3 As UInteger = R(hp, FullOffset2 + &H5C, 4)
        Dim FullOffset4 As UInteger = R(hp, FullOffset3 + &H10, 4)

        Satiety = CDec(R(hp, FullOffset4 + &HF6, 2))
        SatietyUpper = CDec(R(hp, FullOffset4 + &HF8, 2))

        Return (
            (FullOffset1 > 0) And
            (FullOffset2 > 0) And
            (FullOffset3 > 0) And
            (FullOffset4 > 0) And
            (0 <= Satiety) And
            (Satiety <= SatietyUpper) And
            (SatietyUpper <= 200)
            )

    End Function

    Public Sub writeSatiety(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger, ByVal upper As UInteger)
        Dim FullOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        Dim FullOffset2 As UInteger = R(hp, FullOffset1 + &H97C, 4)
        Dim FullOffset3 As UInteger = R(hp, FullOffset2 + &H5C, 4)
        Dim FullOffset4 As UInteger = R(hp, FullOffset3 + &H10, 4)

        W(hp, FullOffset4 + &HF6, n, 2)
        W(hp, FullOffset4 + &HF8, upper, 2)
    End Sub

    Public Function getLv(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Level As UInteger) As Boolean

        Dim LvOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
        Dim LvOffset2 As UInteger = R(hp, LvOffset1 + &H97C, 4)
        Dim LvOffset3 As UInteger = R(hp, LvOffset2 + &H58, 4)
        Dim LvOffset4 As UInteger = R(hp, LvOffset3 + &H28, 4)

        Level = CDec(R(hp, LvOffset4 + &HE3, 1))

        Return (
            (LvOffset1 > 0) And
            (LvOffset2 > 0) And
            (LvOffset3 > 0) And
            (LvOffset4 > 0) And
            (1 <= Level) And
            (Level <= 99)
            )

    End Function

    'Public Sub writeLv(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
    '    'Dim LvOffset1 As UInteger = R(hp, BaseAddress + &H3D750C, 4)
    '    'Dim LvOffset2 As UInteger = R(hp, LvOffset1 + &H97C, 4)
    '    'Dim LvOffset3 As UInteger = R(hp, LvOffset2 + &H58, 4)
    '    'Dim LvOffset4 As UInteger = R(hp, LvOffset3 + &H28, 4)

    '    'W(hp, LvOffset4 + &HE3, n, 1)
    '    writeExp(hp, BaseAddress, 65535)
    'End Sub
    Private Function getExp(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Exp As UInteger) As Boolean

        Dim ExpOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim ExpOffset2 As UInteger = R(hp, ExpOffset1 + &H2C, 4)

        Exp = CDec(R(hp, ExpOffset2 + &HEC, 4))

        Return (
            (ExpOffset1 > 0) And
            (ExpOffset2 > 0) And
            (0 <= Exp) And
            (Exp <= 2660000)
            )

    End Function

    Public Sub writeExp(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
        Dim ExpOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim ExpOffset2 As UInteger = R(hp, ExpOffset1 + &H2C, 4)

        W(hp, ExpOffset2 + &HEC, n, 4)
    End Sub

    Public Function getDanmakuNum(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef DanmakuNum As UInteger) As Boolean
        Dim DanmakuNumOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim DanmakuNumOffset2 As UInteger = R(hp, DanmakuNumOffset1 + &H28, 4)
        Dim DanmakuNumOffset3 As UInteger = R(hp, DanmakuNumOffset2 + &H10, 4)

        DanmakuNum = CDec(R(hp, DanmakuNumOffset3 + &H100, 1))
        Dim test1 As Integer = CDec(R(hp, DanmakuNumOffset3 + &H101, 1))
        Dim test2 As Integer = CDec(R(hp, DanmakuNumOffset3 + &H0FF, 1))
        Dim test3 As Integer = CDec(R(hp, DanmakuNumOffset3 + &H102, 1))
        Dim test4 As Integer = CDec(R(hp, DanmakuNumOffset3 + &H103, 1))
        Dim test5 As Integer = CDec(R(hp, DanmakuNumOffset3 + &H104, 1))

        Return (
        (DanmakuNumOffset1 > 0) And
        (DanmakuNumOffset2 > 0) And
        (DanmakuNumOffset3 > 0) And
        (0 <= DanmakuNum) And
        (DanmakuNum <= 5)
        )
    End Function

    Public Sub writeDanmakuNum(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
        Dim DanmakuNumOffset1 As UInteger = R(hp, BaseAddress + &H3D7530, 4)
        Dim DanmakuNumOffset2 As UInteger = R(hp, DanmakuNumOffset1 + &H28, 4)
        Dim DanmakuNumOffset3 As UInteger = R(hp, DanmakuNumOffset2 + &H10, 4)

        W(hp, DanmakuNumOffset3 + &H100, n, 1)
    End Sub

    Public Function getProcessBase(ByRef ProcessHwnd As UInteger, ByRef BaseAddress As UInteger) As Boolean

reGet:

        If ExistProcess("MiracleSuperParty") Then
            Dim pid As UInteger = 0
            Dim fw As UInteger = FindWindow(vbNullString, "みらくる超パーティーPLUS.G Ver2.11")
            Dim err As UInteger = GetWindowThreadProcessId(fw, pid)
            ProcessHwnd = OpenProcess(&HFFF, False, pid)

            Try
                BaseAddress = Process.GetProcessesByName("MiracleSuperParty")(0).MainModule.BaseAddress

            Catch ex As Exception
                If ex.ToString <> "" Then GoTo reGet

            End Try

            Return (
                (fw > 0) And
                (pid > 0) And
                (ProcessHwnd > 0) And
                (BaseAddress > 0)
                )

        Else
            Return False

        End If

    End Function

    ''' 
    ''' err HP          0000 0000 0000 0001
    ''' err Cash        0000 0000 0000 0010
    ''' err Strength    0000 0000 0000 0100
    ''' err Satiety     0000 0000 0000 1000
    ''' err Stage       0000 0000 0001 0000
    ''' err Lv          0000 0000 0010 0000
    ''' err Exp         0000 0000 0100 0000
    ''' err Danmaku     0000 0000 1000 0000
    ''' invalid arr     0100 0000 0000 0000
    ''' no base addr    1000 0000 0000 0000
    ''' 
    Public Function inGame(ByVal max As Integer, ByRef c As UInteger(), ByRef err As String) As Boolean

        Dim errCode As UShort = 0
        Dim pHwnd, BaseAdd As UInteger

        If getProcessBase(pHwnd, BaseAdd) Then

            Dim HP, HPUpper, Cash, Strength, StrengthUpper, Satiety, SatietyUpper, Stage, Lv, Exp, DanmakuNum As UInteger
            Dim isHP As Boolean = getHP(pHwnd, BaseAdd, HP, HPUpper)
            Dim isCash As Boolean = getCash(pHwnd, BaseAdd, Cash)
            Dim isStrength As Boolean = getStrength(pHwnd, BaseAdd, Strength, StrengthUpper)
            Dim isSatiety As Boolean = getSatiety(pHwnd, BaseAdd, Satiety, SatietyUpper)
            Dim isStage As Boolean = getStage(pHwnd, BaseAdd, Stage)
            Dim isLv As Boolean = getLv(pHwnd, BaseAdd, Lv)
            Dim isExp As Boolean = getExp(pHwnd, BaseAdd, Exp)
            Dim isDanmakuNum As Boolean = getDanmakuNum(pHwnd, BaseAdd, DanmakuNum)

            Select Case (c.Count)
                Case 2
                    c(0) = pHwnd
                    c(1) = BaseAdd
                    errCode = 0

                Case max
                    If isHP Then c(0) = HP : c(1) = HPUpper Else c(0) = 15 : c(1) = 15 : errCode = errCode Or &H1
                    If isCash Then c(2) = Cash Else c(2) = 0 : errCode = errCode Or &H2
                    If isStrength Then c(3) = Strength : c(4) = StrengthUpper Else c(3) = 8 : c(4) = 8 : errCode = errCode Or &H4
                    If isSatiety Then c(5) = Satiety : c(6) = SatietyUpper Else c(5) = 100 : c(6) = 100 : errCode = errCode Or &H8
                    If isLv Then c(7) = Lv Else c(7) = 1 : errCode = errCode Or &H10
                    If isExp Then c(8) = Exp Else c(8) = 0 : errCode = errCode Or &H20
                    If isStage Then c(9) = Stage Else c(9) = 1 : errCode = errCode Or &H40
                    If isDanmakuNum Then c(10) = DanmakuNum Else c(10) = 0 : errCode = errCode Or &H80

                Case Else
                    err += "Invalid array input. "
                    errCode = &H4000

            End Select

        Else
            If CheatOn Then Call CheatPause()
            err += "Failed to get base address or game window. "
            errCode = &H8000

        End If

        Return errCode = 0

    End Function

End Module
