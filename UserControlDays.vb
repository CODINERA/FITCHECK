Public Class UserControlDays
    Public DDate As DateTime
    Private savedEmoji As String

    'Constructor to initialize the day
    Public Sub New(day As Integer, month As Integer, year As Integer)
        InitializeComponent()
        DDate = New DateTime(year, month, day)
        lbldays.Text = day.ToString()
    End Sub
    Public Sub days(numday As Integer)
        lbldays.Text = numday.ToString() + ""
    End Sub

    ' Method to set and display the emoji
    Public Sub SetEmoji(emoji As String)
        savedEmoji = emoji
        picEmoji.Text = emoji
        picEmoji.Visible = True
    End Sub

    ' Helper method to get the emoji image based on the emoji string
    Private Function GetEmojiImage(emoji As String) As Image
        Select Case emoji
            Case "Excited"
                Return My.Resources.Excited ' Replace with the actual image resource name
            Case "Happy"
                Return My.Resources.Happy ' Replace with the actual image resource name
            Case "Neutral"
                Return My.Resources.Neutral ' Replace with the actual image resource name
            Case "Sad"
                Return My.Resources.Sad ' Replace with the actual image resource name
            Case "Angry"
                Return My.Resources.Angry ' Replace with the actual image resource name
            Case Else
                Return Nothing
        End Select
    End Function


    Private Sub UserControlDays_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Dim Diary As New Form7()

        Diary.SetDiaryDate(DDate)
        Diary.Show()
    End Sub
End Class
