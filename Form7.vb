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
    Public ddate As String

    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "123"
    Dim database As String = "fitcheck"
    Dim databaseDate As String
    ''---------- Other Refresh Logic ----------'
    'Public Event DataSaved As EventHandler
    Private selectedDate As DateTime
    Public selectedEmoji As String = String.Empty
    Private connectionString As String = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"

    ' List of acceptable ENUM values for mood
    Private ReadOnly moodEnumValues As List(Of String) = New List(Of String) From {
        "Happy", "Sad", "Neutral", "Angry", "Excited"
    }

    Public Sub SetDiaryDate(selectedDate As DateTime)
        lblDate.Text = selectedDate.ToString("MMMM d, yyyy")
        databaseDate = selectedDate.ToString("yyyy-MM-dd")
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlConn.ConnectionString = "server=" + Server + ";user id=" + username + ";password=" + password + ";database=" + database + ";"
        txtDiary.Text = "Today..."
        txtDiary.ForeColor = Color.Gray
        InitializeLabels()
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

            cmd.Parameters.AddWithValue("user_id", "3") ' Use the logged-in user ID
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

            '------------------------------Testing for Refresh Calendar!!!--------------------------------'
            '' Call the method in Form4 to refresh the calendar
            'If Me.Owner IsNot Nothing Then
            '    MessageBox.Show("Owner is not Nothing, proceeding to refresh.")
            '    CType(Me.Owner, Form4).RefreshCalendar()
            'Else
            '    MessageBox.Show("Owner is Nothing, cannot refresh.")
            'End

            ''------------------------------ Other Refresh Logic -------------------------------'
            '' Raise the DataSaved event
            'RaiseEvent DataSaved(Me, EventArgs.Empty)

        Catch ex As MySqlException
            MessageBox.Show("An error occured: " & ex.Message)
        End Try
        '' Debug to ensure this line is reached
        MessageBox.Show("Closing Form7")
        Me.Close()
    End Sub

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


End Class