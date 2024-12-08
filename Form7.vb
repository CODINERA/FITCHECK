Imports MySql.Data.MySqlClient
Public Class Form7
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Public ddate As String

    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "123"
    Dim database As String = "fitcheck"
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ucdays As New UserControlDays()
        Guna2HtmlLabel1.Text = ddate
        MessageBox.Show("daysDone" & ddate)
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

    Private Sub UpdateEnergy(rating As Integer)
        '' Set all stars to empty first
        'For i As Integer = 1 To 5
        '    Dim pbEnergy As PictureBox = CType(Me.Controls("pbEnergy" & i), PictureBox)
        '    pbEnergy.Image = My.Resources.energy_empty
        'Next

        '' Fill the stars up to the rating value
        'For i As Integer = 1 To rating
        '    Dim pbStar As PictureBox = CType(Me.Controls("pbEnergy" & i), PictureBox)
        '    pbEnergy.Image = My.Resources.energy_filled
        'Next

        ' Set all stars to empty first
        For i As Integer = 1 To 5
            Dim pbEnergy As Guna.UI2.WinForms.Guna2CircleButton = CType(Me.Controls("pbEnergy" & i), Guna.UI2.WinForms.Guna2CircleButton)
            If pbEnergy IsNot Nothing Then
                pbEnergy.Image = My.Resources.energy_empty
            End If
        Next

        ' Fill the stars up to the rating value
        For i As Integer = 1 To rating
            Dim pbEnergy As Guna.UI2.WinForms.Guna2CircleButton = CType(Me.Controls("pbEnergy" & i), Guna.UI2.WinForms.Guna2CircleButton)
            If pbEnergy IsNot Nothing Then
                pbEnergy.Image = My.Resources.energy_filled
            End If
        Next

    End Sub

    Private Sub Energy_CLick(sender As Object, e As EventArgs) Handles pbEnergy4.Click, pbEnergy3.Click, pbEnergy2.Click, pbEnergy1.Click, pbEnergy5.Click
        Dim clickedEnergy As Guna.UI2.WinForms.Guna2CircleButton = CType(sender, Guna.UI2.WinForms.Guna2CircleButton)
        Dim energyNumber As Integer = CInt(clickedEnergy.Name.Substring(8)) ' Extract number from "pbEnergyX"
        UpdateEnergy(energyNumber)
    End Sub


End Class