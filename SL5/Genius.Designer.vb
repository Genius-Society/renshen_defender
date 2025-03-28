<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Genius
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
        Me.GenMainContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GenHeadContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.CloseGen = New System.Windows.Forms.Label()
        Me.GenLabel = New System.Windows.Forms.Label()
        Me.GeniusTab = New System.Windows.Forms.TabControl()
        Me.GameTabPg = New System.Windows.Forms.TabPage()
        Me.GenButtonContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.GenResButton = New System.Windows.Forms.Button()
        Me.FSavButton = New System.Windows.Forms.Button()
        Me.GenList = New System.Windows.Forms.ListView()
        Me.CheaTabPg = New System.Windows.Forms.TabPage()
        Me.LockGroup = New System.Windows.Forms.GroupBox()
        Me.CheatPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.FExpCheck = New System.Windows.Forms.CheckBox()
        Me.FHPCheck = New System.Windows.Forms.CheckBox()
        Me.FSatietyCheck = New System.Windows.Forms.CheckBox()
        Me.FStrengthCheck = New System.Windows.Forms.CheckBox()
        Me.FCashCheck = New System.Windows.Forms.CheckBox()
        Me.FDmkCheck = New System.Windows.Forms.CheckBox()
        Me.GenMainContainer.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.GenHeadContainer.SuspendLayout()
        Me.GeniusTab.SuspendLayout()
        Me.GameTabPg.SuspendLayout()
        Me.GenButtonContainer.SuspendLayout()
        Me.CheaTabPg.SuspendLayout()
        Me.LockGroup.SuspendLayout()
        Me.CheatPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'GenMainContainer
        '
        Me.GenMainContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.GenMainContainer.ColumnCount = 1
        Me.GenMainContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.GenMainContainer.Controls.Add(Me.StatusStrip, 0, 2)
        Me.GenMainContainer.Controls.Add(Me.GenHeadContainer, 0, 0)
        Me.GenMainContainer.Controls.Add(Me.GeniusTab, 0, 1)
        Me.GenMainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GenMainContainer.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GenMainContainer.Location = New System.Drawing.Point(0, 0)
        Me.GenMainContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.GenMainContainer.Name = "GenMainContainer"
        Me.GenMainContainer.RowCount = 3
        Me.GenMainContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.GenMainContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.0!))
        Me.GenMainContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.GenMainContainer.Size = New System.Drawing.Size(182, 273)
        Me.GenMainContainer.TabIndex = 0
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(1, 247)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip.Size = New System.Drawing.Size(180, 25)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(25, 20)
        Me.ToolStripStatusLabel.Text = "    "
        '
        'GenHeadContainer
        '
        Me.GenHeadContainer.BackColor = System.Drawing.Color.White
        Me.GenHeadContainer.ColumnCount = 2
        Me.GenHeadContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.GenHeadContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.GenHeadContainer.Controls.Add(Me.CloseGen, 1, 0)
        Me.GenHeadContainer.Controls.Add(Me.GenLabel, 0, 0)
        Me.GenHeadContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GenHeadContainer.Location = New System.Drawing.Point(1, 1)
        Me.GenHeadContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.GenHeadContainer.Name = "GenHeadContainer"
        Me.GenHeadContainer.RowCount = 1
        Me.GenHeadContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.GenHeadContainer.Size = New System.Drawing.Size(180, 17)
        Me.GenHeadContainer.TabIndex = 2
        '
        'CloseGen
        '
        Me.CloseGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CloseGen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CloseGen.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CloseGen.ForeColor = System.Drawing.Color.DimGray
        Me.CloseGen.Location = New System.Drawing.Point(165, 0)
        Me.CloseGen.Margin = New System.Windows.Forms.Padding(3, 0, 0, 4)
        Me.CloseGen.Name = "CloseGen"
        Me.CloseGen.Size = New System.Drawing.Size(15, 13)
        Me.CloseGen.TabIndex = 0
        Me.CloseGen.Text = "×"
        Me.CloseGen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GenLabel
        '
        Me.GenLabel.AutoSize = True
        Me.GenLabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.GenLabel.Location = New System.Drawing.Point(0, 0)
        Me.GenLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.GenLabel.Name = "GenLabel"
        Me.GenLabel.Size = New System.Drawing.Size(58, 17)
        Me.GenLabel.TabIndex = 1
        Me.GenLabel.Text = "Genius"
        Me.GenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GeniusTab
        '
        Me.GeniusTab.Controls.Add(Me.GameTabPg)
        Me.GeniusTab.Controls.Add(Me.CheaTabPg)
        Me.GeniusTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GeniusTab.Location = New System.Drawing.Point(4, 22)
        Me.GeniusTab.Name = "GeniusTab"
        Me.GeniusTab.SelectedIndex = 0
        Me.GeniusTab.Size = New System.Drawing.Size(174, 220)
        Me.GeniusTab.TabIndex = 1
        '
        'GameTabPg
        '
        Me.GameTabPg.Controls.Add(Me.GenButtonContainer)
        Me.GameTabPg.Location = New System.Drawing.Point(4, 29)
        Me.GameTabPg.Name = "GameTabPg"
        Me.GameTabPg.Padding = New System.Windows.Forms.Padding(3)
        Me.GameTabPg.Size = New System.Drawing.Size(166, 187)
        Me.GameTabPg.TabIndex = 0
        Me.GameTabPg.Text = "Game"
        Me.GameTabPg.UseVisualStyleBackColor = True
        '
        'GenButtonContainer
        '
        Me.GenButtonContainer.ColumnCount = 1
        Me.GenButtonContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.GenButtonContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.GenButtonContainer.Controls.Add(Me.GenResButton, 0, 2)
        Me.GenButtonContainer.Controls.Add(Me.FSavButton, 0, 1)
        Me.GenButtonContainer.Controls.Add(Me.GenList, 0, 0)
        Me.GenButtonContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GenButtonContainer.Location = New System.Drawing.Point(3, 3)
        Me.GenButtonContainer.Name = "GenButtonContainer"
        Me.GenButtonContainer.RowCount = 3
        Me.GenButtonContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.GenButtonContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.GenButtonContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.GenButtonContainer.Size = New System.Drawing.Size(160, 181)
        Me.GenButtonContainer.TabIndex = 0
        '
        'GenResButton
        '
        Me.GenResButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GenResButton.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GenResButton.Location = New System.Drawing.Point(0, 153)
        Me.GenResButton.Margin = New System.Windows.Forms.Padding(0)
        Me.GenResButton.Name = "GenResButton"
        Me.GenResButton.Size = New System.Drawing.Size(160, 28)
        Me.GenResButton.TabIndex = 1
        Me.GenResButton.Text = "Restart"
        Me.GenResButton.UseVisualStyleBackColor = True
        '
        'FSavButton
        '
        Me.FSavButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FSavButton.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FSavButton.Location = New System.Drawing.Point(0, 126)
        Me.FSavButton.Margin = New System.Windows.Forms.Padding(0)
        Me.FSavButton.Name = "FSavButton"
        Me.FSavButton.Size = New System.Drawing.Size(160, 27)
        Me.FSavButton.TabIndex = 0
        Me.FSavButton.Text = "FastSave"
        Me.FSavButton.UseVisualStyleBackColor = True
        '
        'GenList
        '
        Me.GenList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GenList.GridLines = True
        Me.GenList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.GenList.Location = New System.Drawing.Point(1, 1)
        Me.GenList.Margin = New System.Windows.Forms.Padding(1)
        Me.GenList.MultiSelect = False
        Me.GenList.Name = "GenList"
        Me.GenList.Size = New System.Drawing.Size(158, 124)
        Me.GenList.TabIndex = 1
        Me.GenList.UseCompatibleStateImageBehavior = False
        '
        'CheaTabPg
        '
        Me.CheaTabPg.Controls.Add(Me.LockGroup)
        Me.CheaTabPg.Location = New System.Drawing.Point(4, 29)
        Me.CheaTabPg.Name = "CheaTabPg"
        Me.CheaTabPg.Padding = New System.Windows.Forms.Padding(3)
        Me.CheaTabPg.Size = New System.Drawing.Size(166, 187)
        Me.CheaTabPg.TabIndex = 1
        Me.CheaTabPg.Text = "Cheat"
        Me.CheaTabPg.UseVisualStyleBackColor = True
        '
        'LockGroup
        '
        Me.LockGroup.Controls.Add(Me.CheatPanel)
        Me.LockGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LockGroup.Location = New System.Drawing.Point(3, 3)
        Me.LockGroup.Name = "LockGroup"
        Me.LockGroup.Size = New System.Drawing.Size(160, 181)
        Me.LockGroup.TabIndex = 22
        Me.LockGroup.TabStop = False
        Me.LockGroup.Text = "Lock"
        '
        'CheatPanel
        '
        Me.CheatPanel.ColumnCount = 1
        Me.CheatPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CheatPanel.Controls.Add(Me.FDmkCheck, 0, 5)
        Me.CheatPanel.Controls.Add(Me.FExpCheck, 0, 4)
        Me.CheatPanel.Controls.Add(Me.FHPCheck, 0, 0)
        Me.CheatPanel.Controls.Add(Me.FSatietyCheck, 0, 1)
        Me.CheatPanel.Controls.Add(Me.FStrengthCheck, 0, 2)
        Me.CheatPanel.Controls.Add(Me.FCashCheck, 0, 3)
        Me.CheatPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheatPanel.Location = New System.Drawing.Point(3, 23)
        Me.CheatPanel.Name = "CheatPanel"
        Me.CheatPanel.RowCount = 6
        Me.CheatPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.CheatPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.CheatPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.CheatPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.CheatPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.CheatPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.CheatPanel.Size = New System.Drawing.Size(154, 155)
        Me.CheatPanel.TabIndex = 0
        '
        'FExpCheck
        '
        Me.FExpCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FExpCheck.AutoSize = True
        Me.FExpCheck.Location = New System.Drawing.Point(3, 103)
        Me.FExpCheck.Name = "FExpCheck"
        Me.FExpCheck.Size = New System.Drawing.Size(57, 19)
        Me.FExpCheck.TabIndex = 22
        Me.FExpCheck.Text = "Exp"
        Me.FExpCheck.UseVisualStyleBackColor = True
        '
        'FHPCheck
        '
        Me.FHPCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FHPCheck.AutoSize = True
        Me.FHPCheck.Location = New System.Drawing.Point(3, 3)
        Me.FHPCheck.Name = "FHPCheck"
        Me.FHPCheck.Size = New System.Drawing.Size(52, 19)
        Me.FHPCheck.TabIndex = 21
        Me.FHPCheck.Text = "HP"
        Me.FHPCheck.UseVisualStyleBackColor = True
        '
        'FSatietyCheck
        '
        Me.FSatietyCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FSatietyCheck.AutoSize = True
        Me.FSatietyCheck.Location = New System.Drawing.Point(3, 28)
        Me.FSatietyCheck.Name = "FSatietyCheck"
        Me.FSatietyCheck.Size = New System.Drawing.Size(81, 19)
        Me.FSatietyCheck.TabIndex = 21
        Me.FSatietyCheck.Text = "Satiety"
        Me.FSatietyCheck.UseVisualStyleBackColor = True
        '
        'FStrengthCheck
        '
        Me.FStrengthCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FStrengthCheck.AutoSize = True
        Me.FStrengthCheck.Location = New System.Drawing.Point(3, 53)
        Me.FStrengthCheck.Name = "FStrengthCheck"
        Me.FStrengthCheck.Size = New System.Drawing.Size(95, 19)
        Me.FStrengthCheck.TabIndex = 21
        Me.FStrengthCheck.Text = "Strength"
        Me.FStrengthCheck.UseVisualStyleBackColor = True
        '
        'FCashCheck
        '
        Me.FCashCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FCashCheck.AutoSize = True
        Me.FCashCheck.Location = New System.Drawing.Point(3, 78)
        Me.FCashCheck.Name = "FCashCheck"
        Me.FCashCheck.Size = New System.Drawing.Size(65, 19)
        Me.FCashCheck.TabIndex = 21
        Me.FCashCheck.Text = "Cash"
        Me.FCashCheck.UseVisualStyleBackColor = True
        '
        'FDmkCheck
        '
        Me.FDmkCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FDmkCheck.AutoSize = True
        Me.FDmkCheck.Location = New System.Drawing.Point(3, 128)
        Me.FDmkCheck.Name = "FDmkCheck"
        Me.FDmkCheck.Size = New System.Drawing.Size(98, 24)
        Me.FDmkCheck.TabIndex = 23
        Me.FDmkCheck.Text = "Danmaku"
        Me.FDmkCheck.UseVisualStyleBackColor = True
        '
        'Genius
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(182, 273)
        Me.Controls.Add(Me.GenMainContainer)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Genius"
        Me.Opacity = 0.95R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Genius"
        Me.TopMost = True
        Me.GenMainContainer.ResumeLayout(False)
        Me.GenMainContainer.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.GenHeadContainer.ResumeLayout(False)
        Me.GenHeadContainer.PerformLayout()
        Me.GeniusTab.ResumeLayout(False)
        Me.GameTabPg.ResumeLayout(False)
        Me.GenButtonContainer.ResumeLayout(False)
        Me.CheaTabPg.ResumeLayout(False)
        Me.LockGroup.ResumeLayout(False)
        Me.CheatPanel.ResumeLayout(False)
        Me.CheatPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GenMainContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FSavButton As System.Windows.Forms.Button
    Friend WithEvents GenResButton As System.Windows.Forms.Button
    Friend WithEvents GenHeadContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CloseGen As System.Windows.Forms.Label
    Friend WithEvents GenLabel As System.Windows.Forms.Label
    Friend WithEvents GenList As System.Windows.Forms.ListView
    Friend WithEvents GeniusTab As System.Windows.Forms.TabControl
    Friend WithEvents GameTabPg As System.Windows.Forms.TabPage
    Friend WithEvents CheaTabPg As System.Windows.Forms.TabPage
    Friend WithEvents GenButtonContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheatPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FHPCheck As System.Windows.Forms.CheckBox
    Friend WithEvents FSatietyCheck As System.Windows.Forms.CheckBox
    Friend WithEvents FStrengthCheck As System.Windows.Forms.CheckBox
    Friend WithEvents FCashCheck As System.Windows.Forms.CheckBox
    Friend WithEvents LockGroup As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FExpCheck As CheckBox
    Friend WithEvents FDmkCheck As CheckBox
End Class
