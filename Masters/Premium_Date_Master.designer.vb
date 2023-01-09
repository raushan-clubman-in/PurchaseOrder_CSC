<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Premium_Date_Master
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Premium_Date_Master))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label_Freeze = New System.Windows.Forms.Label()
        Me.Cmd_CodeHelp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Desc_txtbox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Premiumdate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BTN_SAVE = New System.Windows.Forms.Button()
        Me.BTN_FREEZE = New System.Windows.Forms.Button()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.BTN_EXIT = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(143, -5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Holiday Master"
        '
        'Label_Freeze
        '
        Me.Label_Freeze.AutoSize = True
        Me.Label_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Label_Freeze.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Freeze.Location = New System.Drawing.Point(98, 6)
        Me.Label_Freeze.Name = "Label_Freeze"
        Me.Label_Freeze.Size = New System.Drawing.Size(88, 15)
        Me.Label_Freeze.TabIndex = 15
        Me.Label_Freeze.Text = "Record Freezed"
        '
        'Cmd_CodeHelp
        '
        Me.Cmd_CodeHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_CodeHelp.Image = CType(resources.GetObject("Cmd_CodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_CodeHelp.Location = New System.Drawing.Point(334, 36)
        Me.Cmd_CodeHelp.Name = "Cmd_CodeHelp"
        Me.Cmd_CodeHelp.Size = New System.Drawing.Size(26, 25)
        Me.Cmd_CodeHelp.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Description"
        '
        'Desc_txtbox
        '
        Me.Desc_txtbox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Desc_txtbox.Location = New System.Drawing.Point(118, 36)
        Me.Desc_txtbox.Name = "Desc_txtbox"
        Me.Desc_txtbox.Size = New System.Drawing.Size(210, 23)
        Me.Desc_txtbox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Premiumdate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Cmd_CodeHelp)
        Me.Panel1.Controls.Add(Me.Label_Freeze)
        Me.Panel1.Controls.Add(Me.Desc_txtbox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 156)
        Me.Panel1.TabIndex = 13
        '
        'Premiumdate
        '
        Me.Premiumdate.Location = New System.Drawing.Point(118, 78)
        Me.Premiumdate.Name = "Premiumdate"
        Me.Premiumdate.Size = New System.Drawing.Size(209, 23)
        Me.Premiumdate.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(71, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Date"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.BTN_SAVE)
        Me.Panel3.Controls.Add(Me.BTN_FREEZE)
        Me.Panel3.Controls.Add(Me.BTN_CLEAR)
        Me.Panel3.Controls.Add(Me.BTN_EXIT)
        Me.Panel3.Location = New System.Drawing.Point(387, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(108, 147)
        Me.Panel3.TabIndex = 30
        '
        'BTN_SAVE
        '
        Me.BTN_SAVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_SAVE.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SAVE.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BTN_SAVE.Location = New System.Drawing.Point(3, 3)
        Me.BTN_SAVE.Name = "BTN_SAVE"
        Me.BTN_SAVE.Size = New System.Drawing.Size(99, 36)
        Me.BTN_SAVE.TabIndex = 27
        Me.BTN_SAVE.Text = "Save"
        Me.BTN_SAVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SAVE.UseVisualStyleBackColor = True
        '
        'BTN_FREEZE
        '
        Me.BTN_FREEZE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_FREEZE.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FREEZE.Location = New System.Drawing.Point(3, 38)
        Me.BTN_FREEZE.Name = "BTN_FREEZE"
        Me.BTN_FREEZE.Size = New System.Drawing.Size(99, 33)
        Me.BTN_FREEZE.TabIndex = 28
        Me.BTN_FREEZE.Text = "Freeze"
        Me.BTN_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_FREEZE.UseVisualStyleBackColor = True
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_CLEAR.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CLEAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CLEAR.Location = New System.Drawing.Point(3, 70)
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        Me.BTN_CLEAR.Size = New System.Drawing.Size(99, 34)
        Me.BTN_CLEAR.TabIndex = 29
        Me.BTN_CLEAR.Text = "Clear"
        Me.BTN_CLEAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CLEAR.UseVisualStyleBackColor = True
        '
        'BTN_EXIT
        '
        Me.BTN_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_EXIT.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_EXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_EXIT.Location = New System.Drawing.Point(3, 104)
        Me.BTN_EXIT.Name = "BTN_EXIT"
        Me.BTN_EXIT.Size = New System.Drawing.Size(99, 37)
        Me.BTN_EXIT.TabIndex = 30
        Me.BTN_EXIT.Text = "Exit"
        Me.BTN_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_EXIT.UseVisualStyleBackColor = True
        '
        'Premium_Date_Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SmartCard.My.Resources.Resources.Chs_Background_form_new
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(509, 200)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Premium_Date_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HSN Master"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Label_Freeze As Label
    Friend WithEvents GRP_DEPARTMENT As GroupBox
    Friend WithEvents Cmd_CodeHelp As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Desc_txtbox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BTN_SAVE As Button
    Friend WithEvents BTN_FREEZE As Button
    Friend WithEvents BTN_CLEAR As Button
    Friend WithEvents BTN_EXIT As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Premiumdate As DateTimePicker
End Class
