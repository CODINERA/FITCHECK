Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class Form5
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter
    Public updatedExValue As Integer
    Public updatedExValue2 As Integer
    Public updatedExValue3 As Integer
    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "123456"
    Dim database As String = "fitcheck"
    Private butmap As Bitmap
    Dim daysDone As Integer
    Dim Progressed As Boolean = True

    Private Sub Guna2Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim form2 As New Form2()
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Dim form3 As New Form3()
        form3.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Dim form4 As New Form4()
        form4.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        Dim nextForm As New Form8()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Workout(sender As Object, e As EventArgs) Handles W3.Click, W2.Click, W1.Click, Guna2GradientPanel1.Click
        Dim WorkoutF As New Form6()
        Dim button As Guna2Button = sender
        WorkoutF.WorkoutName = button.Text
        Dim W1text As String = "this is a push up workout"
        Dim W2text As String = "this is a squats workout"
        Dim W3text As String = "this is a Running workout"
        If button.Name = "W1" Then
            WorkoutF.Workoutdesc = W1text
        ElseIf button.Name = "W2" Then
            WorkoutF.Workoutdesc = W2text
        ElseIf button.Name = "W3" Then
            WorkoutF.Workoutdesc = W3text
        Else
            WorkoutF.Workoutdesc = "Nothing to show here"
        End If

        'If Not String.IsNullOrEmpty(button.Text) Then
        '    Workout.WorkoutName = button.Text
        'Else
        '    ' Optionally handle the case where the button text is empty or invalid
        '    MessageBox.Show("No workout name assigned to the button!")
        '    Return
        'End If


        WorkoutF.Show()
    End Sub
    Private Function GetWorkoutProgress(workoutReco As String) As Integer
        Dim Query As String = "SELECT workout_progress FROM workout WHERE user_id = @UserID AND workout_reco = @WorkOutReco"
        Dim cmd = New MySqlCommand(Query, sqlConn)
        cmd.Parameters.AddWithValue("@UserID", "1")
        cmd.Parameters.AddWithValue("@WorkOutReco", workoutReco)
        Dim currentProgress As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        Dim newProgress As Integer = updatedExValue ' Assuming updatedExValue is the new progress value
        'MessageBox.Show(newProgress + " " + currentProgress)

        If currentProgress <> newProgress Then

            Return Convert.ToInt32(cmd.ExecuteScalar())

        Else
            Progressed = False
            ' If the data hasn't changed, display a message or skip the update
            MessageBox.Show("No changes detected. Progress remains the same.")
        End If
    End Function
    Private Sub UpdateProgress(progressBar As Guna.UI2.WinForms.Guna2CircleProgressBar, label As Guna.UI2.WinForms.Guna2HtmlLabel, updatedExValue As Integer)
        If updatedExValue <> 0 Then
            Dim daysDone As Integer = updatedExValue \ 3 ' Integer division to get full days
            For i As Integer = 0 To daysDone - 1
                ' Update progress bar
                If progressBar.Value < 100 Then
                    progressBar.Value += 14.285714285714286 ' Increase by 14.28 each iteration
                Else
                    progressBar.Value = 100
                    Exit For
                End If

                ' Update label text
                Dim currentVal As Double
                If Double.TryParse(label.Text, currentVal) Then
                    label.Text = (currentVal + 14.28).ToString("0.00")
                    label.Location = New Point(40, 55)
                Else
                    label.Text = "14.28"
                End If
            Next i
        End If
    End Sub
    Private Sub MainFunction()
        Try
            sqlConn.Open()
            Dim checkQuery As String = "SELECT COUNT(*) FROM workout WHERE user_id = @UserID "
            Dim cmdr = New MySqlCommand(checkQuery, sqlConn)
            cmdr.Parameters.AddWithValue("@UserID", "1")
            Dim count As Integer = Convert.ToInt32(cmdr.ExecuteScalar())  ' Get the count of records

            If count > 0 Then
                ' Retrieve workout progress for Push-Up, Squats, and Running
                updatedExValue = GetWorkoutProgress("Push-UP")
                updatedExValue2 = GetWorkoutProgress("Squats")
                updatedExValue3 = GetWorkoutProgress("Running")
            Else
                MessageBox.Show("There is no activity yet.")
            End If
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            sqlConn.Close()
        End Try
        If Progressed Then
            ' Update progress for each exercise
            UpdateProgress(Guna2CircleProgressBar1, Guna2HtmlLabel6, updatedExValue)
            UpdateProgress(Guna2CircleProgressBar2, Guna2HtmlLabel7, updatedExValue2)
            UpdateProgress(Guna2CircleProgressBar3, Guna2HtmlLabel8, updatedExValue3)
        End If

    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim WorkoutF As New Form6()
        sqlConn.ConnectionString = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"
        MainFunction()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        MainFunction()
    End Sub
End Class