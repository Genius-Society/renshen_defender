Public Class PGB
    Dim PBForm As Form = New Form
    Dim PB As ProgressBar = New ProgressBar

    Public Sub New(max As Integer)

        With PBForm 
            .Width = 170
            .Height = 47
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.CenterScreen
        End With

        Dim TLP As TableLayoutPanel = New TableLayoutPanel
        With TLP
            .Parent = PBForm
            .Dock = DockStyle.Fill
        End With

        With PB
            .Parent = TLP
            .Minimum = 0
            .Maximum = max - 1
            .Step = 1
            .Width = 146
            .Height = 23
            .Anchor = AnchorStyles.None
        End With

        PBForm.Show()
    End Sub

    Public Sub UpdValue(i As Integer)
        PB.Value = i
    End Sub

    Public Sub Dispose()
        PBForm.Dispose()
    End Sub

End Class
