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
    Dim password As String = "123"
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
        Dim W1text As String = "
        1. Prepare Yourself
            - Begin with a 5-minute warm-up to loosen your muscles. Include light stretches, arm 
              circles, and a few jumping jacks.

        2. Set Your Timee
            - Ensure your timer is ready to track your push-up session.

        3. Push-Up Routine
            - Perform 1 set of push-ups, aiming for the best form and effort.
            - Rest for 1-2 minutes between sets.
            - Repeat the routine 3 times today for optimal results.
        
        4. Start the Timer
            - When ready, press Start on your timer and begin your push-ups!

        Stay consistent and focus on proper form. Let’s do this!"

        Dim W2text As String = "
        1. Warm-Up First
           - Start with a 5-minute warm-up** to prepare your muscles. Include dynamic 
             stretches like leg swings, bodyweight lunges, and a few jumping jacks.  

        2. repare Your Timer 
           - Get your timer ready to track your squat session.  

        3. Squat Routine
           - Perform 1 set of squats**, focusing on proper form and depth.  
           - Rest for 1-2 minutes between sets.  
           - Repeat the routine 3 times today for best results.  

        4. Start the Timer
           - Once you’re ready, press Start on your timer and begin your squats!  

        Stay consistent and maintain good form. You’ve got this!"



        Dim W3text As String = "
        1. Warm-Up First
           - Start with a 5-10 minute warm-up to prepare your body. Include light jogging, 
             dynamic stretches (like leg swings and arm circles), and walking lunges to loosen up.  

        2. Prepare Your Timer
           - Ensure your timer is ready to track your running session.  

        3. Running Routine 
           - Complete 1 running session.  
           - Rest for 5-10 minutes between sessions to recover.  
           - Repeat this running routine 3 times today for maximum impact.  

        4. Start the Timer  
           - When ready, press Start on your timer and begin your run!  

        Stay hydrated, and remember to cool down with stretches after completing 
        your routine. Let’s hit the ground running!"


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
        cmd.Parameters.AddWithValue("@UserID", "3")
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
            Return currentProgress
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
            cmdr.Parameters.AddWithValue("@UserID", "3")
            Dim count As Integer = Convert.ToInt32(cmdr.ExecuteScalar())  ' Get the count of records

            If count > 0 Then
                ' Retrieve workout progress for Push-Up, Squats, and Running
                updatedExValue = GetWorkoutProgress("Push-Up")
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