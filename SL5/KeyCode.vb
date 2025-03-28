Module KeyCode

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Const VK_LSHIFT = &HA0
    Private Const VK_RSHIFT = &HA1
    Private Const VK_LCTRL = &HA2
    Private Const VK_RCTRL = &HA3
    Private Const VK_LMENU = &HA4
    Private Const VK_RMENU = &HA5


    Public Function KeyToStr(ByVal vbKeycode As Integer) As String
        Dim KeyCodeToStr As String = ""

        If vbKeycode > 0 And vbKeycode < 10 Then
            KeyCodeToStr = "D" & vbKeycode.ToString
            Return KeyCodeToStr
            Exit Function

        ElseIf vbKeycode = 10 Then
            KeyCodeToStr = "D0"
            Return KeyCodeToStr
            Exit Function

        ElseIf vbKeycode > 57 And vbKeycode < 68 Then
            KeyCodeToStr = "F" & (vbKeycode - 57).ToString
            Return KeyCodeToStr
            Exit Function

        ElseIf vbKeycode > 83 And vbKeycode < 86 Then
            KeyCodeToStr = "F" & (vbKeycode - 73).ToString
            Return KeyCodeToStr
            Exit Function

        End If

        Select Case vbKeycode

            Case 0
                KeyCodeToStr = "Escape"

            Case 118
                KeyCodeToStr = "Pause"

            Case 116
                KeyCodeToStr = "Sysrq"

            Case 127
                KeyCodeToStr = "Insert"

            Case 128
                KeyCodeToStr = "Delete"

            Case 40
                KeyCodeToStr = "Grave"

            Case 11
                KeyCodeToStr = "Minus"

            Case 12
                KeyCodeToStr = "Equals"

            Case 13
                KeyCodeToStr = "Back"

            Case 119
                KeyCodeToStr = "Home"

            Case 15
                KeyCodeToStr = "Q"

            Case 16
                KeyCodeToStr = "W"

            Case 17
                KeyCodeToStr = "E"

            Case 18
                KeyCodeToStr = "R"

            Case 19
                KeyCodeToStr = "T"

            Case 20
                KeyCodeToStr = "Y"

            Case 21
                KeyCodeToStr = "U"

            Case 22
                KeyCodeToStr = "I"

            Case 23
                KeyCodeToStr = "O"

            Case 24
                KeyCodeToStr = "P"

            Case 25
                KeyCodeToStr = "LeftBracket"

            Case 26
                KeyCodeToStr = "RightBracket"

            Case 42
                KeyCodeToStr = "Backslash"

            Case 121
                KeyCodeToStr = "PageUp"

            Case 57
                KeyCodeToStr = "Capital"

            Case 29
                KeyCodeToStr = "A"

            Case 30
                KeyCodeToStr = "S"

            Case 31
                KeyCodeToStr = "D"

            Case 32
                KeyCodeToStr = "F"

            Case 33
                KeyCodeToStr = "G"

            Case 34
                KeyCodeToStr = "H"

            Case 35
                KeyCodeToStr = "J"

            Case 36
                KeyCodeToStr = "K"

            Case 37
                KeyCodeToStr = "L"

            Case 38
                KeyCodeToStr = "Semicolon"

            Case 39
                KeyCodeToStr = "Apostrophe"

            Case 27
                KeyCodeToStr = "Return"

            Case 126
                KeyCodeToStr = "PageDown"

            Case 41
                KeyCodeToStr = "LeftShift"

            Case 43
                KeyCodeToStr = "Z"
            Case 44
                KeyCodeToStr = "X"

            Case 45
                KeyCodeToStr = "C"
            Case 46
                KeyCodeToStr = "V"
            Case 47
                KeyCodeToStr = "B"
            Case 48
                KeyCodeToStr = "N"
            Case 49
                KeyCodeToStr = "M"
            Case 50
                KeyCodeToStr = "Comma"
            Case 51
                KeyCodeToStr = "Period"
            Case 52
                KeyCodeToStr = "Slash"
            Case 53
                KeyCodeToStr = "RightShift"
            Case 120
                KeyCodeToStr = "Up"
            Case 124
                KeyCodeToStr = "End"
            Case 28
                KeyCodeToStr = "LeftControl"
            Case 55
                KeyCodeToStr = "LeftAlt"
            Case 56
                KeyCodeToStr = "Space"
            Case 117
                KeyCodeToStr = "RightAlt"
            Case 131
                KeyCodeToStr = "Apps"
            Case 106
                KeyCodeToStr = "RightControl"
            Case 122
                KeyCodeToStr = "Left"
            Case 125
                KeyCodeToStr = "Down"
            Case 123
                KeyCodeToStr = "Right"
            Case Else
                KeyCodeToStr = "Unknown"
        End Select

        Return KeyCodeToStr
    End Function

    Public Function StrToKey(ByVal s As String) As Integer
        Select Case s
            Case "Escape"
                Return 0

            Case "F1"
                Return 58
            Case "F2"
                Return 59
            Case "F3"
                Return 60
            Case "F4"
                Return 61
            Case "F5"
                Return 62
            Case "F6"
                Return 63
            Case "F7"
                Return 64
            Case "F8"
                Return 65
            Case "F9"
                Return 66
            Case "F10"
                Return 67
            Case "F11"
                Return 84
            Case "F12"
                Return 85
            Case "Pause"
                Return 118
                'Sysrq
            Case "Sysrq"
                Return 116

            Case "Insert"
                Return 127
            Case "Delete"
                Return 128
            Case "Grave"
                Return 40

            Case "D1"
                Return 1
            Case "D2"
                Return 2
            Case "D3"
                Return 3
            Case "D4"
                Return 4
            Case "D5"
                Return 5
            Case "D6"
                Return 6
            Case "D7"
                Return 7
            Case "D8"
                Return 8
            Case "D9"
                Return 9
            Case "D0"
                Return 10

            Case "Minus"
                Return 11
            Case "Equals"
                Return 12
            Case "Back"
                Return 13
            Case "Home"
                Return 119
            Case "Q"
                Return 15
            Case "W"
                Return 16
            Case "E"
                Return 17
            Case "R"
                Return 18
            Case "T"
                Return 19
            Case "Y"
                Return 20
            Case "U"
                Return 21
            Case "I"
                Return 22
            Case "O"
                Return 23
            Case "P"
                Return 24

            Case "LeftBracket"
                Return 25
            Case "RightBracket"
                Return 26
            Case "Backslash"
                Return 42
            Case "PageUp"
                Return 121
            Case "Capital"
                Return 57

            Case "A"
                Return 29
            Case "S"
                Return 30
            Case "D"
                Return 31
            Case "F"
                Return 32
            Case "G"
                Return 33
            Case "H"
                Return 34
            Case "J"
                Return 35
            Case "K"
                Return 36
            Case "L"
                Return 37

            Case "Semicolon"
                Return 38
            Case "Apostrophe"
                Return 39
            Case "Return"
                Return 27
            Case "PageDown"
                Return 126
            Case "LeftShift"
                Return 41

            Case "Z"
                Return 43
            Case "X"
                Return 44
            Case "C"
                Return 45
            Case "V"
                Return 46
            Case "B"
                Return 47
            Case "N"
                Return 48
            Case "M"
                Return 49

            Case "Comma"
                Return 50
            Case "Period"
                Return 51
            Case "Slash"
                Return 52
            Case "RightShift"
                Return 53
            Case "Up"
                Return 120
            Case "End"
                Return 124
            Case "LeftControl"
                Return 28
            Case "LeftAlt"
                Return 55
            Case "Space"
                Return 56
            Case "RightAlt"
                Return 117
            Case "Apps"
                Return 131
            Case "RightControl"
                Return 106
            Case "Left"
                Return 122
            Case "Down"
                Return 125
            Case "Right"
                Return 123

            Case Else
                Return -1
        End Select
    End Function

    Public Function StrToKeyStr(ByVal e As System.Windows.Forms.KeyEventArgs) As String
        If e.KeyCode.ToString = "ShiftKey" And GetAsyncKeyState(VK_LSHIFT) Then
            Return "LeftShift"

        ElseIf e.KeyCode.ToString = "ShiftKey" And GetAsyncKeyState(VK_RSHIFT) Then
            Return "RightShift"

        ElseIf e.KeyCode.ToString = "ControlKey" And GetAsyncKeyState(VK_LCTRL) Then
            Return "LeftControl"

        ElseIf e.KeyCode.ToString = "ControlKey" And GetAsyncKeyState(VK_RCTRL) Then
            Return "RightControl"

        ElseIf e.KeyCode.ToString = "Menu" And GetAsyncKeyState(VK_LMENU) Then
            Return "LeftAlt"

        ElseIf e.KeyCode.ToString = "Menu" And GetAsyncKeyState(VK_RMENU) Then
            Return "RightAlt"

        ElseIf e.KeyCode.ToString = "LWin" Then
            Return "Sysrq"
        Else

            Select Case e.KeyCode.ToString
                Case "Oemtilde"
                    Return "Grave"
                Case "OemMinus"
                    Return "Minus"
                Case "Oemplus"
                    Return "Equals"
                Case "OemOpenBrackets"
                    Return "LeftBracket"
                Case "Oem6"
                    Return "RightBracket"
                Case "Oem5"
                    Return "Backslash"
                Case "Oem1"
                    Return "Semicolon"
                Case "Oem7"
                    Return "Apostrophe"
                Case "Next"
                    Return "PageDown"
                Case "Oemcomma"
                    Return "Comma"
                Case "OemPeriod"
                    Return "Period"
                Case "OemQuestion"
                    Return "Slash"

                Case Else
                    Return e.KeyCode.ToString
            End Select
        End If

    End Function
End Module
