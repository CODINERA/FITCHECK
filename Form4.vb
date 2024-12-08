Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class Form4
    Dim month As Integer
    Dim year As Integer
    Private diaryEntries As New Dictionary(Of DateTime, String)
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim nextForm As New Form1()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim nextForm As New Form2()
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
    Private Sub dispDays()
        Dim now As DateTime = DateTime.Now
        month = DateTime.Now.Month
        year = DateTime.Now.Year

        Dim monthname As String = DateTimeFormatInfo.CurrentInfo.GetMonthName(month)
        lbldate.Text = monthname & " " & year
        Dim Startofthemonth = New DateTime(year, month, 1)

        Dim days = DateTime.DaysInMonth(year, month)
        Dim daysoftheweek = Convert.ToInt32(Startofthemonth.DayOfWeek.ToString("d")) + 1

        ' Clear the container before adding new controls
        'daycontainer.Controls.Clear()

        'DateTime Now = DateTime.Now
        For i = 1 To daysoftheweek - 1
            Dim ucblank = New UserControlBlank()
            daycontainer.Controls.Add(ucblank)
        Next i

        For i = 1 To days
            Dim ucdays As New UserControlDays(i, month, year)
            ucdays.days(i)
            AddHandler ucdays.Click, Sub(sender, e) ShowForm7AndSaveEntry(ucdays.DDate)
            daycontainer.Controls.Add(ucdays)

            ' Update the UserControlDays with the emoji from the dictionary
            If diaryEntries.ContainsKey(ucdays.DDate) Then
                ucdays.SetEmoji(diaryEntries(ucdays.DDate))
            End If
        Next i
    End Sub

    ' Save the diary entry and emoji to the dictionary
    Public Sub SaveDiaryEntry(entryDate As DateTime, emoji As String)
        diaryEntries(entryDate) = emoji
    End Sub

    Private Sub ShowForm7AndSaveEntry(entryDate As DateTime)
        Dim form7 As New Form7()
        form7.SetDiaryDate(entryDate)
        If form7.ShowDialog() = DialogResult.OK Then
            SaveDiaryEntry(entryDate, form7.selectedEmoji)
            dispDays() ' Refresh the days to show updated emojis
        End If
    End Sub


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the start position to center screen
        Me.StartPosition = FormStartPosition.CenterScreen
        dispDays()
    End Sub

    Private Sub lblNext_Click(sender As Object, e As EventArgs) Handles lblNext.Click
        'clear container
        daycontainer.Controls.Clear()

        'increment month to go to next month
        month += 1

        If month > 12 Then
            month = 1
            year += 1
        End If

        Dim monthname As String = DateTimeFormatInfo.CurrentInfo.GetMonthName(month)
        lbldate.Text = monthname & " " & year

        Dim Startofthemonth = New DateTime(year, month, 1)

        Dim days = DateTime.DaysInMonth(year, month)
        Dim daysoftheweek = Convert.ToInt32(Startofthemonth.DayOfWeek.ToString("d")) + 1
        'DateTime Now = DateTime.Now
        For i = 1 To daysoftheweek - 1
            Dim ucblank = New UserControlBlank()
            daycontainer.Controls.Add(ucblank)
        Next i

        For i = 1 To days
            Dim ucdays As New UserControlDays(i, month, year)
            ucdays.days(i)
            'ucdays.month = monthname
            'ucdays.year = year
            daycontainer.Controls.Add(ucdays)
        Next i
    End Sub

    Private Sub lblPrev_Click(sender As Object, e As EventArgs) Handles lblPrev.Click
        daycontainer.Controls.Clear()

        'decrement month to go to prev month
        month -= 1

        If month < 1 Then
            month = 12
            year -= 1
        End If

        Dim monthname As String = DateTimeFormatInfo.CurrentInfo.GetMonthName(month)
        lbldate.Text = monthname & " " & year

        Dim Startofthemonth = New DateTime(year, month, 1)

        Dim days = DateTime.DaysInMonth(year, month)
        Dim daysoftheweek = Convert.ToInt32(Startofthemonth.DayOfWeek.ToString("d")) + 1
        'DateTime Now = DateTime.Now
        For i = 1 To daysoftheweek - 1
            Dim ucblank = New UserControlBlank()

            daycontainer.Controls.Add(ucblank)
        Next i

        For i = 1 To days
            Dim ucdays As New UserControlDays(i, month, year)
            ucdays.days(i)
            'ucdays.month = monthname
            'ucdays.year = year
            daycontainer.Controls.Add(ucdays)
        Next i

    End Sub


End Class