<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_IndentTypeMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chk_authorizeduser = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chk_user = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chk_cat = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_hlp = New System.Windows.Forms.Button()
        Me.TXT_INDENTNAME = New System.Windows.Forms.TextBox()
        Me.TXT_INDENTCODE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.BTN_VOID = New System.Windows.Forms.Button()
        Me.BTN_EXIT = New System.Windows.Forms.Button()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.chk_all_cat = New System.Windows.Forms.CheckBox()
        Me.chk_all_user = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(185, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 525)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chk_authorizeduser)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 353)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(652, 162)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Authorizer Details"
        '
        'chk_authorizeduser
        '
        Me.chk_authorizeduser.Enabled = False
        Me.chk_authorizeduser.FormattingEnabled = True
        Me.chk_authorizeduser.Location = New System.Drawing.Point(9, 19)
        Me.chk_authorizeduser.Name = "chk_authorizeduser"
        Me.chk_authorizeduser.Size = New System.Drawing.Size(622, 139)
        Me.chk_authorizeduser.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chk_all_user)
        Me.GroupBox4.Controls.Add(Me.chk_user)
        Me.GroupBox4.Location = New System.Drawing.Point(352, 86)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(301, 250)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Given Rights"
        '
        'chk_user
        '
        Me.chk_user.Cursor = System.Windows.Forms.Cursors.Default
        Me.chk_user.FormattingEnabled = True
        Me.chk_user.Location = New System.Drawing.Point(9, 40)
        Me.chk_user.Name = "chk_user"
        Me.chk_user.Size = New System.Drawing.Size(276, 199)
        Me.chk_user.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chk_all_cat)
        Me.GroupBox3.Controls.Add(Me.chk_cat)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 86)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(301, 250)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Category Items Allowed"
        '
        'chk_cat
        '
        Me.chk_cat.FormattingEnabled = True
        Me.chk_cat.Location = New System.Drawing.Point(9, 40)
        Me.chk_cat.Name = "chk_cat"
        Me.chk_cat.Size = New System.Drawing.Size(276, 199)
        Me.chk_cat.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_hlp)
        Me.GroupBox2.Controls.Add(Me.TXT_INDENTNAME)
        Me.GroupBox2.Controls.Add(Me.TXT_INDENTCODE)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(652, 69)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Indent Detail"
        '
        'btn_hlp
        '
        Me.btn_hlp.Location = New System.Drawing.Point(228, 23)
        Me.btn_hlp.Name = "btn_hlp"
        Me.btn_hlp.Size = New System.Drawing.Size(38, 23)
        Me.btn_hlp.TabIndex = 6
        Me.btn_hlp.Text = "Help"
        Me.btn_hlp.UseVisualStyleBackColor = True
        '
        'TXT_INDENTNAME
        '
        Me.TXT_INDENTNAME.Location = New System.Drawing.Point(424, 25)
        Me.TXT_INDENTNAME.Name = "TXT_INDENTNAME"
        Me.TXT_INDENTNAME.Size = New System.Drawing.Size(222, 20)
        Me.TXT_INDENTNAME.TabIndex = 5
        '
        'TXT_INDENTCODE
        '
        Me.TXT_INDENTCODE.Location = New System.Drawing.Point(123, 24)
        Me.TXT_INDENTCODE.Name = "TXT_INDENTCODE"
        Me.TXT_INDENTCODE.Size = New System.Drawing.Size(100, 20)
        Me.TXT_INDENTCODE.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(301, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Indent Type Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Indent Type Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(182, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INDENT TYPE MASTER"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.BTN_VOID)
        Me.GroupBox6.Controls.Add(Me.BTN_EXIT)
        Me.GroupBox6.Controls.Add(Me.BTN_CLEAR)
        Me.GroupBox6.Controls.Add(Me.btn_add)
        Me.GroupBox6.Location = New System.Drawing.Point(873, 153)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(123, 358)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'BTN_VOID
        '
        Me.BTN_VOID.BackgroundImage = Global.SmartCard.My.Resources.Resources.save
        Me.BTN_VOID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_VOID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BTN_VOID.ForeColor = System.Drawing.Color.Black
        Me.BTN_VOID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_VOID.Location = New System.Drawing.Point(6, 211)
        Me.BTN_VOID.Name = "BTN_VOID"
        Me.BTN_VOID.Size = New System.Drawing.Size(111, 56)
        Me.BTN_VOID.TabIndex = 3
        Me.BTN_VOID.Text = "VOID"
        Me.BTN_VOID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_VOID.UseVisualStyleBackColor = True
        '
        'BTN_EXIT
        '
        Me.BTN_EXIT.BackgroundImage = Global.SmartCard.My.Resources.Resources._Exit
        Me.BTN_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_EXIT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BTN_EXIT.ForeColor = System.Drawing.Color.Black
        Me.BTN_EXIT.Location = New System.Drawing.Point(6, 296)
        Me.BTN_EXIT.Name = "BTN_EXIT"
        Me.BTN_EXIT.Size = New System.Drawing.Size(111, 56)
        Me.BTN_EXIT.TabIndex = 2
        Me.BTN_EXIT.Text = "EXIT"
        Me.BTN_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_EXIT.UseVisualStyleBackColor = True
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.BackgroundImage = Global.SmartCard.My.Resources.Resources.Clear
        Me.BTN_CLEAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_CLEAR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BTN_CLEAR.ForeColor = System.Drawing.Color.Black
        Me.BTN_CLEAR.Location = New System.Drawing.Point(6, 130)
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        Me.BTN_CLEAR.Size = New System.Drawing.Size(111, 56)
        Me.BTN_CLEAR.TabIndex = 1
        Me.BTN_CLEAR.Text = "CLEAR"
        Me.BTN_CLEAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CLEAR.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.BackgroundImage = Global.SmartCard.My.Resources.Resources.save
        Me.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_add.ForeColor = System.Drawing.Color.Black
        Me.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add.Location = New System.Drawing.Point(6, 58)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(111, 56)
        Me.btn_add.TabIndex = 0
        Me.btn_add.Text = "ADD"
        Me.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'chk_all_cat
        '
        Me.chk_all_cat.AutoSize = True
        Me.chk_all_cat.Location = New System.Drawing.Point(11, 19)
        Me.chk_all_cat.Name = "chk_all_cat"
        Me.chk_all_cat.Size = New System.Drawing.Size(70, 17)
        Me.chk_all_cat.TabIndex = 1
        Me.chk_all_cat.Text = "Select All"
        Me.chk_all_cat.UseVisualStyleBackColor = True
        '
        'chk_all_user
        '
        Me.chk_all_user.AutoSize = True
        Me.chk_all_user.Location = New System.Drawing.Point(11, 19)
        Me.chk_all_user.Name = "chk_all_user"
        Me.chk_all_user.Size = New System.Drawing.Size(70, 17)
        Me.chk_all_user.TabIndex = 2
        Me.chk_all_user.Text = "Select All"
        Me.chk_all_user.UseVisualStyleBackColor = True
        '
        'Frm_IndentTypeMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SmartCard.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1008, 682)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_IndentTypeMaster"
        Me.Text = "Frm_IndentTypeMaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chk_authorizeduser As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_user As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_cat As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_hlp As System.Windows.Forms.Button
    Friend WithEvents TXT_INDENTNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXT_INDENTCODE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_EXIT As System.Windows.Forms.Button
    Friend WithEvents BTN_CLEAR As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents BTN_VOID As System.Windows.Forms.Button
    Friend WithEvents chk_all_user As System.Windows.Forms.CheckBox
    Friend WithEvents chk_all_cat As System.Windows.Forms.CheckBox
End Class
