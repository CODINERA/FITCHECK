Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class Form1

    ' Declare the previous button globally
    Private previousButton As Guna.UI2.WinForms.Guna2GradientButton

    ' Initialize the previousButton to null in the form's load event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        previousButton = Nothing
    End Sub
    ' Handler for the btnHomepage click event
    Private Sub btnHomepage_Click(sender As Object, e As EventArgs) Handles btnHomepage.Click
        ' Open the homepage form or desired action
        Dim nextForm As New Form1() ' Replace with actual form logic (homepage form)
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnSettings click event
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' Navigate to settings form
        Dim nextForm As New Form8() ' Replace with actual form logic (settings form)
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnUserActivity click event
    Private Sub btnUserActivity_Click(sender As Object, e As EventArgs) Handles btnUserActivity.Click
        ' Navigate to user activity form
        Dim nextForm As New Form2() ' Replace with actual form logic (user activity form)
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnNutrition click event
    Private Sub btnNutrition_Click(sender As Object, e As EventArgs) Handles btnNutrition.Click
        ' Navigate to nutrition form
        Dim nextForm As New Form3() ' Replace with actual form logic (nutrition form)
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnDiary click event
    Private Sub btnDiary_Click(sender As Object, e As EventArgs) Handles btnDiary.Click
        ' Navigate to diary form
        Dim nextForm As New Form4() ' Replace with actual form logic (diary form)
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnProgress click event
    Private Sub btnProgress_Click(sender As Object, e As EventArgs) Handles btnProgress.Click
        ' Navigate to progress form
        Dim nextForm As New Form5() ' Replace with actual form logic (progress form)
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub


    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        Process.Start("https://youtu.be/FFlAcBTd_K0?si=spLQasnoZ6Mj_3SG")
    End Sub

    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton2.Click
        Process.Start("https://youtu.be/p-R0HSfL6nw?si=baVWxv5RLz6wDv8p")
    End Sub

    Private Sub Guna2ImageButton3_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton3.Click
        Process.Start("https://youtu.be/6gvmcqr226U?si=kWbCQW9qd_N_SR3T")
    End Sub

End Class




