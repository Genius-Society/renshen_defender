Imports System.IO
Module Game
    Public pname As String = "LotusLand4"
    Public path As String = Application.StartupPath()

    Public Function ExistProcess(ByVal pn As String) As Boolean
        Return Process.GetProcessesByName(pn).Count > 0
    End Function

    Public Sub EndProcess(ByVal pname As String)
        Dim ps As Process() = Process.GetProcessesByName(pname)
        If ps.Count > 0 Then
            For Each p As Process In ps
                If Not p.HasExited Then p.Kill()
            Next
        End If
    End Sub

    Public Sub StartProcess()
        EndProcess("LEProc")
        Dim path1 As String = Chr(34) & path & "\LotusLand4.exe" & Chr(34)
        Dim path2 As String = path & "\LE\LEProc.exe"
        If File.Exists(path & "\LotusLand4.exe") And File.Exists(path2) Then
            Dim pInfo As New ProcessStartInfo()
            pInfo.FileName = path2
            pInfo.Arguments = " -run " & path1
            Process.Start(pInfo)
        End If
    End Sub

    Public Sub OpenSettings()
        Dim path2 As String = path & "\2.exe"
        If File.Exists(path2) And Not ExistProcess("2") Then
            Dim pInfo As New ProcessStartInfo()
            pInfo.FileName = path2
            Process.Start(pInfo)
        End If
    End Sub

    Public Sub ResumeGame()
        If Not ExistProcess(pname) Then Call StartProcess()
    End Sub

    Public Function ExistDir(ByVal p As String) As Boolean
        Return My.Computer.FileSystem.DirectoryExists(p)
    End Function

    Public Function CreateDir(ByVal p As String, ByRef err As String) As Boolean

        If Not ExistDir(p) Then

            Try
                My.Computer.FileSystem.CreateDirectory(p)

            Catch ex As Exception
                If ex.ToString <> "" Then err += ex.ToString + " "

            End Try

        End If

        Return ExistDir(p)

    End Function

    Public Function ExistFile(ByVal p As String) As Boolean
        Return My.Computer.FileSystem.FileExists(p)
    End Function

    Public Function FileCover(ByVal OldName As String, ByVal NewName As String, ByVal SavDate As String) As String
        Dim err = ""
        Dim dname As String = OldName & "_" & InvDateFormat(SavDate)
        RemoveFile(path & "\SL\" & dname & ".rds", err)
        err += FileCreate(NewName)
        Return err
    End Function

    Public Function FileCreate(ByVal SavName As String) As String

        Dim ct As String = Format(DateTime.Now, "yyyy-MM-dd_HH-mm-ss").ToString
        Dim dname As String = Trim(SavName) & "_" & ct
        Return FileSave(dname)

    End Function

    Public Function FileSave(ByVal dn As String) As String
        Dim dname As String = dn

        Do While ExistFile(path & "\SL\" & dname)
            dname = "[2]" & dname
        Loop

        Dim rootPath As String = path & "\SL\" & dname
        Return makeSave(path, rootPath & ".rds")
    End Function

    Private Function makeSave(ByVal src As String, ByVal dst As String) As String
        Dim length As UShort
        Dim err As String = ""

        Try
            Dim s() As Byte = My.Computer.FileSystem.ReadAllBytes(src & "\000.sav")
            length = s.Length() And &HFFFFUS
            My.Computer.FileSystem.WriteAllBytes(dst, s, False)

        Catch ex As Exception
            If ex.ToString <> "" Then err += ex.ToString + " "

        End Try

        Return err
    End Function

    Private Function UShortA2ByteA(register As UShort()) As Byte()
        Dim bl As UInteger = register.Length()
        Dim br(0 To (2 * bl - 1)) As Byte

        For i As UInteger = 0 To bl - 1

            br(2 * i) = (register(i) And &HFF00US) >> 8
            br(2 * i + 1) = register(i) And &HFFUS

        Next

        Return br
    End Function

    Public Function RemoveFile(ByVal p As String, ByRef err As String) As Boolean
        If ExistFile(p) Then
            Try
                My.Computer.FileSystem.DeleteFile(p)

            Catch ex As Exception
                If ex.ToString <> "" Then err += ex.ToString + " "

            End Try

        End If

        Return Not ExistFile(p)
    End Function

    Public Function InvDateFormat(ByVal cd As String) As String
        Dim ch() As Char = cd
        For i As Integer = 1 To 5
            ch(3 * i + 1) = "-"
        Next
        ch(10) = "_"
        cd = ch
        Return cd
    End Function

    Public Function DateFormat(ByVal cd As String) As String
        Dim ch() As Char = cd
        ch(4) = "/"
        ch(7) = "/"
        ch(10) = " "
        ch(13) = ":"
        ch(16) = ":"
        cd = ch
        Return cd
    End Function

    Public Function LoadGame(ByVal SavName As String, ByVal SavDate As String) As String

        Dim dname As String = SavName & "_" & InvDateFormat(SavDate)
        Dim err As String = ""

        If isArchive(path & "\SL\" & dname, path, err) Then
            Call EndProcess(pname)
            Call StartProcess()
        Else
            err += "Invalid Save! "
        End If

        Return err

    End Function

    Private Function isArchive(ByVal src As String, ByVal dst As String, ByRef err As String) As Boolean

        Dim rds() As Byte = My.Computer.FileSystem.ReadAllBytes(src & ".rds")
        Dim dL As Integer = rds.Length()

        If dL > 48 Then
            Try
                My.Computer.FileSystem.WriteAllBytes(dst & "\000.sav", rds, False)

            Catch ex As Exception
                If ex.ToString <> "" Then err += ex.ToString + " "

            End Try

            Return True

        Else
            Return False

        End If

    End Function

    Public Sub AdjNumRange(num As Object)
        If TypeName(num) = "NumericUpDown" Then
            If num.Value < num.Minimum Then num.Value = num.Minimum
            If num.Value > num.Maximum Then num.Value = num.Maximum
        End If
    End Sub


End Module
