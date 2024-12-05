Imports Guna.UI2.WinForms
Public Class Form5

    Dim daysDone As Integer
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

    Private Sub Guna2CircleProgressBar1_ValueChanged(sender As Object, e As EventArgs) Handles Guna2CircleProgressBar1.ValueChanged




    End Sub
    Private Sub test()
        Dim WorkoutF As New Form6()
        If WorkoutF IsNot Nothing Then
            'Guna2HtmlLabel6.Text = WorkoutF.ExcersisDone

            If WorkoutF.ExcersisDone <> 0 Then

                ' Check if ExcersisDone is divisible by 3
                If WorkoutF.ExcersisDone Mod 3 = 0 Then
                    daysDone += 1
                End If

                ' Update progress bar and labels based on daysDone
                For i As Integer = 0 To daysDone - 1
                    ' Ensure the progress bar does not exceed its max value (100)
                    If Guna2CircleProgressBar1.Value < 100 Then
                        Guna2CircleProgressBar1.Value += 14.285714285714286
                    Else
                        Guna2CircleProgressBar1.Value = 100 ' Cap the value at 100 if it exceeds
                    End If

                    ' Declare a variable to hold the parsed value of the label
                    Dim currentVal As Double

                    ' Safely update the labels by parsing the current text and adding 14.28
                    If Double.TryParse(Guna2HtmlLabel6.Text, currentVal) Then
                        Guna2HtmlLabel6.Text = (currentVal + 14.28).ToString("0.00")
                    Else
                        ' If parsing fails, initialize the label with 14.28
                        Guna2HtmlLabel6.Text = "14.28"
                    End If

                    If Double.TryParse(Guna2HtmlLabel7.Text, currentVal) Then
                        Guna2HtmlLabel7.Text = (currentVal + 14.28).ToString("0.00")
                    Else
                        ' If parsing fails, initialize the label with 14.28
                        Guna2HtmlLabel7.Text = "14.28"
                    End If

                    If Double.TryParse(Guna2HtmlLabel8.Text, currentVal) Then
                        Guna2HtmlLabel8.Text = (currentVal + 14.28).ToString("0.00")
                    Else
                        ' If parsing fails, initialize the label with 14.28
                        Guna2HtmlLabel8.Text = "14.28"
                    End If
                Next i
            End If
        End If
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim WorkoutF As New Form6()


        test()
    End Sub
End Class