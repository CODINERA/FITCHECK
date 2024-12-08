Public Class UserControlDays
    Dim DDate As String
    Public month As String
    Public year As String

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lbldays.Click

    End Sub

    Private Sub UserControlDays_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub days(numday As Integer)
        lbldays.Text = numday.ToString() + ""
    End Sub

    Private Sub UserControlDays_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Dim Diary As New Form7()
        DDate = month.ToString() + " " + lbldays.Text + "," + " " + year.ToString()
        Diary.ddate = DDate
        Diary.Show()
    End Sub
End Class
