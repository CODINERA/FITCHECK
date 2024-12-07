Imports MySql.Data.MySqlClient
Public Class Form7
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter

    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "123123"
    Dim database As String = "fitcheck"
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlConn.ConnectionString = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"
        txtDiary.Text = "Today..."
        txtDiary.ForeColor = Color.Gray
    End Sub

    Private Sub txtBox_Enter(sender As Object, e As EventArgs) Handles txtDiary.Enter
        If txtDiary.Text = "Today..." Then
            txtDiary.Text = String.Empty
            txtDiary.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtDiary_Leave(sender As Object, e As EventArgs) Handles txtDiary.Leave
        If txtDiary.Text = String.Empty Then
            txtDiary.Text = "Today..."
            txtDiary.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub backlbl_Click(sender As Object, e As EventArgs) Handles backlbl.Click
        Me.Close()
    End Sub
End Class