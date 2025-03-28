 Imports System.Threading
Public Class Genius

    Dim dname As String = "" 
    Dim HBound = My.Computer.Screen.WorkingArea.Height
    Dim WBound = My.Computer.Screen.WorkingArea.Width
 
    Dim OldX, OldY, OldFormX, OldFormY As Integer
    Dim FLThread, FSThread, FRThread, StaThread As Thread
    Dim IsMouseDown As Boolean
    Dim oldLocation As Point

    Structure ValBorder
        Dim ValOut As Integer
        Dim ValOffset As Integer
        Dim ValDate As String
    End Structure

    Private Delegate Sub FLDel(ByVal hwnd As Boolean)
    Private Delegate Sub FSDel(ByVal hwnd As Boolean)
    Private Delegate Sub FRDel(ByVal hwnd As Boolean)
    Private Delegate Sub StatusDel(ByVal str As String)

    Private Sub Genius_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = 130
        Me.Height = 350
        Me.Opacity = 0.95
        Me.ActiveControl = Me.CloseGen
        Me.StartPosition = FormStartPosition.Manual
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(WBound - Me.Width - 1, 0.5 * (HBound - Me.Height))

        Call InitGenHead()
         
        kn = 0
    End Sub


    Private Sub Genius_Dispose(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Call AutoStop()
        kn = 0
        GeniusOn = True
        With SL5
            .AutoButtonInit()
            .Show()
        End With
    End Sub

    Private Sub InitGenHead()
        With GenList
            .Clear()
            .View = View.Details
            .FullRowSelect = True
            .HideSelection = False
            .MultiSelect = False
            .GridLines = False
            .ShowItemToolTips = True
            .HeaderStyle = ColumnHeaderStyle.None
            .Columns.Add("Record", CInt(.Size.Width) - 22, HorizontalAlignment.Left)
        End With
    End Sub

 
 
    Public Sub UpdateGenList() 
        Dim InsertItem As String = k.ToString & "(" & kn.ToString & ")"
        Dim itm As ListViewItem = GenList.Items.Insert(0, InsertItem)
        itm.Name = CurrTime
        GenList.Items.Item(0).EnsureVisible()
        GenList.Refresh()
    End Sub


    Private Sub Genius_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GenHeadContainer.MouseDown
        IsMouseDown = True
        OldFormX = Me.Location.X
        OldFormY = Me.Location.Y
        OldX = Cursor.Position.X
        OldY = Cursor.Position.Y
    End Sub

    Private Sub Genius_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GenHeadContainer.MouseUp
        IsMouseDown = False
        If Me.Top < 0 Then
            Me.Top = 0
        ElseIf Me.Top > HBound - Me.Height Then
            Me.Top = HBound - Me.Height
        End If

        If Me.Left < 0 Then
            Me.Left = 0
        ElseIf Me.Left > WBound - Me.Width Then
            Me.Left = WBound - Me.Width
        End If
    End Sub

    Private Sub Genius_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GenHeadContainer.MouseMove
        If IsMouseDown Then Me.Location = New Point(OldFormX + Cursor.Position.X - OldX, OldFormY + Cursor.Position.Y - OldY)
    End Sub

    Private Sub CloseGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseGen.Click
        CheatPause()
        CheatOn = False
        Me.Dispose()
    End Sub

    Private Sub GenListItem_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenList.DoubleClick
        If GenList.SelectedItems.Count > 0 Then Call StartFL() 
    End Sub

    Private Sub StartFL()
        FLUpdateUI(False)

        Dim dat As String = GenList.SelectedItems.Item(0).Name
        If k < 0 Then
            dname = "「" & MazeName & "」" & "_" & dat
        Else
            Dim stage As String = GenList.SelectedItems.Item(0).Text
            If Val(k) <> Val(stage) Then
                k = CInt(Val(stage))
                kn = 0
            End If
            dname = "「Stage " & stage & " - " & MazeName & "」" & "_" & dat
        End If

        BeginThread(FLThread, AddressOf FL)
    End Sub

    Private Sub FastLoading(ByVal src As String, ByVal dst As String)

        Dim rds() As Byte = My.Computer.FileSystem.ReadAllBytes(src & ".rds")

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


    Private Sub FL()
        Call AutoPause()
        CrashGame(False)

        Try
            FastLoading(path & "\SL\" & dname, path & "\Game\save\" & username)

        Catch ex As Exception
            If ex.ToString <> "" Then StatusTip(ex.ToString)

        End Try
 
        Call StartGame()
        Me.Invoke(New FLDel(AddressOf FLUpdateUI), True)
        TimerHold(AutoStartOn)
    End Sub

    Private Sub FLUpdateUI(hwnd As Boolean)
        Me.ActiveControl = Me.GenLabel
        GenMainContainer.Enabled = hwnd

    End Sub


    Private Sub FSavButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSavButton.Click
        Call StartFS()
    End Sub

    Private Sub StartFS()
        FSUpdateUI(False) 
        BeginThread(FSThread, AddressOf FS)
    End Sub

    Private Sub FS()
        Dim err As String = FFC(MazeName)
        If err <> "" Then StatusTip(err)
        Me.Invoke(New FSDel(AddressOf FSUpdateUI), True)
    End Sub

    Private Sub FSUpdateUI(hwnd As Boolean)
        Me.ActiveControl = Me.GenLabel
        If hwnd Then Call UpdateGenList()
        CloseGen.Enabled = hwnd
        GenList.Enabled = hwnd
        FSavButton.Enabled = hwnd
    End Sub


    Private Sub GenResButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenResButton.Click
        Call StartFR()
    End Sub

    Private Sub StartFR()
        FLUpdateUI(False)
        BeginThread(FRThread, AddressOf FR)
    End Sub

    Private Sub FR()
        FStartGame(AutoStartOn)
        Me.Invoke(New FRDel(AddressOf FLUpdateUI), True)
        TimerHold(AutoStartOn)
    End Sub

 
    Private Sub GenList_MouseHover(ByVal sender As System.Object, ByVal e As ListViewItemMouseHoverEventArgs) Handles GenList.ItemMouseHover

        Try
            Dim hmess As String = "「Stage " & e.Item.Text & " - " & MazeName & "」 " & DateFormat(e.Item.Name)
            Dim hint As New ToolTip()
            hint.ShowAlways = True
            hint.InitialDelay = 500
            hint.SetToolTip(GenList, hmess)
            hint.Show(hmess, GenList, Cursor.Position.X - Me.Location.X - 2, Cursor.Position.Y - Me.Location.Y - 43, 3000)

        Catch ex As Exception
            If ex.ToString <> "" Then StatusTip(ex.ToString)

        End Try

    End Sub

    Public Sub alterValue(ByVal opt As Integer)

        Dim c(0 To 1) As UInteger
        Dim err As String = ""

        If inGame(LastCheatId + 1, c, err) Then
            Select Case opt
                Case 0
                    writeHP(c(0), c(1), 65535, 65535) ' max HP
                Case 1
                    writeCash(c(0), c(1), 999999999) ' max money
                Case 2
                    writeStrength(c(0), c(1), 15, 15) ' max energy
                Case 3
                    writeSatiety(c(0), c(1), 200, 200) ' max full
                Case 4
                    writeExp(c(0), c(1), 2660000) ' max exp
                Case Else
                    writeDanmakuNum(c(0), c(1), 5) ' max danmaku count
            End Select

        End If

    End Sub

    Private Sub RefreshCheatOn()
        CheatOn = (
            FHPCheck.Checked Or
            FCashCheck.Checked Or
            FStrengthCheck.Checked Or
            FSatietyCheck.Checked Or
            FExpCheck.Checked Or
            FDmkCheck.Checked
            )

        CheaTimer.Enabled = CheatOn
    End Sub

    Private Sub FHPCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FHPCheck.CheckedChanged
        If FHPCheck.Checked Then
            cheatCheck = cheatCheck Or &H1 ' 0000 0001
        Else
            cheatCheck = cheatCheck And &HFE ' 1111 1110
        End If
        RefreshCheatOn()
    End Sub

    Private Sub FSatietyCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FSatietyCheck.CheckedChanged
        If FSatietyCheck.Checked Then
            cheatCheck = cheatCheck Or &H2 ' 0000 0010
        Else
            cheatCheck = cheatCheck And &HFD ' 1111 1101
        End If
        RefreshCheatOn()
    End Sub


    Private Sub FStrengthCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FStrengthCheck.CheckedChanged
        If FStrengthCheck.Checked Then
            cheatCheck = cheatCheck Or &H4 ' 0000 0100
        Else
            cheatCheck = cheatCheck And &HFB ' 1111 1011
        End If
        RefreshCheatOn()
    End Sub

    Private Sub FCashCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FCashCheck.CheckedChanged
        If FCashCheck.Checked Then
            cheatCheck = cheatCheck Or &H8 ' 0000 1000
        Else
            cheatCheck = cheatCheck And &HF7 ' 1111 0111
        End If
        RefreshCheatOn()
    End Sub

    Private Sub FExpCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FExpCheck.CheckedChanged
        If FExpCheck.Checked Then
            cheatCheck = cheatCheck Or &H10 ' 0001 0000
        Else
            cheatCheck = cheatCheck And &HEF ' 1110 1111
        End If
        RefreshCheatOn()
    End Sub

    Private Sub FDmkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles FDmkCheck.CheckedChanged
        If FDmkCheck.Checked Then
            cheatCheck = cheatCheck Or &H20 ' 0010 0000
        Else
            cheatCheck = cheatCheck And &HDF ' 1101 1111
        End If
        RefreshCheatOn()
    End Sub

    Private Sub StatusText(str As String)
        ToolStripStatusLabel.Text = str
    End Sub

    Private Sub ClearStatus()
        Threading.Thread.Sleep(3000)
        Invoke(New StatusDel(AddressOf StatusText), "    ")
    End Sub

    Private Sub StatusTip(str As String)
        StatusText(str)
        BeginThread(StaThread, AddressOf ClearStatus)
    End Sub

End Class