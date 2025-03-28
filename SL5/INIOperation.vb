Module INIOperation
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32


    Public Sub ExportReg(ByVal RegPath As String)
        Dim Reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\AQUASTYLE\LotusLand5", False)
        If Not Reg Is Nothing Then
            For i As Integer = 0 To 7
                WriteINI("Save", i.ToString, Hex(Reg.OpenSubKey("Save" & i.ToString, False).GetValue("value")).ToLower, RegPath)
            Next
        End If
    End Sub

    Public Sub ImportReg(ByVal RegPath As String)
        Dim Reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\AQUASTYLE\LotusLand5", True)
        If Not Reg Is Nothing Then
            For i As Integer = 0 To 7
                Reg.OpenSubKey("Save" & i.ToString, True).SetValue("value", Convert.ToInt32(GetINI("Save", i.ToString, RegPath), 16), Microsoft.Win32.RegistryValueKind.DWord)
            Next
        End If
    End Sub

    Public Function GetINI(ByVal Section As String, ByVal AppName As String, FileName As String) As String 
        Dim lpDefault As String = ""
        Dim Str As String = ""
        Str = LSet(Str, 255)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Trim(Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1))
    End Function

    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, FileName As String) As Long 
        WriteINI = WritePrivateProfileString(Trim(Section), Trim(AppName), Trim(lpDefault), FileName)
    End Function

    Public Sub BatchWrite(ByVal log() As Integer)
        WriteINI("GameConfig", "LogRowCount", log(0).ToString, inipath)
        WriteINI("GameConfig", "LogPosition", log(1).ToString, inipath)
        WriteINI("GameConfig", "LogFontType", log(2).ToString, inipath)
        WriteINI("GameConfig", "LogLineHeight", log(3).ToString, inipath)
        WriteINI("GameConfig", "LogOriginX", log(4).ToString, inipath)
        WriteINI("GameConfig", "LogOriginY", log(5).ToString, inipath)
    End Sub

End Module
