Imports System.IO
Imports System.Threading
Module GameOperation

    Public Function ExistProcess(ByVal pn As String) As Boolean
        Return Process.GetProcessesByName(pn).Count > 0
    End Function

    Private Sub EndProcess(ByVal pname As String)
        Dim ps As Process() = Process.GetProcessesByName(pname)
        If ps.Count > 0 Then
            For Each p As Process In ps
                If Not p.HasExited Then p.Kill()
            Next
        End If
    End Sub

    Private Sub StartProcess()
        EndProcess("LEProc")
        Dim path1 As String = Chr(34) & path & "\LLLauncher.exe" & Chr(34)
        Dim path2 As String = path & "\LE\LEProc.exe"
        Dim pInfo As New ProcessStartInfo()
        pInfo.FileName = path2
        pInfo.Arguments = " -run " & path1
        Process.Start(pInfo)
    End Sub

    Public Sub StartGame()

        Dim Threshold As Integer = 55000
        Dim Attempt As Integer = 0
ReTry:
        If Not ExistProcess("MiracleSuperParty") Then Call StartProcess()

        Dim hwnd As UInteger = 0
        Dim TryTime As Integer = 0

        Do
            TryTime += 1
            hwnd = FindWindow(vbNullString, "みらくる超パーティーPLUS.G Ver2.11")
        Loop Until (hwnd > 0 Or TryTime > Threshold)

        If TryTime > Threshold And Attempt < 3 Then
            If ExistProcess("MiracleSuperParty") Then CrashGame(AutoStartOn)
            Attempt += 1
            GoTo ReTry
        End If

        If Attempt >= 3 Then
            Exit Sub
        End If

        CWnd = hwnd

        Dim w As Integer = CInt(GetINI("Graphics", "ScreenWidth", inipath)) + 6
        Dim h As Integer = CInt(GetINI("Graphics", "ScreenHeight", inipath)) + 28

        MoveWindow(hwnd, 0, 0, w, h, True)

        If CheatOn Then CheaTimer.Start()

    End Sub

    Public Sub CrashGame(ByVal AutoStartOn As Boolean)
        If CheatOn Then Call CheatPause()
        If AutoStartOn Then Call AutoPause()
        EndProcess("MiracleSuperParty")
    End Sub

    Public Sub TimerHold(ByVal AutoStartOn As Boolean)
        If AutoStartOn Then
            Dim savPath As String = path & "\Game\save\" & username

            Call AutoPause()
            modify = DirLastWTime(savPath)
            Do Until modify <> DirLastWTime(savPath)
                If Not ExistProcess("MiracleSuperParty") Then Exit Do
            Loop
            Threading.Thread.Sleep(500)
            modify = DirLastWTime(savPath)
            AutoTimer.Start()
        End If
    End Sub

    Public Sub AutoPause()
        Do
            AutoTimer.Stop()
        Loop Until Not AutoTimer.Enabled
    End Sub

    Public Sub CheatPause()
        Do
            CheaTimer.Stop()
        Loop Until Not CheaTimer.Enabled
    End Sub

    Public Sub AutoStop()
        Call AutoPause()
        AutoStartOn = False
    End Sub

    Public Sub ResumeGame()
        Dim hwnd As Integer = CWnd
        If ExistProcess("MiracleSuperParty") Then
            ShowWindow(hwnd, 1)
            SetForegroundWindow(hwnd)
        Else
            Call StartGame()
        End If
    End Sub

    Public Sub RestartGame(ByVal AutoStartOn As Boolean)
        If ExistProcess("MiracleSuperParty") Then
            CrashGame(AutoStartOn)
            Call StartGame()
        End If
    End Sub

    Public Sub BeginGame()
        If Not ExistProcess("MiracleSuperParty") Then Call StartGame() 
    End Sub

    Public Sub FStartGame(ByVal AutoStartOn As Boolean)
        If ExistProcess("MiracleSuperParty") Then CrashGame(AutoStartOn)
        Call StartGame()
    End Sub

    Private Sub Loading(rds As Byte(), ByVal dst As String)
        Dim Reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\AQUASTYLE\LotusLand5", True)
        If Not Reg Is Nothing Then
            For i As Integer = 0 To 7
                Dim value As UInteger = rds(4 * i + 10) * (&H1000000UI)
                value += rds(4 * i + 11) * (&H10000UI)
                value += rds(4 * i + 12) * (&H100UI)
                value += rds(4 * i + 13)
                Reg.OpenSubKey("Save" & i.ToString, True).SetValue("value", Convert.ToInt32(Hex(value), 16), Microsoft.Win32.RegistryValueKind.DWord)
            Next
        End If

        Dim mL As UShort = rds(42) * (&H100US) + rds(43)
        Dim rL As UShort = rds(44) * (&H100US) + rds(45)
        Dim sL As UShort = rds(46) * (&H100US) + rds(47)

        Dim m(0 To mL - 1) As Byte
        Dim r(0 To rL - 1) As Byte
        Dim s(0 To sL - 1) As Byte

        For i As Integer = 0 To mL - 1
            m(i) = rds(48 + i)
        Next

        For i As Integer = 0 To rL - 1
            r(i) = rds(48 + mL + i)
        Next

        For i As Integer = 0 To sL - 1
            s(i) = rds(48 + mL + rL + i)
        Next

        My.Computer.FileSystem.WriteAllBytes(dst & "\m00.sav", m, False)
        My.Computer.FileSystem.WriteAllBytes(dst & "\r00.sav", r, False)
        My.Computer.FileSystem.WriteAllBytes(dst & "\s00.sav", s, False)
    End Sub

    Private Function isArchive(ByVal src As String, ByVal dst As String, ByRef err As String) As Boolean

        Dim rds() As Byte = My.Computer.FileSystem.ReadAllBytes(src & ".rds")
        Dim dL As Integer = rds.Length()

        If dL > 48 Then

            If rds(0) = &H4C And rds(1) = &H6F And rds(2) = &H74 And rds(3) = &H75 And rds(4) = &H73 And
                rds(5) = &H4C And rds(6) = &H61 And rds(7) = &H6E And rds(8) = &H64 And rds(9) = &H35 Then

                Try
                    Loading(rds, dst)

                Catch ex As Exception

                    If ex.ToString <> "" Then err += ex.ToString + " "

                End Try

                Return True

            Else

                Return False

            End If

        Else

            Return False

        End If

    End Function

    Public Function LoadGame(ByVal AutoStartOn As Boolean, ByVal SavName As String, ByVal SavDate As String) As String
        CrashGame(AutoStartOn)

        Dim dname As String = SavName & "_" & InvDateFormat(SavDate)
        Dim src As String = path & "\SL\" & dname
        Dim dst As String = path & "\Game\save\" & username
        Dim err As String = ""

        If isArchive(src, dst, err) Then
            Call StartGame()
        Else
            err += "Invalid Save! "
        End If

        Return err

    End Function

End Module
