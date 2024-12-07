Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Guna.UI2.WinForms
Imports Microsoft.SqlServer

Public Class Form6
    Public WorkoutName As String
    Public Workoutdesc As String
    Public ExcersisDone As Integer = 1
    Private countdown As Integer


    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel1.Text = WorkoutName.ToString()
        Timer1.Interval = 1000
        Guna2HtmlLabel4.Text = "30"
        Guna2TextBox1.Text = Workoutdesc.ToString()
    End Sub
    Private Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        countdown = 1 ' Set the countdown value to 30 seconds
        Guna2HtmlLabel4.Text = countdown.ToString() ' Update the label
        Timer1.Start() ' Start the s
        ExcersisDone += 1
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If countdown > 0 Then
            countdown -= 1 ' Decrease the countdown value
            Guna2HtmlLabel4.Text = countdown.ToString() ' Update the label
        Else
            ExcersisDone += 1
            Timer1.Stop() ' Stop the timer when countdown reaches 
            MessageBox.Show("Time's up!") ' Optional: Show a message when the countdown ends
        End If
    End Sub

    Private Sub backbtn_Click(sender As Object, e As EventArgs) Handles backbtn.Click
        Me.Close()
    End Sub

End Class