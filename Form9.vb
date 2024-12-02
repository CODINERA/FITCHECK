Public Class Form9

    ' In Form9 (or any other form from where you want to navigate back to Form3)
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim form3 As New Form3()
        form3.StartPosition = FormStartPosition.CenterScreen
        form3.Show()
        Me.Hide()
    End Sub

End Class