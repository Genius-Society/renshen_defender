<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TabControl_Main = New System.Windows.Forms.TabControl()
        Me.TabPage_Main = New System.Windows.Forms.TabPage()
        Me.MainContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel_MainSub1_Sub = New System.Windows.Forms.TableLayoutPanel()
        Me.SetBtn = New System.Windows.Forms.Button()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.RestartBtn = New System.Windows.Forms.Button()
        Me.EndBtn = New System.Windows.Forms.Button()
        Me.TabPage_Archive = New System.Windows.Forms.TabPage()
        Me.SaveContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ResumeBtn = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.LoadBtn = New System.Windows.Forms.Button()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.SaveListPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.SaveTextBox = New System.Windows.Forms.TextBox()
        Me.SaveBox = New System.Windows.Forms.ListView()
        Me.TabPage_Cheat = New System.Windows.Forms.TabPage()
        Me.CheatContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel31 = New System.Windows.Forms.TableLayoutPanel()
        Me.LockBtn = New System.Windows.Forms.Button()
        Me.RefreshBtn = New System.Windows.Forms.Button()
        Me.UnlockBtn = New System.Windows.Forms.Button()
        Me.MaxBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel32 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel38 = New System.Windows.Forms.TableLayoutPanel()
        Me.MExpBtn = New System.Windows.Forms.Button()
        Me.RExpBtn = New System.Windows.Forms.Button()
        Me.ExpBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel33 = New System.Windows.Forms.TableLayoutPanel()
        Me.LvNum = New System.Windows.Forms.NumericUpDown()
        Me.ExpCheck = New System.Windows.Forms.CheckBox()
        Me.ExpNum = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel25 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel26 = New System.Windows.Forms.TableLayoutPanel()
        Me.HPNum = New System.Windows.Forms.NumericUpDown()
        Me.HPUpperNum = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.HPCheck = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel35 = New System.Windows.Forms.TableLayoutPanel()
        Me.MHPBtn = New System.Windows.Forms.Button()
        Me.RHPBtn = New System.Windows.Forms.Button()
        Me.HPBtn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel34 = New System.Windows.Forms.TableLayoutPanel()
        Me.MCashBtn = New System.Windows.Forms.Button()
        Me.RCashBtn = New System.Windows.Forms.Button()
        Me.CashBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel24 = New System.Windows.Forms.TableLayoutPanel()
        Me.CashNum = New System.Windows.Forms.NumericUpDown()
        Me.CashCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel27 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel37 = New System.Windows.Forms.TableLayoutPanel()
        Me.MStrengthBtn = New System.Windows.Forms.Button()
        Me.RStrengthBtn = New System.Windows.Forms.Button()
        Me.StrengthBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel28 = New System.Windows.Forms.TableLayoutPanel()
        Me.StrengthNum = New System.Windows.Forms.NumericUpDown()
        Me.StrengthUpperNum = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StrengthCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel29 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel36 = New System.Windows.Forms.TableLayoutPanel()
        Me.MSatietyBtn = New System.Windows.Forms.Button()
        Me.RSatietyBtn = New System.Windows.Forms.Button()
        Me.SatietyBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel30 = New System.Windows.Forms.TableLayoutPanel()
        Me.SatietyNum = New System.Windows.Forms.NumericUpDown()
        Me.SatietyUpperNum = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SatietyCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel39 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel40 = New System.Windows.Forms.TableLayoutPanel()
        Me.RStageBtn = New System.Windows.Forms.Button()
        Me.StageBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel41 = New System.Windows.Forms.TableLayoutPanel()
        Me.StageVal = New System.Windows.Forms.NumericUpDown()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MDanmakuBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DanmakuNum = New System.Windows.Forms.NumericUpDown()
        Me.DanmakuCheck = New System.Windows.Forms.CheckBox()
        Me.TabControl_Main.SuspendLayout()
        Me.TabPage_Main.SuspendLayout()
        Me.MainContainer.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel_MainSub1_Sub.SuspendLayout()
        Me.TabPage_Archive.SuspendLayout()
        Me.SaveContainer.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SaveListPanel.SuspendLayout()
        Me.TabPage_Cheat.SuspendLayout()
        Me.CheatContainer.SuspendLayout()
        Me.TableLayoutPanel31.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TableLayoutPanel32.SuspendLayout()
        Me.TableLayoutPanel38.SuspendLayout()
        Me.TableLayoutPanel33.SuspendLayout()
        CType(Me.LvNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel25.SuspendLayout()
        Me.TableLayoutPanel26.SuspendLayout()
        CType(Me.HPNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HPUpperNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel35.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel34.SuspendLayout()
        Me.TableLayoutPanel24.SuspendLayout()
        CType(Me.CashNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel27.SuspendLayout()
        Me.TableLayoutPanel37.SuspendLayout()
        Me.TableLayoutPanel28.SuspendLayout()
        CType(Me.StrengthNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StrengthUpperNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel29.SuspendLayout()
        Me.TableLayoutPanel36.SuspendLayout()
        Me.TableLayoutPanel30.SuspendLayout()
        CType(Me.SatietyNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SatietyUpperNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.TableLayoutPanel39.SuspendLayout()
        Me.TableLayoutPanel40.SuspendLayout()
        Me.TableLayoutPanel41.SuspendLayout()
        CType(Me.StageVal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        CType(Me.DanmakuNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl_Main
        '
        Me.TabControl_Main.Controls.Add(Me.TabPage_Main)
        Me.TabControl_Main.Controls.Add(Me.TabPage_Archive)
        Me.TabControl_Main.Controls.Add(Me.TabPage_Cheat)
        Me.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl_Main.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.TabControl_Main.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl_Main.Name = "TabControl_Main"
        Me.TabControl_Main.SelectedIndex = 0
        Me.TabControl_Main.Size = New System.Drawing.Size(939, 456)
        Me.TabControl_Main.TabIndex = 0
        '
        'TabPage_Main
        '
        Me.TabPage_Main.Controls.Add(Me.MainContainer)
        Me.TabPage_Main.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage_Main.Name = "TabPage_Main"
        Me.TabPage_Main.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage_Main.Size = New System.Drawing.Size(931, 423)
        Me.TabPage_Main.TabIndex = 0
        Me.TabPage_Main.Text = "Main Page"
        Me.TabPage_Main.UseVisualStyleBackColor = True
        '
        'MainContainer
        '
        Me.MainContainer.ColumnCount = 2
        Me.MainContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.MainContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.MainContainer.Controls.Add(Me.PictureBox1, 0, 0)
        Me.MainContainer.Controls.Add(Me.TableLayoutPanel_MainSub1_Sub, 1, 0)
        Me.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainContainer.Location = New System.Drawing.Point(4, 4)
        Me.MainContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.MainContainer.Name = "MainContainer"
        Me.MainContainer.RowCount = 1
        Me.MainContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainContainer.Size = New System.Drawing.Size(923, 415)
        Me.MainContainer.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.SL4.My.Resources.Resources.cover
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(684, 407)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TableLayoutPanel_MainSub1_Sub
        '
        Me.TableLayoutPanel_MainSub1_Sub.ColumnCount = 1
        Me.TableLayoutPanel_MainSub1_Sub.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_MainSub1_Sub.Controls.Add(Me.SetBtn, 0, 3)
        Me.TableLayoutPanel_MainSub1_Sub.Controls.Add(Me.StartBtn, 0, 0)
        Me.TableLayoutPanel_MainSub1_Sub.Controls.Add(Me.RestartBtn, 0, 2)
        Me.TableLayoutPanel_MainSub1_Sub.Controls.Add(Me.EndBtn, 0, 1)
        Me.TableLayoutPanel_MainSub1_Sub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel_MainSub1_Sub.Location = New System.Drawing.Point(696, 4)
        Me.TableLayoutPanel_MainSub1_Sub.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel_MainSub1_Sub.Name = "TableLayoutPanel_MainSub1_Sub"
        Me.TableLayoutPanel_MainSub1_Sub.RowCount = 4
        Me.TableLayoutPanel_MainSub1_Sub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_MainSub1_Sub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_MainSub1_Sub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_MainSub1_Sub.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel_MainSub1_Sub.Size = New System.Drawing.Size(223, 407)
        Me.TableLayoutPanel_MainSub1_Sub.TabIndex = 1
        '
        'SetBtn
        '
        Me.SetBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SetBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.SetBtn.ForeColor = System.Drawing.Color.Black
        Me.SetBtn.Location = New System.Drawing.Point(4, 307)
        Me.SetBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.SetBtn.Name = "SetBtn"
        Me.SetBtn.Size = New System.Drawing.Size(215, 96)
        Me.SetBtn.TabIndex = 2
        Me.SetBtn.Text = "Settings"
        Me.SetBtn.UseVisualStyleBackColor = True
        '
        'StartBtn
        '
        Me.StartBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StartBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.StartBtn.ForeColor = System.Drawing.Color.Black
        Me.StartBtn.Location = New System.Drawing.Point(4, 4)
        Me.StartBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(215, 93)
        Me.StartBtn.TabIndex = 0
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'RestartBtn
        '
        Me.RestartBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RestartBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.RestartBtn.ForeColor = System.Drawing.Color.Black
        Me.RestartBtn.Location = New System.Drawing.Point(4, 206)
        Me.RestartBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RestartBtn.Name = "RestartBtn"
        Me.RestartBtn.Size = New System.Drawing.Size(215, 93)
        Me.RestartBtn.TabIndex = 1
        Me.RestartBtn.Text = "Restart"
        Me.RestartBtn.UseVisualStyleBackColor = True
        '
        'EndBtn
        '
        Me.EndBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EndBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.EndBtn.ForeColor = System.Drawing.Color.Black
        Me.EndBtn.Location = New System.Drawing.Point(4, 105)
        Me.EndBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EndBtn.Name = "EndBtn"
        Me.EndBtn.Size = New System.Drawing.Size(215, 93)
        Me.EndBtn.TabIndex = 1
        Me.EndBtn.Text = "End"
        Me.EndBtn.UseVisualStyleBackColor = True
        '
        'TabPage_Archive
        '
        Me.TabPage_Archive.Controls.Add(Me.SaveContainer)
        Me.TabPage_Archive.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Archive.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage_Archive.Name = "TabPage_Archive"
        Me.TabPage_Archive.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage_Archive.Size = New System.Drawing.Size(931, 423)
        Me.TabPage_Archive.TabIndex = 2
        Me.TabPage_Archive.Text = "Archives"
        Me.TabPage_Archive.UseVisualStyleBackColor = True
        '
        'SaveContainer
        '
        Me.SaveContainer.ColumnCount = 2
        Me.SaveContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.SaveContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.SaveContainer.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.SaveContainer.Controls.Add(Me.SaveListPanel, 0, 0)
        Me.SaveContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveContainer.Location = New System.Drawing.Point(4, 4)
        Me.SaveContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveContainer.Name = "SaveContainer"
        Me.SaveContainer.RowCount = 1
        Me.SaveContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SaveContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 415.0!))
        Me.SaveContainer.Size = New System.Drawing.Size(923, 415)
        Me.SaveContainer.TabIndex = 6
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ResumeBtn, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.SaveBtn, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LoadBtn, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.DeleteBtn, 0, 3)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(693, 4)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(229, 407)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'ResumeBtn
        '
        Me.ResumeBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResumeBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ResumeBtn.Location = New System.Drawing.Point(1, 105)
        Me.ResumeBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.ResumeBtn.Name = "ResumeBtn"
        Me.ResumeBtn.Size = New System.Drawing.Size(227, 93)
        Me.ResumeBtn.TabIndex = 3
        Me.ResumeBtn.Text = "Resume"
        Me.ResumeBtn.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(1, 4)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(227, 93)
        Me.SaveBtn.TabIndex = 2
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'LoadBtn
        '
        Me.LoadBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LoadBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LoadBtn.Location = New System.Drawing.Point(1, 206)
        Me.LoadBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.LoadBtn.Name = "LoadBtn"
        Me.LoadBtn.Size = New System.Drawing.Size(227, 93)
        Me.LoadBtn.TabIndex = 3
        Me.LoadBtn.Text = "Load"
        Me.LoadBtn.UseVisualStyleBackColor = True
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeleteBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DeleteBtn.Location = New System.Drawing.Point(1, 307)
        Me.DeleteBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(227, 96)
        Me.DeleteBtn.TabIndex = 3
        Me.DeleteBtn.Text = "Delete"
        Me.DeleteBtn.UseVisualStyleBackColor = True
        '
        'SaveListPanel
        '
        Me.SaveListPanel.ColumnCount = 1
        Me.SaveListPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SaveListPanel.Controls.Add(Me.SaveTextBox, 0, 1)
        Me.SaveListPanel.Controls.Add(Me.SaveBox, 0, 0)
        Me.SaveListPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveListPanel.Location = New System.Drawing.Point(4, 4)
        Me.SaveListPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveListPanel.Name = "SaveListPanel"
        Me.SaveListPanel.RowCount = 2
        Me.SaveListPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666!))
        Me.SaveListPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.SaveListPanel.Size = New System.Drawing.Size(684, 407)
        Me.SaveListPanel.TabIndex = 0
        '
        'SaveTextBox
        '
        Me.SaveTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveTextBox.Location = New System.Drawing.Point(1, 377)
        Me.SaveTextBox.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.SaveTextBox.Name = "SaveTextBox"
        Me.SaveTextBox.Size = New System.Drawing.Size(682, 27)
        Me.SaveTextBox.TabIndex = 1
        '
        'SaveBox
        '
        Me.SaveBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.SaveBox.Location = New System.Drawing.Point(4, 4)
        Me.SaveBox.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveBox.Name = "SaveBox"
        Me.SaveBox.Size = New System.Drawing.Size(676, 365)
        Me.SaveBox.TabIndex = 0
        Me.SaveBox.UseCompatibleStateImageBehavior = False
        '
        'TabPage_Cheat
        '
        Me.TabPage_Cheat.Controls.Add(Me.CheatContainer)
        Me.TabPage_Cheat.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Cheat.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage_Cheat.Name = "TabPage_Cheat"
        Me.TabPage_Cheat.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage_Cheat.Size = New System.Drawing.Size(931, 423)
        Me.TabPage_Cheat.TabIndex = 1
        Me.TabPage_Cheat.Text = "Cheat Mode"
        Me.TabPage_Cheat.UseVisualStyleBackColor = True
        '
        'CheatContainer
        '
        Me.CheatContainer.ColumnCount = 2
        Me.CheatContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.CheatContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.CheatContainer.Controls.Add(Me.TableLayoutPanel31, 0, 0)
        Me.CheatContainer.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.CheatContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheatContainer.Location = New System.Drawing.Point(4, 4)
        Me.CheatContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.CheatContainer.Name = "CheatContainer"
        Me.CheatContainer.RowCount = 1
        Me.CheatContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CheatContainer.Size = New System.Drawing.Size(923, 415)
        Me.CheatContainer.TabIndex = 11
        '
        'TableLayoutPanel31
        '
        Me.TableLayoutPanel31.ColumnCount = 1
        Me.TableLayoutPanel31.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel31.Controls.Add(Me.LockBtn, 0, 3)
        Me.TableLayoutPanel31.Controls.Add(Me.RefreshBtn, 0, 0)
        Me.TableLayoutPanel31.Controls.Add(Me.UnlockBtn, 0, 2)
        Me.TableLayoutPanel31.Controls.Add(Me.MaxBtn, 0, 1)
        Me.TableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel31.Location = New System.Drawing.Point(693, 4)
        Me.TableLayoutPanel31.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.TableLayoutPanel31.Name = "TableLayoutPanel31"
        Me.TableLayoutPanel31.RowCount = 4
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel31.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel31.Size = New System.Drawing.Size(229, 407)
        Me.TableLayoutPanel31.TabIndex = 3
        '
        'LockBtn
        '
        Me.LockBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LockBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.LockBtn.Location = New System.Drawing.Point(1, 307)
        Me.LockBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.LockBtn.Name = "LockBtn"
        Me.LockBtn.Size = New System.Drawing.Size(227, 96)
        Me.LockBtn.TabIndex = 4
        Me.LockBtn.Text = "Invincible"
        Me.LockBtn.UseVisualStyleBackColor = True
        '
        'RefreshBtn
        '
        Me.RefreshBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RefreshBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RefreshBtn.Location = New System.Drawing.Point(1, 4)
        Me.RefreshBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.RefreshBtn.Name = "RefreshBtn"
        Me.RefreshBtn.Size = New System.Drawing.Size(227, 93)
        Me.RefreshBtn.TabIndex = 1
        Me.RefreshBtn.Text = "Refresh"
        Me.RefreshBtn.UseVisualStyleBackColor = True
        '
        'UnlockBtn
        '
        Me.UnlockBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnlockBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.UnlockBtn.Location = New System.Drawing.Point(1, 206)
        Me.UnlockBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.UnlockBtn.Name = "UnlockBtn"
        Me.UnlockBtn.Size = New System.Drawing.Size(227, 93)
        Me.UnlockBtn.TabIndex = 3
        Me.UnlockBtn.Text = "Unlock"
        Me.UnlockBtn.UseVisualStyleBackColor = True
        '
        'MaxBtn
        '
        Me.MaxBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MaxBtn.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.MaxBtn.Location = New System.Drawing.Point(1, 105)
        Me.MaxBtn.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.MaxBtn.Name = "MaxBtn"
        Me.MaxBtn.Size = New System.Drawing.Size(227, 93)
        Me.MaxBtn.TabIndex = 2
        Me.MaxBtn.Text = "Maximize"
        Me.MaxBtn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox6, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(684, 407)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TableLayoutPanel32)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(4, 274)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(334, 129)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Lv / Exp"
        '
        'TableLayoutPanel32
        '
        Me.TableLayoutPanel32.ColumnCount = 1
        Me.TableLayoutPanel32.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel32.Controls.Add(Me.TableLayoutPanel38, 0, 1)
        Me.TableLayoutPanel32.Controls.Add(Me.TableLayoutPanel33, 0, 0)
        Me.TableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel32.Location = New System.Drawing.Point(4, 24)
        Me.TableLayoutPanel32.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel32.Name = "TableLayoutPanel32"
        Me.TableLayoutPanel32.RowCount = 2
        Me.TableLayoutPanel32.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel32.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel32.Size = New System.Drawing.Size(326, 101)
        Me.TableLayoutPanel32.TabIndex = 0
        '
        'TableLayoutPanel38
        '
        Me.TableLayoutPanel38.ColumnCount = 3
        Me.TableLayoutPanel38.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel38.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel38.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel38.Controls.Add(Me.MExpBtn, 0, 0)
        Me.TableLayoutPanel38.Controls.Add(Me.RExpBtn, 0, 0)
        Me.TableLayoutPanel38.Controls.Add(Me.ExpBtn, 2, 0)
        Me.TableLayoutPanel38.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel38.Location = New System.Drawing.Point(4, 54)
        Me.TableLayoutPanel38.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel38.Name = "TableLayoutPanel38"
        Me.TableLayoutPanel38.RowCount = 1
        Me.TableLayoutPanel38.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel38.Size = New System.Drawing.Size(318, 43)
        Me.TableLayoutPanel38.TabIndex = 3
        '
        'MExpBtn
        '
        Me.MExpBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MExpBtn.Location = New System.Drawing.Point(110, 4)
        Me.MExpBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MExpBtn.Name = "MExpBtn"
        Me.MExpBtn.Size = New System.Drawing.Size(98, 35)
        Me.MExpBtn.TabIndex = 15
        Me.MExpBtn.Text = "Max"
        Me.MExpBtn.UseVisualStyleBackColor = True
        '
        'RExpBtn
        '
        Me.RExpBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RExpBtn.Location = New System.Drawing.Point(4, 4)
        Me.RExpBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RExpBtn.Name = "RExpBtn"
        Me.RExpBtn.Size = New System.Drawing.Size(98, 35)
        Me.RExpBtn.TabIndex = 13
        Me.RExpBtn.Text = "Refresh"
        Me.RExpBtn.UseVisualStyleBackColor = True
        '
        'ExpBtn
        '
        Me.ExpBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpBtn.Location = New System.Drawing.Point(216, 4)
        Me.ExpBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.ExpBtn.Name = "ExpBtn"
        Me.ExpBtn.Size = New System.Drawing.Size(98, 35)
        Me.ExpBtn.TabIndex = 11
        Me.ExpBtn.Text = "Confirm"
        Me.ExpBtn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel33
        '
        Me.TableLayoutPanel33.ColumnCount = 4
        Me.TableLayoutPanel33.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel33.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel33.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel33.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel33.Controls.Add(Me.LvNum, 0, 0)
        Me.TableLayoutPanel33.Controls.Add(Me.ExpCheck, 3, 0)
        Me.TableLayoutPanel33.Controls.Add(Me.ExpNum, 2, 0)
        Me.TableLayoutPanel33.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel33.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel33.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel33.Name = "TableLayoutPanel33"
        Me.TableLayoutPanel33.RowCount = 1
        Me.TableLayoutPanel33.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel33.Size = New System.Drawing.Size(318, 42)
        Me.TableLayoutPanel33.TabIndex = 0
        '
        'LvNum
        '
        Me.LvNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.LvNum.Location = New System.Drawing.Point(4, 7)
        Me.LvNum.Margin = New System.Windows.Forms.Padding(4)
        Me.LvNum.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.LvNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LvNum.Name = "LvNum"
        Me.LvNum.ReadOnly = True
        Me.LvNum.Size = New System.Drawing.Size(93, 27)
        Me.LvNum.TabIndex = 18
        Me.LvNum.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ExpCheck
        '
        Me.ExpCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ExpCheck.AutoSize = True
        Me.ExpCheck.Location = New System.Drawing.Point(238, 9)
        Me.ExpCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.ExpCheck.Name = "ExpCheck"
        Me.ExpCheck.Size = New System.Drawing.Size(65, 24)
        Me.ExpCheck.TabIndex = 11
        Me.ExpCheck.Text = "Lock"
        Me.ExpCheck.UseVisualStyleBackColor = True
        '
        'ExpNum
        '
        Me.ExpNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ExpNum.Location = New System.Drawing.Point(127, 7)
        Me.ExpNum.Margin = New System.Windows.Forms.Padding(4)
        Me.ExpNum.Maximum = New Decimal(New Integer() {2000000, 0, 0, 0})
        Me.ExpNum.Name = "ExpNum"
        Me.ExpNum.Size = New System.Drawing.Size(93, 27)
        Me.ExpNum.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(105, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 20)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "/"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel25)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(334, 127)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HP"
        '
        'TableLayoutPanel25
        '
        Me.TableLayoutPanel25.ColumnCount = 1
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel25.Controls.Add(Me.TableLayoutPanel26, 0, 0)
        Me.TableLayoutPanel25.Controls.Add(Me.TableLayoutPanel35, 0, 1)
        Me.TableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel25.Location = New System.Drawing.Point(4, 24)
        Me.TableLayoutPanel25.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel25.Name = "TableLayoutPanel25"
        Me.TableLayoutPanel25.RowCount = 2
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel25.Size = New System.Drawing.Size(326, 99)
        Me.TableLayoutPanel25.TabIndex = 0
        '
        'TableLayoutPanel26
        '
        Me.TableLayoutPanel26.ColumnCount = 4
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel26.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel26.Controls.Add(Me.HPNum, 0, 0)
        Me.TableLayoutPanel26.Controls.Add(Me.HPUpperNum, 2, 0)
        Me.TableLayoutPanel26.Controls.Add(Me.Label9, 1, 0)
        Me.TableLayoutPanel26.Controls.Add(Me.HPCheck, 3, 0)
        Me.TableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel26.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel26.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel26.Name = "TableLayoutPanel26"
        Me.TableLayoutPanel26.RowCount = 1
        Me.TableLayoutPanel26.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel26.Size = New System.Drawing.Size(318, 41)
        Me.TableLayoutPanel26.TabIndex = 12
        '
        'HPNum
        '
        Me.HPNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HPNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HPNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HPNum.Location = New System.Drawing.Point(4, 7)
        Me.HPNum.Margin = New System.Windows.Forms.Padding(4)
        Me.HPNum.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.HPNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.HPNum.Name = "HPNum"
        Me.HPNum.Size = New System.Drawing.Size(93, 27)
        Me.HPNum.TabIndex = 11
        Me.HPNum.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'HPUpperNum
        '
        Me.HPUpperNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HPUpperNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.HPUpperNum.Location = New System.Drawing.Point(127, 7)
        Me.HPUpperNum.Margin = New System.Windows.Forms.Padding(4)
        Me.HPUpperNum.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.HPUpperNum.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.HPUpperNum.Name = "HPUpperNum"
        Me.HPUpperNum.Size = New System.Drawing.Size(93, 27)
        Me.HPUpperNum.TabIndex = 11
        Me.HPUpperNum.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(105, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "/"
        '
        'HPCheck
        '
        Me.HPCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HPCheck.AutoSize = True
        Me.HPCheck.Location = New System.Drawing.Point(238, 8)
        Me.HPCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.HPCheck.Name = "HPCheck"
        Me.HPCheck.Size = New System.Drawing.Size(65, 24)
        Me.HPCheck.TabIndex = 20
        Me.HPCheck.Text = "Lock"
        Me.HPCheck.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel35
        '
        Me.TableLayoutPanel35.ColumnCount = 3
        Me.TableLayoutPanel35.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel35.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33335!))
        Me.TableLayoutPanel35.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel35.Controls.Add(Me.MHPBtn, 0, 0)
        Me.TableLayoutPanel35.Controls.Add(Me.RHPBtn, 0, 0)
        Me.TableLayoutPanel35.Controls.Add(Me.HPBtn, 2, 0)
        Me.TableLayoutPanel35.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel35.Location = New System.Drawing.Point(4, 53)
        Me.TableLayoutPanel35.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel35.Name = "TableLayoutPanel35"
        Me.TableLayoutPanel35.RowCount = 1
        Me.TableLayoutPanel35.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel35.Size = New System.Drawing.Size(318, 42)
        Me.TableLayoutPanel35.TabIndex = 2
        '
        'MHPBtn
        '
        Me.MHPBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MHPBtn.Location = New System.Drawing.Point(109, 4)
        Me.MHPBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MHPBtn.Name = "MHPBtn"
        Me.MHPBtn.Size = New System.Drawing.Size(98, 34)
        Me.MHPBtn.TabIndex = 14
        Me.MHPBtn.Text = "Max"
        Me.MHPBtn.UseVisualStyleBackColor = True
        '
        'RHPBtn
        '
        Me.RHPBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RHPBtn.Location = New System.Drawing.Point(4, 4)
        Me.RHPBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RHPBtn.Name = "RHPBtn"
        Me.RHPBtn.Size = New System.Drawing.Size(97, 34)
        Me.RHPBtn.TabIndex = 13
        Me.RHPBtn.Text = "Refresh"
        Me.RHPBtn.UseVisualStyleBackColor = True
        '
        'HPBtn
        '
        Me.HPBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HPBtn.Location = New System.Drawing.Point(215, 4)
        Me.HPBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.HPBtn.Name = "HPBtn"
        Me.HPBtn.Size = New System.Drawing.Size(99, 34)
        Me.HPBtn.TabIndex = 13
        Me.HPBtn.Text = "Confirm"
        Me.HPBtn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel10)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(346, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(334, 127)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cash"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 1
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.TableLayoutPanel34, 0, 1)
        Me.TableLayoutPanel10.Controls.Add(Me.TableLayoutPanel24, 0, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(4, 24)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 2
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(326, 99)
        Me.TableLayoutPanel10.TabIndex = 0
        '
        'TableLayoutPanel34
        '
        Me.TableLayoutPanel34.ColumnCount = 3
        Me.TableLayoutPanel34.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel34.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel34.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel34.Controls.Add(Me.MCashBtn, 0, 0)
        Me.TableLayoutPanel34.Controls.Add(Me.RCashBtn, 0, 0)
        Me.TableLayoutPanel34.Controls.Add(Me.CashBtn, 2, 0)
        Me.TableLayoutPanel34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel34.Location = New System.Drawing.Point(4, 53)
        Me.TableLayoutPanel34.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel34.Name = "TableLayoutPanel34"
        Me.TableLayoutPanel34.RowCount = 1
        Me.TableLayoutPanel34.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel34.Size = New System.Drawing.Size(318, 42)
        Me.TableLayoutPanel34.TabIndex = 3
        '
        'MCashBtn
        '
        Me.MCashBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MCashBtn.Location = New System.Drawing.Point(110, 4)
        Me.MCashBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MCashBtn.Name = "MCashBtn"
        Me.MCashBtn.Size = New System.Drawing.Size(98, 34)
        Me.MCashBtn.TabIndex = 15
        Me.MCashBtn.Text = "Max"
        Me.MCashBtn.UseVisualStyleBackColor = True
        '
        'RCashBtn
        '
        Me.RCashBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RCashBtn.Location = New System.Drawing.Point(4, 4)
        Me.RCashBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RCashBtn.Name = "RCashBtn"
        Me.RCashBtn.Size = New System.Drawing.Size(98, 34)
        Me.RCashBtn.TabIndex = 13
        Me.RCashBtn.Text = "Refresh"
        Me.RCashBtn.UseVisualStyleBackColor = True
        '
        'CashBtn
        '
        Me.CashBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CashBtn.Location = New System.Drawing.Point(216, 4)
        Me.CashBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.CashBtn.Name = "CashBtn"
        Me.CashBtn.Size = New System.Drawing.Size(98, 34)
        Me.CashBtn.TabIndex = 11
        Me.CashBtn.Text = "Confirm"
        Me.CashBtn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel24
        '
        Me.TableLayoutPanel24.ColumnCount = 2
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel24.Controls.Add(Me.CashNum, 0, 0)
        Me.TableLayoutPanel24.Controls.Add(Me.CashCheck, 1, 0)
        Me.TableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel24.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel24.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel24.Name = "TableLayoutPanel24"
        Me.TableLayoutPanel24.RowCount = 1
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel24.Size = New System.Drawing.Size(318, 41)
        Me.TableLayoutPanel24.TabIndex = 0
        '
        'CashNum
        '
        Me.CashNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CashNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.CashNum.Location = New System.Drawing.Point(4, 7)
        Me.CashNum.Margin = New System.Windows.Forms.Padding(4)
        Me.CashNum.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.CashNum.Name = "CashNum"
        Me.CashNum.Size = New System.Drawing.Size(217, 27)
        Me.CashNum.TabIndex = 10
        '
        'CashCheck
        '
        Me.CashCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CashCheck.AutoSize = True
        Me.CashCheck.Location = New System.Drawing.Point(239, 8)
        Me.CashCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.CashCheck.Name = "CashCheck"
        Me.CashCheck.Size = New System.Drawing.Size(65, 24)
        Me.CashCheck.TabIndex = 11
        Me.CashCheck.Text = "Lock"
        Me.CashCheck.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel27)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(4, 139)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(334, 127)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Strength"
        '
        'TableLayoutPanel27
        '
        Me.TableLayoutPanel27.ColumnCount = 1
        Me.TableLayoutPanel27.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel27.Controls.Add(Me.TableLayoutPanel37, 0, 1)
        Me.TableLayoutPanel27.Controls.Add(Me.TableLayoutPanel28, 0, 0)
        Me.TableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel27.Location = New System.Drawing.Point(4, 24)
        Me.TableLayoutPanel27.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel27.Name = "TableLayoutPanel27"
        Me.TableLayoutPanel27.RowCount = 2
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel27.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel27.Size = New System.Drawing.Size(326, 99)
        Me.TableLayoutPanel27.TabIndex = 1
        '
        'TableLayoutPanel37
        '
        Me.TableLayoutPanel37.ColumnCount = 3
        Me.TableLayoutPanel37.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel37.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel37.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel37.Controls.Add(Me.MStrengthBtn, 0, 0)
        Me.TableLayoutPanel37.Controls.Add(Me.RStrengthBtn, 0, 0)
        Me.TableLayoutPanel37.Controls.Add(Me.StrengthBtn, 2, 0)
        Me.TableLayoutPanel37.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel37.Location = New System.Drawing.Point(4, 53)
        Me.TableLayoutPanel37.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel37.Name = "TableLayoutPanel37"
        Me.TableLayoutPanel37.RowCount = 1
        Me.TableLayoutPanel37.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel37.Size = New System.Drawing.Size(318, 42)
        Me.TableLayoutPanel37.TabIndex = 3
        '
        'MStrengthBtn
        '
        Me.MStrengthBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MStrengthBtn.Location = New System.Drawing.Point(110, 4)
        Me.MStrengthBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MStrengthBtn.Name = "MStrengthBtn"
        Me.MStrengthBtn.Size = New System.Drawing.Size(98, 34)
        Me.MStrengthBtn.TabIndex = 15
        Me.MStrengthBtn.Text = "Max"
        Me.MStrengthBtn.UseVisualStyleBackColor = True
        '
        'RStrengthBtn
        '
        Me.RStrengthBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RStrengthBtn.Location = New System.Drawing.Point(4, 4)
        Me.RStrengthBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RStrengthBtn.Name = "RStrengthBtn"
        Me.RStrengthBtn.Size = New System.Drawing.Size(98, 34)
        Me.RStrengthBtn.TabIndex = 13
        Me.RStrengthBtn.Text = "Refresh"
        Me.RStrengthBtn.UseVisualStyleBackColor = True
        '
        'StrengthBtn
        '
        Me.StrengthBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StrengthBtn.Location = New System.Drawing.Point(216, 4)
        Me.StrengthBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.StrengthBtn.Name = "StrengthBtn"
        Me.StrengthBtn.Size = New System.Drawing.Size(98, 34)
        Me.StrengthBtn.TabIndex = 13
        Me.StrengthBtn.Text = "Confirm"
        Me.StrengthBtn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel28
        '
        Me.TableLayoutPanel28.ColumnCount = 4
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel28.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel28.Controls.Add(Me.StrengthNum, 0, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.StrengthUpperNum, 2, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel28.Controls.Add(Me.StrengthCheck, 3, 0)
        Me.TableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel28.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel28.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel28.Name = "TableLayoutPanel28"
        Me.TableLayoutPanel28.RowCount = 1
        Me.TableLayoutPanel28.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel28.Size = New System.Drawing.Size(318, 41)
        Me.TableLayoutPanel28.TabIndex = 12
        '
        'StrengthNum
        '
        Me.StrengthNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StrengthNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.StrengthNum.Location = New System.Drawing.Point(4, 7)
        Me.StrengthNum.Margin = New System.Windows.Forms.Padding(4)
        Me.StrengthNum.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.StrengthNum.Name = "StrengthNum"
        Me.StrengthNum.Size = New System.Drawing.Size(93, 27)
        Me.StrengthNum.TabIndex = 11
        Me.StrengthNum.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'StrengthUpperNum
        '
        Me.StrengthUpperNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StrengthUpperNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.StrengthUpperNum.Location = New System.Drawing.Point(127, 7)
        Me.StrengthUpperNum.Margin = New System.Windows.Forms.Padding(4)
        Me.StrengthUpperNum.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.StrengthUpperNum.Name = "StrengthUpperNum"
        Me.StrengthUpperNum.Size = New System.Drawing.Size(93, 27)
        Me.StrengthUpperNum.TabIndex = 11
        Me.StrengthUpperNum.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(105, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "/"
        '
        'StrengthCheck
        '
        Me.StrengthCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StrengthCheck.AutoSize = True
        Me.StrengthCheck.Location = New System.Drawing.Point(238, 8)
        Me.StrengthCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.StrengthCheck.Name = "StrengthCheck"
        Me.StrengthCheck.Size = New System.Drawing.Size(65, 24)
        Me.StrengthCheck.TabIndex = 20
        Me.StrengthCheck.Text = "Lock"
        Me.StrengthCheck.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel29)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(346, 139)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(334, 127)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Satiety"
        '
        'TableLayoutPanel29
        '
        Me.TableLayoutPanel29.ColumnCount = 1
        Me.TableLayoutPanel29.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel29.Controls.Add(Me.TableLayoutPanel36, 0, 1)
        Me.TableLayoutPanel29.Controls.Add(Me.TableLayoutPanel30, 0, 0)
        Me.TableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel29.Location = New System.Drawing.Point(4, 24)
        Me.TableLayoutPanel29.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel29.Name = "TableLayoutPanel29"
        Me.TableLayoutPanel29.RowCount = 2
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel29.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel29.Size = New System.Drawing.Size(326, 99)
        Me.TableLayoutPanel29.TabIndex = 2
        '
        'TableLayoutPanel36
        '
        Me.TableLayoutPanel36.ColumnCount = 3
        Me.TableLayoutPanel36.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel36.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel36.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel36.Controls.Add(Me.MSatietyBtn, 0, 0)
        Me.TableLayoutPanel36.Controls.Add(Me.RSatietyBtn, 0, 0)
        Me.TableLayoutPanel36.Controls.Add(Me.SatietyBtn, 2, 0)
        Me.TableLayoutPanel36.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel36.Location = New System.Drawing.Point(4, 53)
        Me.TableLayoutPanel36.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel36.Name = "TableLayoutPanel36"
        Me.TableLayoutPanel36.RowCount = 1
        Me.TableLayoutPanel36.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel36.Size = New System.Drawing.Size(318, 42)
        Me.TableLayoutPanel36.TabIndex = 3
        '
        'MSatietyBtn
        '
        Me.MSatietyBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MSatietyBtn.Location = New System.Drawing.Point(110, 4)
        Me.MSatietyBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MSatietyBtn.Name = "MSatietyBtn"
        Me.MSatietyBtn.Size = New System.Drawing.Size(98, 34)
        Me.MSatietyBtn.TabIndex = 15
        Me.MSatietyBtn.Text = "Max"
        Me.MSatietyBtn.UseVisualStyleBackColor = True
        '
        'RSatietyBtn
        '
        Me.RSatietyBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RSatietyBtn.Location = New System.Drawing.Point(4, 4)
        Me.RSatietyBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RSatietyBtn.Name = "RSatietyBtn"
        Me.RSatietyBtn.Size = New System.Drawing.Size(98, 34)
        Me.RSatietyBtn.TabIndex = 13
        Me.RSatietyBtn.Text = "Refresh"
        Me.RSatietyBtn.UseVisualStyleBackColor = True
        '
        'SatietyBtn
        '
        Me.SatietyBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SatietyBtn.Location = New System.Drawing.Point(216, 4)
        Me.SatietyBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.SatietyBtn.Name = "SatietyBtn"
        Me.SatietyBtn.Size = New System.Drawing.Size(98, 34)
        Me.SatietyBtn.TabIndex = 13
        Me.SatietyBtn.Text = "Confirm"
        Me.SatietyBtn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel30
        '
        Me.TableLayoutPanel30.ColumnCount = 4
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel30.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel30.Controls.Add(Me.SatietyNum, 0, 0)
        Me.TableLayoutPanel30.Controls.Add(Me.SatietyUpperNum, 2, 0)
        Me.TableLayoutPanel30.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel30.Controls.Add(Me.SatietyCheck, 3, 0)
        Me.TableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel30.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel30.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel30.Name = "TableLayoutPanel30"
        Me.TableLayoutPanel30.RowCount = 1
        Me.TableLayoutPanel30.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel30.Size = New System.Drawing.Size(318, 41)
        Me.TableLayoutPanel30.TabIndex = 12
        '
        'SatietyNum
        '
        Me.SatietyNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SatietyNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.SatietyNum.Location = New System.Drawing.Point(4, 7)
        Me.SatietyNum.Margin = New System.Windows.Forms.Padding(4)
        Me.SatietyNum.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.SatietyNum.Name = "SatietyNum"
        Me.SatietyNum.Size = New System.Drawing.Size(93, 27)
        Me.SatietyNum.TabIndex = 11
        Me.SatietyNum.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'SatietyUpperNum
        '
        Me.SatietyUpperNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SatietyUpperNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.SatietyUpperNum.Location = New System.Drawing.Point(127, 7)
        Me.SatietyUpperNum.Margin = New System.Windows.Forms.Padding(4)
        Me.SatietyUpperNum.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.SatietyUpperNum.Name = "SatietyUpperNum"
        Me.SatietyUpperNum.Size = New System.Drawing.Size(93, 27)
        Me.SatietyUpperNum.TabIndex = 11
        Me.SatietyUpperNum.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "/"
        '
        'SatietyCheck
        '
        Me.SatietyCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SatietyCheck.AutoSize = True
        Me.SatietyCheck.Location = New System.Drawing.Point(238, 8)
        Me.SatietyCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.SatietyCheck.Name = "SatietyCheck"
        Me.SatietyCheck.Size = New System.Drawing.Size(65, 24)
        Me.SatietyCheck.TabIndex = 20
        Me.SatietyCheck.Text = "Lock"
        Me.SatietyCheck.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TableLayoutPanel39)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(346, 274)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(334, 129)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Stage / Danmaku"
        '
        'TableLayoutPanel39
        '
        Me.TableLayoutPanel39.ColumnCount = 1
        Me.TableLayoutPanel39.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel39.Controls.Add(Me.TableLayoutPanel40, 0, 1)
        Me.TableLayoutPanel39.Controls.Add(Me.TableLayoutPanel41, 0, 0)
        Me.TableLayoutPanel39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel39.Location = New System.Drawing.Point(4, 24)
        Me.TableLayoutPanel39.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel39.Name = "TableLayoutPanel39"
        Me.TableLayoutPanel39.RowCount = 2
        Me.TableLayoutPanel39.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel39.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel39.Size = New System.Drawing.Size(326, 101)
        Me.TableLayoutPanel39.TabIndex = 0
        '
        'TableLayoutPanel40
        '
        Me.TableLayoutPanel40.ColumnCount = 3
        Me.TableLayoutPanel40.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel40.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33112!))
        Me.TableLayoutPanel40.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel40.Controls.Add(Me.MDanmakuBtn, 0, 0)
        Me.TableLayoutPanel40.Controls.Add(Me.RStageBtn, 0, 0)
        Me.TableLayoutPanel40.Controls.Add(Me.StageBtn, 2, 0)
        Me.TableLayoutPanel40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel40.Location = New System.Drawing.Point(4, 54)
        Me.TableLayoutPanel40.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel40.Name = "TableLayoutPanel40"
        Me.TableLayoutPanel40.RowCount = 1
        Me.TableLayoutPanel40.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel40.Size = New System.Drawing.Size(318, 43)
        Me.TableLayoutPanel40.TabIndex = 3
        '
        'RStageBtn
        '
        Me.RStageBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RStageBtn.Location = New System.Drawing.Point(4, 4)
        Me.RStageBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RStageBtn.Name = "RStageBtn"
        Me.RStageBtn.Size = New System.Drawing.Size(98, 35)
        Me.RStageBtn.TabIndex = 13
        Me.RStageBtn.Text = "Refresh"
        Me.RStageBtn.UseVisualStyleBackColor = True
        '
        'StageBtn
        '
        Me.StageBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StageBtn.Location = New System.Drawing.Point(215, 4)
        Me.StageBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.StageBtn.Name = "StageBtn"
        Me.StageBtn.Size = New System.Drawing.Size(99, 35)
        Me.StageBtn.TabIndex = 11
        Me.StageBtn.Text = "Confirm"
        Me.StageBtn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel41
        '
        Me.TableLayoutPanel41.ColumnCount = 4
        Me.TableLayoutPanel41.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel41.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel41.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel41.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel41.Controls.Add(Me.DanmakuNum, 0, 0)
        Me.TableLayoutPanel41.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel41.Controls.Add(Me.StageVal, 0, 0)
        Me.TableLayoutPanel41.Controls.Add(Me.DanmakuCheck, 3, 0)
        Me.TableLayoutPanel41.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel41.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel41.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel41.Name = "TableLayoutPanel41"
        Me.TableLayoutPanel41.RowCount = 1
        Me.TableLayoutPanel41.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel41.Size = New System.Drawing.Size(318, 42)
        Me.TableLayoutPanel41.TabIndex = 0
        '
        'StageVal
        '
        Me.StageVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StageVal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.StageVal.Location = New System.Drawing.Point(4, 7)
        Me.StageVal.Margin = New System.Windows.Forms.Padding(4)
        Me.StageVal.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.StageVal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.StageVal.Name = "StageVal"
        Me.StageVal.ReadOnly = True
        Me.StageVal.Size = New System.Drawing.Size(93, 27)
        Me.StageVal.TabIndex = 10
        Me.StageVal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 457)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(939, 25)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(65, 20)
        Me.ToolStripStatusLabel.Text = "              "
        '
        'MDanmakuBtn
        '
        Me.MDanmakuBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MDanmakuBtn.Location = New System.Drawing.Point(110, 4)
        Me.MDanmakuBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MDanmakuBtn.Name = "MDanmakuBtn"
        Me.MDanmakuBtn.Size = New System.Drawing.Size(97, 35)
        Me.MDanmakuBtn.TabIndex = 16
        Me.MDanmakuBtn.Text = "Max"
        Me.MDanmakuBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "/"
        '
        'DanmakuNum
        '
        Me.DanmakuNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DanmakuNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DanmakuNum.Location = New System.Drawing.Point(127, 7)
        Me.DanmakuNum.Margin = New System.Windows.Forms.Padding(4)
        Me.DanmakuNum.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.DanmakuNum.Name = "DanmakuNum"
        Me.DanmakuNum.Size = New System.Drawing.Size(93, 27)
        Me.DanmakuNum.TabIndex = 18
        '
        'DanmakuCheck
        '
        Me.DanmakuCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DanmakuCheck.AutoSize = True
        Me.DanmakuCheck.Location = New System.Drawing.Point(238, 9)
        Me.DanmakuCheck.Name = "DanmakuCheck"
        Me.DanmakuCheck.Size = New System.Drawing.Size(65, 24)
        Me.DanmakuCheck.TabIndex = 19
        Me.DanmakuCheck.Text = "Lock"
        Me.DanmakuCheck.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 482)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.TabControl_Main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reshen-Defender-SL4"
        Me.TabControl_Main.ResumeLayout(False)
        Me.TabPage_Main.ResumeLayout(False)
        Me.MainContainer.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel_MainSub1_Sub.ResumeLayout(False)
        Me.TabPage_Archive.ResumeLayout(False)
        Me.SaveContainer.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.SaveListPanel.ResumeLayout(False)
        Me.SaveListPanel.PerformLayout()
        Me.TabPage_Cheat.ResumeLayout(False)
        Me.CheatContainer.ResumeLayout(False)
        Me.TableLayoutPanel31.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TableLayoutPanel32.ResumeLayout(False)
        Me.TableLayoutPanel38.ResumeLayout(False)
        Me.TableLayoutPanel33.ResumeLayout(False)
        Me.TableLayoutPanel33.PerformLayout()
        CType(Me.LvNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel25.ResumeLayout(False)
        Me.TableLayoutPanel26.ResumeLayout(False)
        Me.TableLayoutPanel26.PerformLayout()
        CType(Me.HPNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HPUpperNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel35.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel34.ResumeLayout(False)
        Me.TableLayoutPanel24.ResumeLayout(False)
        Me.TableLayoutPanel24.PerformLayout()
        CType(Me.CashNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel27.ResumeLayout(False)
        Me.TableLayoutPanel37.ResumeLayout(False)
        Me.TableLayoutPanel28.ResumeLayout(False)
        Me.TableLayoutPanel28.PerformLayout()
        CType(Me.StrengthNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StrengthUpperNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel29.ResumeLayout(False)
        Me.TableLayoutPanel36.ResumeLayout(False)
        Me.TableLayoutPanel30.ResumeLayout(False)
        Me.TableLayoutPanel30.PerformLayout()
        CType(Me.SatietyNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SatietyUpperNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.TableLayoutPanel39.ResumeLayout(False)
        Me.TableLayoutPanel40.ResumeLayout(False)
        Me.TableLayoutPanel41.ResumeLayout(False)
        Me.TableLayoutPanel41.PerformLayout()
        CType(Me.StageVal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.DanmakuNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl_Main As TabControl
    Friend WithEvents TabPage_Main As TabPage
    Friend WithEvents TabPage_Cheat As TabPage
    Friend WithEvents MainContainer As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel_MainSub1_Sub As TableLayoutPanel
    Friend WithEvents StartBtn As Button
    Friend WithEvents RestartBtn As Button
    Friend WithEvents EndBtn As Button
    Friend WithEvents CheatContainer As TableLayoutPanel
    Friend WithEvents TableLayoutPanel31 As TableLayoutPanel
    Friend WithEvents LockBtn As Button
    Friend WithEvents RefreshBtn As Button
    Friend WithEvents UnlockBtn As Button
    Friend WithEvents MaxBtn As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TableLayoutPanel32 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel38 As TableLayoutPanel
    Friend WithEvents MExpBtn As Button
    Friend WithEvents RExpBtn As Button
    Friend WithEvents ExpBtn As Button
    Friend WithEvents TableLayoutPanel33 As TableLayoutPanel
    Friend WithEvents LvNum As NumericUpDown
    Friend WithEvents ExpCheck As CheckBox
    Friend WithEvents ExpNum As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel25 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel26 As TableLayoutPanel
    Friend WithEvents HPNum As NumericUpDown
    Friend WithEvents HPUpperNum As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents HPCheck As CheckBox
    Friend WithEvents TableLayoutPanel35 As TableLayoutPanel
    Friend WithEvents MHPBtn As Button
    Friend WithEvents RHPBtn As Button
    Friend WithEvents HPBtn As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel34 As TableLayoutPanel
    Friend WithEvents MCashBtn As Button
    Friend WithEvents RCashBtn As Button
    Friend WithEvents CashBtn As Button
    Friend WithEvents TableLayoutPanel24 As TableLayoutPanel
    Friend WithEvents CashNum As NumericUpDown
    Friend WithEvents CashCheck As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TableLayoutPanel27 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel37 As TableLayoutPanel
    Friend WithEvents MStrengthBtn As Button
    Friend WithEvents RStrengthBtn As Button
    Friend WithEvents StrengthBtn As Button
    Friend WithEvents TableLayoutPanel28 As TableLayoutPanel
    Friend WithEvents StrengthNum As NumericUpDown
    Friend WithEvents StrengthUpperNum As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents StrengthCheck As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel29 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel36 As TableLayoutPanel
    Friend WithEvents MSatietyBtn As Button
    Friend WithEvents RSatietyBtn As Button
    Friend WithEvents SatietyBtn As Button
    Friend WithEvents TableLayoutPanel30 As TableLayoutPanel
    Friend WithEvents SatietyNum As NumericUpDown
    Friend WithEvents SatietyUpperNum As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents SatietyCheck As CheckBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TableLayoutPanel39 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel40 As TableLayoutPanel
    Friend WithEvents RStageBtn As Button
    Friend WithEvents StageBtn As Button
    Friend WithEvents TableLayoutPanel41 As TableLayoutPanel
    Friend WithEvents StageVal As NumericUpDown
    Friend WithEvents TabPage_Archive As TabPage
    Friend WithEvents SaveContainer As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents ResumeBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents SaveListPanel As TableLayoutPanel
    Friend WithEvents SaveTextBox As TextBox
    Friend WithEvents SaveBox As ListView
    Friend WithEvents LoadBtn As Button
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents SetBtn As Button
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents MDanmakuBtn As Button
    Friend WithEvents DanmakuNum As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents DanmakuCheck As CheckBox
End Class
