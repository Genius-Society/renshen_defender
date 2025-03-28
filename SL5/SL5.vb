Imports System.IO
Imports System.Timers
Imports System.Threading

Public Class SL5

    Dim SavStatus As Integer
    Dim s(0 To 30) As String
    Dim KeyCon(0 To 13) As Object
    Dim SavName, OldName, SavDate As String
    Dim reStartThread, SGThread, SaveThread, ResThread, AutoThread, LoadThread, CheaThread, StaThread As Thread
    Dim StaTimer As System.Timers.Timer
    Dim StatuSec As UInteger

    Private Delegate Sub TimerDel(ByVal hwnd As Boolean)
    Private Delegate Sub AutoDel(ByVal hwnd As Boolean)
    Private Delegate Sub StartDel(ByVal hwnd As Boolean)
    Private Delegate Sub reStartDel(ByVal hwnd As Boolean)
    Private Delegate Sub SaveDel(ByVal hwnd As Boolean)
    Private Delegate Sub ResumeDel(ByVal hwnd As Boolean)
    Private Delegate Sub LoadDel(ByVal hwnd As Boolean)
    Private Delegate Sub StatusDel(ByVal str As String)

    Private Sub DelButtonInit()
        DelConfirmButton.Enabled = (DeleteBox.SelectedItems.Count > 0)
        BackupButton.Enabled = (DeleteBox.SelectedItems.Count > 0)
    End Sub
    Private Sub LoadButtonInit()
        LoadConfirmButton.Enabled = (LoadBox.SelectedItems.Count > 0)
        ExportButton.Enabled = (LoadBox.SelectedItems.Count = 1)
    End Sub
    Private Sub SaveButtonInit()
        If Not My.Computer.FileSystem.DirectoryExists(path & "\Game\save\") Then My.Computer.FileSystem.CreateDirectory(path & "\Game\save")
        SaveConfirmButton.Enabled = (Directory.GetDirectories(path & "\Game\save\").Count > 0)
        'AutoSaveButton.Enabled = SaveConfirmButton.Enabled
    End Sub

    Public Sub AutoButtonInit()
        AutoStartButton.Enabled = (MazesCombo.Text <> "" And Not AutoStartOn)
        AutoStopButton.Enabled = AutoStartOn
        AutoMainPanel.Enabled = Not AutoStartOn
        RadioGenius.Checked = GeniusOn
        RadioNormal.Checked = Not RadioGenius.Checked
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

        If w Is DeleteBox Then
            w.MultiSelect = True
            w.Columns.Add("Record", CInt(Val(w.Size.Width) * 0.54), HorizontalAlignment.Left)
            w.Columns.Add("Date", CInt(Val(w.Size.Width) * 0.4), HorizontalAlignment.Left)
        Else
            w.MultiSelect = False
            w.Columns.Add("Record", CInt(Val(w.Size.Width) * 0.56), HorizontalAlignment.Left)
            w.Columns.Add("Date", CInt(Val(w.Size.Width) * 0.4), HorizontalAlignment.Left)
        End If
    End Sub


    Private Sub GrapInit()
        FullScreenTrue.Checked = CBool(GetINI("Graphics", "Fullscreen", inipath))
        FullScreenFalse.Checked = Not FullScreenTrue.Checked
        WinSizeCombo.Enabled = FullScreenFalse.Checked

        Dim w As Double = Val(GetINI("Graphics", "ScreenWidth", inipath))
        WinSizeCombo.Text = WinSizeCombo.Items.Item(CInt((w - 640.0) / 320.0)).ToString

        ScreenProtectFalse.Checked = CBool(GetINI("Graphics", "ScreenSaverCancel", inipath))
        ScreenProtectTrue.Checked = Not ScreenProtectFalse.Checked

        Frame15.Checked = (GetINI("Graphics", "FrameSkip", inipath) = "2")
        Frame30.Checked = (GetINI("Graphics", "FrameSkip", inipath) = "1")
        Frame60.Checked = (GetINI("Graphics", "FrameSkip", inipath) = "0")

        TexLowQuality.Checked = (GetINI("Graphics", "FontTexType", inipath) = "0")
        TexHighQuality.Checked = Not TexLowQuality.Checked

        MovLowQuality.Checked = (GetINI("Graphics", "MovieQuality", inipath) = "0")
        MovHighQuality.Checked = Not MovLowQuality.Checked
    End Sub
    Private Sub PlayInit()

        LMiniMap.Checked = (GetINI("GameConfig", "MinimapPosition", inipath) = "0")
        CMiniMap.Checked = (GetINI("GameConfig", "MinimapPosition", inipath) = "1")
        RMiniMap.Checked = (GetINI("GameConfig", "MinimapPosition", inipath) = "2")

        Dim dx As Double = Val(GetINI("GameConfig", "LogPosition", inipath))
        Dim dy As Double = Val(GetINI("GameConfig", "LogFontType", inipath))
        Dim d As Integer = CInt((-1.0) ^ (1.0 - dx) + 2.0 ^ (1.0 - dy))
        LLog.Checked = (d = 0)
        CLog.Checked = (d = 1)
        RLog.Checked = (d = 2)

        KanaTrue.Checked = CBool(GetINI("Adventure", "ShowRuby", inipath))
        KanaFalse.Checked = Not KanaTrue.Checked

        VoiceWaitTrue.Checked = CBool(GetINI("Adventure", "VoiceWait", inipath))
        VoiceWaitFalse.Checked = Not VoiceWaitTrue.Checked

        Dim s As Double = Val(GetINI("GameConfig", "GameSpeed", inipath))
        SpeedTextBox.Text = s.ToString
        SpeedTrack.Value = CInt(2.0 * s)

        SpecialCheckBox.Checked = CBool(GetINI("GameConfig", "IDashSkewSwap", inipath))
    End Sub
    Private Sub SoundInit()
        BGMTrack.Value = CInt(0.1 * Val(GetINI("Sound", "BGMVolume", inipath)))
        SETrack.Value = CInt(0.1 * Val(GetINI("Sound", "SEVolume", inipath)))
        VoiceTrack.Value = CInt(0.1 * Val(GetINI("Sound", "VoiceVolume", inipath)))
        ADVoiceTrack.Value = CInt(0.1 * Val(GetINI("Adventure", "VoiceVolume", inipath)))
    End Sub

    Private Sub KeyLoad()
        KeyCon(0) = Key0
        KeyCon(1) = Key1
        KeyCon(2) = Key2
        KeyCon(3) = Key3
        KeyCon(4) = Key4
        KeyCon(5) = Key5
        KeyCon(6) = Key6
        KeyCon(7) = Key7
        KeyCon(8) = Key8
        KeyCon(9) = Key9
        KeyCon(10) = Key10
        KeyCon(11) = Key11
        KeyCon(12) = Key12
        KeyCon(13) = Key13
    End Sub
    Private Sub KeyInit()
        Call KeyLoad()
        For i As Integer = 0 To 13
            Dim KeyValue As Integer = CInt(GetINI("Key", "Key-" & i.ToString, inipath))
            KeyCon(i).Text = KeyToStr(KeyValue)
            KeyCon(i).TabIndex = i
        Next
    End Sub


    Private Sub GraphSave()
        WriteINI("Graphics", "Fullscreen", FullScreenTrue.Checked.ToString, inipath)

        If FullScreenFalse.Checked Then
            Dim w As Integer = WinSizeCombo.SelectedIndex
            WriteINI("Graphics", "ScreenWidth", (640 + 320 * w).ToString, inipath)
            WriteINI("Graphics", "ScreenHeight", (360 + 180 * w).ToString, inipath)
        End If

        WriteINI("Graphics", "ScreenSaverCancel", ScreenProtectFalse.Checked.ToString, inipath)
        Dim f As Integer = 2 * Phi(Frame15.Checked) + Phi(Frame30.Checked)
        WriteINI("Graphics", "FrameSkip", f.ToString, inipath)
        WriteINI("Graphics", "FontTexType", (1 + CInt(TexLowQuality.Checked)).ToString, inipath)
        WriteINI("Graphics", "ActorTexType", (1 + CInt(TexLowQuality.Checked)).ToString, inipath)
        WriteINI("Graphics", "MovieQuality", (1 + CInt(MovLowQuality.Checked)).ToString, inipath)

    End Sub

    Private Sub PlaySave()

        Dim m As Integer = 2 * Phi(RMiniMap.Checked) + Phi(CMiniMap.Checked)
        WriteINI("GameConfig", "MinimapPosition", m.ToString, inipath)

        If RLog.Checked Then
            Dim RLog() As Integer = {13, 1, 1, 29, 23, 140}
            BatchWrite(RLog)
        ElseIf CLog.Checked Then
            Dim CLog() As Integer = {6, 0, 0, 32, 323, 480}
            BatchWrite(CLog)
        Else
            Dim LLog() As Integer = {13, 0, 1, 29, 23, 140}
            BatchWrite(LLog)
        End If

        WriteINI("Adventure", "ShowRuby", KanaTrue.Checked.ToString, inipath)
        WriteINI("Adventure", "VoiceWait", VoiceWaitTrue.Checked.ToString, inipath)
        WriteINI("GameConfig", "GameSpeed", SpeedTextBox.Text, inipath)
        WriteINI("GameConfig", "IDashSkewSwap", SpecialCheckBox.Checked.ToString, inipath)
    End Sub
    Private Sub SoundSave()
        WriteINI("Sound", "BGMVolume", (10 * BGMTrack.Value).ToString, inipath)
        WriteINI("Sound", "SEVolume", (10 * SETrack.Value).ToString, inipath)
        WriteINI("Sound", "VoiceVolume", (10 * VoiceTrack.Value).ToString, inipath)
        WriteINI("Adventure", "VoiceVolume", (10 * ADVoiceTrack.Value).ToString, inipath)
    End Sub
    Private Sub KeySave()
        For i As Integer = 0 To 13
            WriteINI("Key", "Key-" & i.ToString, StrToKey(KeyCon(i).Text).ToString, inipath)
        Next
    End Sub


    'Public Sub ToPage(ByVal w As Object)
    '    Dim err As String = ""
    '    Dim obj(0 To 6) As Object
    '    obj(0) = MainContainer
    '    obj(1) = LoadContainer
    '    obj(2) = SaveContainer
    '    obj(3) = DeleteContainer
    '    obj(4) = AutoContainer
    '    obj(5) = SetContainer
    '    obj(6) = CheatContainer

    '    If w Is obj(0) Then
    '        RecoverButton.Enabled = False

    '    ElseIf w Is obj(1) Then
    '        UpdateList(LoadBox)
    '        LoadButtonInit()
    '        err += InitEssDir()

    '    ElseIf w Is obj(2) Then
    '        UpdateList(SaveBox)
    '        SaveTextBox.Clear()
    '        SaveButtonInit()
    '        err += InitEssDir()

    '    ElseIf w Is obj(3) Then
    '        UpdateList(DeleteBox)
    '        DelButtonInit()
    '        err += InitEssDir()

    '    ElseIf w Is obj(4) Then
    '        If MazesCombo.Text = "" Then MazesCombo.SelectedIndex = 0
    '        AutoButtonInit()
    '        err += InitEssDir()

    '    ElseIf w Is obj(5) Then
    '        If My.Computer.FileSystem.FileExists(inipath) Then
    '            Call GrapInit()
    '            Call PlayInit()
    '            Call SoundInit()
    '            Call KeyInit()
    '        Else
    '            Call SetDefault()
    '            Call KeyLoad()
    '        End If
    '        TabControl_Set.SelectedTab = TabPage1
    '        RecoverButton.Enabled = False
    '        Call SetValues()
    '    Else

    '        Call RefreshBtn_Click()

    '    End If


    '    'For i As Integer = 0 To 6
    '    '    If w Is obj(i) Then
    '    '        obj(i).Show()
    '    '    Else
    '    '        obj(i).Hide()
    '    '    End If
    '    'Next

    '    If err <> "" Then StatusTip(err)

    'End Sub

    Private Sub TabControl_Main_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl_Main.Selected

        If e.TabPage.TabIndex = TabPage_Main.TabIndex Then
            RecoverButton.Enabled = False
            StatusTip("Main Page")
        End If

        If e.TabPage.TabIndex = TabPage_Set.TabIndex Then
            If My.Computer.FileSystem.FileExists(inipath) Then
                Call GrapInit()
                Call PlayInit()
                Call SoundInit()
                Call KeyInit()
            Else
                Call SetDefault()
                Call KeyLoad()
            End If
            TabControl_Set.SelectedTab = TabPage1
            RecoverButton.Enabled = False
            Call SetValues()
            StatusTip("Settings")
        End If

        If e.TabPage.TabIndex = TabPage_Load.TabIndex Then
            UpdateList(LoadBox)
            LoadButtonInit()
            StatusTip(InitEssDir())
        End If

        If e.TabPage.TabIndex = TabPage_Delete.TabIndex Then
            UpdateList(DeleteBox)
            DelButtonInit()
            StatusTip(InitEssDir())
        End If

        If e.TabPage.TabIndex = TabPage_Save.TabIndex Then
            UpdateList(SaveBox)
            SaveTextBox.Clear()
            SaveButtonInit()
            StatusTip(InitEssDir())
        End If

        If e.TabPage.TabIndex = TabPage_Auto.TabIndex Then  'for auto save tab
            If MazesCombo.Text = "" Then MazesCombo.SelectedIndex = 0
            AutoButtonInit()
            StatusTip(InitEssDir())
        End If

        If e.TabPage.TabIndex = TabPage_Cheat.TabIndex Then
            If Not CheaTimer.Enabled Then
                UnlockAll()
            End If
            RefreshAll()
            'StatusTip("Cheat")
        End If
    End Sub

    Private Sub InitCheat()
        CheaTimer = New System.Timers.Timer(100)
        AddHandler CheaTimer.Elapsed, New ElapsedEventHandler(AddressOf CheaTimerTick)
    End Sub
    Private Sub InitGlobalVar()

        AutoStartOn = False
        GeniusOn = False
        CheatOn = False

        k = 0
        CWnd = 0
        SavStatus = 0
        StatuSec = 300
        cheatCheck = 0
        LastCheatId = 10

        SavName = ""
        SavDate = ""

        modify = My.Computer.FileSystem.GetDirectoryInfo(path & "\Game\save\" & username).LastWriteTime

        AutoTimer = New System.Timers.Timer(1500)
        AddHandler AutoTimer.Elapsed, New ElapsedEventHandler(AddressOf AutoTimerTick)
        InitCheat()

        StaTimer = New System.Timers.Timer(1)
        AddHandler StaTimer.Elapsed, New ElapsedEventHandler(AddressOf StaTimerTick)

        If Process.GetProcessesByName("MiracleSuperParty").Count > 0 Then
            Dim i As Integer = 0
            Do
                CWnd = FindWindow(vbNullString, "みらくる超パーティーPLUS.G Ver2.11")
                i += 1
            Loop Until (CWnd > 0 Or i > 1)
            If i > 1 Then CrashGame(False)
        End If

    End Sub
    '=================================================Init==========================================================================

    Private Sub InitMainUI()
        Me.Width = 742
        Me.Height = 418

        RecoverButton.Enabled = False
        SaveTextBox.ShortcutsEnabled = False
        SaveTextBox.MaxLength = 29
        Me.ActiveControl = Me.SaveTextBox

        InitHead(SaveBox)
        InitHead(LoadBox)
        InitHead(DeleteBox)
        'ToPage(MainContainer)
        'TabControl_Main.TabPages(TabPage_Auto.TabIndex - 1).Parent = Nothing
        'Need to recover it in the future
    End Sub

    Private Sub SL5_Dispose(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Environment.Exit(0)
    End Sub
    Private Sub SL5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            MsgBox("Please run as admin.")     '请以管理员身份运行！
            Me.Dispose()
        ElseIf Not My.Computer.FileSystem.FileExists(path & "\LLLauncher.exe") Then
            MsgBox("Please reinstall the patch to game path.")     '请重新安装补丁到游戏所在目录！
            Me.Dispose()
        Else
            Dim err As String = InitEssDir()
            If err <> "" Then StatusTip(err)
            Call InitGlobalVar()
            Call InitMainUI()
        End If
    End Sub

    Private Sub SL5_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Dim ans As MsgBoxResult
        Dim c As Integer = Phi(AutoStartOn) + 2 * Phi(RecoverButton.Enabled)

        Select Case c
            Case 3
                ans = MsgBox("Quit with interrupting automatic archive and without saving all changes in settings?", vbYesNo)
            Case 2
                ans = MsgBox("Quit without saving all changes in settings?", vbYesNo)
            Case 1
                ans = MsgBox("Quit with interrupting automatic archive?", vbYesNo)
        End Select

        e.Cancel = (ans = vbNo)
    End Sub

    '---------------------------------------------MainBox------------------------------------------------------------

    Private Sub Crash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndProButton.Click
        Call CrashGame(AutoStartOn)
    End Sub

    Private Sub Restart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        If Not ExistProcess("MiracleSuperParty") Then
            Call StartSG()
        Else
            StatusTip("Game already started")
        End If
    End Sub


    Public Sub BeginRestart()
        UpdateResUI(False)
        BeginThread(reStartThread, AddressOf Restart)
    End Sub

    Private Sub Restart()
        RestartGame(AutoStartOn)
        Me.Invoke(New reStartDel(AddressOf UpdateResUI), True)
        TimerHold(AutoStartOn)
    End Sub

    Private Sub UpdateResUI(ByVal hwnd As Integer)

        TableLayoutPanel_MainSub1_Sub.Enabled = hwnd
        'LoadButton.Enabled = hwnd
        'SaveButton.Enabled = hwnd
        'DeleteButton.Enabled = hwnd
        If hwnd Then
            Me.ActiveControl = Me.StartButton
        Else
            Me.ActiveControl = Me.SaveTextBox
        End If
    End Sub

    Private Sub FileDelete()
        Dim ans As String = MsgBox("Delete all selected?", vbYesNo)   '确定删除所有选中项?
        If ans = vbYes Then
            Dim n As Integer = DeleteBox.SelectedItems.Count
            For i As Integer = 0 To n - 1
                Dim s As String = DeleteBox.SelectedItems.Item(i).SubItems.Item(1).Text
                Dim dname As String = DeleteBox.SelectedItems.Item(i).Text & "_" & InvDateFormat(s)
                My.Computer.FileSystem.DeleteFile(path & "\SL\" & dname & ".rds")
            Next
            Call UpdateList(DeleteBox)
        End If
    End Sub

    '============================

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

    End Sub

    '========================= Save =============================
    Private Sub SaveConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveConfirmButton.Click
        Call StartSave()
    End Sub

    Private Sub BeginSave(ByVal s As Integer)
        UpdateSaveUI(False)
        SavStatus = s
        BeginThread(SaveThread, AddressOf Save)
    End Sub

    Private Sub StartSave()

        SavName = SaveTextBox.Text
        If SavName.Trim = "" Then SavName = "Untitled"

        If SaveBox.SelectedItems.Count > 0 Then
            If SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text <> "" Then
                Dim ans As String = MsgBox("Overwrite the archive that already exists?", vbYesNo) '存档已存在，是否覆盖?
                If ans = vbYes Then
                    OldName = SaveBox.SelectedItems.Item(0).SubItems.Item(0).Text
                    SavDate = SaveBox.SelectedItems.Item(0).SubItems.Item(1).Text
                    BeginSave(2)
                Else
                    SavStatus = 0
                End If
            Else
                BeginSave(1)
            End If
        Else
            BeginSave(1)
        End If
    End Sub

    Private Sub Save()

        Dim err As String = ""
        Select Case SavStatus
            Case 2
                err += FileCover(OldName, SavName, SavDate)
            Case 1
                err += FileCreate(SavName)
        End Select

        SavStatus = 0
        If err <> "" Then StatusTip(err)
        Me.Invoke(New SaveDel(AddressOf UpdateSaveUI), True)
    End Sub

    Private Sub UpdateSaveUI(hwnd As Boolean)
        SaveListPanel.Enabled = hwnd
        SaveConfirmButton.Enabled = hwnd
        'AutoSaveButton.Enabled = hwnd
        'SaveCancelButton.Enabled = hwnd

        If hwnd Then
            UpdateList(SaveBox)
            Call SaveButtonInit()
            Me.ActiveControl = Me.SaveConfirmButton
        Else
            Me.ActiveControl = Me.PictureBox1
        End If
    End Sub

    '============================= resume ============================
    Private Sub Resume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumeButton.Click
        Call StartResume()
    End Sub



    Private Sub StartResume()
        UpdateResumeUI(False)
        BeginThread(ResThread, AddressOf Resuming)
    End Sub

    Private Sub Resuming()
        Call ResumeGame()
        Me.Invoke(New ResumeDel(AddressOf UpdateResumeUI), True)
        TimerHold(AutoStartOn)
    End Sub

    Private Sub UpdateResumeUI(ByVal hwnd As Boolean)
        ResumeButton.Enabled = hwnd
        'AutoSaveButton.Enabled = hwnd
        'SaveCancelButton.Enabled = hwnd
        SaveListPanel.Enabled = hwnd

        If hwnd Then
            Me.ActiveControl = Me.ResumeButton
        Else
            Me.ActiveControl = Me.PictureBox1
        End If
    End Sub

    '================================

    'Private Sub Auto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ToPage(AutoContainer)
    'End Sub

    '-------------------------------------------SaveBox-------------------------------------------------------------

    Private Sub SaveBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBox.SelectedIndexChanged
        Call SaveButtonInit()
        If SaveBox.SelectedItems.Count > 0 Then If SaveBox.SelectedItems.Item(0).Index > 0 Then SaveTextBox.Text = SaveBox.SelectedItems.Item(0).Text
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
                'MsgBox()  '存档名不能包含下列任何字符: 
                StatusTip("An archive name cannot contain any of the following characters: \/:*?""<>|")
            End If
        Else
            e.CancelEdit = True
        End If
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
        If e.KeyCode = Keys.Enter Then Call StartSave()
    End Sub


    Private Sub CheaTimerTick()

        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""

        If inGame(LastCheatId + 1, c, err) Then
            If Not GeniusOn Then
                If HPCheck.Checked Then If c(0) <> HPNum.Value Or c(1) <> HPUpperNum.Value Then changeValue(0)
                If CashCheck.Checked Then If c(2) <> CashNum.Value Then changeValue(1)
                If StrengthCheck.Checked Then If c(3) <> StrengthNum.Value Or c(4) <> StrengthUpperNum.Value Then changeValue(2)
                If SatietyCheck.Checked Then If c(5) <> SatietyNum.Value Or c(6) <> SatietyUpperNum.Value Then changeValue(3)
                If ExpCheck.Checked Then If c(8) <> ExpNum.Value Then changeValue(4) ' c7 is lv, read only here
                If UnlimitedDanmakuCheck.Checked Then If c(10) <> DanmakuNum.Value Then changeValue(5) ' c9 is stage, read only

            Else
                If (cheatCheck And &H1) Then If c(0) <> 65535 Or c(1) <> 65535 Then Genius.alterValue(0)
                If (cheatCheck And &H2) Then If c(5) <> 200 Or c(6) <> 200 Then Genius.alterValue(3)
                If (cheatCheck And &H4) Then If c(3) <> 15 Or c(4) <> 15 Then Genius.alterValue(2)
                If (cheatCheck And &H8) Then If c(2) <> 999999999 Then Genius.alterValue(1)
                If (cheatCheck And &H10) Then If c(8) <> 2660000 Then Genius.alterValue(4)
                If (cheatCheck And &H20) Then If c(10) <> 5 Then Genius.alterValue(5)
            End If

        End If

        If err <> "" Then StatusTip(err)

    End Sub

    Private Sub AutoTimerTick()

        If ExistProcess("MiracleSuperParty") Then
            If modify <> DirLastWTime(path & "\Game\save\" & username) Then

                Call AutoPause()
                Dim Threshold As Integer = 100
                Dim n As Integer = 0
                Do
                    n += 1
                Loop Until (Not ExistProcess("MiracleSuperParty")) Or (n > Threshold)

                If ExistProcess("MiracleSuperParty") And n > Threshold Then

                    Me.Invoke(New TimerDel(AddressOf TimerUpdateUI), False)
                    Dim err As String = ""
                    k = AutoCreate(MazeName, k, MazeTop, err)
                    If err <> "" Then StatusTip(err)
                    Me.Invoke(New TimerDel(AddressOf TimerUpdateUI), True)

                End If

            End If
        Else
            Call AutoPause()
        End If

    End Sub

    Private Sub TimerUpdateUI(ByVal hwnd As Boolean)
        If hwnd Then
            UpdateList(SaveBox)
            UpdateList(LoadBox)
            UpdateList(DeleteBox)
            If GeniusOn Then
                With Genius
                    If AutoStartOn Then
                        .UpdateGenList()
                    Else
                        .Dispose()
                    End If
                End With
            End If

        End If

        UpdateSaveUI(hwnd)
        If GeniusOn Then
            With Genius
                .FSavButton.Enabled = hwnd
                .GenList.Enabled = hwnd
                .CloseGen.Enabled = hwnd
                .FSavButton.Enabled = hwnd
            End With
        End If

    End Sub

    Private Sub BeginAuto()
        AutoUpdateUI(False)
        AutoStartOn = True
        k = CInt(StageNum.Value)
        MazeName = MazesCombo.SelectedItem.ToString & WeekCombo.Text
        MazeTop = 1 + TopLimit(MazeName) * Phi(CInt(ReturnNum.Value) = 0) + CInt(ReturnNum.Value) * Phi(CInt(ReturnNum.Value) > 0)
        BeginThread(AutoThread, AddressOf Auto)
    End Sub

    Private Sub AutoStart()
        If Process.GetProcessesByName("MiracleSuperParty").Count > 0 Then
            Dim ans = MsgBox("Begin automatic archive by restarting the game at latest updated point?", vbYesNo) ' 自动存档将重启游戏，若从本层最近刷新位置开始存档，请点击是，否则请正常退出游戏再开始。 
            If ans = vbYes Then Call BeginAuto()
        Else
            Call BeginAuto()
        End If
    End Sub

    Private Sub AutoBegin(ByVal k As Integer)
        CurrTime = Format(DateTime.Now, "yyyy-MM-dd_HH-mm-ss").ToString
        Dim dname As String = ""

        If GeniusOn Then
            kn = 0
            dname = "「Stage " & k.ToString & "(" & kn.ToString & ")" & " - " & MazeName & "」" & "_" & CurrTime
        Else
            dname = "「Stage " & k.ToString & " - " & MazeName & "」" & "_" & CurrTime
        End If
        Dim err As String = FileSave(dname)
        If err <> "" Then StatusTip(err)
        modify = My.Computer.FileSystem.GetDirectoryInfo(path & "\Game\save\" & username).LastWriteTime
        AutoTimer.Start()
    End Sub

    Private Sub Auto()
        If GeniusOn Then CheatPause()
        AutoBegin(k)
        FStartGame(AutoStartOn)
        Me.Invoke(New AutoDel(AddressOf AutoUpdateUI), True)
        TimerHold(AutoStartOn)
    End Sub

    Private Sub AutoUpdateUI(ByVal hwnd As Boolean)

        If GeniusOn Then

            CheatOn = False
            HPCheck.Checked = False
            SatietyCheck.Checked = False
            StrengthCheck.Checked = False
            CashCheck.Checked = False

            With Genius
                .GenList.Enabled = hwnd
                .CloseGen.Enabled = hwnd
                .GenButtonContainer.Enabled = hwnd
            End With
            'Else
            '    MainMenuButton.Enabled = hwnd
            '    AutoCancelButton.Enabled = hwnd
        End If

        If hwnd Then
            If GeniusOn Then Genius.UpdateGenList()
        Else
            If GeniusOn Then
                Me.Hide()
                Genius.Show()
            Else
                Me.ActiveControl = Me.SaveTextBox
                AutoMainPanel.Enabled = False
                AutoStopButton.Enabled = True
                AutoStartButton.Enabled = False
            End If
        End If
    End Sub


    Private Sub AutoStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStartButton.Click
        Call AutoStart()
    End Sub
    Private Sub AutoStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStopButton.Click
        Me.ActiveControl = Me.SaveTextBox
        Call AutoStop()
        Call AutoButtonInit()
    End Sub


    Private Sub StageNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StageNum.KeyPress, HPNum.KeyPress, HPUpperNum.KeyPress, CashNum.KeyPress, StrengthNum.KeyPress, StrengthUpperNum.KeyPress, SatietyNum.KeyPress, SatietyUpperNum.KeyPress, StageVal.KeyPress, DanmakuNum.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = Chr(8))
    End Sub

    '==============================================LoadContainer====================================================================

    Private Sub LoadConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadConfirmButton.Click
        Call StartLoad()
    End Sub



    Private Sub StartLoad()

        Dim res As MsgBoxResult = vbYes

        If Process.GetProcessesByName("MiracleSuperParty").Count > 0 And Not (AutoStartOn And LoadBox.SelectedItems.Item(0).Text <> "「Stage " & k.ToString & " - " & MazesCombo.Text & "」") Then res = MsgBox("Abandon current process to load selected archive?", vbYesNo)

        If res = vbYes Or Process.GetProcessesByName("MiracleSuperParty").Count = 0 Then

            SavName = LoadBox.SelectedItems.Item(0).Text
            SavDate = LoadBox.SelectedItems.Item(0).SubItems.Item(1).Text

            If AutoStartOn And SavName <> "「Stage " & k.ToString & " - " & MazesCombo.Text & "」" Then
                Dim ans As MsgBoxResult = MsgBox("Autosave will stop if the loaded archive is not at Stage " & k.ToString & " of maze 「" & MazesCombo.Text & "」, is it there or not?", vbYesNoCancel) 'Dim ans = MsgBox("检测到您当前的位置是迷宫 「" & MazesCombo.Text & "」第" & k.ToString & "层" & vbCrLf & "若您要载入的存档不在该位置，自动存档将会中断。请问是否在该位置？", vbYesNoCancel)
                Select Case ans
                    Case vbYes
                        BeginLoad(3)
                    Case vbNo
                        BeginLoad(4)
                    Case vbCancel
                        SavStatus = 0
                End Select
            Else
                BeginLoad(3)
            End If
        End If
    End Sub

    Private Sub BeginLoad(ByVal s As Integer)
        UpdateLoadUI(False)
        SavStatus = s
        BeginThread(LoadThread, AddressOf Loading)
    End Sub

    Private Sub Loading()
        If SavStatus = 4 Then Call AutoStop()
        Dim err As String = LoadGame(AutoStartOn, SavName, SavDate)
        If err <> "" Then StatusTip(err)
        Me.Invoke(New LoadDel(AddressOf UpdateLoadUI), True)
        TimerHold(AutoStartOn)
        SavStatus = 0
    End Sub

    Private Sub UpdateLoadUI(ByVal hwnd As Boolean)
        LoadConfirmButton.Enabled = hwnd
        'LoadCancelButton.Enabled = hwnd
        LoadBox.Enabled = hwnd
        If hwnd Then
            Me.ActiveControl = Me.LoadConfirmButton
        Else
            Me.ActiveControl = Me.SaveTextBox
        End If
    End Sub


    '--------------------------------------------------LoadBox-----------------------------------------------------------

    Private Sub LoadBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadBox.SelectedIndexChanged
        Call LoadButtonInit()
    End Sub
    Private Sub LoadBoxItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadBox.DoubleClick
        If LoadBox.SelectedItems.Count > 0 Then Call StartLoad()
    End Sub
    Private Sub LoadBoxItems_KeyPress(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles LoadBox.KeyDown
        If LoadBox.SelectedItems.Count > 0 And (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space) Then Call StartLoad()
    End Sub


    '==============================================DeleteContainer==================================================================

    Private Sub DeleteConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelConfirmButton.Click
        Call FileDelete()
        Call DelButtonInit()

    End Sub

    '----------------------------------------------------DeleteBox-------------------------------------------------------

    Private Sub InvertButton_Click(sender As Object, e As EventArgs) Handles InvertButton.Click
        If DeleteBox.Items.Count > 0 Then
            For i As Integer = 0 To DeleteBox.Items.Count - 1
                DeleteBox.Items.Item(i).Selected = Not DeleteBox.Items.Item(i).Selected
            Next
        End If
    End Sub

    Private Sub Backup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupButton.Click
        BackupDialog.Filter = "zip files (*.zip)|*.zip"
        BackupDialog.FileName = "Archive_Packup_" & Format(Date.Now, "yyyy-MM-dd_HH-mm-ss") & ".zip"
        BackupDialog.ShowDialog()
    End Sub

    Private Sub BackupDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BackupDialog.FileOk

        Dim slvic As ListView.SelectedListViewItemCollection = DeleteBox.SelectedItems
        Dim PBForm As PGB = New PGB(slvic.Count)

        If Dir(BackupDialog.FileName) <> "" Then My.Computer.FileSystem.DeleteFile(BackupDialog.FileName)

        Dim tempath As String = path & "\SL\Archive_Packup_" & Format(Date.Now, "yyyy-MM-dd_HH-mm-ss")
        My.Computer.FileSystem.CreateDirectory(tempath)

        For i As Integer = 0 To slvic.Count - 1
            PBForm.UpdValue(i)

            Dim rec As String = slvic.Item(i).SubItems.Item(0).Text
            Dim dat As String = slvic.Item(i).SubItems.Item(1).Text
            Dim dname As String = rec & "_" & InvDateFormat(dat) & ".rds"
            My.Computer.FileSystem.CopyFile(path & "\SL\" & dname, tempath & "\" & dname)
        Next

        FastCreateZip(BackupDialog.FileName, tempath)
        My.Computer.FileSystem.DeleteDirectory(tempath, FileIO.DeleteDirectoryOption.DeleteAllContents)
        If Dir(BackupDialog.FileName) = "" Then StatusTip("Failed to backup the archives.")
        PBForm.Dispose()
    End Sub


    Private Sub DeleteBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBox.SelectedIndexChanged
        Call DelButtonInit()
    End Sub

    '==============================================SetContainer=====================================================================

    Private Sub SetSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecoverButton.Click
        Call RecoverSet()
        Me.ActiveControl = Me.SaveTextBox
    End Sub

    Private Sub SetValues()
        s(0) = FullScreenFalse.Checked.ToString
        s(1) = WinSizeCombo.SelectedIndex.ToString
        s(2) = ScreenProtectFalse.Checked.ToString
        s(3) = (15 * Phi(Frame15.Checked) + 30 * Phi(Frame30.Checked) + 60 * Phi(Frame60.Checked)).ToString
        s(4) = TexHighQuality.Checked.ToString
        s(5) = MovHighQuality.Checked.ToString
        s(6) = RMiniMap.Checked.ToString
        s(7) = LLog.Checked.ToString
        s(8) = KanaTrue.Checked.ToString
        s(9) = VoiceWaitTrue.Checked.ToString
        s(10) = SpeedTextBox.Text
        s(11) = SpeedTrack.Value.ToString
        s(12) = SpecialCheckBox.Checked.ToString
        s(13) = BGMTrack.Value.ToString
        s(14) = SETrack.Value.ToString
        s(15) = VoiceTrack.Value.ToString
        s(16) = ADVoiceTrack.Value.ToString

        For i As Integer = 0 To 13
            s(i + 17) = KeyCon(i).Text
        Next
    End Sub

    Private Sub RecoverSet()
        FullScreenFalse.Checked = CBool(s(0))
        WinSizeCombo.SelectedIndex = CInt(s(1))
        ScreenProtectFalse.Checked = CBool(s(2))
        Select Case CInt(s(3))
            Case 15
                Frame15.Checked = True
            Case 30
                Frame30.Checked = True
            Case Else
                Frame60.Checked = True
        End Select
        TexHighQuality.Checked = CBool(s(4))
        MovHighQuality.Checked = CBool(s(5))
        RMiniMap.Checked = CBool(s(6))
        LLog.Checked = CBool(s(7))
        KanaTrue.Checked = CBool(s(8))
        VoiceWaitTrue.Checked = CBool(s(9))
        SpeedTextBox.Text = s(10)
        SpeedTrack.Value = CInt(s(11))
        SpecialCheckBox.Checked = CBool(s(12))
        BGMTrack.Value = CInt(s(13))
        SETrack.Value = CInt(s(14))
        VoiceTrack.Value = CInt(s(15))
        ADVoiceTrack.Value = CInt(s(16))

        For i As Integer = 0 To 13
            KeyCon(i).Text = s(i + 17)
        Next
    End Sub

    Private Sub SetDefault()
        FullScreenFalse.Checked = True
        WinSizeCombo.SelectedIndex = 2
        ScreenProtectFalse.Checked = True
        Frame60.Checked = True
        TexHighQuality.Checked = True
        MovHighQuality.Checked = True

        RMiniMap.Checked = True
        LLog.Checked = True
        KanaTrue.Checked = True
        VoiceWaitTrue.Checked = True
        SpeedTextBox.Text = "1.5"
        SpeedTrack.Value = CInt(2.0 * Val(SpeedTextBox.Text))
        SpecialCheckBox.Checked = False

        BGMTrack.Value = 2
        SETrack.Value = 4
        VoiceTrack.Value = 8
        ADVoiceTrack.Value = 8

        Key0.Text = "Up"
        Key1.Text = "Right"
        Key2.Text = "Down"
        Key3.Text = "Left"
        Key4.Text = "S"
        Key5.Text = "Z"
        Key6.Text = "A"
        Key7.Text = "X"
        Key8.Text = "Q"
        Key9.Text = "D1"
        Key10.Text = "W"
        Key11.Text = "D2"
        Key12.Text = "Space"
        Key13.Text = "E"
    End Sub
    Private Sub Default_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultButton.Click
        Call SetDefault()
    End Sub

    Private Sub AppSet()
        Call GraphSave()
        Call PlaySave()
        Call SoundSave()
        Call KeySave()
        Call SetValues()
        RecoverButton.Enabled = False
    End Sub
    Private Sub Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppButton.Click
        Call AppSet()
    End Sub
    'Private Sub SetCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RecoverButton.Enabled Then
    '        Dim ans = MsgBox("Abandon all changes in settings?", vbYesNo)
    '        If ans = vbYes Then
    '            Call RecoverSet()
    '            ToPage(MainContainer)
    '        End If
    '    Else
    '        ToPage(MainContainer)
    '    End If
    'End Sub

    '------------------------------------------StartSettings(GraphGroup)-------------------------------------------------

    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenFalse.CheckedChanged, FullScreenTrue.CheckedChanged
        WinSizeCombo.Enabled = FullScreenFalse.Checked
    End Sub

    '------------------------------------------PlaySettings(GameSpeed)---------------------------------------------------

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SpeedTextBox.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = Chr(8) OrElse e.KeyChar = ".")
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedTextBox.TextChanged
        If SpeedTextBox.Text <> "" Then

            If Val(SpeedTextBox.Text) < 0.5 * Val(SpeedTrack.Minimum) Then
                SpeedTrack.Value = SpeedTrack.Minimum
            ElseIf Val(SpeedTextBox.Text) > 0.5 * Val(SpeedTrack.Maximum) Then
                SpeedTrack.Value = SpeedTrack.Maximum
            Else
                SpeedTrack.Value = CInt(2.0 * Val(SpeedTextBox.Text))
            End If

        Else
            SpeedTrack.Value = SpeedTrack.Minimum
        End If
    End Sub
    Private Sub TrackBar1_Scroll_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedTrack.Scroll
        SpeedTextBox.Text = (0.5 * Val(SpeedTrack.Value)).ToString
    End Sub

    '------------------------------------------KeySettings---------------------------------------------------------------

    Private Sub Key0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key0.KeyDown
        Key0.Text = StrToKeyStr(e)
        Key1.Focus()
        Key1.Select(0, 0)
    End Sub
    Private Sub Key1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key1.KeyDown
        Key1.Text = StrToKeyStr(e)
        Key2.Focus()
        Key2.Select(0, 0)
    End Sub
    Private Sub Key2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key2.KeyDown
        Key2.Text = StrToKeyStr(e)
        Key3.Focus()
        Key3.Select(0, 0)
    End Sub
    Private Sub Key3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key3.KeyDown
        Key3.Text = StrToKeyStr(e)
        Key4.Focus()
        Key4.Select(0, 0)
    End Sub
    Private Sub Key4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key4.KeyDown
        Key4.Text = StrToKeyStr(e)
        Key5.Focus()
        Key5.Select(0, 0)
    End Sub
    Private Sub Key5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key5.KeyDown
        Key5.Text = StrToKeyStr(e)
        Key6.Focus()
        Key6.Select(0, 0)
    End Sub
    Private Sub Key6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key6.KeyDown
        Key6.Text = StrToKeyStr(e)
        Key7.Focus()
        Key7.Select(0, 0)
    End Sub
    Private Sub Key7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key7.KeyDown
        Key7.Text = StrToKeyStr(e)
        Key8.Focus()
        Key8.Select(0, 0)
    End Sub
    Private Sub Key8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key8.KeyDown
        Key8.Text = StrToKeyStr(e)
        Key9.Focus()
        Key9.Select(0, 0)
    End Sub
    Private Sub Key9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key9.KeyDown
        Key9.Text = StrToKeyStr(e)
        Key10.Focus()
        Key10.Select(0, 0)
    End Sub
    Private Sub Key10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key10.KeyDown
        Key10.Text = StrToKeyStr(e)
        Key11.Focus()
        Key11.Select(0, 0)
    End Sub
    Private Sub Key11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key11.KeyDown
        Key11.Text = StrToKeyStr(e)
        Key12.Focus()
        Key12.Select(0, 0)
    End Sub
    Private Sub Key12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key12.KeyDown
        Key12.Text = StrToKeyStr(e)
        Key13.Focus()
        Key13.Select(0, 0)
    End Sub
    Private Sub Key13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Key13.KeyDown
        Key13.Text = StrToKeyStr(e)
    End Sub


    Private Sub StartSG()
        UpdateStartUI(False)
        BeginThread(SGThread, AddressOf Starting)
    End Sub


    Private Sub Starting()
        Call BeginGame()
        Me.Invoke(New StartDel(AddressOf UpdateStartUI), True)
        TimerHold(AutoStartOn)
    End Sub

    Private Sub UpdateStartUI(hwnd As Boolean)
        TableLayoutPanel_MainSub1_Sub.Enabled = hwnd
        'LoadButton.Enabled = hwnd
        'SaveButton.Enabled = hwnd
        'DeleteButton.Enabled = hwnd
        If hwnd Then
            'Me.ActiveControl = Me.SGButton
        Else
            Me.ActiveControl = Me.SaveTextBox
        End If
    End Sub

    Private Sub ExportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportButton.Click
        Dim rec As String = LoadBox.SelectedItems.Item(0).SubItems.Item(0).Text
        Dim dat As String = LoadBox.SelectedItems.Item(0).SubItems.Item(1).Text
        Dim dname As String = rec & "_" & InvDateFormat(dat)
        ExportDialog.Filter = "rds files (*.rds)|*.rds"
        ExportDialog.FileName = dname & ".rds"
        ExportDialog.ShowDialog()
    End Sub

    Private Sub ExportDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ExportDialog.FileOk
ExportRetry:
        Dim rec As String = LoadBox.SelectedItems.Item(0).SubItems.Item(0).Text
        Dim dat As String = LoadBox.SelectedItems.Item(0).SubItems.Item(1).Text
        Dim dname As String = rec & "_" & InvDateFormat(dat)
        If Dir(ExportDialog.FileName) <> "" Then My.Computer.FileSystem.DeleteFile(ExportDialog.FileName)
        My.Computer.FileSystem.CopyFile(path & "\SL\" & dname & ".rds", ExportDialog.FileName)
        If Dir(ExportDialog.FileName) = "" Then
            Dim res As MsgBoxResult = MsgBox("Failed to export the archive.", MsgBoxStyle.RetryCancel)
            If res = MsgBoxResult.Retry Then GoTo ExportRetry
        End If
    End Sub

    Private Sub ImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportButton.Click
        ImportDialog.Filter = "rds files (*.rds)|*.rds"
        ImportDialog.ShowDialog()
    End Sub

    Private Sub ImportDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ImportDialog.FileOk
        Dim rns As String() = ImportDialog.FileNames
        Dim PBForm As PGB = New PGB(rns.Count)

        For i As Integer = 0 To rns.Count - 1
            PBForm.UpdValue(i)
ImportRetry:
            Dim rn As String = rns(i)
            Dim dat As String = rn.Substring(rn.Length - 23, 19)
            Dim fn As String = System.IO.Path.GetFileName(rn)

            If Not Microsoft.VisualBasic.IsDate(DateFormat(dat)) Then
                Dim objFileInfo As FileInfo = New FileInfo(rn)
                fn = fn.Substring(0, fn.Length - 4) & Format(objFileInfo.CreationTime, "_yyyy-MM-dd_HH-mm-ss") & ".rds"
            End If

            Do Until Not ExistFile(path & "\SL\" & fn)
                fn = fn.Substring(0, fn.Length - 23) & Format(Date.Now, "yyyy-MM-dd_HH-mm-ss") & ".rds"
            Loop

            My.Computer.FileSystem.CopyFile(rn, path & "\SL\" & fn)
            If Not ExistFile(path & "\SL\" & fn) Then
                Dim res As MsgBoxResult = MsgBox("Failed to import the archive '" & fn & "'.", MsgBoxStyle.AbortRetryIgnore)
                Select Case res
                    Case vbAbort
                        Exit For
                    Case vbRetry
                        GoTo ImportRetry
                    Case vbIgnore
                        Continue For
                End Select
            End If
        Next

        PBForm.Dispose()
        UpdateList(LoadBox)
    End Sub

    Private Sub RadioNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioNormal.CheckedChanged, RadioGenius.CheckedChanged
        GeniusOn = RadioGenius.Checked
    End Sub

    Private Sub Settings_Changed(sender As Object, e As EventArgs) Handles FullScreenFalse.CheckedChanged, FullScreenTrue.CheckedChanged, WinSizeCombo.SelectedIndexChanged, ScreenProtectTrue.CheckedChanged, ScreenProtectFalse.CheckedChanged, Frame15.CheckedChanged, Frame30.CheckedChanged, Frame60.CheckedChanged, TexLowQuality.CheckedChanged, TexHighQuality.CheckedChanged, MovLowQuality.CheckedChanged, MovHighQuality.CheckedChanged, LMiniMap.CheckedChanged, CMiniMap.CheckedChanged, RMiniMap.CheckedChanged, LLog.CheckedChanged, CLog.CheckedChanged, RLog.CheckedChanged, KanaTrue.CheckedChanged, KanaFalse.CheckedChanged, VoiceWaitTrue.CheckedChanged, VoiceWaitFalse.CheckedChanged, SpeedTrack.Scroll, SpeedTrack.ValueChanged, SpeedTextBox.TextChanged, SpecialCheckBox.CheckedChanged, BGMTrack.Scroll, SETrack.Scroll, VoiceTrack.Scroll, ADVoiceTrack.Scroll, BGMTrack.ValueChanged, SETrack.ValueChanged, VoiceTrack.ValueChanged, ADVoiceTrack.ValueChanged, Key0.TextChanged, Key1.TextChanged, Key2.TextChanged, Key3.TextChanged, Key4.TextChanged, Key5.TextChanged, Key6.TextChanged, Key7.TextChanged, Key8.TextChanged, Key9.TextChanged, Key10.TextChanged, Key11.TextChanged, Key12.TextChanged, Key13.TextChanged
        RecoverButton.Enabled = Not (
                s(0) = FullScreenFalse.Checked.ToString And
                s(1) = WinSizeCombo.SelectedIndex.ToString And
                s(2) = ScreenProtectFalse.Checked.ToString And
                s(3) = (15 * Phi(Frame15.Checked) + 30 * Phi(Frame30.Checked) + 60 * Phi(Frame60.Checked)).ToString And
                s(4) = TexHighQuality.Checked.ToString And
                s(5) = MovHighQuality.Checked.ToString And
                s(6) = RMiniMap.Checked.ToString And
                s(7) = LLog.Checked.ToString And
                s(8) = KanaTrue.Checked.ToString And
                s(9) = VoiceWaitTrue.Checked.ToString And
                s(10) = SpeedTextBox.Text And
                s(11) = SpeedTrack.Value.ToString And
                s(12) = SpecialCheckBox.Checked.ToString And
                s(13) = BGMTrack.Value.ToString And
                s(14) = SETrack.Value.ToString And
                s(15) = VoiceTrack.Value.ToString And
                s(16) = ADVoiceTrack.Value.ToString And
                s(17) = Key0.Text And
                s(18) = Key1.Text And
                s(19) = Key2.Text And
                s(20) = Key3.Text And
                s(21) = Key4.Text And
                s(22) = Key5.Text And
                s(23) = Key6.Text And
                s(24) = Key7.Text And
                s(25) = Key8.Text And
                s(26) = Key9.Text And
                s(27) = Key10.Text And
                s(28) = Key11.Text And
                s(29) = Key12.Text And
                s(30) = Key13.Text
                )
    End Sub

    Private Sub MazesCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MazesCombo.SelectedIndexChanged
        Call UpdWeekCombo()
        Call UpdStageNum()
        Call UpdReturNum()
    End Sub

    Private Sub WeekCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WeekCombo.SelectedIndexChanged
        Call UpdStageNum()
        Call UpdReturNum()
    End Sub

    Private Sub StageNum_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StageNum.TextChanged
        Call UpdStageNum()
        Call UpdReturNum()
    End Sub
    Private Sub ReturnNum_ValueChanged(sender As Object, e As EventArgs) Handles ReturnNum.TextChanged
        Call UpdReturNum()
    End Sub

    Private Sub UpdWeekCombo()
        MazeName = MazesCombo.SelectedItem.ToString & WeekCombo.Text
        With WeekCombo
            .Enabled = WEnabled(MazesCombo.Text)
            .SelectedIndex = CInt(Not .Enabled)
        End With
    End Sub
    Private Sub UpdStageNum()
        MazeName = MazesCombo.SelectedItem.ToString & WeekCombo.Text
        With StageNum
            .Maximum = CDec(TopLimit(MazeName))
            .Minimum = SMin(MazesCombo.Text, WeekCombo.SelectedIndex)
            AdjNumRange(StageNum)
            .Increment = 1
        End With
    End Sub

    Private Sub UpdReturNum()
        With ReturnNum
            .Enabled = REnabled(MazesCombo.Text)
            .Maximum = StageNum.Maximum
            .Minimum = RMin(MazesCombo.Text, StageNum.Value, WeekCombo.SelectedIndex)
            AdjNumRange(ReturnNum)
            .Value = RValue(MazesCombo.Text, ReturnNum.Value, WeekCombo.SelectedIndex)
            .Increment = RStep(MazesCombo.Text, .Value)
        End With
    End Sub


    Private Sub Refresh_Enabled()

        CheatOn = (
            HPCheck.Checked Or
            CashCheck.Checked Or
            StrengthCheck.Checked Or
            SatietyCheck.Checked Or
            ExpCheck.Checked Or
            UnlimitedDanmakuCheck.Checked
            )

        CheaTimer.Enabled = CheatOn
        RefreshBtn.Enabled = Not (
            HPCheck.Checked And
            CashCheck.Checked And
            StrengthCheck.Checked And
            SatietyCheck.Checked And
            ExpCheck.Checked And
            UnlimitedDanmakuCheck.Checked
            )

    End Sub

    Private Sub HPUpperCheck_CheckedChanged(sender As Object, e As EventArgs) Handles HPCheck.CheckedChanged

        HPNum.Enabled = Not HPCheck.Checked
        HPUpperNum.Enabled = Not HPCheck.Checked
        HPBtn.Enabled = Not HPCheck.Checked
        MHPBtn.Enabled = Not HPCheck.Checked
        RHPBtn.Enabled = Not HPCheck.Checked

        If HPCheck.Checked Then changeValue(0)

        Call Refresh_Enabled()

    End Sub

    Private Sub CashCheck_CheckedChanged(sender As Object, e As EventArgs) Handles CashCheck.CheckedChanged
        CashNum.Enabled = Not CashCheck.Checked
        CashBtn.Enabled = Not CashCheck.Checked
        MCashBtn.Enabled = Not CashCheck.Checked
        RCashBtn.Enabled = Not CashCheck.Checked

        If CashCheck.Checked Then changeValue(1)
        Call Refresh_Enabled()
    End Sub

    Private Sub StrengthUpperCheck_CheckedChanged(sender As Object, e As EventArgs) Handles StrengthCheck.CheckedChanged

        StrengthNum.Enabled = Not StrengthCheck.Checked
        StrengthUpperNum.Enabled = Not StrengthCheck.Checked
        StrengthBtn.Enabled = Not StrengthCheck.Checked
        MStrengthBtn.Enabled = Not StrengthCheck.Checked
        RStrengthBtn.Enabled = Not StrengthCheck.Checked

        If StrengthCheck.Checked Then changeValue(2)

        Call Refresh_Enabled()

    End Sub

    Private Sub SatietyUpperCheck_CheckedChanged(sender As Object, e As EventArgs) Handles SatietyCheck.CheckedChanged

        SatietyNum.Enabled = Not SatietyCheck.Checked
        SatietyUpperNum.Enabled = Not SatietyCheck.Checked
        SatietyBtn.Enabled = Not SatietyCheck.Checked
        MSatietyBtn.Enabled = Not SatietyCheck.Checked
        RSatietyBtn.Enabled = Not SatietyCheck.Checked

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

    Private Sub MaxDanmakuNum()
        If Not UnlimitedDanmakuCheck.Checked Then
            DanmakuNum.Value = DanmakuNum.Maximum
        End If
    End Sub

    Private Sub LockAllBtn_Click(sender As Object, e As EventArgs) Handles MaxBtn.Click
        MaxHP()
        MaxCash()
        MaxStrength()
        MaxSatiety()
        MaxExp()
        MaxDanmakuNum()
    End Sub

    Private Sub UnlockAll()
        HPCheck.Checked = False
        CashCheck.Checked = False
        StrengthCheck.Checked = False
        SatietyCheck.Checked = False
        ExpCheck.Checked = False
        UnlimitedDanmakuCheck.Checked = False
    End Sub

    Private Sub UnlockAllBtn_Click(sender As Object, e As EventArgs) Handles UnlockBtn.Click
        UnlockAll()
        'If Not HPCheck.Checked Then
        '    HPUpperNum.Value = 15
        '    HPNum.Value = 15
        'End If

        'If Not CashCheck.Checked Then
        '    CashNum.Value = 0
        'End If

        'If Not StrengthCheck.Checked Then
        '    StrengthUpperNum.Value = 8
        '    StrengthNum.Value = 8
        'End If

        'If Not SatietyCheck.Checked Then
        '    SatietyUpperNum.Value = 100
        '    SatietyNum.Value = 100
        'End If

        'If Not ExpCheck.Checked Then
        '    ExpNum.Value = 1
        'End If
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

    Private Sub StageValChanged(sender As Object, e As EventArgs) Handles StageVal.TextChanged, DanmakuNum.TextChanged
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
        If ExistProcess("MiracleSuperParty") Then
            MaxBtn.PerformClick()
            HPCheck.Checked = True
            CashCheck.Checked = True
            StrengthCheck.Checked = True
            SatietyCheck.Checked = True
            ExpCheck.Checked = True
            UnlimitedDanmakuCheck.Checked = True
        Else
            StatusTip("Game has not been started.")
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
        If Not ExpCheck.Checked Then ExpNum.Value = CDec(c8)
    End Sub

    Private Sub RefreshStageAndDanmakuNum(c9 As Integer, c10 As Integer)
        StageVal.Value = CDec(c9)
        If Not UnlimitedDanmakuCheck.Checked Then DanmakuNum.Value = CDec(c10)
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
            RefreshStageAndDanmakuNum(c(9), c(10))
        End If

        If err <> "" Then
            StatusTip(err)
        Else
            StatusTip("Refreshing success!")
        End If
    End Sub

    Private Sub RefreshBtn_Click(sender As Object, e As EventArgs) Handles RefreshBtn.Click
        RefreshAll()
    End Sub

    Private Sub LvCheck_CheckedChanged(sender As Object, e As EventArgs) Handles ExpCheck.CheckedChanged
        ExpNum.Enabled = Not ExpCheck.Checked
        ExpBtn.Enabled = Not ExpCheck.Checked
        MExpBtn.Enabled = Not ExpCheck.Checked

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

    Private Sub RestartBtn_Click(sender As Object, e As EventArgs) Handles RestartBtn.Click
        If ExistProcess("MiracleSuperParty") Then
            Call BeginRestart()
        Else
            StatusTip("Game has not been started.")
        End If
    End Sub

    Private Sub RStageBtn_Click(sender As Object, e As EventArgs) Handles RStageBtn.Click
        Dim c(0 To LastCheatId) As UInteger
        Dim err As String = ""
        If inGame(LastCheatId + 1, c, err) Then
            RefreshStageAndDanmakuNum(c(9), c(10))
        End If
        If err <> "" Then StatusTip(err)
    End Sub

    Private Sub StageBtn_Click(sender As Object, e As EventArgs) Handles StageBtn.Click
        changeValue(5)
    End Sub

    Private Sub MaxDanmakuBtn_Click(sender As Object, e As EventArgs) Handles MaxDanmakuBtn.Click
        MaxDanmakuNum()
    End Sub

    Private Sub DanmakuNum_ValueChanged(sender As Object, e As EventArgs) Handles DanmakuNum.ValueChanged
        AdjNumRange(DanmakuNum)
    End Sub

    Private Sub UnlimitedDanmakuCheck_CheckedChanged(sender As Object, e As EventArgs) Handles UnlimitedDanmakuCheck.CheckedChanged
        DanmakuNum.Enabled = Not UnlimitedDanmakuCheck.Checked
        StageBtn.Enabled = Not UnlimitedDanmakuCheck.Checked
        MaxDanmakuBtn.Enabled = Not UnlimitedDanmakuCheck.Checked

        If UnlimitedDanmakuCheck.Checked Then changeValue(5)
        Call Refresh_Enabled()
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
                    writeDanmakuNum(c(0), c(1), CDec(DanmakuNum.Value))

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
