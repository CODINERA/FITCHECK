Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Guna.UI2.WinForms
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Crypto
Imports Mysqlx.XDevAPI.Common
Public Class Form6
    Public WorkoutName As String
    Public Workoutdesc As String
    Public Shared ExerciseDone As Integer = 0
    Dim WorkoutTime As Integer
    Private countdown As Integer
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "123123"
    Dim database As String = "fitcheck"
    Private butmap As Bitmap

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel1.Text = WorkoutName
        Guna2TextBox1.Text = Workoutdesc.ToString()
        Timer1.Interval = 1000
        Guna2HtmlLabel4.Text = "30"
        sqlConn.ConnectionString = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"

        Try
            sqlConn.Open()
            Dim checkQuery As String = "SELECT COUNT(*) FROM workout WHERE user_id = @UserID "
            Dim cmdr = New MySqlCommand(checkQuery, sqlConn)
            cmdr.Parameters.AddWithValue("@UserID", "1")
            Dim count As Integer = Convert.ToInt32(cmdr.ExecuteScalar())  ' Get the count of records
            If count > 0 Then
                Dim Query As String = "SELECT workout_progress FROM workout WHERE user_id = @UserID AND workout_reco = @WorkOutReco "
                Dim cmd1 = New MySqlCommand(Query, sqlConn)
                cmd1.Parameters.AddWithValue("@UserID", "1")
                cmd1.Parameters.AddWithValue("@WorkOutReco", WorkoutName)
                Dim Ex As Integer = Convert.ToInt32(cmd1.ExecuteScalar())
                ExerciseDone = Ex
                Dim Query1 As String = "SELECT workout_time FROM workout WHERE user_id = @UserID AND workout_reco = @WorkOutReco "
                Dim cmd2 = New MySqlCommand(Query1, sqlConn)
                cmd2.Parameters.AddWithValue("@UserID", "1")
                cmd2.Parameters.AddWithValue("@WorkOutReco", WorkoutName)
                Dim Ex2 As Object = cmd2.ExecuteScalar()
                If Ex2 IsNot Nothing Then
                    ' Assuming the result is a valid time format (e.g., "hh:mm:ss" or seconds)
                    Dim timeSpan As TimeSpan = TimeSpan.Parse(Ex2.ToString())
                    Dim time As Integer = timeSpan.TotalSeconds
                    WorkoutTime = time
                Else
                    MessageBox.Show("No data returned.")
                End If
                'WorkoutTime = Ex2
                'MessageBox.Show(Ex2)
            Else
                MessageBox.Show("there is no activity yet")
            End If
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            sqlConn.Close()
        End Try
    End Sub
    Private Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        countdown = 1 ' Set the countdown value to 30 seconds
        Guna2HtmlLabel4.Text = countdown.ToString() ' Update the label
        Timer1.Start() ' Start the timer
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
            If Math.Abs(countdown) <= 9 Then
                Guna2HtmlLabel4.Location = New Point(67, 66)
            End If
        Else
            ExerciseDone += 1
            WorkoutTime += 30
            Timer1.Stop() ' Stop the timer when countdown reaches 
            'MessageBox.Show("Time's up!") ' Optional: Show a message when the countdown ends
            Try
                sqlConn.Open()
                Dim time As TimeSpan = TimeSpan.FromSeconds(WorkoutTime)
                Dim formattedTime As String = time.ToString("hh\:mm\:ss")
                Dim checkQuery As String = "SELECT COUNT(*) FROM workout WHERE workout_reco = @WorkOutReco AND user_id = @UserID "
                Dim cmdr = New MySqlCommand(checkQuery, sqlConn)
                cmdr.Parameters.AddWithValue("@UserID", "1")
                cmdr.Parameters.AddWithValue("@WorkOutReco", WorkoutName)
                Dim count As Integer = Convert.ToInt32(cmdr.ExecuteScalar())  ' Get the count of records

                If count > 0 Then
                    ' If the record exists, update the existing record
                    Dim updateQuery As String = "UPDATE workout SET user_id = @UserID, workout_progress = @WorkOutProg, workout_time = @WorkOutTime WHERE workout_reco = @WorkOutReco"
                    Using updateCmd As New MySqlCommand(updateQuery, sqlConn)
                        updateCmd.Parameters.AddWithValue("@UserID", "1")
                        updateCmd.Parameters.AddWithValue("@WorkOutProg", ExerciseDone)
                        updateCmd.Parameters.AddWithValue("@WorkOutTime", formattedTime)
                        updateCmd.Parameters.AddWithValue("@WorkOutReco", WorkoutName)
                        updateCmd.ExecuteNonQuery()  ' Execute the update query
                    End Using
                    MessageBox.Show("Workout data updated successfully!")
                Else
                    Dim query As String = "INSERT INTO workout (user_id, workout_reco, workout_progress, workout_time) 
                                    VALUES (@UserID, @WorkOutReco, @WorkOutProg, @WorkOutTime)"
                    Dim cmds = New MySqlCommand(query, sqlConn)
                    cmds.Parameters.AddWithValue("@UserID", "1")
                    cmds.Parameters.AddWithValue("@WorkOutReco", WorkoutName)
                    cmds.Parameters.AddWithValue("@WorkOutProg", ExerciseDone)
                    cmds.Parameters.AddWithValue("@WorkOutTime", formattedTime)
                    cmds.ExecuteNonQuery()
                    MessageBox.Show("Survey data saved successfully!")
                End If

                ' Validate inputs before proceeding
            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message)
            Finally
                sqlConn.Close()
            End Try
        End If
    End Sub

    Private Sub backbtn_Click(sender As Object, e As EventArgs) Handles backbtn.Click
        Me.Close()
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub

    Private Sub Guna2HtmlLabel4_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel4.Click

    End Sub
End Class