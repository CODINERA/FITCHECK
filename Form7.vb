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
    Public Energy As Integer
    Dim button As Guna2CircleButton
    Dim Rating As Integer
    Public userEntry As String
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
        If txtDiary.Text Is "" Then
            txtDiary.Text = "Today..."
        Else
            txtDiary.Text = userEntry
        End If

        txtDiary.ForeColor = Color.Gray
        InitializeLabels()
        For i As Integer = 0 To Energy - 1
            Select Case i
                Case 0
                    pbEnergy1.BackgroundImage = My.Resources.energy_filled
                Case 1
                    pbEnergy2.BackgroundImage = My.Resources.energy_filled
                Case 2
                    pbEnergy3.BackgroundImage = My.Resources.energy_filled
                Case 3
                    pbEnergy4.BackgroundImage = My.Resources.energy_filled
                Case 4
                    pbEnergy5.BackgroundImage = My.Resources.energy_filled
            End Select
        Next i
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
            savelbl.Enabled = False
            ' Define the SQL query to check if an entry already exists for the given user_id and date
            Dim checkSql As String = "SELECT COUNT(*) FROM diary WHERE user_id = @user_id AND date = @date"
            Dim checkCmd As New MySqlCommand(checkSql, sqlConn)
            checkCmd.Parameters.AddWithValue("@user_id", "3") ' Use the logged-in user ID
            checkCmd.Parameters.AddWithValue("@date", databaseDate)

            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If count > 0 Then
                ' If an entry exists, update the diary entry
                Dim updateSql As String = "UPDATE diary SET diary_entry = @diary_entry, mood = @mood,energy_level = @energy WHERE user_id = @user_id AND date = @date"
                Dim updateCmd As New MySqlCommand(updateSql, sqlConn)

                updateCmd.Parameters.AddWithValue("@user_id", "3") ' Use the logged-in user ID
                updateCmd.Parameters.AddWithValue("@date", databaseDate)
                updateCmd.Parameters.AddWithValue("@diary_entry", txtDiary.Text)
                updateCmd.Parameters.AddWithValue("@energy", Energy)
                If selectedEmoji IsNot "" Then
                    updateCmd.Parameters.AddWithValue("@mood", selectedEmoji)
                Else
                    updateCmd.Parameters.AddWithValue("@mood", DBNull.Value)
                End If

                updateCmd.ExecuteNonQuery()
                'MessageBox.Show("Diary entry updated.")
            Else
                ' If no entry exists, insert a new entry
                Dim insertSql As String = "INSERT INTO diary(user_id, date, diary_entry, mood,energy_level) VALUES(@user_id, @date, @diary_entry, @mood,@energy)"
                Dim insertCmd As New MySqlCommand(insertSql, sqlConn)

                insertCmd.Parameters.AddWithValue("@user_id", "3") ' Use the logged-in user ID
                insertCmd.Parameters.AddWithValue("@date", databaseDate)
                insertCmd.Parameters.AddWithValue("@diary_entry", txtDiary.Text)
                insertCmd.Parameters.AddWithValue("@energy", Energy)
                If selectedEmoji IsNot "" Then
                    insertCmd.Parameters.AddWithValue("@mood", selectedEmoji)
                Else
                    insertCmd.Parameters.AddWithValue("@mood", DBNull.Value)
                End If

                insertCmd.ExecuteNonQuery()
                'MessageBox.Show("New diary entry saved.")
            End If

            sqlConn.Close()
            Form4.RefreshCalendar()
            Me.Close()
        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            ' Ensure the button is re-enabled in case of an error
            savelbl.Enabled = True
        End Try

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

    Private Sub Energy_Click(sender As Object, e As EventArgs) Handles pbEnergy1.Click, pbEnergy2.Click, pbEnergy3.Click, pbEnergy4.Click, pbEnergy5.Click
        button = sender
        Rating = CInt(button.Text)
        pbEnergy1.BackgroundImage = My.Resources.energy_empty
        pbEnergy2.BackgroundImage = My.Resources.energy_empty
        pbEnergy3.BackgroundImage = My.Resources.energy_empty
        pbEnergy4.BackgroundImage = My.Resources.energy_empty
        pbEnergy5.BackgroundImage = My.Resources.energy_empty
        For i As Integer = 0 To Rating - 1
            Select Case i
                Case 0
                    pbEnergy1.BackgroundImage = My.Resources.energy_filled
                    Energy = i + 1
                Case 1
                    pbEnergy2.BackgroundImage = My.Resources.energy_filled
                    Energy = i + 1
                Case 2
                    pbEnergy3.BackgroundImage = My.Resources.energy_filled
                    Energy = i + 1
                Case 3
                    pbEnergy4.BackgroundImage = My.Resources.energy_filled
                    Energy = i + 1
                Case 4
                    pbEnergy5.BackgroundImage = My.Resources.energy_filled
                    Energy = i + 1
            End Select
        Next i
        Energy = Rating
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub
End Class