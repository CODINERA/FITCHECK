Imports Guna.UI2.WinForms

Public Class Form10
    Public Sub SetPanelText(text As String)
        ' Clear existing controls in Panel2
        Guna2Panel2.Controls.Clear()
        ' Add a new Label with the text
        Dim lbl As New Label()
        lbl.Text = text
        lbl.AutoSize = True
        Guna2Panel2.Controls.Add(lbl)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim form3 As New Form3()
        form3.StartPosition = FormStartPosition.CenterScreen
        form3.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
            ' Clear the controls in Panel2
            Guna2Panel2.Controls.Clear()
        End Sub

    End Class
