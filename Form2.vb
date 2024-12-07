Public Class Form2

    ' Declare a counter for tracking the number of clicks
    Private clickCount As Integer = 0
    ' Declare variables for initial positions or sizes of the waterPictureBox and glassImageButton
    Private initialWaterTop As Integer
    Private initialWaterHeight As Integer

    ' When the form loads, capture the initial state of the waterPictureBox
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialWaterTop = waterPicturebox.Top  ' Save the initial top position of the water PictureBox
        initialWaterHeight = waterPicturebox.Height  ' Save the initial height of the water PictureBox
    End Sub

    ' The function for when the glass of water is clicked
    Private Sub glassImageButton_Click(sender As Object, e As EventArgs) Handles glassImageButton.Click
        ' Increase the click count
        clickCount += 1

        ' Move the water up (increase the height or top position)
        If waterPicturebox.Top > initialWaterTop - (waterPicturebox.Height) Then
            waterPicturebox.Top -= 32 ' Adjust this to make the water rise (you can change the 10 value)
        End If

        ' If the user clicks 8 times, show the message box and reset
        If clickCount >= 8 Then
            MessageBox.Show("Congratulations! You've drunk 8 glasses of water!", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset the water level
            waterPicturebox.Top = initialWaterTop
            clickCount = 0 ' Reset click count

            ' Optionally, reset any other things you might want here, like resetting the glass image or other UI elements
        End If
    End Sub

    ' Your existing button click functions
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim nextForm As New Form1()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim nextForm As New Form3()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim nextForm As New Form4()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim nextForm As New Form5()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Dim nextForm As New Form8()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub


End Class




