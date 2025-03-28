Imports System.IO
Imports System.Timers

Public Class MainForm

    'Dim SavStatus As Integer
    Dim SavName, OldName, SavDate As String
    Dim StaTimer As System.Timers.Timer
    Dim StatuSec As UInteger
    Private Delegate Sub StatusDel(ByVal str As String)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        InitMainUI()
    End Sub

    Private Sub InitMainUI()
        CreateDir(path & "\SL", "")

        Me.Width = 742

        SaveTextBox.ShortcutsEnabled = False
        SaveTextBox.MaxLength = 29
        Me.ActiveControl = Me.SaveTextBox

        CheatOn = False
        StatuSec = 300
        LastCheatId = 10
        SavName = ""
        SavDate = ""

        InitHead(SaveBox)
        InitCheat()
        StaTimer = New System.Timers.Timer(1)
        AddHandler StaTimer.Elapsed, New ElapsedEventHandler(AddressOf StaTimerTick)
    End Sub

    Private Sub SetBtn_Click(sender As Object, e As EventArgs) Handles SetBtn.Click
        Call OpenSettings()
    End Sub

    Private Sub RestartBtn_Click(sender As Object, e As EventArgs) Handles RestartBtn.Click
        If ExistProcess(pname) Then
            Call EndProcess(pname)
            Call StartProcess()
        End If
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        If Not ExistProcess(pname) Then
            Call StartProcess()
        End If
    End Sub

    Private Sub EndBtn_Click(sender As Object, e As EventArgs) Handles EndBtn.Click
        Call EndProcess(pname)
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Call StartSave()
        Call UpdateList(SaveBox)
        Call SaveButtonInit()
    End Sub

    Private Sub ResumeBtn_Click(sender As Object, e As EventArgs) Handles ResumeBtn.Click
        Call ResumeGame()
    End Sub

    Private Sub SaveButtonInit()
        SaveBtn.Enabled = ExistFile(path & "\000.sav")
        LoadBtn.Enabled = False
        DeleteBtn.Enabled = False
        If SaveBox.Items.Count > 0 Then
            If SaveBox.SelectedItems.Count > 0 Then
                If SaveBox.SelectedItems(0).Index <> 0 Then
                    LoadBtn.Enabled = True
                    DeleteBtn.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub SaveBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBox.SelectedIndexChanged
        Call SaveButtonInit()
        If SaveBox.SelectedItems.Count > 0 Then
            If SaveBox.SelectedItems.Item(0).Index > 0 Then
                SaveTextBox.Text = SaveBox.SelectedItems.Item(0).Text
            End If
        End If
    End Sub
    Private Sub SaveBoxItems_DoubleClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles SaveBox.MouseDoubleClick

        If e.Button = MouseButtons.Left And SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text <> "" Then
            SaveBox.LabelEdit = True
            SaveBox.SelectedItems.Item(0).BeginEdit()
        Else
            SaveBox.LabelEdit = False
        End If

    End Sub

    Private Sub SaveBoxItems_AfterEdit(ByVal sender As System.Object, ByVal e As LabelEditEventArgs) Handles SaveBox.AfterLabelEdit
        Dim primename As String = SaveBox.SelectedItems.Item(0).Text
        Dim filedate As String = SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text
        Dim prime As String = primename & "_" & InvDateFormat(filedate) & ".rds"
        If e.Label <> "" And Trim(e.Label) <> primename And Trim(e.Label).Length < 30 Then

            If InStr(e.Label, "\") ^ 2 + InStr(e.Label, "/") ^ 2 + InStr(e.Label, "*") ^ 2 +
               InStr(e.Label, ":") ^ 2 + InStr(e.Label, "?") ^ 2 + InStr(e.Label, "<") ^ 2 +
               InStr(e.Label, ">") ^ 2 + InStr(e.Label, """") ^ 2 + InStr(e.Label, "|") ^ 2 = 0 Then
                Dim newname As String = Trim(e.Label) & "_" & InvDateFormat(filedate) & ".rds"

                If Dir(path & "\SL\" & newname) <> "" Then newname = Trim(e.Label) & Format(DateTime.Now, "_yyyy-MM-dd_HH-mm-ss") & ".rds"
                My.Computer.FileSystem.RenameFile(path & "\SL\" & prime, newname)
                e.CancelEdit = True
                UpdateList(SaveBox)
            Else
                e.CancelEdit = True
                StatusTip("An archive name cannot contain any of the following characters: \/:*?""<>|")
            End If
        Else
            e.CancelEdit = True
        End If
    End Sub

    Private Sub UpdateList(ByVal w As Object)
        w.Items.Clear()
        If w Is SaveBox Then w.Items.Add("").SubItems.Add("")
        Dim SortedDirectories = New DirectoryInfo(path & "\SL\").GetFiles("*.rds", IO.SearchOption.AllDirectories).OrderBy(Function(f) f.CreationTime).ToList()

        Dim n As Integer = SortedDirectories.Count
        If n > 0 Then
            For i As Integer = 0 To n - 1
                Dim rn As String = SortedDirectories(n - 1 - i).Name.ToString
                Dim rec As String = rn.Substring(0, rn.Length - 24)
                Dim dat As String = rn.Substring(rn.Length - 23, 19)
                If Not IsDate(DateFormat(dat)) Then
                    Dim unsave = New FileInfo(path & "\SL\" & rn)
                    dat = Format(unsave.CreationTime, "yyyy/MM/dd HH:mm:ss")
                    rec = rn.Substring(0, rn.Length - 4)
                    Dim newname As String = rec & "_" & InvDateFormat(dat) & ".rds"
                    If Dir(path & "\SL\" & newname) <> "" Then newname = rec & Format(DateTime.Now, "_yyyy-MM-dd_HH-mm-ss") & ".rds"
                    My.Computer.FileSystem.RenameFile(path & "\SL\" & rn, newname)
                End If
                Dim itm As ListViewItem = w.Items.Add(rec)
                itm.SubItems.Add(DateFormat(dat))
            Next
        End If
        w.Refresh()
        If w.Items.Count > 0 Then w.Items.Item(0).Selected = True
        'StatusTip(n.ToString)

    End Sub

    Private Sub SaveTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTextBox.TextChanged
        If Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = "\" Or Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = "/" Or
               Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = "*" Or Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = ":" Or
               Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = "?" Or Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = "<" Or
               Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = """" Or Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = ">" Or
               Microsoft.VisualBasic.Right(SaveTextBox.Text, 1) = "|" Then
            SaveTextBox.Text = Microsoft.VisualBasic.Left(SaveTextBox.Text, Len(SaveTextBox.Text) - 1)
            SaveTextBox.SelectionStart = Len(SaveTextBox.Text)
        End If
    End Sub

    Private Sub SaveTextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles SaveTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call StartSave()
            Call UpdateList(SaveBox)
        End If
    End Sub

    Private Sub StartSave()

        SavName = SaveTextBox.Text
        If SavName = "" Then SavName = "Untitled"

        If SaveBox.SelectedItems.Count > 0 Then
            If SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text <> "" Then
                Dim ans As String = MsgBox("Overwrite the archive that already exists?", vbYesNo)        '存档已存在，是否覆盖?
                If ans = vbYes Then
                    OldName = SaveBox.SelectedItems.Item(0).SubItems.Item(0).Text
                    SavDate = SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text
                    FileCover(OldName, SavName, SavDate)
                End If
            Else
                FileCreate(SavName)
            End If
        Else
            FileCreate(SavName)
        End If
    End Sub


    Private Sub TabControl_Main_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl_Main.Selected

        If e.TabPage.TabIndex = TabPage_Archive.TabIndex Then
            UpdateList(SaveBox)
            SaveTextBox.Clear()
            SaveButtonInit()
            StatusTip("Archive Tab")
        End If

        If e.TabPage.TabIndex = TabPage_Cheat.TabIndex Then
            If Not CheaTimer.Enabled Then
                UnlockAllBtn()
            End If
            RefreshAll()
        End If
    End Sub

    Private Sub LoadBtn_Click(sender As Object, e As EventArgs) Handles LoadBtn.Click
        Dim res As MsgBoxResult = MsgBox("Abandon current point to load selected archive?", vbYesNo)
        If res = vbYes Or Process.GetProcessesByName(pname).Count = 0 Then
            SavName = SaveBox.SelectedItems.Item(0).Text
            SavDate = SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text
            LoadGame(SavName, SavDate)
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim res As MsgBoxResult = MsgBox("Delete selected archive?", vbYesNo)
        If res = vbYes Or Process.GetProcessesByName(pname).Count = 0 Then
            SavName = SaveBox.SelectedItems.Item(0).Text
            SavDate = SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text
            Dim dname As String = SavName & "_" & InvDateFormat(SavDate)
            My.Computer.FileSystem.DeleteFile(path & "\SL\" & dname & ".rds")
            Call UpdateList(SaveBox)
        End If
    End Sub

    Private Sub InitCheat()
        CheaTimer = New System.Timers.Timer(100)
        AddHandler CheaTimer.Elapsed, New ElapsedEventHandler(AddressOf CheaTimerTick)
    End Sub

    Private Sub CheaTimerTick()

        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""

        If inGame(LastCheatId + 1, c, err) Then
            If HPCheck.Checked Then If c(0) <> HPNum.Value Or c(1) <> HPUpperNum.Value Then changeValue(0)
            If CashCheck.Checked Then If c(2) <> CashNum.Value Then changeValue(1)
            If StrengthCheck.Checked Then If c(3) <> StrengthNum.Value Or c(4) <> StrengthUpperNum.Value Then changeValue(2)
            If SatietyCheck.Checked Then If c(5) <> SatietyNum.Value Or c(6) <> SatietyUpperNum.Value Then changeValue(3)
            If ExpCheck.Checked Then If c(8) <> ExpNum.Value Then changeValue(4)
            If DanmakuCheck.Checked Then If c(10) <> DanmakuNum.Value Then changeValue(5)

        End If

        If err <> "" Then StatusTip(err)

    End Sub

    Private Sub Refresh_Enabled()

        CheatOn = (
            HPCheck.Checked Or
            CashCheck.Checked Or
            StrengthCheck.Checked Or
            SatietyCheck.Checked Or
            ExpCheck.Checked Or
            DanmakuCheck.Checked
            )

        CheaTimer.Enabled = CheatOn
        RefreshBtn.Enabled = Not (
            HPCheck.Checked And
            CashCheck.Checked And
            StrengthCheck.Checked And
            SatietyCheck.Checked And
            ExpCheck.Checked And
            DanmakuCheck.Checked
            )

    End Sub

    Private Sub HPUpperCheck_CheckedChanged(sender As Object, e As EventArgs) Handles HPCheck.CheckedChanged
        HPNum.Enabled = Not HPCheck.Checked
        HPUpperNum.Enabled = Not HPCheck.Checked
        HPBtn.Enabled = Not HPCheck.Checked
        If HPCheck.Checked Then changeValue(0)
        Call Refresh_Enabled()
    End Sub

    Private Sub CashCheck_CheckedChanged(sender As Object, e As EventArgs) Handles CashCheck.CheckedChanged
        CashNum.Enabled = Not CashCheck.Checked
        CashBtn.Enabled = CashNum.Enabled
        If CashCheck.Checked Then changeValue(1)
        Call Refresh_Enabled()
    End Sub

    Private Sub StrengthUpperCheck_CheckedChanged(sender As Object, e As EventArgs) Handles StrengthCheck.CheckedChanged
        StrengthNum.Enabled = Not StrengthCheck.Checked
        StrengthUpperNum.Enabled = Not StrengthCheck.Checked
        StrengthBtn.Enabled = Not StrengthCheck.Checked
        If StrengthCheck.Checked Then changeValue(2)
        Call Refresh_Enabled()
    End Sub

    Private Sub SatietyUpperCheck_CheckedChanged(sender As Object, e As EventArgs) Handles SatietyCheck.CheckedChanged
        SatietyNum.Enabled = Not SatietyCheck.Checked
        SatietyUpperNum.Enabled = Not SatietyCheck.Checked
        SatietyBtn.Enabled = Not SatietyCheck.Checked
        If SatietyCheck.Checked Then changeValue(3)
        Call Refresh_Enabled()
    End Sub

    Private Sub MaxHP()
        If Not HPCheck.Checked Then
            HPUpperNum.Value = HPUpperNum.Maximum
            HPNum.Value = HPNum.Maximum
        End If
    End Sub

    Private Sub MaxCash()
        If Not CashCheck.Checked Then
            CashNum.Value = CashNum.Maximum
        End If
    End Sub

    Private Sub MaxStrength()
        If Not StrengthCheck.Checked Then
            StrengthUpperNum.Value = StrengthUpperNum.Maximum
            StrengthNum.Value = StrengthNum.Maximum
        End If
    End Sub

    Private Sub MaxSatiety()
        If Not SatietyCheck.Checked Then
            SatietyUpperNum.Value = SatietyUpperNum.Maximum
            SatietyNum.Value = SatietyNum.Maximum
        End If
    End Sub

    Private Sub MaxExp()
        If Not ExpCheck.Checked Then
            LvNum.Value = LvNum.Maximum
            ExpNum.Value = ExpNum.Maximum
        End If
    End Sub

    Private Sub MaxDanmaku()
        If Not DanmakuCheck.Checked Then
            DanmakuNum.Value = DanmakuNum.Maximum
        End If
    End Sub

    Private Sub LockAllBtn_Click(sender As Object, e As EventArgs) Handles MaxBtn.Click
        MaxHP()
        MaxCash()
        MaxStrength()
        MaxSatiety()
        MaxExp()
        MaxDanmaku()
    End Sub

    Private Sub UnlockAllBtn()
        HPCheck.Checked = False
        CashCheck.Checked = False
        StrengthCheck.Checked = False
        SatietyCheck.Checked = False
        ExpCheck.Checked = False
        DanmakuCheck.Checked = False
    End Sub

    Private Sub UnlockAllBtn_Click(sender As Object, e As EventArgs) Handles UnlockBtn.Click
        UnlockAllBtn()
    End Sub

    Private Sub HPNum_TextChanged(sender As Object, e As EventArgs) Handles HPNum.TextChanged
        AdjNumRange(HPNum)
    End Sub

    Private Sub HPUpperNum_LostFocus(sender As Object, e As EventArgs) Handles HPUpperNum.LostFocus, HPUpperNum.ValueChanged, HPUpperNum.Leave
        AdjNumRange(HPUpperNum)
        HPNum.Maximum = HPUpperNum.Value
    End Sub


    Private Sub CashNum_ValueChanged(sender As Object, e As EventArgs) Handles CashNum.TextChanged
        AdjNumRange(CashNum)
    End Sub

    Private Sub StageValChanged(sender As Object, e As EventArgs) Handles StageVal.TextChanged
        AdjNumRange(StageVal)
    End Sub

    Private Sub LvNum_ValueChanged(sender As Object, e As EventArgs) Handles ExpNum.TextChanged
        AdjNumRange(ExpNum)
    End Sub

    Private Sub StrengthNum_TextChanged(sender As Object, e As EventArgs) Handles StrengthNum.TextChanged
        AdjNumRange(StrengthNum)
    End Sub

    Private Sub StrengthUpperNum_TextChanged(sender As Object, e As EventArgs) Handles StrengthUpperNum.LostFocus, StrengthUpperNum.ValueChanged, StrengthUpperNum.Leave
        AdjNumRange(StrengthUpperNum)
        StrengthNum.Maximum = StrengthUpperNum.Value
    End Sub

    Private Sub SatietyNum_TextChanged(sender As Object, e As EventArgs) Handles SatietyNum.TextChanged
        AdjNumRange(SatietyNum)
    End Sub

    Private Sub SatietyUpperNum_TextChanged(sender As Object, e As EventArgs) Handles SatietyUpperNum.LostFocus, SatietyUpperNum.ValueChanged, SatietyUpperNum.Leave
        AdjNumRange(SatietyUpperNum)
        SatietyNum.Maximum = SatietyUpperNum.Value
    End Sub


    Private Sub ConfirmAllBtn_Click(sender As Object, e As EventArgs) Handles LockBtn.Click
        If ExistProcess(pname) Then
            MaxBtn.PerformClick()
            HPCheck.Checked = True
            CashCheck.Checked = True
            StrengthCheck.Checked = True
            SatietyCheck.Checked = True
            ExpCheck.Checked = True
            DanmakuCheck.Checked = True
        Else
            StatusTip("Game not start")
        End If
    End Sub

    Private Sub RefreshHP(c0 As Integer, c1 As Integer)
        If Not HPCheck.Checked Then
            HPUpperNum.Value = CDec(c1)
            HPNum.Maximum = HPUpperNum.Value
            HPNum.Value = CDec(c0)
        End If
    End Sub

    Private Sub RefreshCash(c2 As Integer)
        If Not CashCheck.Checked Then
            CashNum.Value = CDec(c2)
        End If
    End Sub

    Private Sub RefreshStrength(c3 As Integer, c4 As Integer)
        If Not StrengthCheck.Checked Then
            StrengthUpperNum.Value = CDec(c4)
            StrengthNum.Maximum = StrengthUpperNum.Value
            StrengthNum.Value = CDec(c3)
        End If
    End Sub

    Private Sub RefreshSatiety(c5 As Integer, c6 As Integer)
        If Not SatietyCheck.Checked Then
            SatietyUpperNum.Value = CDec(c6)
            SatietyNum.Maximum = SatietyUpperNum.Value
            SatietyNum.Value = CDec(c5)
        End If
    End Sub

    Private Sub RefreshExp(c7 As Integer, c8 As Integer)
        LvNum.Value = CDec(c7)
        If Not ExpCheck.Checked Then
            ExpNum.Value = CDec(c8)
        End If
    End Sub

    Private Sub RefreshStageAndDanmaku(c9 As Integer, c10 As Integer)
        StageVal.Value = CDec(c9)
        If Not DanmakuCheck.Checked Then
            DanmakuNum.Value = CDec(c10)
        End If
    End Sub

    Private Sub RefreshAll()
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""

        If inGame(LastCheatId + 1, c, err) Then
            RefreshHP(c(0), c(1))
            RefreshCash(c(2))
            RefreshStrength(c(3), c(4))
            RefreshSatiety(c(5), c(6))
            RefreshExp(c(7), c(8))
            RefreshStageAndDanmaku(c(9), c(10))
        End If

        If err <> "" Then
            StatusTip(err)
        Else
            StatusTip("Refreshing success!")
        End If
    End Sub

    Private Sub InitHead(ByVal w As Object)
        With w
            .Clear()
            .View = View.Details
            .FullRowSelect = True
            .HideSelection = False
            .MultiSelect = False
            .GridLines = True
            .HeaderStyle = ColumnHeaderStyle.None
        End With

        w.MultiSelect = False
        w.Columns.Add("Record", CInt(Val(w.Size.Width) * 0.56), HorizontalAlignment.Left)
        w.Columns.Add("Date", CInt(Val(w.Size.Width) * 0.4), HorizontalAlignment.Left)
    End Sub

    Private Sub LvCheck_CheckedChanged(sender As Object, e As EventArgs) Handles ExpCheck.CheckedChanged
        ExpNum.Enabled = Not ExpCheck.Checked
        ExpBtn.Enabled = ExpNum.Enabled
        If ExpCheck.Checked Then changeValue(4)
        Call Refresh_Enabled()
    End Sub

    Private Sub MHPBtn_Click(sender As Object, e As EventArgs) Handles MHPBtn.Click
        MaxHP()
    End Sub

    Private Sub MCashBtn_Click(sender As Object, e As EventArgs) Handles MCashBtn.Click
        MaxCash()
    End Sub

    Private Sub MStrengthBtn_Click(sender As Object, e As EventArgs) Handles MStrengthBtn.Click
        MaxStrength()
    End Sub

    Private Sub MSatietyBtn_Click(sender As Object, e As EventArgs) Handles MSatietyBtn.Click
        MaxSatiety()
    End Sub

    Private Sub MExpBtn_Click(sender As Object, e As EventArgs) Handles MExpBtn.Click
        MaxExp()
    End Sub

    Private Sub RHPBtn_Click(sender As Object, e As EventArgs) Handles RHPBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then RefreshHP(c(0), c(1))
        If err <> "" Then StatusTip(err)
    End Sub

    Private Sub RCashBtn_Click(sender As Object, e As EventArgs) Handles RCashBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then RefreshCash(c(2))
        If err <> "" Then StatusTip(err)
    End Sub

    Private Sub RStrengthBtn_Click(sender As Object, e As EventArgs) Handles RStrengthBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then RefreshStrength(c(3), c(4))
        If err <> "" Then StatusTip(err)
    End Sub

    Private Sub RSatietyBtn_Click(sender As Object, e As EventArgs) Handles RSatietyBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then RefreshSatiety(c(5), c(6))
        If err <> "" Then StatusTip(err)
    End Sub

    Private Sub RExpBtn_Click(sender As Object, e As EventArgs) Handles RExpBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then RefreshExp(c(7), c(8))
        If err <> "" Then StatusTip(err)
    End Sub


    Private Sub RStageBtn_Click(sender As Object, e As EventArgs) Handles RStageBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then RefreshStageAndDanmaku(c(9), c(10))
        If err <> "" Then StatusTip(err)
    End Sub

    Private Sub StageBtn_Click(sender As Object, e As EventArgs) Handles StageBtn.Click
        changeValue(5)
    End Sub

    Private Sub changeValue(ByVal opt As Integer)

        Dim c(0 To 1) As UInteger
        Dim err As String = ""

        If inGame(LastCheatId + 1, c, err) Then

            Select Case opt
                Case 0
                    writeHP(c(0), c(1), CDec(HPNum.Value), CDec(HPUpperNum.Value))
                Case 1
                    writeCash(c(0), c(1), CDec(CashNum.Value))
                Case 2
                    writeStrength(c(0), c(1), CDec(StrengthNum.Value), CDec(StrengthUpperNum.Value))
                Case 3
                    writeSatiety(c(0), c(1), CDec(SatietyNum.Value), CDec(SatietyUpperNum.Value))
                Case 4
                    writeExp(c(0), c(1), CDec(ExpNum.Value))
                Case Else
                    writeDanmakuCount(c(0), c(1), CDec(DanmakuNum.Value))

            End Select

        End If

        If err <> "" Then StatusTip(err)

    End Sub

    Private Sub HPBtn_Click(sender As Object, e As EventArgs) Handles HPBtn.Click
        changeValue(0)
    End Sub

    Private Sub CashBtn_Click(sender As Object, e As EventArgs) Handles CashBtn.Click
        changeValue(1)
    End Sub

    Private Sub StrengthBtn_Click(sender As Object, e As EventArgs) Handles StrengthBtn.Click
        changeValue(2)
    End Sub

    Private Sub SatietyBtn_Click(sender As Object, e As EventArgs) Handles SatietyBtn.Click
        changeValue(3)
    End Sub
    Private Sub LvBtn_Click(sender As Object, e As EventArgs) Handles ExpBtn.Click
        changeValue(4)
    End Sub

    Private Sub StatusText(str As String)
        ToolStripStatusLabel.Text = str
    End Sub

    Private Sub RefreshBtn_Click(sender As Object, e As EventArgs) Handles RefreshBtn.Click
        RefreshAll()
    End Sub

    Private Sub DanmakuNum_ValueChanged(sender As Object, e As EventArgs) Handles DanmakuNum.ValueChanged
        AdjNumRange(DanmakuNum)
    End Sub

    Private Sub DanmakuCheck_CheckedChanged(sender As Object, e As EventArgs) Handles DanmakuCheck.CheckedChanged
        DanmakuNum.Enabled = Not DanmakuCheck.Checked
        StageBtn.Enabled = Not DanmakuCheck.Checked
        If DanmakuCheck.Checked Then changeValue(5)
        Call Refresh_Enabled()
    End Sub

    Private Sub MDanmakuBtn_Click(sender As Object, e As EventArgs) Handles MDanmakuBtn.Click
        MaxDanmaku()
    End Sub

    Private Sub StaTimerTick()
        If StatuSec > 0 Then
            StatuSec -= 1
        Else
            Do
                StaTimer.Stop()
            Loop Until Not StaTimer.Enabled
            Invoke(New StatusDel(AddressOf StatusText), "")
        End If
    End Sub

    Private Sub StatusTip(str As String)
        StatusText(str)
        StatuSec = 300
        If Not StaTimer.Enabled Then StaTimer.Start()
    End Sub

End Class
