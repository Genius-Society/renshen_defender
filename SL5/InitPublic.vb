Imports System.IO
Imports System.Timers
Imports System.Threading

Module InitPublic
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
 
    Public AutoTimer, CheaTimer As System.Timers.Timer
    Public AutoStartOn, GeniusOn As Boolean
    Public CurrTime, MazeName As String
    Public MazeTop, k, kn As Integer
    Public modify As Date
    Public LastCheatId As Integer
    Public CWnd As UInteger
    Public CheatOn As Boolean

    Public username As String = Environment.GetEnvironmentVariable("USERNAME")
    Public path As String = Application.StartupPath()
    Public inipath As String = path & "\Game\config.ini"

    Public cheatCheck As Byte

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


    Public Sub BeginThread(ByVal Th As Thread, ByRef Ad As ParameterizedThreadStart)
        If Not IsNothing(Th) Then If Th.IsAlive Then Th.Abort()
        Th = New Thread(Ad)
        Th.Start()
    End Sub
     
    Public Function Phi(b As Boolean) As Integer
        Return -CInt(b)
    End Function

End Module