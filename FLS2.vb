Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class FLS2

    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter

    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = ""
    Dim database As String = "fitcheck"
    Private butmap As Bitmap

    Dim weekly_goal As Double
    Dim monthly_goal As Double
    Dim btn As Guna2Button

    Private Sub FLS2Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlConn.ConnectionString = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles backButton.Click
        Dim fls1Form As New FLS1()
        fls1Form.UserID = UserID ' Pass UserID back to FLS1 if needed
        fls1Form.Show()
        Me.Hide()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        If Not ValidateInputs() Then
            Return
        End If

        Try
            sqlConn.Open()

            ' Check if user exists in the survey table
            Dim checkQuery As String = "SELECT COUNT(*) FROM surveys WHERE user_id = @UserID"
            Dim checkCmd As New MySqlCommand(checkQuery, sqlConn)
            checkCmd.Parameters.AddWithValue("@UserID", UserID)
            Dim userExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If userExists = 0 Then
                MessageBox.Show("User does not exist in the survey table. Please check your data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Update query to modify weekly and monthly goals
            Dim query As String = "UPDATE surveys SET weekly_goal = @WeeklyGoal, monthly_goal = @MonthlyGoal WHERE user_id = @UserID"
            Dim cmd = New MySqlCommand(query, sqlConn)
            cmd.Parameters.AddWithValue("@UserID", UserID)
            cmd.Parameters.AddWithValue("@WeeklyGoal", CSng(weekly_goal)) ' Convert to Float
            cmd.Parameters.AddWithValue("@MonthlyGoal", CSng(monthly_goal)) ' Convert to Float

            cmd.ExecuteNonQuery()
            MessageBox.Show("Weekly and Monthly goals saved successfully!")

            ' Update FLS1Status to True after survey completion
            Dim updateStatusQuery As String = "UPDATE USERS SET FLS2Status = True WHERE user_id = @UserID"
            Dim cmdStatus = New MySqlCommand(updateStatusQuery, sqlConn)
            cmdStatus.Parameters.AddWithValue("@UserID", UserID)
            cmdStatus.ExecuteNonQuery()

            ' Navigate to the home page or next step
            Dim homePageForm As New Form1()
            homePageForm.Show()
            Me.Hide()

        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            sqlConn.Close()
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If weekly_goal <= 0 Then
            MessageBox.Show("Weekly goal cannot be empty or zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If monthly_goal <= 0 Then
            MessageBox.Show("Monthly goal cannot be empty or zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    ' Weekly Goal Button Clicks
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnWEEk1.Click
        weekly_goal = 0.25
        UpdateButtonAppearance(sender)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles btnWEEk2.Click
        weekly_goal = 0.5
        UpdateButtonAppearance(sender)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnWEEk3.Click
        weekly_goal = 0.75
        UpdateButtonAppearance(sender)
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles btnWEEk4.Click
        weekly_goal = 1
        UpdateButtonAppearance(sender)
    End Sub

    ' Monthly Goal Button Clicks
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles btnMonth1.Click
        monthly_goal = 0.25
        UpdateButtonAppearance(sender)
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles btnMonth2.Click
        monthly_goal = 0.5
        UpdateButtonAppearance(sender)
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles btnMonth3.Click
        monthly_goal = 0.75
        UpdateButtonAppearance(sender)
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles btnMonth4.Click
        monthly_goal = 1
        UpdateButtonAppearance(sender)
    End Sub

    ' Update Button Appearance Function
    Private Sub UpdateButtonAppearance(clickedButton As Object)
        Try
            ' Reset all buttons to default appearance
            ResetButtonAppearance()

            ' Check the type of the clicked button and cast accordingly
            If TypeOf clickedButton Is Button Then
                Dim button As Button = CType(clickedButton, Button)
                button.BackColor = Color.White ' Highlight with dark orange background
                button.ForeColor = Color.Black ' Change text color to white
            ElseIf TypeOf clickedButton Is Guna.UI2.WinForms.Guna2GradientButton Then
                Dim gunaButton As Guna.UI2.WinForms.Guna2GradientButton = CType(clickedButton, Guna.UI2.WinForms.Guna2GradientButton)
                gunaButton.FillColor = Color.White ' Change the fill color for the start of the gradient
                gunaButton.FillColor2 = Color.White ' Change the fill color for the end of the gradient
                gunaButton.ForeColor = Color.Black ' Change text color to black
            End If
        Catch ex As Exception
            MessageBox.Show("Error in UpdateButtonAppearance: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub


    ' Function to reset button appearance
    Private Sub ResetButtonAppearance()
        ' Reset the appearance of all buttons to the default state
        btnWEEk1.BorderRadius = 10
        btnWEEk2.BorderRadius = 10
        btnWEEk3.BorderRadius = 10
        btnWEEk4.BorderRadius = 10
        btnMonth1.BorderRadius = 10
        btnMonth2.BorderRadius = 10
        btnMonth3.BorderRadius = 10
        btnMonth4.BorderRadius = 10


        ' Reset Guna2GradientButton colors to default (or any other desired default)
        'btnLoseWeight.FillColor = Color.Transparent
        'btnLoseWeight.FillColor2 = Color.Transparent
        'btnLoseWeight.ForeColor = Color.Black
    End Sub
    Public Property UserID As Integer ' Property to hold the user ID

End Class