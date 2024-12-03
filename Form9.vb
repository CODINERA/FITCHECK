Public Class Form9
    Public Sub SetRecipeText(text As String)
        ' Assuming Form9 has a TextBox named TextBox1
        Guna2TextBox1.Multiline = True
        Guna2TextBox1.ScrollBars = ScrollBars.Vertical ' Enable vertical scrolling
        Guna2TextBox1.ReadOnly = True ' Make the TextBox read-only
        Guna2TextBox1.BorderStyle = BorderStyle.None ' Remove the border
        Guna2TextBox1.BackColor = Me.BackColor ' Set background color to match the form
        Guna2TextBox1.Text = text
    End Sub

    ' In Form9 (or any other form from where you want to navigate back to Form3)
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim form3 As New Form3()
        form3.StartPosition = FormStartPosition.CenterScreen
        form3.Show()
        Me.Hide()
    End Sub

End Class