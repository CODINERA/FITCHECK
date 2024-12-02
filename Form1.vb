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
        UpdateButtonAppearance(DirectCast(sender, Guna.UI2.WinForms.Guna2GradientButton))
        ' Open the homepage form or desired action
        Dim nextForm As New Form1() ' Replace with actual form logic
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnSettings click event
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        UpdateButtonAppearance(DirectCast(sender, Guna.UI2.WinForms.Guna2GradientButton))
        Dim nextForm As New Form8()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnUserActivity click event
    Private Sub btnUserActivity_Click(sender As Object, e As EventArgs) Handles btnUserActivity.Click
        UpdateButtonAppearance(DirectCast(sender, Guna.UI2.WinForms.Guna2GradientButton))
        Dim nextForm As New Form2()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnNutrition click event
    Private Sub btnNutrition_Click(sender As Object, e As EventArgs) Handles btnNutrition.Click
        UpdateButtonAppearance(DirectCast(sender, Guna.UI2.WinForms.Guna2GradientButton))
        Dim nextForm As New Form3()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnDiary click event
    Private Sub btnDiary_Click(sender As Object, e As EventArgs) Handles btnDiary.Click
        UpdateButtonAppearance(DirectCast(sender, Guna.UI2.WinForms.Guna2GradientButton))
        Dim nextForm As New Form4()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Handler for the btnProgress click event
    Private Sub btnProgress_Click(sender As Object, e As EventArgs) Handles btnProgress.Click
        UpdateButtonAppearance(DirectCast(sender, Guna.UI2.WinForms.Guna2GradientButton))
        Dim nextForm As New Form5()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    ' Minimize window event
    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    ' Close window event
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
    End Sub

    ' Method to update the appearance of the clicked button
    Private Sub UpdateButtonAppearance(clickedButton As Guna.UI2.WinForms.Guna2GradientButton)
        ' Check if previousButton is not null
        If previousButton IsNot Nothing Then
            ' Reset the gradient of the previous button to its original colors
            previousButton.FillColor = Color.Transparent ' Set gradient background color back to default
            previousButton.FillColor2 = Color.Transparent ' Set the other gradient color back to default
            previousButton.BorderColor = Color.Transparent ' Optionally reset border color
        End If

        ' Highlight the clicked button by changing its gradient colors
        clickedButton.FillColor = Color.DarkBlue ' Change the first gradient color to blue
        clickedButton.FillColor2 = Color.LightBlue ' Change the second gradient color to light blue


        ' Update previousButton to the currently clicked button
        previousButton = clickedButton
    End Sub
End Class



