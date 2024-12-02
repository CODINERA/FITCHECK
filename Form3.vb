Public Class Form3

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint
    End Sub

    Private Sub Guna2Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel4.Paint
    End Sub

    Private Sub Guna2Panel8_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Guna2GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2GradientPanel1.Paint
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim form2 As New Form2()
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim form4 As New Form4()
        form4.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim form5 As New Form5()
        form5.Show()
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


    Private Sub Guna2Panel6_Click(sender As Object, e As EventArgs) Handles Guna2Panel6.Click
        Dim form9 As New Form9()
        form9.StartPosition = FormStartPosition.CenterScreen
        form9.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Panel7_Click(sender As Object, e As EventArgs) Handles Guna2Panel7.Click
        Dim form9 As New Form9()
        form9.StartPosition = FormStartPosition.CenterScreen
        form9.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Panel10_Click(sender As Object, e As EventArgs) Handles Guna2Panel10.Click
        Dim form9 As New Form9()
        form9.StartPosition = FormStartPosition.CenterScreen
        form9.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        ' Set alignment for the input TextBox to upper-left
        Guna2TextBox1.TextAlign = HorizontalAlignment.Left
        Guna2TextBox1.Padding = New Padding(0) ' Optional: Ensure padding is set to 0 to avoid shifting the text
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        ' Get the input from the main TextBox
        Dim inputText As String = Guna2TextBox1.Text

        ' Check if an item is selected in the ComboBox
        If Guna2ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a meal from the dropdown.")
            Exit Sub
        End If

        ' Check the selected item in the ComboBox and append to the corresponding TextBox
        Select Case Guna2ComboBox1.SelectedItem.ToString()
            Case "Breakfast"
                ' Append the new text with a comma if there's already text in the Breakfast TextBox
                Guna2Panel11.Text &= If(Guna2Panel11.Text = "", "", ", ") & inputText
            Case "Lunch"
                ' Append the new text with a comma if there's already text in the Lunch TextBox
                Guna2Panel12.Text &= If(Guna2Panel12.Text = "", "", ", ") & inputText
            Case "Snacks"
                ' Append the new text with a comma if there's already text in the Snacks TextBox
                Guna2Panel13.Text &= If(Guna2Panel13.Text = "", "", ", ") & inputText
            Case "Dinner"
                ' Append the new text with a comma if there's already text in the Dinner TextBox
                Guna2Panel14.Text &= If(Guna2Panel14.Text = "", "", ", ") & inputText
            Case Else
                MessageBox.Show("Invalid selection. Please select a valid meal.")
                Exit Sub
        End Select

        ' Clear the input TextBox after submission and reset the ComboBox
        Guna2TextBox1.Clear()
        Guna2ComboBox1.SelectedItem = Nothing
    End Sub

    ' Handle the Click event for Guna2Panel11
    Private Sub Guna2Panel11_Click(sender As Object, e As EventArgs) Handles Guna2Panel11.Click
        Dim form10 As New Form10()
        form10.StartPosition = FormStartPosition.CenterScreen
        form10.Show()
        Me.Hide()
    End Sub


End Class
