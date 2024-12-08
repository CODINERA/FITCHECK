<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlDays
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbldays = New System.Windows.Forms.Label()
        Me.picEmoji = New System.Windows.Forms.PictureBox()
        CType(Me.picEmoji, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbldays
        '
        Me.lbldays.AutoSize = True
        Me.lbldays.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldays.Location = New System.Drawing.Point(6, 32)
        Me.lbldays.Name = "lbldays"
        Me.lbldays.Size = New System.Drawing.Size(21, 14)
        Me.lbldays.TabIndex = 1
        Me.lbldays.Text = "00"
        '
        'picEmoji
        '
        Me.picEmoji.Location = New System.Drawing.Point(49, 9)
        Me.picEmoji.Name = "picEmoji"
        Me.picEmoji.Size = New System.Drawing.Size(40, 40)
        Me.picEmoji.TabIndex = 2
        Me.picEmoji.TabStop = False
        Me.picEmoji.Visible = False
        '
        'UserControlDays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.Controls.Add(Me.picEmoji)
        Me.Controls.Add(Me.lbldays)
        Me.Name = "UserControlDays"
        Me.Size = New System.Drawing.Size(92, 52)
        CType(Me.picEmoji, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'Friend WithEvents lbldays As Label
    'Friend WithEvents picEmoji As PictureBox
    Private lbldays As System.Windows.Forms.Label
    Private picEmoji As System.Windows.Forms.PictureBox
End Class
