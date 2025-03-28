Module Cheat

    Public LastCheatId As Integer = 9
    Public CheatOn As Boolean
    Public CheaTimer As System.Timers.Timer
    Public MaxDigit As Integer = 1
    ''' This may have potential bug
    ''' it seems 99 is not the upper of stages in LotusLand4, 
    ''' if 999 or 1000 exist, MaxDigit shall be 2 or 3
    ''' but now digit 2 and 3 are not 0 causing isStage() not work

    Public Declare Function MoveWindow Lib "user32" (ByVal hwnd As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Integer) As Integer
    Public Declare Function SetParent Lib "user32" Alias "SetParent" (ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer
    Public Declare Function ShowWindow Lib "user32.dll" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    Public Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Integer) As Integer
    Public Declare Function CloseWindow Lib "user32" (ByVal hwnd As Integer) As Integer

    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal A As String, ByVal B As String) As UInteger
    Public Declare Function GetWindowThreadProcessId Lib "user32" (ByVal A As UInteger, ByRef B As UInteger) As UInteger
    Public Declare Function OpenProcess Lib "kernel32" (ByVal A As UInteger, ByVal B As UInteger, ByVal C As UInteger) As UInteger
    Public Declare Function ReadProcessMemory Lib "kernel32" (ByVal A As UInteger, ByVal B As UInteger, ByRef C As UInteger, ByVal D As UInteger, ByVal E As IntPtr) As UInteger
    Public Declare Function WriteProcessMemory Lib "kernel32" (ByVal A As UInteger, ByVal B As UInteger, ByRef C As UInteger, ByVal D As UInteger, ByRef E As IntPtr) As UInteger


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

        For i As Integer = 1 To MaxDigit
            If Not res Then Return False
            res = res And ((0 <= Ly(i) And Ly(i) <= 9) Or Ly(i) = &HFF)
        Next

        Return res
    End Function

    Public Function getStage(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Stage As UInteger) As Boolean

        Dim LayerOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim LayerOffset2 As UInteger = R(hp, LayerOffset1 + &H24, 4)
        Dim LayerOffset3 As UInteger = R(hp, LayerOffset2 + &H34, 4)
        Dim Layer(0 To MaxDigit) As UInteger

        For i As Integer = 0 To MaxDigit
            Layer(i) = CDec(R(hp, LayerOffset3 + &H20 + i * 4, 1))
        Next

        Dim istage As Boolean = isStage(Layer)

        If istage Then
            Stage = Layer(0)

            For i As Integer = 1 To MaxDigit
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
            (Stage <= 99)
            )
    End Function

    Public Sub writeStage(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Stage As UInteger)

        Dim LayerOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim LayerOffset2 As UInteger = R(hp, LayerOffset1 + &H24, 4)
        Dim LayerOffset3 As UInteger = R(hp, LayerOffset2 + &H34, 4)
        Dim Layer(0 To MaxDigit) As UInteger

        For i As Integer = MaxDigit To 0 Step -1
            Layer(i) = Math.Floor(Stage * Math.Pow(10, -i))
            For j As UInteger = i + 1 To MaxDigit
                Layer(i) -= Layer(j) * Math.Pow(10, j - i)
            Next
        Next

        For i As Integer = 0 To MaxDigit
            W(hp, LayerOffset3 + &H20 + i * 4, Hex(Layer(i)), 1)
        Next
    End Sub

    Public Function getHP(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef HealthPoint As UInteger, ByRef HPUpper As UInteger) As Boolean
        Dim HPOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim HPOffset2 As UInteger = R(hp, HPOffset1 + &H24, 4)
        Dim HPOffset3 As UInteger = R(hp, HPOffset2 + &H18, 4)
        Dim HPOffset4 As UInteger = R(hp, HPOffset3 + &H10, 4)

        HealthPoint = CDec(R(hp, HPOffset4 + &H1D0, 2))
        HPUpper = CDec(R(hp, HPOffset4 + &H1D2, 2))

        Return (
            (HPOffset1 > 0) And
            (HPOffset2 > 0) And
            (HPOffset3 > 0) And
            (HPOffset4 > 0) And
            (1 <= HealthPoint) And
            (HealthPoint <= HPUpper) And
            (HPUpper <= 65535) And
            (15 <= HPUpper)
            )

    End Function

    Public Sub writeHP(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger, ByVal upper As UInteger)
        Dim HPOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim HPOffset2 As UInteger = R(hp, HPOffset1 + &H24, 4)
        Dim HPOffset3 As UInteger = R(hp, HPOffset2 + &H18, 4)
        Dim HPOffset4 As UInteger = R(hp, HPOffset3 + &H10, 4)
        W(hp, HPOffset4 + &H1D0, n, 2)
        W(hp, HPOffset4 + &H1D2, upper, 2)
    End Sub


    Public Function getCash(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Cash As UInteger) As Boolean
        Dim CashOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim CashOffset2 As UInteger = R(hp, CashOffset1 + &H20, 4)
        Cash = CDec(R(hp, CashOffset2 + &H1C, 4))
        Return (CashOffset1 > 0) And (0 <= Cash)
    End Function

    Public Sub writeCash(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
        Dim CashOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim CashOffset2 As UInteger = R(hp, CashOffset1 + &H20, 4)
        W(hp, CashOffset2 + &H1C, n, 4)
    End Sub

    Public Function getStrength(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Strength As UInteger, ByRef StrengthUpper As UInteger) As Boolean

        Dim StrengthOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim StrengthOffset2 As UInteger = R(hp, StrengthOffset1 + &H24, 4)
        Dim StrengthOffset3 As UInteger = R(hp, StrengthOffset2 + &H18, 4)
        Dim StrengthOffset4 As UInteger = R(hp, StrengthOffset3 + &H10, 4)

        Strength = CDec(R(hp, StrengthOffset4 + &H1DE, 2))
        StrengthUpper = CDec(R(hp, StrengthOffset4 + &H1E0, 2))

        Return (
                (StrengthOffset1 > 0) And
                (StrengthOffset2 > 0) And
                (StrengthOffset3 > 0) And
                (StrengthOffset4 > 0) And
                (0 <= Strength) And
                (Strength <= StrengthUpper) And
                (StrengthUpper <= 15)
                )

    End Function

    Public Sub writeStrength(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger, ByVal upper As UInteger)
        Dim StrengthOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim StrengthOffset2 As UInteger = R(hp, StrengthOffset1 + &H24, 4)
        Dim StrengthOffset3 As UInteger = R(hp, StrengthOffset2 + &H18, 4)
        Dim StrengthOffset4 As UInteger = R(hp, StrengthOffset3 + &H10, 4)

        W(hp, StrengthOffset4 + &H1DE, n, 2)
        W(hp, StrengthOffset4 + &H1E0, upper, 2)
    End Sub

    Public Function getSatiety(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Satiety As UInteger, ByRef SatietyUpper As UInteger) As Boolean

        Dim FullOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim FullOffset2 As UInteger = R(hp, FullOffset1 + &H24, 4)
        Dim FullOffset3 As UInteger = R(hp, FullOffset2 + &H40, 4)
        Dim FullOffset4 As UInteger = R(hp, FullOffset3 + &H08, 4)

        Satiety = CDec(R(hp, FullOffset4 + &H1DA, 2))
        SatietyUpper = CDec(R(hp, FullOffset4 + &H1DC, 2))

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
        Dim FullOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim FullOffset2 As UInteger = R(hp, FullOffset1 + &H24, 4)
        Dim FullOffset3 As UInteger = R(hp, FullOffset2 + &H40, 4)
        Dim FullOffset4 As UInteger = R(hp, FullOffset3 + &H08, 4)

        W(hp, FullOffset4 + &H1DA, n, 2)
        W(hp, FullOffset4 + &H1DC, upper, 2)
    End Sub

    Public Function getLv(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Level As UInteger) As Boolean

        Dim LvOffset1 As UInteger = R(hp, BaseAddress + &H347028, 4)
        Dim LvOffset2 As UInteger = R(hp, LvOffset1 + &H08, 4)

        Level = CDec(R(hp, LvOffset2 + &H1C7, 1))

        Return (
            (LvOffset1 > 0) And
            (LvOffset2 > 0) And
            (1 <= Level) And
            (Level <= 99)
            )

    End Function

    Private Function getExp(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef Exp As UInteger) As Boolean

        Dim ExpOffset1 As UInteger = R(hp, BaseAddress + &H347028, 4)
        Dim ExpOffset2 As UInteger = R(hp, ExpOffset1 + &H08, 4)

        Exp = CDec(R(hp, ExpOffset2 + &H1F4, 4))

        Return (
            (ExpOffset1 > 0) And
            (ExpOffset2 > 0) And
            (0 <= Exp) And
            (Exp <= 2000000)
            )

    End Function

    Public Sub writeExp(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
        Dim ExpOffset1 As UInteger = R(hp, BaseAddress + &H347028, 4)
        Dim ExpOffset2 As UInteger = R(hp, ExpOffset1 + &H08, 4)

        W(hp, ExpOffset2 + &H1F4, n, 4)
    End Sub
    Public Function getDanmakuCount(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByRef DanmakuCount As UInteger) As Boolean

        Dim FullOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim FullOffset2 As UInteger = R(hp, FullOffset1 + &H24, 4)
        Dim FullOffset3 As UInteger = R(hp, FullOffset2 + &H40, 4)
        Dim FullOffset4 As UInteger = R(hp, FullOffset3 + &H08, 4)

        DanmakuCount = CDec(R(hp, FullOffset4 + &H1E8, 1))

        Return (
            (FullOffset1 > 0) And
            (FullOffset2 > 0) And
            (FullOffset3 > 0) And
            (FullOffset4 > 0) And
            (0 <= DanmakuCount) And
            (DanmakuCount <= 5)
            )

    End Function

    Public Sub writeDanmakuCount(ByVal hp As UInteger, ByVal BaseAddress As UInteger, ByVal n As UInteger)
        Dim FullOffset1 As UInteger = R(hp, BaseAddress + &H346E30, 4)
        Dim FullOffset2 As UInteger = R(hp, FullOffset1 + &H24, 4)
        Dim FullOffset3 As UInteger = R(hp, FullOffset2 + &H40, 4)
        Dim FullOffset4 As UInteger = R(hp, FullOffset3 + &H08, 4)

        W(hp, FullOffset4 + &H1E8, n, 1)
    End Sub

    Public Function getProcessBase(ByRef ProcessHwnd As UInteger, ByRef BaseAddress As UInteger) As Boolean

reGet:

        If ExistProcess(pname) Then
            Dim pid As UInteger = 0
            Dim fw As UInteger = FindWindow(vbNullString, "みらくる☆パーティー Plus Ver1.56")
            Dim err As UInteger = GetWindowThreadProcessId(fw, pid)
            ProcessHwnd = OpenProcess(&HFFF, False, pid)

            Try
                BaseAddress = Process.GetProcessesByName(pname)(0).MainModule.BaseAddress

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

    Public Function inGame(ByVal max As Integer, ByRef c As UInteger(), ByRef err As String) As Boolean

        Dim pHwnd, BaseAdd As UInteger

        If getProcessBase(pHwnd, BaseAdd) Then

            Dim HP, HPUpper, Cash, Strength, StrengthUpper, Satiety, SatietyUpper, Stage, Lv, Exp, DanmakuCount As UInteger

            Dim isHP As Boolean = getHP(pHwnd, BaseAdd, HP, HPUpper)
            Dim isCash As Boolean = getCash(pHwnd, BaseAdd, Cash)
            Dim isStrength As Boolean = getStrength(pHwnd, BaseAdd, Strength, StrengthUpper)
            Dim isSatiety As Boolean = getSatiety(pHwnd, BaseAdd, Satiety, SatietyUpper)
            Dim isStage As Boolean = getStage(pHwnd, BaseAdd, Stage)
            Dim isLv As Boolean = getLv(pHwnd, BaseAdd, Lv)
            Dim isExp As Boolean = getExp(pHwnd, BaseAdd, Exp)
            Dim isDanmakuCount As Boolean = getDanmakuCount(pHwnd, BaseAdd, DanmakuCount)

            If isHP And isCash And isStrength And isSatiety And isStage And isLv And isExp And isDanmakuCount Then

                Select Case (c.Count)

                    Case 2
                        c(0) = pHwnd
                        c(1) = BaseAdd
                        Return True

                    Case max
                        c(0) = HP
                        c(1) = HPUpper
                        c(2) = Cash
                        c(3) = Strength
                        c(4) = StrengthUpper
                        c(5) = Satiety
                        c(6) = SatietyUpper
                        c(7) = Lv
                        c(8) = Exp
                        c(9) = Stage
                        c(10) = DanmakuCount
                        Return True

                    Case Else
                        err += "Invalid array input. "
                        Return False

                End Select

            Else
                err += "Failed to get some value. "
                Return False

            End If

        Else
            If CheatOn Then Call CheatPause()
            err += "Failed to get base address. "
            Return False

        End If

    End Function

    Public Sub CheatPause()
        Do
            CheaTimer.Stop()
        Loop Until Not CheaTimer.Enabled
    End Sub

End Module
