Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class Form4
    Dim month As Integer
    Dim year As Integer
    Private moodEntries As New Dictionary(Of DateTime, String)
    Private diaryEntries As New Dictionary(Of DateTime, String)
    Private energyEntries As New Dictionary(Of DateTime, Integer)

    Private sqlConn As MySqlConnection
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

        '----------------------Calling LoadmoodEntries() For Emoji ----------------------'
        ' Load diary entries from the database
        LoadmoodEntries(month, year)
        '----------------------Calling LoadmoodEntries() For Emoji ----------------------'

        'DateTime Now = DateTime.Now
        For i = 1 To daysoftheweek - 1
            Dim ucblank = New UserControlBlank()
            daycontainer.Controls.Add(ucblank)
        Next i

        For i = 1 To days
            Dim ucdays As New UserControlDays(i, month, year)
            ucdays.days(i)
            'AddHandler ucdays.Click, Sub(sender, e) ShowForm7AndSaveEntry(ucdays.DDate)
            daycontainer.Controls.Add(ucdays)

            ' Update the UserControlDays with the emoji from the dictionary
            If moodEntries.ContainsKey(ucdays.DDate) Then
                ucdays.SetEmoji(moodEntries(ucdays.DDate))
            End If
            If energyEntries.ContainsKey(ucdays.DDate) Then
                ucdays.setEnergy(energyEntries(ucdays.DDate))
            End If
            If diaryEntries.ContainsKey(ucdays.DDate) Then
                ucdays.setEntry(diaryEntries(ucdays.DDate))
            End If
        Next i
    End Sub

    ' Save the diary entry and emoji to the dictionary
    Public Sub SaveDiaryEntry(entryDate As DateTime, emoji As String)
        moodEntries(entryDate) = emoji
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
        LoadmoodEntries(month, year)
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
            If moodEntries.ContainsKey(ucdays.DDate) Then
                ucdays.SetEmoji(moodEntries(ucdays.DDate))
            End If
            If energyEntries.ContainsKey(ucdays.DDate) Then
                ucdays.setEnergy(energyEntries(ucdays.DDate))
            End If
            If diaryEntries.ContainsKey(ucdays.DDate) Then
                ucdays.setEntry(diaryEntries(ucdays.DDate))
            End If

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
        LoadmoodEntries(month, year)

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
            If moodEntries.ContainsKey(ucdays.DDate) Then
                ucdays.SetEmoji(moodEntries(ucdays.DDate))
            End If
            If energyEntries.ContainsKey(ucdays.DDate) Then
                ucdays.setEnergy(energyEntries(ucdays.DDate))
            End If
            If diaryEntries.ContainsKey(ucdays.DDate) Then
                ucdays.setEntry(diaryEntries(ucdays.DDate))
            End If
        Next i

    End Sub

    '------------------------------------------For Displaying Emojis ------------------------------------------'
    Private Sub LoadmoodEntries(ByVal Mon, ByVal Yer)
        Try
            Dim connString As String = "server=localhost;user id=root;password='123123';database=fitcheck;"
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim sql As String = "SELECT date, mood , energy_level,diary_entry FROM diary WHERE MONTH(date) = @month AND YEAR(date) = @year"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@month", Mon)
                    cmd.Parameters.AddWithValue("@year", Yer)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        moodEntries.Clear() ' Clear the existing diary entries
                        While reader.Read()
                            Dim entryDate As DateTime = reader.GetDateTime("date")
                            Dim mood As String = If(reader.IsDBNull(reader.GetOrdinal("mood")), String.Empty, reader.GetString("mood"))
                            moodEntries(entryDate) = mood
                            Dim energy = If(reader.IsDBNull(reader.GetOrdinal("energy_level")), 0, reader.GetInt32("energy_level"))
                            energyEntries(entryDate) = energy
                            Dim diaryEntry = If(reader.IsDBNull(reader.GetOrdinal("diary_entry")), String.Empty, reader.GetString("diary_entry"))
                            diaryEntries(entryDate) = diaryEntry

                        End While
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("An error occurred while loading diary entries: " & ex.Message)
        End Try
        'Try
        '    Dim connString As String = "server=localhost;user id=root;password='123123';database=fitcheck;"
        '    Using conn As New MySqlConnection(connString)
        '        conn.Open()
        '        Dim sql As String = "SELECT date, mood FROM diary WHERE MONTH(date) = @month AND YEAR(date) = @year"
        '        Using cmd As New MySqlCommand(sql, conn)
        '            cmd.Parameters.AddWithValue("@month", month)
        '            cmd.Parameters.AddWithValue("@year", year)

        '            Using reader As MySqlDataReader = cmd.ExecuteReader()
        '                moodEntries.Clear()
        '                While reader.Read()
        '                    Dim entryDate As DateTime = reader.GetDateTime("date")
        '                    'Dim mood As String = reader.GetString("mood")
        '                    Dim mood As String = String.Empty

        '                    'If Not reader.IsDBNull(reader.GetOrdinal("mood")) Then
        '                    '    Dim todaymood As String = reader.GetString("mood")
        '                    '    moodEntries(entryDate) = mood
        '                    'End If

        '                    If Not reader.IsDBNull(reader.GetOrdinal("mood")) Then
        '                        mood = reader.GetString("mood")
        '                    Else
        '                        mood = "" ' Default or placeholder value End If
        '                    End If
        '                    moodEntries(entryDate) = mood
        '                End While
        '            End Using
        '        End Using
        '    End Using
        'Catch ex As MySqlException
        '    MessageBox.Show("An error occurred while loading diary entries: " & ex.Message)
        'End Try
    End Sub
    'Private Sub OpenForm7()
    '    Dim form7 As New Form7()
    '    ' Subscribe to the DataSaved event
    '    AddHandler form7.DataSaved, AddressOf OnDataSaved
    '    form7.Show()
    'End Sub

    '' Event handler for DataSaved event
    'Private Sub OnDataSaved(sender As Object, e As EventArgs)
    '    RefreshCalendar()
    'End Sub

    Public Sub RefreshCalendar()
        'MessageBox.Show("RefreshCalendar is called.")
        '' Call dispDays to refresh the calendar
        'dispDays()

        ' Clear existing entries
        daycontainer.Controls.Clear()
        dispDays()
        ' Fetch all diary entries
        Dim allEntries As New List(Of DiaryEntry)
        Try
            Dim connString As String = "server=localhost;user id=root;password='123123';database=fitcheck;"
            Dim conn As New MySqlConnection(connString)
            conn.Open()
            Dim sql As String = "SELECT * FROM diary"
            Dim cmd As MySqlCommand = conn.CreateCommand()
            cmd.CommandText = sql
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim entry As New DiaryEntry()
                entry.UserId = reader("user_id")
                entry.Date = reader("date")
                entry.DiaryEntry = reader("diary_entry")
                entry.Mood = If(IsDBNull(reader("mood")), String.Empty, reader("mood").ToString())
                entry.Energy = If(IsDBNull(reader("energy_level")), 0, Convert.ToInt32(reader("energy_level")))
                allEntries.Add(entry)
            End While
            'MessageBox.Show()
            reader.Close()
            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show("An error occurred while fetching entries: " & ex.Message)
        End Try

        ' Load the entries into the calendar
        'LoadmoodEntries(allEntries)

        'MessageBox.Show("Calendar refreshed!")
    End Sub
    Public Class DiaryEntry
        Public Property UserId As String
        Public Property [Date] As Date
        Public Property DiaryEntry As String
        Public Property Mood As String
        Public Property Energy As Integer
    End Class

    'Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
    '    Guna2GradientButton1.Enabled = False
    '    daycontainer.Controls.Clear()
    '    RefreshCalendar()

    '    Guna2GradientButton1.Enabled = True
    'End Sub

End Class