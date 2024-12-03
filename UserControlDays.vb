Public Class UserControlDays

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lbldays.Click

    End Sub

    Private Sub UserControlDays_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub days(numday As Integer)
        lbldays.Text = numday.ToString() + ""
    End Sub

    Private Sub UserControlDays_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Dim Diary As New Form7()
        Diary.Show()
    End Sub
End Class
