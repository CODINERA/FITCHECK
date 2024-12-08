Imports System.Globalization
Imports System.Management.Instrumentation
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class Form7
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter

    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "123"
    Dim database As String = "fitcheck"
    Dim databaseDate As String
    Private selectedDate As DateTime
    Public selectedEmoji As String = String.Empty
    Private connectionString As String = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"

    ' List of acceptable ENUM values for mood
    Private ReadOnly moodEnumValues As List(Of String) = New List(Of String) From {
        "Happy", "Sad", "Neutral", "Angry", "Excited"
    }

    Public Sub SetDiaryDate(selectedDate As DateTime)
        'selectedDate = Date 'where are u getting this from the Date ?
        'selectedDate As DateTime, [date] As Date)
        lblDate.Text = selectedDate.ToString("MMMM d, yyyy")
        databaseDate = selectedDate.ToString("yyyy-MM-dd")
        'Return selectedDate.ToString("yyyy-MM-dd")
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlConn.ConnectionString = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"
        txtDiary.Text = "Today..."
        txtDiary.ForeColor = Color.Gray
        InitializeLabels()

        '' Set button texts to match ENUM valuess
        'btnExcited.Text = "Excited"
        'btnHappy.Text = "Happy"
        'btnNeutral.Text = "Neutral"
        'btnSad.Text = "Sad"
        'btnAngry.Text = "Angry"

        ' Initialize Guna2CircleButtons with names pbEnergy1, pbEnergy2, pbEnergy3, pbEnergy4, pbEnergy5
        'For i As Integer = 1 To 5
        '    Dim pbEnergy As New Guna2CircleButton()
        '    pbEnergy.Name = "pbEnergy" & i
        '    pbEnergy.Image = My.Resources.energy_empty

        '    'pbEnergy.Location = New Point(50 * i, 50)
        '    'pbEnergy.Size = New Size(40, 40)
        '    AddHandler pbEnergy.Click, AddressOf Energy_CLick
        '    Me.Controls.Add(pbEnergy)
        'Next
    End Sub

    ' Define labels for the emoji buttons
    Private Sub InitializeLabels()
        lblExcited.Text = "Excited"
        lblHappy.Text = "Happy"
        lblNeutral.Text = "Neutral"
        lblSad.Text = "Sad"
        lblAngry.Text = "Angry"
    End Sub

    Private Sub txtBox_Enter(sender As Object, e As EventArgs) Handles txtDiary.Enter
        If txtDiary.Text = "Today..." Then
            txtDiary.Text = String.Empty
            txtDiary.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtDiary_Leave(sender As Object, e As EventArgs) Handles txtDiary.Leave
        If txtDiary.Text = String.Empty Then
            txtDiary.Text = "Today..."
            txtDiary.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub backlbl_Click(sender As Object, e As EventArgs) Handles backlbl.Click
        Me.Close()
    End Sub

    'Private Sub UpdateEnergy(rating As Integer)
    '    ' Set all stars to empty first
    '    For i As Integer = 1 To 5
    '        Dim pbEnergy As Guna2CircleButton = CType(Me.Controls("pbEnergy" & i), Guna2CircleButton)
    '        If pbEnergy IsNot Nothing Then
    '            pbEnergy.Image = My.Resources.energy_empty
    '        End If
    '    Next

    '    ' Fill the stars up to the rating value
    '    For i As Integer = 1 To rating
    '        Dim pbEnergy As Guna2CircleButton = CType(Me.Controls("pbEnergy" & i), Guna2CircleButton)
    '        If pbEnergy IsNot Nothing Then
    '            pbEnergy.Image = My.Resources.energy_filled
    '        End If
    '    Next

    'End Sub

    'Private Sub Energy_CLick(sender As Object, e As EventArgs) Handles pbEnergy4.Click, pbEnergy3.Click, pbEnergy2.Click, pbEnergy1.Click, pbEnergy5.Click
    '    Dim clickedEnergy As Guna2CircleButton = CType(sender, Guna2CircleButton)
    '    Dim energyNumber As Integer = CInt(clickedEnergy.Name.Substring(8)) ' Extract number from "pbEnergyX"
    '    UpdateEnergy(energyNumber)
    'End Sub

    ' Property to get the diary entry text
    Public ReadOnly Property DiaryEntry As String
        Get
            Return txtDiary.Text
        End Get
    End Property

    ' Property to get the selected emoji
    Public ReadOnly Property EmojiSelected As String
        Get
            Return selectedEmoji
        End Get
    End Property



    Private Sub savelbl_Click(sender As Object, e As EventArgs) Handles savelbl.Click



        Try
            sqlConn.Open()
            'Dim Conn As New MySqlConnection(sqlConn.ConnectionString)

            Dim sql As String = "INSERT INTO diary(user_id, date,diary_entry,mood) values(?,?,?,?)"
            Dim cmd As MySqlCommand = sqlConn.CreateCommand()
            cmd.CommandText = sql
            'cmd.Parameters.AddWithValue("user_id", LOGDESIGN.LoggedInUserID) ' Use the logged-in user ID
            cmd.Parameters.AddWithValue("user_id", "3") ' Use the logged-in user ID
            'cmd.Parameters.AddWithValue("date", lblDate.Text)
            cmd.Parameters.AddWithValue("date", databaseDate)
            cmd.Parameters.AddWithValue("diary_entry", txtDiary.Text)
            If selectedEmoji IsNot "" Then
                cmd.Parameters.AddWithValue("mood", selectedEmoji)
            Else
                cmd.Parameters.AddWithValue("mood", DBNull.Value)
            End If
            cmd.ExecuteNonQuery()
            MessageBox.Show("Saved")
            'cmd.Dispose()
            sqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show("An error occured: " & ex.Message)
        End Try
        Me.Close()
    End Sub

    'Private Sub lblDate_Click(sender As Object, e As EventArgs) Handles lblDate.Click
    '    Dim monthname As String = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month)
    '    lblDate.Text = monthname & " " & Year()
    'End Sub

    'Private Sub btnEmoji_Click(sender As Object, e As EventArgs, emojiText As String) Handles btnAngry.Click, btnSad.Click, btnNeutral.Click, btnHappy.Click, btnExcited.Click




    'End Sub

    Private Sub btnEmoji_Click(sender As Object, e As EventArgs) Handles btnSad.Click, btnNeutral.Click, btnHappy.Click, btnExcited.Click, btnAngry.Click
        Dim clickedButton As Guna2CircleButton = CType(sender, Guna2CircleButton)
        ' Identify the corresponding label based on the clicked button's name
        Dim emojiText As String = String.Empty
        Select Case clickedButton.Name
            Case "btnExcited"
                emojiText = lblExcited.Text
            Case "btnHappy"
                emojiText = lblHappy.Text
            Case "btnNeutral"
                emojiText = lblNeutral.Text
            Case "btnSad"
                emojiText = lblSad.Text
            Case "btnAngry"
                emojiText = lblAngry.Text
        End Select

        ' Validate the emojiText against the ENUM values
        If moodEnumValues.Contains(emojiText) Then
            selectedEmoji = emojiText
            MessageBox.Show("Valid emoji selection: " & selectedEmoji)
        Else
            MessageBox.Show("Invalid emoji selection. Available moods: " & String.Join(", ", moodEnumValues))
        End If
    End Sub

    Private Sub pbEnergy1_Click(sender As Object, e As EventArgs) Handles pbEnergy1.Click

    End Sub

    'Private Sub SaveEmojiToDatabase(emoji As String)
    '    Try
    '        Using connection As New MySqlConnection(connectionString)
    '            connection.Open()
    '            Dim query As String = "INSERT INTO Diary (mood) VALUES (@mood)"
    '            Using command As New MySqlCommand(query, connection)
    '                command.Parameters.AddWithValue("@mood", emoji)
    '                command.ExecuteNonQuery()
    '            End Using
    '        End Using
    '        MessageBox.Show("Emoji saved successfully!")
    '    Catch ex As MySqlException
    '        MessageBox.Show("An error occurred: " & ex.Message)
    '    End Try
    'End Sub
End Class