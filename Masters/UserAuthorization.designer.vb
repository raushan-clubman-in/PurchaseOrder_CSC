<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserAuthorization
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserAuthorization))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CHK_STORE = New System.Windows.Forms.CheckBox()
        Me.STORE = New System.Windows.Forms.CheckedListBox()
        Me.txt_orderno = New System.Windows.Forms.TextBox()
        Me.combo_service = New System.Windows.Forms.ComboBox()
        Me.dtp_todate = New System.Windows.Forms.DateTimePicker()
        Me.help_userid = New System.Windows.Forms.Button()
        Me.dtp_fromdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_todate = New System.Windows.Forms.Label()
        Me.combo_status = New System.Windows.Forms.ComboBox()
        Me.lbl_fromdate = New System.Windows.Forms.Label()
        Me.combo_desig = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_limit = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_userid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.help_store = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_store = New System.Windows.Forms.TextBox()
        Me.combo_order = New System.Windows.Forms.ComboBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.grid_details = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grid_details, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CHK_STORE)
        Me.Panel1.Controls.Add(Me.STORE)
        Me.Panel1.Controls.Add(Me.txt_orderno)
        Me.Panel1.Controls.Add(Me.combo_service)
        Me.Panel1.Controls.Add(Me.dtp_todate)
        Me.Panel1.Controls.Add(Me.help_userid)
        Me.Panel1.Controls.Add(Me.dtp_fromdate)
        Me.Panel1.Controls.Add(Me.lbl_todate)
        Me.Panel1.Controls.Add(Me.combo_status)
        Me.Panel1.Controls.Add(Me.lbl_fromdate)
        Me.Panel1.Controls.Add(Me.combo_desig)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txt_limit)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txt_email)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txt_mobileno)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_username)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_userid)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(9, 70)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(646, 208)
        Me.Panel1.TabIndex = 0
        '
        'CHK_STORE
        '
        Me.CHK_STORE.AutoSize = True
        Me.CHK_STORE.Location = New System.Drawing.Point(505, 15)
        Me.CHK_STORE.Name = "CHK_STORE"
        Me.CHK_STORE.Size = New System.Drawing.Size(70, 17)
        Me.CHK_STORE.TabIndex = 8
        Me.CHK_STORE.Text = "Select All"
        Me.CHK_STORE.UseVisualStyleBackColor = True
        '
        'STORE
        '
        Me.STORE.FormattingEnabled = True
        Me.STORE.Location = New System.Drawing.Point(505, 38)
        Me.STORE.Name = "STORE"
        Me.STORE.Size = New System.Drawing.Size(138, 154)
        Me.STORE.TabIndex = 7
        '
        'txt_orderno
        '
        Me.txt_orderno.Location = New System.Drawing.Point(133, 132)
        Me.txt_orderno.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_orderno.Name = "txt_orderno"
        Me.txt_orderno.Size = New System.Drawing.Size(120, 20)
        Me.txt_orderno.TabIndex = 6
        '
        'combo_service
        '
        Me.combo_service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_service.FormattingEnabled = True
        Me.combo_service.Items.AddRange(New Object() {"Indent", "PO", "Both"})
        Me.combo_service.Location = New System.Drawing.Point(136, 68)
        Me.combo_service.Margin = New System.Windows.Forms.Padding(2)
        Me.combo_service.Name = "combo_service"
        Me.combo_service.Size = New System.Drawing.Size(120, 21)
        Me.combo_service.TabIndex = 5
        '
        'dtp_todate
        '
        Me.dtp_todate.Location = New System.Drawing.Point(133, 163)
        Me.dtp_todate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtp_todate.Name = "dtp_todate"
        Me.dtp_todate.Size = New System.Drawing.Size(120, 20)
        Me.dtp_todate.TabIndex = 2
        Me.dtp_todate.Visible = False
        '
        'help_userid
        '
        Me.help_userid.BackColor = System.Drawing.Color.Transparent
        Me.help_userid.FlatAppearance.BorderSize = 0
        Me.help_userid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.help_userid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.help_userid.Image = CType(resources.GetObject("help_userid.Image"), System.Drawing.Image)
        Me.help_userid.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.help_userid.Location = New System.Drawing.Point(258, 13)
        Me.help_userid.Margin = New System.Windows.Forms.Padding(2)
        Me.help_userid.Name = "help_userid"
        Me.help_userid.Size = New System.Drawing.Size(20, 17)
        Me.help_userid.TabIndex = 4
        Me.help_userid.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.help_userid.UseVisualStyleBackColor = False
        '
        'dtp_fromdate
        '
        Me.dtp_fromdate.Location = New System.Drawing.Point(357, 163)
        Me.dtp_fromdate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtp_fromdate.Name = "dtp_fromdate"
        Me.dtp_fromdate.Size = New System.Drawing.Size(120, 20)
        Me.dtp_fromdate.TabIndex = 2
        Me.dtp_fromdate.Visible = False
        '
        'lbl_todate
        '
        Me.lbl_todate.AutoSize = True
        Me.lbl_todate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_todate.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_todate.ForeColor = System.Drawing.Color.Black
        Me.lbl_todate.Location = New System.Drawing.Point(12, 165)
        Me.lbl_todate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_todate.Name = "lbl_todate"
        Me.lbl_todate.Size = New System.Drawing.Size(46, 13)
        Me.lbl_todate.TabIndex = 1
        Me.lbl_todate.Text = "To Date"
        Me.lbl_todate.Visible = False
        '
        'combo_status
        '
        Me.combo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_status.FormattingEnabled = True
        Me.combo_status.Items.AddRange(New Object() {"Active", "OutOfOffice", "InActive", "Closed"})
        Me.combo_status.Location = New System.Drawing.Point(354, 108)
        Me.combo_status.Margin = New System.Windows.Forms.Padding(2)
        Me.combo_status.Name = "combo_status"
        Me.combo_status.Size = New System.Drawing.Size(120, 21)
        Me.combo_status.TabIndex = 3
        '
        'lbl_fromdate
        '
        Me.lbl_fromdate.AutoSize = True
        Me.lbl_fromdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_fromdate.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fromdate.ForeColor = System.Drawing.Color.Black
        Me.lbl_fromdate.Location = New System.Drawing.Point(270, 165)
        Me.lbl_fromdate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_fromdate.Name = "lbl_fromdate"
        Me.lbl_fromdate.Size = New System.Drawing.Size(61, 13)
        Me.lbl_fromdate.TabIndex = 1
        Me.lbl_fromdate.Text = "From Date"
        Me.lbl_fromdate.Visible = False
        '
        'combo_desig
        '
        Me.combo_desig.FormattingEnabled = True
        Me.combo_desig.Location = New System.Drawing.Point(133, 95)
        Me.combo_desig.Margin = New System.Windows.Forms.Padding(2)
        Me.combo_desig.Name = "combo_desig"
        Me.combo_desig.Size = New System.Drawing.Size(120, 21)
        Me.combo_desig.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(12, 71)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Type of Authorisation"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(309, 111)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Status"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(13, 131)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Order"
        '
        'txt_limit
        '
        Me.txt_limit.Location = New System.Drawing.Point(354, 80)
        Me.txt_limit.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_limit.Name = "txt_limit"
        Me.txt_limit.Size = New System.Drawing.Size(120, 20)
        Me.txt_limit.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(315, 84)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Limit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(13, 100)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Designation"
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(133, 41)
        Me.txt_email.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(120, 20)
        Me.txt_email.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(13, 47)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Email"
        '
        'txt_mobileno
        '
        Me.txt_mobileno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_mobileno.Location = New System.Drawing.Point(354, 48)
        Me.txt_mobileno.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_mobileno.MaxLength = 10
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.Size = New System.Drawing.Size(120, 20)
        Me.txt_mobileno.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(304, 51)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Mobile"
        '
        'txt_username
        '
        Me.txt_username.Location = New System.Drawing.Point(354, 12)
        Me.txt_username.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(120, 20)
        Me.txt_username.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(293, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "User Name"
        '
        'txt_userid
        '
        Me.txt_userid.Location = New System.Drawing.Point(133, 12)
        Me.txt_userid.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_userid.Name = "txt_userid"
        Me.txt_userid.ReadOnly = True
        Me.txt_userid.Size = New System.Drawing.Size(120, 20)
        Me.txt_userid.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "User ID"
        '
        'help_store
        '
        Me.help_store.BackColor = System.Drawing.Color.Transparent
        Me.help_store.FlatAppearance.BorderColor = System.Drawing.Color.Khaki
        Me.help_store.FlatAppearance.BorderSize = 0
        Me.help_store.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.help_store.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.help_store.Image = CType(resources.GetObject("help_store.Image"), System.Drawing.Image)
        Me.help_store.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.help_store.Location = New System.Drawing.Point(245, 44)
        Me.help_store.Margin = New System.Windows.Forms.Padding(2)
        Me.help_store.Name = "help_store"
        Me.help_store.Size = New System.Drawing.Size(20, 18)
        Me.help_store.TabIndex = 4
        Me.help_store.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.help_store.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(60, 45)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Store"
        '
        'txt_store
        '
        Me.txt_store.Location = New System.Drawing.Point(121, 43)
        Me.txt_store.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_store.Name = "txt_store"
        Me.txt_store.ReadOnly = True
        Me.txt_store.Size = New System.Drawing.Size(120, 20)
        Me.txt_store.TabIndex = 2
        '
        'combo_order
        '
        Me.combo_order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_order.FormattingEnabled = True
        Me.combo_order.Location = New System.Drawing.Point(550, 46)
        Me.combo_order.Margin = New System.Windows.Forms.Padding(2)
        Me.combo_order.Name = "combo_order"
        Me.combo_order.Size = New System.Drawing.Size(120, 21)
        Me.combo_order.TabIndex = 5
        Me.combo_order.Visible = False
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(345, 46)
        Me.txt_password.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.ReadOnly = True
        Me.txt_password.Size = New System.Drawing.Size(120, 20)
        Me.txt_password.TabIndex = 2
        Me.txt_password.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(265, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "User Password"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(144, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Authorization"
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_save.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save.Location = New System.Drawing.Point(9, 15)
        Me.btn_save.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(85, 30)
        Me.btn_save.TabIndex = 2
        Me.btn_save.Text = "Save"
        Me.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btn_exit)
        Me.Panel2.Controls.Add(Me.btn_clear)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Location = New System.Drawing.Point(712, 99)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(110, 136)
        Me.Panel2.TabIndex = 3
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exit.Location = New System.Drawing.Point(9, 89)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(85, 30)
        Me.btn_exit.TabIndex = 2
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_clear.Location = New System.Drawing.Point(9, 51)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(85, 30)
        Me.btn_clear.TabIndex = 2
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'grid_details
        '
        Me.grid_details.AllowUserToAddRows = False
        Me.grid_details.AllowUserToDeleteRows = False
        Me.grid_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_details.Location = New System.Drawing.Point(9, 296)
        Me.grid_details.Margin = New System.Windows.Forms.Padding(2)
        Me.grid_details.Name = "grid_details"
        Me.grid_details.ReadOnly = True
        Me.grid_details.RowTemplate.Height = 24
        Me.grid_details.Size = New System.Drawing.Size(837, 198)
        Me.grid_details.TabIndex = 4
        '
        'UserAuthorization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SmartCard.My.Resources.Resources.Chs_Background_form_new
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(857, 516)
        Me.Controls.Add(Me.grid_details)
        Me.Controls.Add(Me.combo_order)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.help_store)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_store)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "UserAuthorization"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserAuthorization"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grid_details, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_username As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_userid As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_limit As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_store As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_email As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_mobileno As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents combo_desig As ComboBox
    Friend WithEvents help_store As Button
    Friend WithEvents help_userid As Button
    Friend WithEvents combo_status As ComboBox
    Friend WithEvents btn_save As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_exit As Button
    Friend WithEvents btn_clear As Button
    Friend WithEvents lbl_todate As Label
    Friend WithEvents lbl_fromdate As Label
    Friend WithEvents dtp_todate As DateTimePicker
    Friend WithEvents dtp_fromdate As DateTimePicker
    Friend WithEvents grid_details As DataGridView
    Friend WithEvents combo_order As ComboBox
    Friend WithEvents combo_service As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_orderno As System.Windows.Forms.TextBox
    Friend WithEvents STORE As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHK_STORE As System.Windows.Forms.CheckBox
End Class
