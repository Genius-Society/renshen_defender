Imports System.Math
Module FileOperation

    Public Function ExistDir(ByVal p As String) As Boolean
        Return My.Computer.FileSystem.DirectoryExists(p)
    End Function

    Public Function ExistFile(ByVal p As String) As Boolean
        Return My.Computer.FileSystem.FileExists(p)
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

    Public Function DeleteDir(ByVal p As String, ByRef err As String) As Boolean

        If ExistDir(p) Then

            Try

                My.Computer.FileSystem.DeleteDirectory(p, FileIO.DeleteDirectoryOption.DeleteAllContents)

            Catch ex As Exception

                If ex.ToString <> "" Then err += ex.ToString + " "

            End Try

        End If

        Return Not ExistDir(p)

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

    Public Function RenameDir(ByVal root As String, ByVal oldName As String, ByVal newName As String, ByRef err As String) As Boolean

        If oldName <> newName And ExistDir(root & "\" & oldName) And Not ExistDir(root & "\" & newName) Then

            Try

                My.Computer.FileSystem.RenameDirectory(root & "\" & oldName, newName)

            Catch ex As Exception

                If ex.ToString <> "" Then err += ex.ToString + " "

            End Try

        End If

        Return ExistDir(root & "\" & newName)

    End Function

    Public Function DirLastWTime(ByVal p As String) As Date

        If ExistDir(p) Then

            Return My.Computer.FileSystem.GetDirectoryInfo(p).LastWriteTime

        Else

            Return modify

        End If

    End Function

    Public Function CopyDir(ByVal src As String, ByVal dst As String, ByRef err As String) As Boolean

        If ExistDir(src) And Not ExistDir(dst) Then

            Try

                My.Computer.FileSystem.CopyDirectory(src, dst)

            Catch ex As Exception

                If ex.ToString <> "" Then err += ex.ToString + " "

            End Try

        End If

        Return ExistDir(dst)

    End Function

    Private Function UIntA2ByteA(register As UInteger()) As Byte()
        Dim bl As UInteger = register.Length()
        Dim br(0 To (4 * bl - 1)) As Byte

        For i As UInteger = 0 To bl - 1

            br(4 * i) = (register(i) And &HFF000000UI) >> 24
            br(4 * i + 1) = (register(i) And &HFF0000UI) >> 16
            br(4 * i + 2) = (register(i) And &HFF00UI) >> 8
            br(4 * i + 3) = register(i) And &HFFUI

        Next

        Return br
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

    Private Function makeSave(ByVal src As String, ByVal dst As String) As String

        Dim lengths(0 To 2) As UShort
        Dim register(0 To 7) As UInteger
        Dim pr() As Byte = {&H4C, &H6F, &H74, &H75, &H73, &H4C, &H61, &H6E, &H64, &H35}
        Dim err As String = ""

        Try

            Dim Reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\AQUASTYLE\LotusLand5", False)
            If Not Reg Is Nothing Then
                For i As Integer = 0 To 7
                    register(i) = Reg.OpenSubKey("Save" & i.ToString, False).GetValue("value") And &HFFFFFFFFUI
                Next
            End If

            Dim m() As Byte = My.Computer.FileSystem.ReadAllBytes(src & "\m00.sav")
            Dim r() As Byte = My.Computer.FileSystem.ReadAllBytes(src & "\r00.sav")
            Dim s() As Byte = My.Computer.FileSystem.ReadAllBytes(src & "\s00.sav")

            lengths(0) = m.Length() And &HFFFFUS
            lengths(1) = r.Length() And &HFFFFUS
            lengths(2) = s.Length() And &HFFFFUS

            My.Computer.FileSystem.WriteAllBytes(dst, pr, False)
            My.Computer.FileSystem.WriteAllBytes(dst, UIntA2ByteA(register), True)
            My.Computer.FileSystem.WriteAllBytes(dst, UShortA2ByteA(lengths), True)
            My.Computer.FileSystem.WriteAllBytes(dst, m, True)
            My.Computer.FileSystem.WriteAllBytes(dst, r, True)
            My.Computer.FileSystem.WriteAllBytes(dst, s, True)


        Catch ex As Exception

            If ex.ToString <> "" Then err += ex.ToString + " "

        End Try

        Return err

    End Function

    Public Function FileSave(ByVal dn As String) As String

        Dim dname As String = dn

        Do While ExistFile(path & "\SL\" & dname)
            dname = "[2]" & dname
        Loop

        Dim rootPath As String = path & "\SL\" & dname

        Return makeSave(path & "\Game\save\" & username, rootPath & ".rds")

    End Function

    Public Function InitEssDir() As String
        Dim err As String = ""
        CreateDir(path & "\SL", err)
        CreateDir(path & "\Game\save", err)
        Return err
    End Function

    Public Function FileCreate(ByVal SavName As String) As String

        Dim ct As String = Format(DateTime.Now, "yyyy-MM-dd_HH-mm-ss").ToString
        Dim dname As String = Trim(SavName) & "_" & ct
        Return FileSave(dname)

    End Function

    Public Function FFC(ByVal MazeName As String) As String

        Dim ct As String = Format(DateTime.Now, "yyyy-MM-dd_HH-mm-ss").ToString
        Dim dname As String = ""
        CurrTime = ct
        kn += 1
        dname = "「Stage " & k.ToString & "(" & kn & ") - " & MazeName & "」" & "_" & ct
        Return FileSave(dname)

    End Function


    Public Function FileCover(ByVal OldName As String, ByVal NewName As String, ByVal SavDate As String) As String
        Dim err = ""
        Dim dname As String = OldName & "_" & InvDateFormat(SavDate)
        RemoveFile(path & "\SL\" & dname & ".rds", err)
        err += FileCreate(NewName)
        Return err
    End Function

    'Enum getLayerRes
    '    SUCCESS
    '    FAIL_JUMP
    '    FAIL_HOME
    '    FAIL_OFF
    'End Enum

    Private Function getLayer(ByVal mTop As Integer, ByRef Layer As Integer) As Boolean

        Dim pHwnd, BaseAdd As UInteger

        If getProcessBase(pHwnd, BaseAdd) Then

            If getStage(pHwnd, BaseAdd, Layer) Then Return Layer > 0 And Layer < Max(mTop, 0)
 
        End If

        Return False

    End Function

    Private Function updStage(ByVal MazeName As String, ByVal mTop As Integer, ByVal k As Integer, ByRef Layer As Integer) As Boolean

        Dim tryTime As Integer = 0
        Dim Threshold As Integer = 200
        Dim Res As Boolean

        Do

            Res = getLayer(mTop, Layer)
            If (Not Res) Or Layer = k Then tryTime += 1

        Loop Until ((SEnabled(MazeName) And Layer = k + 1) Or ((Not SEnabled(MazeName)) And Abs(Layer - k) = 1)) Or tryTime > Threshold

        If tryTime <= Threshold And Res Then

            Return True

        Else

            Layer = -1
            Return False

        End If

    End Function

    Public Function AutoCreate(ByVal MazeName As String, ByVal k As Integer, ByVal mTop As Integer, ByRef err As String) As Integer

        Dim ct As String = Format(DateTime.Now, "yyyy-MM-dd_HH-mm-ss").ToString
        Dim dname As String = ""
        Dim Layer As Integer = 0
        CurrTime = ct

        If updStage(MazeName, mTop, k, Layer) Then

            If GeniusOn Then
                kn = 0
                dname = "「Stage " & Layer.ToString & "(" & kn.ToString & ")" & " - " & MazeName & "」" & "_" & ct
            Else
                dname = "「Stage " & Layer.ToString & " - " & MazeName & "」" & "_" & ct
            End If

            err += FileSave(dname)
            modify = DirLastWTime(path & "\Game\save\" & username)
            AutoTimer.Start()

        Else

            dname = "「Home - " & MazeName & "」" & "_" & ct
            err += FileSave(dname)
            Call AutoStop()

        End If

        Return Layer

    End Function


End Module
