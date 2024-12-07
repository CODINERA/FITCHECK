Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate ComboBox1 with meal options
        Guna2ComboBox1.Items.AddRange(New String() {"Breakfast", "Lunch", "Snack", "Dinner"})
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim form1 As New Form1()
        form1.StartPosition = FormStartPosition.CenterScreen
        form1.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim form2 As New Form2()
        form2.StartPosition = FormStartPosition.CenterScreen
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim form4 As New Form4()
        form4.StartPosition = FormStartPosition.CenterScreen
        form4.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim form5 As New Form5()
        form5.StartPosition = FormStartPosition.CenterScreen
        form5.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Dim nextForm As New Form8()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub


    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        ' Set alignment for the input TextBox to upper-left
        Guna2TextBox1.TextAlign = HorizontalAlignment.Left
        Guna2TextBox1.Padding = New Padding(0) ' Optional: Ensure padding is set to 0 to avoid shifting the text
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        ' Ensure that an item is selected in ComboBox1
        If Guna2ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedMeal As String = Guna2ComboBox1.SelectedItem.ToString()
            Dim inputText As String = Guna2TextBox1.Text

            ' Clear the text in the appropriate panel and set the new text
            Select Case selectedMeal
                Case "Breakfast"
                    Guna2Panel11.Controls.Clear()
                    Dim lbl As New Label()
                    lbl.Text = inputText
                    lbl.AutoSize = True
                    Guna2Panel11.Controls.Add(lbl)
                Case "Lunch"
                    Guna2Panel12.Controls.Clear()
                    Dim lbl As New Label()
                    lbl.Text = inputText
                    lbl.AutoSize = True
                    Guna2Panel12.Controls.Add(lbl)
                Case "Snack"
                    Guna2Panel13.Controls.Clear()
                    Dim lbl As New Label()
                    lbl.Text = inputText
                    lbl.AutoSize = True
                    Guna2Panel13.Controls.Add(lbl)
                Case "Dinner"
                    Guna2Panel14.Controls.Clear()
                    Dim lbl As New Label()
                    lbl.Text = inputText
                    lbl.AutoSize = True
                    Guna2Panel14.Controls.Add(lbl)
                Case Else
                    MessageBox.Show("Please select a valid meal option.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        Else
            MessageBox.Show("Please select a meal option from the dropdown.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Guna2Panel11_Click(sender As Object, e As EventArgs) Handles Guna2Panel11.Click
            ' Assume the text is stored in a label inside Guna2Panel11
            Dim panelText As String = String.Empty
            If Guna2Panel11.Controls.Count > 0 AndAlso TypeOf Guna2Panel11.Controls(0) Is Label Then
                panelText = CType(Guna2Panel11.Controls(0), Label).Text
            End If

            Dim form10 As New Form10()
            form10.StartPosition = FormStartPosition.CenterScreen
            form10.SetPanelText(panelText) ' Pass the panel text to Form10
            form10.Show()
            Me.Hide()
        End Sub

    Private Sub Guna2Panel12_Click(sender As Object, e As EventArgs) Handles Guna2Panel12.Click
        ' Assume the text is stored in a label inside Guna2Panel12
        Dim panelText As String = String.Empty
        If Guna2Panel12.Controls.Count > 0 AndAlso TypeOf Guna2Panel12.Controls(0) Is Label Then
            panelText = CType(Guna2Panel12.Controls(0), Label).Text
        End If

        Dim form10 As New Form10()
        form10.StartPosition = FormStartPosition.CenterScreen
        form10.SetPanelText(panelText) ' Pass the panel text to Form10
        form10.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Panel13_Click(sender As Object, e As EventArgs) Handles Guna2Panel13.Click
        ' Assume the text is stored in a label inside Guna2Panel13
        Dim panelText As String = String.Empty
        If Guna2Panel13.Controls.Count > 0 AndAlso TypeOf Guna2Panel13.Controls(0) Is Label Then
            panelText = CType(Guna2Panel13.Controls(0), Label).Text
        End If

        Dim form10 As New Form10()
        form10.StartPosition = FormStartPosition.CenterScreen
        form10.SetPanelText(panelText) ' Pass the panel text to Form10
        form10.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Panel14_Click(sender As Object, e As EventArgs) Handles Guna2Panel14.Click
        ' Assume the text is stored in a label inside Guna2Panel14
        Dim panelText As String = String.Empty
        If Guna2Panel14.Controls.Count > 0 AndAlso TypeOf Guna2Panel14.Controls(0) Is Label Then
            panelText = CType(Guna2Panel14.Controls(0), Label).Text
        End If

        Dim form10 As New Form10()
        form10.StartPosition = FormStartPosition.CenterScreen
        form10.SetPanelText(panelText) ' Pass the panel text to Form10
        form10.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Panel6_Click(sender As Object, e As EventArgs) Handles Guna2Panel6.Click
        Dim recipeText As String = "Beef Tapa" & vbCrLf &
            "Ingredient: " & vbCrLf &
            "0.5 kg Top Sirloin" & vbCrLf &
            "0.5 sachet MAGGI® Magic Sarap®, to taste" & vbCrLf &
            "2 tbsp MAGGI® Savor Hot Chili" & vbCrLf &
            "0.25 tsp Ground Pepper" & vbCrLf &
            "3 tbsp Brown Sugar" & vbCrLf &
            "4 cloves Garlic" & vbCrLf &
            "2 tbsp Vegetable Oil" & vbCrLf &
            "1 tbsp Spring Onion" & vbCrLf &
            "1 tbsp Toasted Garlic" & vbCrLf & vbCrLf &
            "Step by step Procedure:" & vbCrLf &
            "Step 1 (10mins) Marinate beef with 8g MAGGI Magic Sarap, MAGGI Savor Hot Chili, pepper, sugar and garlic. Set aside for 10mins." & vbCrLf &
            "Step 2 (5mins) Sauté beef in oil over high heat until golden brown." & vbCrLf &
            "Step 3 (5mins) Transfer on a serving plate, top with spring onion and toasted garlic. Serve immediately."

        Dim form9 As New Form9()
            form9.StartPosition = FormStartPosition.CenterScreen
            form9.SetRecipeText(recipeText) ' Pass the recipe text to Form9
            form9.Show()
            Me.Hide()
        End Sub

    Private Sub Guna2Panel7_Click(sender As Object, e As EventArgs) Handles Guna2Panel7.Click
        Dim recipeText As String = "Fried Liempo" & vbCrLf &
            "Ingredients:" & vbCrLf &
            "0.5 kg Pork Belly" & vbCrLf &
            "1 sachet MAGGI® Magic Sarap® 8g" & vbCrLf &
            "4 cloves Garlic" & vbCrLf &
            "0.25 tsp Freshly ground pepper" & vbCrLf &
            "1 cup Vegetable Oil" & vbCrLf &
            "0.25 cup Spiced Vinegar" & vbCrLf & vbCrLf &
            "Step by Step Procedure:" & vbCrLf &
            "Step 1 (5mins) Marinate pork with MAGGI® Magic Sarap®, garlic, and pepper overnight in the refrigerator." & vbCrLf &
            "Step 2 (15mins) Remove pork from the refrigerator 1 hour before cooking. Fry pork in preheated oil until golden brown. Set aside to drain excess oil. Transfer on a serving plate and serve with spiced vinegar."

        Dim form9 As New Form9()
        form9.StartPosition = FormStartPosition.CenterScreen
        form9.SetRecipeText(recipeText) ' Pass the recipe text to Form9
        form9.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Panel10_Click(sender As Object, e As EventArgs) Handles Guna2Panel10.Click
        Dim recipeText As String = "Chicken Tinola " & vbCrLf &
            "Ingredients" & vbCrLf &
            "0.5 kg Chicken Leg" & vbCrLf &
            "2 tbsp Vegetable Oil" & vbCrLf &
            "4 cloves Garlic" & vbCrLf &
            "1 pc Ginger" & vbCrLf &
            "1 pc Onion" & vbCrLf &
            "1 stalk Lemongrass" & vbCrLf &
            "4 cups Water" & vbCrLf &
            "8 g MAGGI® Magic Sarap® 8g" & vbCrLf &
            "1 pc Siling Panigang" & vbCrLf &
            "2 cups Papaya" & vbCrLf &
            "1 g Finger Chili" & vbCrLf & vbCrLf &
            "Step by Step Procedure:" & vbCrLf &
            "Step 1 (5mins) Sauté garlic, ginger, onion, and finger chili in oil. Add chicken and cook for 2mins." & vbCrLf &
            "Step 2 (15mins) Pour water, bring to a boil, skim the scum and simmer for 15 minutes." & vbCrLf &
            "Step 3 (5mins) Add MAGGI® Magic Chicken Cubes. Add papaya and simmer for another 5 minutes." & vbCrLf &
            "Step 4 (1min) Stir in malunggay leaves. Transfer into a serving bowl and serve immediately."

        Dim form9 As New Form9()
        form9.StartPosition = FormStartPosition.CenterScreen
        form9.SetRecipeText(recipeText) ' Pass the recipe text to Form9
        form9.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2GradientPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2Panel11_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel11.Paint

    End Sub
End Class

