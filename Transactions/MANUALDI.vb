Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions

Public Class MANUALDI
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Dim sqlstring, Sstr As String
    Dim docno, doctype, docno1() As String
    Dim grtot, grvat, totaldiscount As Double
    Dim vconn As New GlobalClass
    Dim Dupchk As Boolean
    Dim i As Integer
    Dim CATEGORY, VENDORLINK As String
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents txt_qty As System.Windows.Forms.TextBox
    Friend WithEvents txt_Totalamount As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    'Dim gconnection As New GlobalClass
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbl_GroupCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Cmd_PONoHelp As System.Windows.Forms.Button
    Friend WithEvents txt_PONo As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_PODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_Vname As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Vcode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Cmb_despatch As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_shipping As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_delivery As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Encl As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Cmb_Freight As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_Freight As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Lbl_Marquee As System.Windows.Forms.Label
    Friend WithEvents Group_MC As System.Windows.Forms.GroupBox
    Friend WithEvents Ssgrid_subject As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Ssgrid_reference As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Ssgrid_body As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Txt_WarrantyCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_WarrantyCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_OtherTermCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_OtherTermCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Chk_MC_Form As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_dept As System.Windows.Forms.TextBox
    Friend WithEvents grp_freight As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_CreditDays As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Closure As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Cmb_CSTForm As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents grp_encl As System.Windows.Forms.GroupBox
    Friend WithEvents grp_cstform As System.Windows.Forms.GroupBox
    Friend WithEvents AmendmentGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Grp_amend_Follow As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents FollowupGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Chk_Followup As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Amendment As System.Windows.Forms.CheckBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txt_docno As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cmddochelp As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MANUALDI))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmddochelp = New System.Windows.Forms.Button()
        Me.txt_docno = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cbo_dept = New System.Windows.Forms.TextBox()
        Me.Cbo_PODate = New System.Windows.Forms.DateTimePicker()
        Me.Txt_Vcode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Vname = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Cmd_PONoHelp = New System.Windows.Forms.Button()
        Me.txt_PONo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lbl_GroupCode = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.Cmd_FREEZE = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.grp_freight = New System.Windows.Forms.GroupBox()
        Me.Cmb_Freight = New System.Windows.Forms.ComboBox()
        Me.Lbl_Freight = New System.Windows.Forms.Label()
        Me.Cmb_shipping = New System.Windows.Forms.ComboBox()
        Me.Cmb_despatch = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Cmb_delivery = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.grp_encl = New System.Windows.Forms.GroupBox()
        Me.Chk_MC_Form = New System.Windows.Forms.CheckBox()
        Me.Txt_Encl = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.grp_cstform = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_CreditDays = New System.Windows.Forms.TextBox()
        Me.Cbo_Closure = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Cmb_CSTForm = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Lbl_Marquee = New System.Windows.Forms.Label()
        Me.Group_MC = New System.Windows.Forms.GroupBox()
        Me.Ssgrid_body = New AxFPSpreadADO.AxfpSpread()
        Me.Ssgrid_subject = New AxFPSpreadADO.AxfpSpread()
        Me.Ssgrid_reference = New AxFPSpreadADO.AxfpSpread()
        Me.Txt_OtherTermCode = New System.Windows.Forms.TextBox()
        Me.Cmd_OtherTermCodeHelp = New System.Windows.Forms.Button()
        Me.Txt_WarrantyCode = New System.Windows.Forms.TextBox()
        Me.Cmd_WarrantyCodeHelp = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Cmd_Ok = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Grp_amend_Follow = New System.Windows.Forms.GroupBox()
        Me.FollowupGrid = New AxFPSpreadADO.AxfpSpread()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Chk_Followup = New System.Windows.Forms.CheckBox()
        Me.Chk_Amendment = New System.Windows.Forms.CheckBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AmendmentGrid = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txt_qty = New System.Windows.Forms.TextBox()
        Me.txt_Totalamount = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_freight.SuspendLayout()
        Me.grp_encl.SuspendLayout()
        Me.grp_cstform.SuspendLayout()
        Me.Group_MC.SuspendLayout()
        CType(Me.Ssgrid_body, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ssgrid_subject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ssgrid_reference, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_amend_Follow.SuspendLayout()
        CType(Me.FollowupGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmendmentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(188, 26)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(206, 18)
        Me.lbl_Heading.TabIndex = 18
        Me.lbl_Heading.Text = "MANUAL DELIVERY ORDER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmddochelp)
        Me.GroupBox1.Controls.Add(Me.txt_docno)
        Me.GroupBox1.Controls.Add(Me.Label52)
        Me.GroupBox1.Controls.Add(Me.cbo_dept)
        Me.GroupBox1.Controls.Add(Me.Cbo_PODate)
        Me.GroupBox1.Controls.Add(Me.Txt_Vcode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Txt_Vname)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Cmd_PONoHelp)
        Me.GroupBox1.Controls.Add(Me.txt_PONo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.lbl_GroupCode)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 132)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(268, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 25)
        Me.Button1.TabIndex = 579
        '
        'cmddochelp
        '
        Me.cmddochelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddochelp.Image = CType(resources.GetObject("cmddochelp.Image"), System.Drawing.Image)
        Me.cmddochelp.Location = New System.Drawing.Point(268, 15)
        Me.cmddochelp.Name = "cmddochelp"
        Me.cmddochelp.Size = New System.Drawing.Size(24, 25)
        Me.cmddochelp.TabIndex = 578
        '
        'txt_docno
        '
        Me.txt_docno.BackColor = System.Drawing.Color.White
        Me.txt_docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_docno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_docno.Location = New System.Drawing.Point(115, 17)
        Me.txt_docno.MaxLength = 10
        Me.txt_docno.Name = "txt_docno"
        Me.txt_docno.Size = New System.Drawing.Size(152, 20)
        Me.txt_docno.TabIndex = 577
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(34, 19)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(65, 14)
        Me.Label52.TabIndex = 576
        Me.Label52.Text = "Indent No :"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_dept
        '
        Me.cbo_dept.BackColor = System.Drawing.Color.White
        Me.cbo_dept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbo_dept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dept.Location = New System.Drawing.Point(115, 44)
        Me.cbo_dept.MaxLength = 10
        Me.cbo_dept.Name = "cbo_dept"
        Me.cbo_dept.ReadOnly = True
        Me.cbo_dept.Size = New System.Drawing.Size(152, 20)
        Me.cbo_dept.TabIndex = 571
        '
        'Cbo_PODate
        '
        Me.Cbo_PODate.CustomFormat = "dd-MMM-yyyy"
        Me.Cbo_PODate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_PODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Cbo_PODate.Location = New System.Drawing.Point(464, 43)
        Me.Cbo_PODate.Name = "Cbo_PODate"
        Me.Cbo_PODate.Size = New System.Drawing.Size(152, 20)
        Me.Cbo_PODate.TabIndex = 2
        '
        'Txt_Vcode
        '
        Me.Txt_Vcode.BackColor = System.Drawing.Color.White
        Me.Txt_Vcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vcode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vcode.Location = New System.Drawing.Point(116, 76)
        Me.Txt_Vcode.MaxLength = 10
        Me.Txt_Vcode.Name = "Txt_Vcode"
        Me.Txt_Vcode.ReadOnly = True
        Me.Txt_Vcode.Size = New System.Drawing.Size(151, 20)
        Me.Txt_Vcode.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(53, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 23)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Name  :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Vname
        '
        Me.Txt_Vname.BackColor = System.Drawing.Color.White
        Me.Txt_Vname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vname.Location = New System.Drawing.Point(116, 102)
        Me.Txt_Vname.MaxLength = 50
        Me.Txt_Vname.Name = "Txt_Vname"
        Me.Txt_Vname.ReadOnly = True
        Me.Txt_Vname.Size = New System.Drawing.Size(182, 20)
        Me.Txt_Vname.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 17)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Vendor Code  :"
        '
        'Cmd_PONoHelp
        '
        Me.Cmd_PONoHelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_PONoHelp.Image = CType(resources.GetObject("Cmd_PONoHelp.Image"), System.Drawing.Image)
        Me.Cmd_PONoHelp.Location = New System.Drawing.Point(620, 16)
        Me.Cmd_PONoHelp.Name = "Cmd_PONoHelp"
        Me.Cmd_PONoHelp.Size = New System.Drawing.Size(24, 25)
        Me.Cmd_PONoHelp.TabIndex = 1
        '
        'txt_PONo
        '
        Me.txt_PONo.BackColor = System.Drawing.Color.White
        Me.txt_PONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_PONo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PONo.Location = New System.Drawing.Point(464, 19)
        Me.txt_PONo.MaxLength = 25
        Me.txt_PONo.Name = "txt_PONo"
        Me.txt_PONo.Size = New System.Drawing.Size(152, 20)
        Me.txt_PONo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(357, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "D.O. Date :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(53, 50)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 14)
        Me.Label38.TabIndex = 570
        Me.Label38.Text = "Store  :"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_GroupCode
        '
        Me.lbl_GroupCode.AutoSize = True
        Me.lbl_GroupCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupCode.Location = New System.Drawing.Point(357, 21)
        Me.lbl_GroupCode.Name = "lbl_GroupCode"
        Me.lbl_GroupCode.Size = New System.Drawing.Size(60, 14)
        Me.lbl_GroupCode.TabIndex = 9
        Me.lbl_GroupCode.Text = "D.O.  No.  :"
        Me.lbl_GroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CmdExit)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdAdd)
        Me.GroupBox4.Controls.Add(Me.Cmd_FREEZE)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Location = New System.Drawing.Point(785, 149)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(131, 291)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.Transparent
        Me.CmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.Color.Black
        Me.CmdExit.Image = Global.SmartCard.My.Resources.Resources._Exit
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.Location = New System.Drawing.Point(0, 224)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(123, 47)
        Me.CmdExit.TabIndex = 5604
        Me.CmdExit.Text = "Exit[F11]"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = Global.SmartCard.My.Resources.Resources.Clear
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(2, 12)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(123, 47)
        Me.CmdClear.TabIndex = 19
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = Global.SmartCard.My.Resources.Resources.save
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(2, 65)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(123, 47)
        Me.CmdAdd.TabIndex = 29
        Me.CmdAdd.Text = "Add[F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'Cmd_FREEZE
        '
        Me.Cmd_FREEZE.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_FREEZE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_FREEZE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_FREEZE.ForeColor = System.Drawing.Color.Black
        Me.Cmd_FREEZE.Image = Global.SmartCard.My.Resources.Resources.Delete
        Me.Cmd_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_FREEZE.Location = New System.Drawing.Point(2, 118)
        Me.Cmd_FREEZE.Name = "Cmd_FREEZE"
        Me.Cmd_FREEZE.Size = New System.Drawing.Size(123, 47)
        Me.Cmd_FREEZE.TabIndex = 20
        Me.Cmd_FREEZE.Text = "Reject[F8]"
        Me.Cmd_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_FREEZE.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Transparent
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = Global.SmartCard.My.Resources.Resources.view
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(0, 171)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(123, 47)
        Me.CmdView.TabIndex = 21
        Me.CmdView.Text = " View[F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(55, 270)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(724, 209)
        Me.ssgrid.TabIndex = 8
        '
        'grp_freight
        '
        Me.grp_freight.BackColor = System.Drawing.Color.Transparent
        Me.grp_freight.Controls.Add(Me.Cmb_Freight)
        Me.grp_freight.Controls.Add(Me.Lbl_Freight)
        Me.grp_freight.Controls.Add(Me.Cmb_shipping)
        Me.grp_freight.Controls.Add(Me.Cmb_despatch)
        Me.grp_freight.Controls.Add(Me.Label26)
        Me.grp_freight.Controls.Add(Me.Label28)
        Me.grp_freight.Controls.Add(Me.Cmb_delivery)
        Me.grp_freight.Controls.Add(Me.Label24)
        Me.grp_freight.Location = New System.Drawing.Point(150, 1000)
        Me.grp_freight.Name = "grp_freight"
        Me.grp_freight.Size = New System.Drawing.Size(912, 48)
        Me.grp_freight.TabIndex = 564
        Me.grp_freight.TabStop = False
        '
        'Cmb_Freight
        '
        Me.Cmb_Freight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Freight.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Freight.Items.AddRange(New Object() {"PAID", "TO BE PAID"})
        Me.Cmb_Freight.Location = New System.Drawing.Point(88, 16)
        Me.Cmb_Freight.MaxLength = 25
        Me.Cmb_Freight.Name = "Cmb_Freight"
        Me.Cmb_Freight.Size = New System.Drawing.Size(104, 25)
        Me.Cmb_Freight.TabIndex = 581
        '
        'Lbl_Freight
        '
        Me.Lbl_Freight.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Freight.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Freight.Location = New System.Drawing.Point(16, 16)
        Me.Lbl_Freight.Name = "Lbl_Freight"
        Me.Lbl_Freight.Size = New System.Drawing.Size(80, 16)
        Me.Lbl_Freight.TabIndex = 582
        Me.Lbl_Freight.Text = "FREIGHT :"
        '
        'Cmb_shipping
        '
        Me.Cmb_shipping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_shipping.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_shipping.Items.AddRange(New Object() {"NIL", "CHENNAI", "VIZAG", "OTHERS"})
        Me.Cmb_shipping.Location = New System.Drawing.Point(568, 16)
        Me.Cmb_shipping.MaxLength = 25
        Me.Cmb_shipping.Name = "Cmb_shipping"
        Me.Cmb_shipping.Size = New System.Drawing.Size(104, 25)
        Me.Cmb_shipping.TabIndex = 22
        Me.Cmb_shipping.Visible = False
        '
        'Cmb_despatch
        '
        Me.Cmb_despatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_despatch.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_despatch.Items.AddRange(New Object() {"NIL", "CHENNAI", "VIZAG", "OTHERS"})
        Me.Cmb_despatch.Location = New System.Drawing.Point(328, 16)
        Me.Cmb_despatch.MaxLength = 25
        Me.Cmb_despatch.Name = "Cmb_despatch"
        Me.Cmb_despatch.Size = New System.Drawing.Size(104, 25)
        Me.Cmb_despatch.TabIndex = 21
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(448, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 23)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "SHIPPING PORT :"
        Me.Label26.Visible = False
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(200, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(128, 23)
        Me.Label28.TabIndex = 12
        Me.Label28.Text = "DESPATCH PORT :"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmb_delivery
        '
        Me.Cmb_delivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_delivery.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_delivery.Items.AddRange(New Object() {"NIL", "CHENNAI", "VIZAG", "OTHERS"})
        Me.Cmb_delivery.Location = New System.Drawing.Point(800, 16)
        Me.Cmb_delivery.MaxLength = 25
        Me.Cmb_delivery.Name = "Cmb_delivery"
        Me.Cmb_delivery.Size = New System.Drawing.Size(104, 25)
        Me.Cmb_delivery.TabIndex = 23
        Me.Cmb_delivery.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(688, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(113, 15)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "DELIVERY PORT :"
        Me.Label24.Visible = False
        '
        'grp_encl
        '
        Me.grp_encl.BackColor = System.Drawing.Color.Transparent
        Me.grp_encl.Controls.Add(Me.Chk_MC_Form)
        Me.grp_encl.Controls.Add(Me.Txt_Encl)
        Me.grp_encl.Controls.Add(Me.Label9)
        Me.grp_encl.Location = New System.Drawing.Point(250, 1000)
        Me.grp_encl.Name = "grp_encl"
        Me.grp_encl.Size = New System.Drawing.Size(912, 40)
        Me.grp_encl.TabIndex = 584
        Me.grp_encl.TabStop = False
        '
        'Chk_MC_Form
        '
        Me.Chk_MC_Form.Appearance = System.Windows.Forms.Appearance.Button
        Me.Chk_MC_Form.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Chk_MC_Form.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_MC_Form.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Chk_MC_Form.Location = New System.Drawing.Point(800, 10)
        Me.Chk_MC_Form.Name = "Chk_MC_Form"
        Me.Chk_MC_Form.Size = New System.Drawing.Size(96, 24)
        Me.Chk_MC_Form.TabIndex = 29
        Me.Chk_MC_Form.Text = "M . C . FORM"
        Me.Chk_MC_Form.UseVisualStyleBackColor = False
        '
        'Txt_Encl
        '
        Me.Txt_Encl.BackColor = System.Drawing.Color.White
        Me.Txt_Encl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Encl.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Encl.Location = New System.Drawing.Point(112, 12)
        Me.Txt_Encl.MaxLength = 50
        Me.Txt_Encl.Name = "Txt_Encl"
        Me.Txt_Encl.Size = New System.Drawing.Size(136, 22)
        Me.Txt_Encl.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 23)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "ENCLOSURES :"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(605, 49)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(139, 16)
        Me.lbl_Freeze.TabIndex = 5572
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'grp_cstform
        '
        Me.grp_cstform.BackColor = System.Drawing.Color.Transparent
        Me.grp_cstform.Controls.Add(Me.Label10)
        Me.grp_cstform.Controls.Add(Me.Txt_CreditDays)
        Me.grp_cstform.Controls.Add(Me.Cbo_Closure)
        Me.grp_cstform.Controls.Add(Me.Label37)
        Me.grp_cstform.Controls.Add(Me.Cmb_CSTForm)
        Me.grp_cstform.Controls.Add(Me.Label39)
        Me.grp_cstform.Location = New System.Drawing.Point(250, 1000)
        Me.grp_cstform.Name = "grp_cstform"
        Me.grp_cstform.Size = New System.Drawing.Size(912, 38)
        Me.grp_cstform.TabIndex = 5575
        Me.grp_cstform.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 15)
        Me.Label10.TabIndex = 5579
        Me.Label10.Text = "CREDIT DAYS :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_CreditDays
        '
        Me.Txt_CreditDays.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_CreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CreditDays.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CreditDays.Location = New System.Drawing.Point(140, 9)
        Me.Txt_CreditDays.MaxLength = 3
        Me.Txt_CreditDays.Name = "Txt_CreditDays"
        Me.Txt_CreditDays.Size = New System.Drawing.Size(72, 22)
        Me.Txt_CreditDays.TabIndex = 5580
        '
        'Cbo_Closure
        '
        Me.Cbo_Closure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Closure.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Closure.Items.AddRange(New Object() {"CLOSURE", "FORCIBLE"})
        Me.Cbo_Closure.Location = New System.Drawing.Point(780, 6)
        Me.Cbo_Closure.Name = "Cbo_Closure"
        Me.Cbo_Closure.Size = New System.Drawing.Size(104, 25)
        Me.Cbo_Closure.TabIndex = 5578
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(652, 6)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 23)
        Me.Label37.TabIndex = 5577
        Me.Label37.Text = "CLOSURE :"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cmb_CSTForm
        '
        Me.Cmb_CSTForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_CSTForm.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_CSTForm.Items.AddRange(New Object() {"YES", "NO"})
        Me.Cmb_CSTForm.Location = New System.Drawing.Point(492, 7)
        Me.Cmb_CSTForm.MaxLength = 25
        Me.Cmb_CSTForm.Name = "Cmb_CSTForm"
        Me.Cmb_CSTForm.Size = New System.Drawing.Size(104, 25)
        Me.Cmb_CSTForm.TabIndex = 5575
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(260, 9)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(200, 16)
        Me.Label39.TabIndex = 5576
        Me.Label39.Text = "CST FORM REQUIREMENTS :"
        '
        'Timer1
        '
        '
        'Lbl_Marquee
        '
        Me.Lbl_Marquee.AutoSize = True
        Me.Lbl_Marquee.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Marquee.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Marquee.ForeColor = System.Drawing.Color.SteelBlue
        Me.Lbl_Marquee.Location = New System.Drawing.Point(1000, 592)
        Me.Lbl_Marquee.Name = "Lbl_Marquee"
        Me.Lbl_Marquee.Size = New System.Drawing.Size(315, 26)
        Me.Lbl_Marquee.TabIndex = 5578
        Me.Lbl_Marquee.Text = "PURCHASE ORDER FORM"
        Me.Lbl_Marquee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lbl_Marquee.Visible = False
        '
        'Group_MC
        '
        Me.Group_MC.BackColor = System.Drawing.Color.DodgerBlue
        Me.Group_MC.BackgroundImage = CType(resources.GetObject("Group_MC.BackgroundImage"), System.Drawing.Image)
        Me.Group_MC.Controls.Add(Me.Ssgrid_body)
        Me.Group_MC.Controls.Add(Me.Ssgrid_subject)
        Me.Group_MC.Controls.Add(Me.Ssgrid_reference)
        Me.Group_MC.Controls.Add(Me.Txt_OtherTermCode)
        Me.Group_MC.Controls.Add(Me.Cmd_OtherTermCodeHelp)
        Me.Group_MC.Controls.Add(Me.Txt_WarrantyCode)
        Me.Group_MC.Controls.Add(Me.Cmd_WarrantyCodeHelp)
        Me.Group_MC.Controls.Add(Me.Label44)
        Me.Group_MC.Controls.Add(Me.Cmd_Ok)
        Me.Group_MC.Controls.Add(Me.Label43)
        Me.Group_MC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_MC.Location = New System.Drawing.Point(1000, 80)
        Me.Group_MC.Name = "Group_MC"
        Me.Group_MC.Size = New System.Drawing.Size(920, 552)
        Me.Group_MC.TabIndex = 5579
        Me.Group_MC.TabStop = False
        Me.Group_MC.Text = "Management Committee Purchase Order :"
        Me.Group_MC.Visible = False
        '
        'Ssgrid_body
        '
        Me.Ssgrid_body.DataSource = Nothing
        Me.Ssgrid_body.Location = New System.Drawing.Point(32, 328)
        Me.Ssgrid_body.Name = "Ssgrid_body"
        Me.Ssgrid_body.OcxState = CType(resources.GetObject("Ssgrid_body.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ssgrid_body.Size = New System.Drawing.Size(864, 160)
        Me.Ssgrid_body.TabIndex = 437
        '
        'Ssgrid_subject
        '
        Me.Ssgrid_subject.DataSource = Nothing
        Me.Ssgrid_subject.Location = New System.Drawing.Point(32, 24)
        Me.Ssgrid_subject.Name = "Ssgrid_subject"
        Me.Ssgrid_subject.OcxState = CType(resources.GetObject("Ssgrid_subject.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ssgrid_subject.Size = New System.Drawing.Size(864, 144)
        Me.Ssgrid_subject.TabIndex = 2
        '
        'Ssgrid_reference
        '
        Me.Ssgrid_reference.DataSource = Nothing
        Me.Ssgrid_reference.Location = New System.Drawing.Point(32, 176)
        Me.Ssgrid_reference.Name = "Ssgrid_reference"
        Me.Ssgrid_reference.OcxState = CType(resources.GetObject("Ssgrid_reference.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ssgrid_reference.Size = New System.Drawing.Size(864, 144)
        Me.Ssgrid_reference.TabIndex = 435
        '
        'Txt_OtherTermCode
        '
        Me.Txt_OtherTermCode.BackColor = System.Drawing.Color.White
        Me.Txt_OtherTermCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_OtherTermCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_OtherTermCode.Location = New System.Drawing.Point(552, 514)
        Me.Txt_OtherTermCode.MaxLength = 25
        Me.Txt_OtherTermCode.Name = "Txt_OtherTermCode"
        Me.Txt_OtherTermCode.Size = New System.Drawing.Size(168, 22)
        Me.Txt_OtherTermCode.TabIndex = 5562
        '
        'Cmd_OtherTermCodeHelp
        '
        Me.Cmd_OtherTermCodeHelp.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_OtherTermCodeHelp.Image = CType(resources.GetObject("Cmd_OtherTermCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_OtherTermCodeHelp.Location = New System.Drawing.Point(728, 514)
        Me.Cmd_OtherTermCodeHelp.Name = "Cmd_OtherTermCodeHelp"
        Me.Cmd_OtherTermCodeHelp.Size = New System.Drawing.Size(24, 25)
        Me.Cmd_OtherTermCodeHelp.TabIndex = 5563
        Me.Cmd_OtherTermCodeHelp.UseVisualStyleBackColor = False
        '
        'Txt_WarrantyCode
        '
        Me.Txt_WarrantyCode.BackColor = System.Drawing.Color.White
        Me.Txt_WarrantyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_WarrantyCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_WarrantyCode.Location = New System.Drawing.Point(200, 512)
        Me.Txt_WarrantyCode.MaxLength = 25
        Me.Txt_WarrantyCode.Name = "Txt_WarrantyCode"
        Me.Txt_WarrantyCode.Size = New System.Drawing.Size(168, 22)
        Me.Txt_WarrantyCode.TabIndex = 5560
        '
        'Cmd_WarrantyCodeHelp
        '
        Me.Cmd_WarrantyCodeHelp.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_WarrantyCodeHelp.Image = CType(resources.GetObject("Cmd_WarrantyCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_WarrantyCodeHelp.Location = New System.Drawing.Point(376, 512)
        Me.Cmd_WarrantyCodeHelp.Name = "Cmd_WarrantyCodeHelp"
        Me.Cmd_WarrantyCodeHelp.Size = New System.Drawing.Size(24, 25)
        Me.Cmd_WarrantyCodeHelp.TabIndex = 5561
        Me.Cmd_WarrantyCodeHelp.UseVisualStyleBackColor = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(408, 514)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(137, 19)
        Me.Label44.TabIndex = 441
        Me.Label44.Text = "OTHER TERMS :"
        '
        'Cmd_Ok
        '
        Me.Cmd_Ok.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Ok.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Ok.ForeColor = System.Drawing.Color.White
        Me.Cmd_Ok.Image = CType(resources.GetObject("Cmd_Ok.Image"), System.Drawing.Image)
        Me.Cmd_Ok.Location = New System.Drawing.Point(767, 510)
        Me.Cmd_Ok.Name = "Cmd_Ok"
        Me.Cmd_Ok.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Ok.TabIndex = 439
        Me.Cmd_Ok.Text = "OK [F5]"
        Me.Cmd_Ok.UseVisualStyleBackColor = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(32, 512)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(161, 19)
        Me.Label43.TabIndex = 440
        Me.Label43.Text = "WARRANTY TERM :"
        '
        'Grp_amend_Follow
        '
        Me.Grp_amend_Follow.BackColor = System.Drawing.Color.Transparent
        Me.Grp_amend_Follow.Controls.Add(Me.FollowupGrid)
        Me.Grp_amend_Follow.Controls.Add(Me.Label48)
        Me.Grp_amend_Follow.Controls.Add(Me.Chk_Followup)
        Me.Grp_amend_Follow.Controls.Add(Me.Chk_Amendment)
        Me.Grp_amend_Follow.Controls.Add(Me.Label29)
        Me.Grp_amend_Follow.Controls.Add(Me.Label7)
        Me.Grp_amend_Follow.Controls.Add(Me.AmendmentGrid)
        Me.Grp_amend_Follow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_amend_Follow.Location = New System.Drawing.Point(264, 1000)
        Me.Grp_amend_Follow.Name = "Grp_amend_Follow"
        Me.Grp_amend_Follow.Size = New System.Drawing.Size(504, 304)
        Me.Grp_amend_Follow.TabIndex = 5592
        Me.Grp_amend_Follow.TabStop = False
        '
        'FollowupGrid
        '
        Me.FollowupGrid.DataSource = Nothing
        Me.FollowupGrid.Location = New System.Drawing.Point(32, 200)
        Me.FollowupGrid.Name = "FollowupGrid"
        Me.FollowupGrid.OcxState = CType(resources.GetObject("FollowupGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.FollowupGrid.Size = New System.Drawing.Size(452, 72)
        Me.FollowupGrid.TabIndex = 570
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Maroon
        Me.Label48.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label48.Location = New System.Drawing.Point(32, 24)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(448, 24)
        Me.Label48.TabIndex = 5580
        Me.Label48.Text = "AMENDMENT && FOLLOWUP"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Chk_Followup
        '
        Me.Chk_Followup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Followup.Location = New System.Drawing.Point(192, 176)
        Me.Chk_Followup.Name = "Chk_Followup"
        Me.Chk_Followup.Size = New System.Drawing.Size(16, 16)
        Me.Chk_Followup.TabIndex = 5579
        Me.Chk_Followup.UseVisualStyleBackColor = False
        Me.Chk_Followup.Visible = False
        '
        'Chk_Amendment
        '
        Me.Chk_Amendment.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Amendment.Location = New System.Drawing.Point(192, 56)
        Me.Chk_Amendment.Name = "Chk_Amendment"
        Me.Chk_Amendment.Size = New System.Drawing.Size(16, 16)
        Me.Chk_Amendment.TabIndex = 5578
        Me.Chk_Amendment.UseVisualStyleBackColor = False
        Me.Chk_Amendment.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(32, 176)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(143, 15)
        Me.Label29.TabIndex = 571
        Me.Label29.Text = "FOLLOW UP DETAILS :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 15)
        Me.Label7.TabIndex = 569
        Me.Label7.Text = "AMENDMENT DETAILS :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AmendmentGrid
        '
        Me.AmendmentGrid.DataSource = Nothing
        Me.AmendmentGrid.Location = New System.Drawing.Point(32, 72)
        Me.AmendmentGrid.Name = "AmendmentGrid"
        Me.AmendmentGrid.OcxState = CType(resources.GetObject("AmendmentGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AmendmentGrid.Size = New System.Drawing.Size(448, 88)
        Me.AmendmentGrid.TabIndex = 567
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Location = New System.Drawing.Point(39, 254)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(740, 231)
        Me.GroupBox7.TabIndex = 5600
        Me.GroupBox7.TabStop = False
        '
        'txt_qty
        '
        Me.txt_qty.BackColor = System.Drawing.Color.Wheat
        Me.txt_qty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_qty.Enabled = False
        Me.txt_qty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qty.Location = New System.Drawing.Point(418, 491)
        Me.txt_qty.MaxLength = 15
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_qty.Size = New System.Drawing.Size(105, 22)
        Me.txt_qty.TabIndex = 5602
        '
        'txt_Totalamount
        '
        Me.txt_Totalamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamount.Enabled = False
        Me.txt_Totalamount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalamount.Location = New System.Drawing.Point(538, 490)
        Me.txt_Totalamount.MaxLength = 15
        Me.txt_Totalamount.Name = "txt_Totalamount"
        Me.txt_Totalamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Totalamount.Size = New System.Drawing.Size(125, 22)
        Me.txt_Totalamount.TabIndex = 5601
        '
        'MANUALDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.SmartCard.My.Resources.Resources.Chs_Background_form_new
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(940, 556)
        Me.Controls.Add(Me.txt_qty)
        Me.Controls.Add(Me.txt_Totalamount)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.Lbl_Marquee)
        Me.Controls.Add(Me.Grp_amend_Follow)
        Me.Controls.Add(Me.grp_encl)
        Me.Controls.Add(Me.grp_freight)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grp_cstform)
        Me.Controls.Add(Me.Group_MC)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.GroupBox7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MANUALDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_freight.ResumeLayout(False)
        Me.grp_freight.PerformLayout()
        Me.grp_encl.ResumeLayout(False)
        Me.grp_encl.PerformLayout()
        Me.grp_cstform.ResumeLayout(False)
        Me.grp_cstform.PerformLayout()
        Me.Group_MC.ResumeLayout(False)
        Me.Group_MC.PerformLayout()
        CType(Me.Ssgrid_body, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ssgrid_subject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ssgrid_reference, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_amend_Follow.ResumeLayout(False)
        Me.Grp_amend_Follow.PerformLayout()
        CType(Me.FollowupGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmendmentGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub PurchaseOrder_SC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        autogenerate1()
        'ssgrid.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width * 17.57) / 100, (Screen.PrimaryScreen.WorkingArea.Height * 35.57) / 100)

        GroupBox7.Controls.Add(ssgrid)
        ssgrid.Location = New Point(5, 20)
        With ssgrid
            .Col = 7
            .Row = i
            .ColHidden = True
        End With

        txt_PONo.ReadOnly = True
        txt_docno.ReadOnly = True
        Show()

        Timer1.Enabled = True
        Timer1.Start()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        Me.txt_docno.Focus()


    End Sub


    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PURCHASE ORDER' AND MODULENAME LIKE 'Manual Delivery Order%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        Me.Cmd_FREEZE.Enabled = False
        Me.CmdView.Enabled = False
        'Me.CmdPrint.Enabled = False
        'Me.cmd_export.Enabled = False
        'Me.cmd_auth.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_FREEZE.Enabled = True
                    Me.CmdView.Enabled = True
                    'Me.cmd_auth.Enabled = True
                    'Me.cmd_export.Enabled = True
                    'Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.CmdAdd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.CmdAdd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_FREEZE.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                    'Me.cmd_rpt.Enabled = True
                    ' Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    'Me.cmd_auth.Enabled = True
                End If
                If Right(x) = "P" Then
                    'Me.CmdPrint.Enabled = True
                End If
            Next
        End If


    End Sub

    Private Sub Cmd_PONoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_PONoHelp.Click
        If txt_docno.Text <> "" Then
            gSQLString = "SELECT DISTINCT ISNULL(DINO,'') AS DINO,ISNULL(DIdate,'')AS DIDATE FROM DI_HDR WHERE"
            M_WhereCondition = "  AUTHDOCNO='" + txt_docno.Text + "' AND DITYPE='MANUAL'"
        Else
            gSQLString = "SELECT DISTINCT ISNULL(DINO,'') AS DINO,ISNULL(DIdate,'')AS DIDATE FROM DI_HDR"
            M_WhereCondition = " WHERE DITYPE='MANUAL' "
        End If

        'gSQLString = "SELECT ISNULL(DINO,'') AS DINO,ISNULL(DIdate,'')AS DIDATE FROM DI_HDR"
        'M_WhereCondition = " "
        Dim vform As New ListOperattion1
        vform.Field = "DINO,DIDATE"
        vform.vFormatstring = "         DINO    |        DIDATE              "
        vform.vCaption = "DI MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_PONo.Text = Trim(vform.keyfield & "")
            Call txt_PONo_Validated(txt_PONo.Text, e)
        End If
        vform.Close()
        vform = Nothing
        'txt_PONo.Focus()
        'Cmd_FREEZE.Enabled = True
    End Sub

    Private Sub cmddochelp_Click(sender As Object, e As EventArgs) Handles cmddochelp.Click
        Try
            gSQLString = "SELECT DISTINCT DOCNO,DOCDATE  FROM  auto_di WHERE "
            M_WhereCondition = " DITYPE='MANUAL' "
            Dim vform As New ListOperattion1
            vform.Field = "DOCNO,DOCDATE"
            vform.vFormatstring = "       DOC NO            |         DOC DATE   | INDENTNO                                                        "
            vform.vCaption = "AUTHORIZED INDENT  NO HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_docno.Text = Trim(vform.keyfield & "")
                ssgrid.ClearRange(1, 1, -1, -1, True)

                Call txt_docno_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_PONo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_PONo.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If Cmd_PONoHelp.Enabled = True Then
                    search = Trim(txt_PONo.Text)
                    Call Cmd_PONoHelp_Click(Cmd_PONoHelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_PONo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_PONo.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_PONo.Text) = "" Then
                    Call Cmd_PONoHelp_Click(Cmd_PONoHelp, e)
                Else
                    txt_PONo_Validated(txt_PONo, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub



    Private Sub txt_PONo_Validated(sender As Object, e As EventArgs) Handles txt_PONo.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, remarks As String
        Dim vTypeseqno, Clsquantity, vGroupseqno As Double
        With ssgrid
            .Col = 7
            .Row = i
            .ColHidden = False
        End With
        Try
            If Trim(txt_PONo.Text) <> "" Then
                sqlstring = "SELECT ISNULL(AUTHDOCNO,'')AUTHDOCNO,ISNULL(STORE,'')STORE,ISNULL(DINO,'')DINO,ISNULL(DIDATE,'')DIDATE,ISNULL(VENDORCODE,'')VENDORCODE,ISNULL(VENDORNAME,'')VENDORNAME,ISNULL(FREEZE,'')FREEZE,ISNULL(UPDATEUSER,'')UPDATEUSER,ISNULL(UPDATETIME,'')UPDATETIME FROM DI_DET WHERE DINO='" + txt_PONo.Text + "'AND DITYPE='MANUAL'"
                gconnection.getDataSet(sqlstring, "DI_HDR")
                If gdataset.Tables("DI_HDR").Rows.Count > 0 Then
                    CmdAdd.Text = "Update[F7]"
                    txt_docno.Text = Trim(gdataset.Tables("DI_HDR").Rows(0).Item("AUTHDOCNO") & "")
                    cbo_dept.Text = Trim(gdataset.Tables("DI_HDR").Rows(0).Item("STORE") & "")
                    Cbo_PODate.Text = Format(CDate(gdataset.Tables("DI_HDR").Rows(0).Item("DIDATE")), "dd-MM-yyyy")
                    Txt_Vcode.Text = Trim(gdataset.Tables("DI_HDR").Rows(0).Item("VENDORCODE") & "")
                    Txt_Vname.Text = Trim(gdataset.Tables("DI_HDR").Rows(0).Item("VENDORNAME") & "")
                End If
            End If
            Dim strsql As String
            Dim STRITEMCODE, STRITEMUOM As String
            sqlstring = "SELECT ISNULL(ITEMCODE,'')ITEMCODE	,ISNULL(ITEMNAME,'')ITEMNAME,	ISNULL(QTY,0)QTY,	UOM	,RATE,	AMOUNT,isnull(freeze,'')as FREEZE FROM DI_DET WHERE  DINO ='" & Trim(txt_PONo.Text) & "' AND DITYPE='MANUAL' ORDER BY AUTOID"
            gconnection.getDataSet(sqlstring, "DI_DET")
            If gdataset.Tables("DI_DET").Rows.Count > 0 Then
                For i = 1 To gdataset.Tables("DI_DET").Rows.Count

                    ssgrid.SetText(1, i, Trim(gdataset.Tables("DI_DET").Rows(j).Item("ITEMCODE")))
                    STRITEMCODE = Trim(gdataset.Tables("DI_DET").Rows(j).Item("ITEMCODE"))
                    ssgrid.SetText(2, i, Trim(gdataset.Tables("DI_DET").Rows(j).Item("ITEMNAME")))
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("DI_DET").Rows(j).Item("UOM"))
                    STRITEMUOM = Trim(gdataset.Tables("DI_DET").Rows(j).Item("UOM"))
                    ssgrid.Text = Trim(gdataset.Tables("DI_DET").Rows(j).Item("UOM"))
                    ssgrid.SetText(4, i, Val(gdataset.Tables("DI_DET").Rows(j).Item("QTY")))
                    ssgrid.SetText(12, i, Format(Val(gdataset.Tables("DI_DET").Rows(j).Item("QTY")), "0.000"))
                    ssgrid.SetText(5, i, Format(Val(gdataset.Tables("DI_DET").Rows(j).Item("RATE")), "0.00"))
                    ssgrid.SetText(6, i, Format(Val(gdataset.Tables("DI_DET").Rows(j).Item("AMOUNT")), "0.00"))
                    If gdataset.Tables("DI_DET").Rows(0).Item("FREEZE") = "Y" Then
                        ssgrid.Row = i
                        ssgrid.Col = 7
                        ssgrid.Text = "REJECT"
                    Else
                        ssgrid.Row = i
                        ssgrid.Col = 7
                        ssgrid.Text = "ACCEPT"

                    End If
                    j = j + 1
                Next
                If gdataset.Tables("DI_HDR").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = "Record Freezed On " & Format(CDate(gdataset.Tables("DI_HDR").Rows(0).Item("UPDATETIME")), "dd-MMM-yyyy")
                    Me.Cmd_FREEZE.Enabled = True

                    ' Me.Cmd_FREEZE.Text = "UnVoid[F8]"
                    Cmd_FREEZE.Enabled = False
                    Me.CmdAdd.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.Cmd_FREEZE.Enabled = True
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_FREEZE.Text = "Void[F8]"
                End If
            End If
            Call Grid_lock()
            Calculate()
        Catch ex As Exception
            MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

    Private Sub txt_PONo_TextChanged(sender As Object, e As EventArgs) Handles txt_PONo.TextChanged

    End Sub

    Private Function Grid_lock()
        Dim i, j As Integer
        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            For j = 1 To ssgrid.MaxCols
                ssgrid.Col = j
                ssgrid.Lock = True
                With ssgrid
                    ssgrid.Col = 4
                    ssgrid.Lock = False
                    ssgrid.Col = 7
                    ssgrid.Lock = False
                End With
            Next
        Next

    End Function

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Function GridRowUnLock()
        Dim i As Integer
        With ssgrid
            For i = 1 To .DataRowCnt
                .Row = i

                .Col = 2
                .Lock = False

                .Col = 3
                .Lock = False

                .Col = 5
                .Lock = False

                .Col = 6
                .Lock = False
            Next i
        End With

    End Function

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        txt_docno.Text = ""
        txt_qty.Text = ""
        txt_Totalamount.Text = ""
        txt_PONo.Text = ""
        Txt_Vcode.Text = ""
        Txt_Vname.Text = ""
        cbo_dept.Text = ""
        With ssgrid
            .Col = 7
            .Row = i
            .ColHidden = True
        End With
        txt_PONo.ReadOnly = True
        txt_docno.ReadOnly = True
        Me.lbl_Freeze.Visible = False
        CmdAdd.Text="Add[F7]"
        autogenerate1()
        Me.Cbo_PODate.Value = Format(Now, "dd/MM/yyyy")

        Call GridRowUnLock()

        ssgrid.ClearRange(1, 1, -1, -1, True)

    End Sub

    Private Sub ssgrid_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub

    Private Sub Calculate()
        Try
            Dim ValQty, ValRate, ValDiscount, VarTotal, clsquantiy As Double
            Dim ValHighratio, ValItemamount, ValDblamount, Calqty, varqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Or ssgrid.ActiveCol = 3 Or ssgrid.ActiveCol = 4 Or ssgrid.ActiveCol = 5 Then
                i = ssgrid.ActiveRow
                ssgrid.Col = 4
                ssgrid.Row = i
                ValQty = Val(ssgrid.Text)
                ssgrid.Col = 5
                ssgrid.Row = i
                ValRate = Val(ssgrid.Text)
                ValItemamount = Format(Val(ValQty) * Val(ValRate), "0.00")
                If Val(ValItemamount) = 0 Then
                    ssgrid.SetText(6, i, "")
                    ssgrid.SetText(7, i, "")
                Else
                    ssgrid.SetText(6, i, Val(ValItemamount))
                End If
                ssgrid.Col = 2
                ssgrid.Row = i
                Me.txt_Totalamount.Text = 0
                VarTotal = 0
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 6
                    ssgrid.Row = i
                    VarTotal = Val(ssgrid.Text)
                    Me.txt_Totalamount.Text = Format(Val(Me.txt_Totalamount.Text) + Val(VarTotal), "0.00")
                Next i
                i = i - 1
                varqty = 0
                Me.txt_qty.Text = 0
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    varqty = Val(ssgrid.Text)
                    Me.txt_qty.Text = Format(Val(Me.txt_qty.Text) + Val(varqty), "0.00")
                Next i
                i = i - 1
            End If
            ssgrid.Col = 4
            ssgrid.Lock = False
            ssgrid.Col = 7
            ssgrid.Lock = False

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub autogenerate1()
        Dim sqlstring, financalyear As String
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            sqlstring = "SELECT MAX(SUBSTRING(DINO,1,5)) FROM DI_HDR  "
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    '  txt_IndentNo.Text = "IND/000001/" & financalyear
                    ' txt_IndentNo.Text =
                    txt_PONo.Text = Format(1, "0000")
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    '  txt_IndentNo.Text = "IND/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    txt_PONo.Text = Format(gdreader(0) + 1, "0000")
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_PONo.Text = Format(1, "0000")
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    'Private Sub autogenerate()
    '    Try
    '        Dim sqlstring, financalyear As String
    '        gcommand = New SqlCommand
    '        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
    '        docno = "DO"


    '        sqlstring = "SELECT MAX(SUBSTRING(DINO,1,5)) FROM DI_HDR WHERE "
    '        gconnection.openConnection()
    '        gcommand.CommandText = sqlstring
    '        gcommand.CommandType = CommandType.Text
    '        gcommand.Connection = gconnection.Myconn
    '        gdreader = gcommand.ExecuteReader
    '        If gdreader.Read Then
    '            If gdreader(0) Is System.DBNull.Value Then
    '                txt_PONo.Text = docno & "/00001/" & financalyear
    '                gdreader.Close()
    '                gcommand.Dispose()
    '                gconnection.closeConnection()
    '            Else
    '                txt_PONo.Text = docno & "/" & Format(gdreader(0) + 1, "00000") & "/" & financalyear
    '                gdreader.Close()
    '                gcommand.Dispose()
    '                gconnection.closeConnection()
    '            End If
    '        Else
    '            txt_PONo.Text = docno & "/00001/" & financalyear
    '            gdreader.Close()
    '            gcommand.Dispose()
    '            gconnection.closeConnection()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub

    Private Sub ssgrid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        'Dim QTY, SQLSTRING As String
        'If e.keyCode = Keys.Enter Then
        '    i = ssgrid.ActiveRow
        '    If ssgrid.ActiveCol = 1 Then
        '        ssgrid.Col = 4
        '        ssgrid.Row = i
        '        ssgrid.Text = QTY
        '        SQLSTRING = ""
        '    End If
        'End If
    End Sub

    Private Sub ssgrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim Issuerate, Highratio, Dblamount, clsquantity As Double
        Dim ItemQty, ItemAmount, ItemRate, IssueQty, CurrentQty As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim focusbool As Boolean
        Dim i, j, K As Integer
        search = Nothing
        If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Then
            Call Calculate()
        End If
        Try
            i = ssgrid.ActiveRow
            If ssgrid.ActiveCol = 4 Then
                ssgrid.Col = 1
                i = ssgrid.ActiveRow

                Itemcode = ssgrid.Text
                ssgrid.Col = 4
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If Itemcode <> "" Then
                    gSQLString = "SELECT [dbo].GETREMAINGQUANTITYFORPO ('" + Trim(txt_docno.Text) + "','" + Itemcode + "')"
                    gconnection.getDataSet(gSQLString, "QQTTY")

                    If gdataset.Tables("QQTTY").Rows.Count > 0 Then
                        ItemQty = Val(gdataset.Tables("QQTTY").Rows(0).Item(0))
                        If Val(ssgrid.Text) > ItemQty Then
                            ssgrid.Text = ItemQty
                        End If
                    End If
                End If
                

                'ssgrid.Lock = False
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then

                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.Row = ssgrid.ActiveRow + 1
                        ssgrid.Col = 1
                        ssgrid.Lock = False
                        ssgrid.Col = 2
                        ssgrid.Lock = False
                        ssgrid.Col = 3
                        ssgrid.Lock = False
                        ssgrid.Col = 4
                        ssgrid.Lock = False
                        ssgrid.Col = 5
                        ssgrid.Lock = False
                        ssgrid.Col = 6
                        ssgrid.Lock = False

                        ssgrid.Col = 4
                        i = ssgrid.ActiveRow
                        ssgrid.Row = i
                        IssueQty = Val(ssgrid.Text)

                        ssgrid.Col = 12
                        i = ssgrid.ActiveRow
                        ssgrid.Row = i
                        'CurrentQty = Val(ssgrid.Text)
                        'If IssueQty > CurrentQty Then
                        '    MsgBox("Issue Qty cannot Be Greater Than Indent Qty")
                        '    ssgrid.Col = 4
                        '    ssgrid.Text = ""
                        '    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                        '    Exit Sub
                        'Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                        ' End If
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 5 Then
                ssgrid.Col = 5
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                'ssgrid.Lock = False
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.Row = ssgrid.ActiveRow + 1
                        ssgrid.Col = 1
                        ssgrid.Lock = False
                        ssgrid.Col = 2
                        ssgrid.Lock = False
                        ssgrid.Col = 3
                        ssgrid.Lock = False
                        ssgrid.Col = 4
                        ssgrid.Lock = False
                        ssgrid.Col = 5
                        ssgrid.Lock = False
                        ssgrid.Col = 6
                        ssgrid.Lock = False
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim sqlstring, sql, Qnt, Itemcode, Insert(0) As String
        Dim FromStorecode, ToStorecode, CURRENTQTY, CURRENTRATE, CURRENTAMOUNT, Item, ITEMNAME, UOM, RATE, VALE As String
        Try
            'autogenerate1()

            

            If CmdAdd.Text = "Add[F7]" Then



                If Trim(Txt_Vcode.Text) = "" Then
                    MessageBox.Show("Vendorcode Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Txt_Vcode.Focus()
                    Exit Sub
                End If

                If Trim(Txt_Vname.Text) = "" Then
                    MessageBox.Show("VendorName Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Txt_Vcode.Focus()
                    Exit Sub
                End If
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    Itemcode = ssgrid.Text
                    If Trim(ssgrid.Text) = "" Then
                        MessageBox.Show("Item Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                        ssgrid.Focus()
                        Exit Sub
                    End If



                    ssgrid.Col = 2
                    If Trim(ssgrid.Text) = "" Then
                        MessageBox.Show("Item Description can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                        ssgrid.Focus()
                        Exit Sub
                    End If
                    ssgrid.Col = 3
                    If Trim(ssgrid.Text) = "" Then
                        MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                        ssgrid.Focus()
                        Exit Sub
                    End If
                    ssgrid.Col = 4

                    gSQLString = "SELECT [dbo].GETREMAINGQUANTITYFORPO ('" + Trim(txt_docno.Text) + "','" + Itemcode + "')"
                    gconnection.getDataSet(gSQLString, "QQTTY")

                    If gdataset.Tables("QQTTY").Rows.Count > 0 Then
                        'Qnt = Val(gdataset.Tables("QQTTY").Rows(0).Item(0))
                        Qnt = Format(Val(gdataset.Tables("QQTTY").Rows(0).Item(0)), "0.00")

                    End If


                    If Val(ssgrid.Text) = 0 Then
                        MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                        ssgrid.Focus()
                        Exit Sub
                    End If

                    If Val(ssgrid.Text) > Qnt Then
                        MessageBox.Show("Quantity Should not Greater than Indent Qty..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                        ssgrid.Focus()
                        Exit Sub
                    End If
                    ssgrid.Col = 5
                    If Val(ssgrid.Text) = 0 Then
                        ' MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        'ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                        'ssgrid.Focus()
                        ssgrid.Text = 1
                        'Exit Sub
                    End If
                    ssgrid.Col = 6
                    If Val(ssgrid.Text) = 0 Then
                        'MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        'ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                        'ssgrid.Focus()
                        'Exit Sub
                        ssgrid.Text = 1
                    End If
                Next


                sqlstring = "INSERT INTO DI_HDR ( AUTHDOCNO,	STORE,	DINO,	DIDATE,	VENDORCODE,	VENDORNAME,	FREEZE,	ADDUSER	,ADDDATETIME,DITYPE)"
                sqlstring = sqlstring & "VALUES ('" & txt_docno.Text & "','" & cbo_dept.Text & "','" & txt_PONo.Text & "','" & Format(CDate(Cbo_PODate.Value), "dd-MMM-yyyy") & "','" & Txt_Vcode.Text & "','" & Txt_Vname.Text & "','N','" & gUsername & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','MANUAL')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        Item = Trim(ssgrid.Text)
                        ssgrid.Col = 2
                        ssgrid.Row = i
                        ITEMNAME = Trim(ssgrid.Text)
                        ssgrid.Col = 3
                        ssgrid.Row = i
                        UOM = Trim(ssgrid.Text)
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        CURRENTQTY = Trim(ssgrid.Text)
                        ssgrid.Col = 5
                        ssgrid.Row = i
                        CURRENTRATE = Trim(ssgrid.Text)
                        ssgrid.Col = 6
                        ssgrid.Row = i
                        CURRENTAMOUNT = Trim(ssgrid.Text)
                        ssgrid.Col = 7
                        ssgrid.Row = i
                        VALE = Trim(ssgrid.Text)
                        sqlstring = "INSERT INTO  DI_DET "
                        sqlstring = sqlstring & "(AUTHDOCNO,STORE,DINO,DIDATE,VENDORCODE,VENDORNAME,ITEMCODE,ITEMNAME,UOM,QTY,RATE,	AMOUNT,FREEZE,ADDUSER,ADDDATETIME,DITYPE)values"
                        sqlstring = sqlstring & "('" & txt_docno.Text & "','" & cbo_dept.Text & "','" & txt_PONo.Text & "','" & Format(CDate(Cbo_PODate.Value), "dd-MMM-yyyy") & "','" & Txt_Vcode.Text & "','" & Txt_Vname.Text & "',"
                        sqlstring = sqlstring & "'" & Item & "',"
                        sqlstring = sqlstring & "'" & ITEMNAME & "',"
                        sqlstring = sqlstring & "'" & UOM & "',"
                        sqlstring = sqlstring & "'" & CURRENTQTY & "',"
                        sqlstring = sqlstring & "'" & CURRENTRATE & "',"
                        sqlstring = sqlstring & "'" & CURRENTAMOUNT & "',"
                        sqlstring = sqlstring & "'N',"
                        sqlstring = sqlstring & "'" & gUsername & "',"
                        sqlstring = sqlstring & "'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                        sqlstring = sqlstring & "'MANUAL')"



                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                        sqlstring = " insert into Indent_Used(Indent_no ,docno,Indentdate,Docdate ,itemcode   ,uom,indentqty ,TransactionQty ,rate,TransactionType,storecode )"

                        sqlstring = sqlstring & "values ('" & Trim(txt_docno.Text) & "','" & Trim(txt_PONo.Text) & "','" & Format(CDate(Cbo_PODate.Value), "dd-MMM-yyyy") & "',"
                        sqlstring = sqlstring & "'" & Format(CDate(Cbo_PODate.Value), "dd-MMM-yyyy") & "',"
                        ssgrid.Col = 1
                        ssgrid.Row = i

                        sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                        ssgrid.Col = 3
                        ssgrid.Row = i
                        sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                        sqlstring = sqlstring & "'0.00',"
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","
                        ssgrid.Col = 5
                        ssgrid.Row = i

                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","
                        sqlstring = sqlstring & "'DO',"
                        sqlstring = sqlstring & "'" & cbo_dept.Text & "')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End With
                Next i

               

                gconnection.MoreTrans(Insert)

            Else


                Dim i, j As Integer
                If MessageBox.Show("Do You Want To Update existing DI ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                    sqlstring = "UPDATE  DI_HDR "

                    sqlstring = sqlstring & " SET VENDORCODE='" + Txt_Vcode.Text + "',VENDORNAME='" + Txt_Vname.Text + "',"
                    sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & " ',"
                    sqlstring = sqlstring & " UPDATETIME ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    If VALE = "REJECT" Then
                        sqlstring = sqlstring & "FREEZE='Y'"
                    End If

                    sqlstring = sqlstring & " WHERE DINO = '" & Trim(txt_PONo.Text) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring


                    For i = 1 To ssgrid.DataRowCnt
                        With ssgrid
                            ssgrid.Col = 1
                            ssgrid.Row = i
                            Item = Trim(ssgrid.Text)
                            ssgrid.Col = 4
                            ssgrid.Row = i
                            CURRENTQTY = Trim(ssgrid.Text)
                            ssgrid.Col = 5
                            ssgrid.Row = i
                            CURRENTRATE = Trim(ssgrid.Text)
                            ssgrid.Col = 6
                            ssgrid.Row = i
                            CURRENTAMOUNT = Trim(ssgrid.Text)
                            ssgrid.Col = 7
                            ssgrid.Row = i
                            VALE = Trim(ssgrid.Text)
                            sqlstring = "UPDATE  DI_DET "

                            sqlstring = sqlstring & " SET QTY= '" + CURRENTQTY + "',AMOUNT='" + CURRENTAMOUNT + "',VENDORCODE='" + Txt_Vcode.Text + "',VENDORNAME='" + Txt_Vname.Text + "',"
                            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & " ',"
                            sqlstring = sqlstring & " UPDATETIME ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                            If VALE = "REJECT" Then
                                sqlstring = sqlstring & ",FREEZE='Y'"
                            End If

                            sqlstring = sqlstring & " WHERE DINO = '" & Trim(txt_PONo.Text) & "'AND ITEMCODE='" + Item + "'"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                            sqlstring = "update indent_used set TransactionQty= '" + CURRENTQTY + "' "
                            If VALE = "REJECT" Then
                                sqlstring = sqlstring & ",FREEZE='Y'"
                            End If
                            sqlstring = sqlstring & " WHERE DocNO = '" & Trim(txt_PONo.Text) & "'AND ITEMCODE='" + Item + "'"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = sqlstring
                        End With
                    Next i

                End If

                gconnection.MoreTrans(Insert)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        Call CmdClear_Click(sender, e)
    End Sub


    Private Sub Cmd_FREEZE_Click(sender As Object, e As EventArgs) Handles Cmd_FREEZE.Click
        Dim sqlstring, sql, Itemcode, Insert(0) As String
        Dim FromStorecode, ToStorecode, CURRENTQTY, CURRENTRATE, CURRENTAMOUNT, Item, VALE As String
        Try
            Dim i, j As Integer
            If MessageBox.Show("Do You Want To freeze existing Indent ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                sqlstring = "UPDATE  DI_DET set freeze='Y' ,UPDATEUSER='" & gUsername & "', UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'WHERE DINO = '" & Trim(txt_PONo.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                sqlstring = "UPDATE  DI_HDR set freeze='Y',UPDATEUSER='" & gUsername & "', UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' WHERE DINO = '" & Trim(txt_PONo.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                sqlstring = "UPDATE  Indent_Used set freeze='Y' WHERE DOCNO = '" & Trim(txt_PONo.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
            End If

            gconnection.MoreTrans(Insert)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        Call CmdClear_Click(sender, e)
    End Sub

    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click
        Try
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_dibill_
            sqlstring = sqlstring & " SELECT 	ISNULL(DINO,'') INDENT_NO, ISNULL(DIDATE,'')  INDENT_DATE,"
            sqlstring = sqlstring & " ISNULL(STORE,'') FROMSTORECODE , ISNULL(STORE,'') STORELOCATIONCODE, ISNULL(STORE,'') STORELOCATIONNAME,"
            sqlstring = sqlstring & " ''AS PRODUCT_TYPE, '' AS REMARKS,VENDORCODE as updsign,VENDORNAME  as updfooter,"
            sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            sqlstring = sqlstring & " ISNULL(QTY,0) QTY, ISNULL(RATE,0) RATE, ISNULL(AMOUNT,0) AMOUNT , ISNULL(ADDDATETIME,'') ADDDATE "
            sqlstring = sqlstring & " FROM DI_DET"
            ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            sqlstring = sqlstring & " WHERE DINO = '" & Trim(txt_PONo.Text) & "' "

            gconnection.getDataSet(sqlstring, "VW_INV_IDENTBILL")

            SSQL = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("FROMSTORECODE") & "' "
            gconnection.getDataSet(SSQL, "FROMSTORE")
            If gdataset.Tables("FROMSTORE").Rows.Count > 0 Then
                FROMSTORE = gdataset.Tables("FROMSTORE").Rows(0).Item("STOREDESC")
            End If
            If gdataset.Tables("VW_INV_IDENTBILL").Rows.Count > 0 Then

                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_IDENTBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim textobj As TextObject
                textobj = r.ReportDefinition.ReportObjects("Text6")
                textobj.Text = FROMSTORE
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text16")
                textobj2.Text = gUsername
                Dim textobj3 As TextObject
                textobj3 = r.ReportDefinition.ReportObjects("Text21")
                textobj3.Text = gUsername
                Dim textobj4 As TextObject
                textobj4 = r.ReportDefinition.ReportObjects("Text19")
                textobj4.Text = Address1 & " , " & Address2 & " , " & gCity & " - " & gPincode
                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text23")
                '  textobj5.Text = "Tel:" & GPHONE & " ,40090019, Fax:" & gFax & ", Email:" & gEmail & "" & ", Web:" & gWebsite
                If gFax = "" Then
                    textobj5.Text = "Tel:" & GPHONE & " , Email:" & gEmail & "" & ", Web:" & gWebsite
                Else
                    textobj5.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & "" & ", Web:" & gWebsite
                End If
                Dim TEXTOBJ6 As TextObject
                TEXTOBJ6 = r.ReportDefinition.ReportObjects("Text25")
                ' TEXTOBJ6.Text = "GSTIN :" & gServiceTax & " , Tin No.:" & gTinNo
                If gTinNo = "" Then
                    TEXTOBJ6.Text = "GSTIN :" & gServiceTax & " "
                Else
                    TEXTOBJ6.Text = "GSTIN :" & gServiceTax & " , Tin No.:" & gTinNo
                End If
                rViewer.Show()
            End If

            'Else
            'gPrint = False
            'Call printoperation()
            ''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlstring As String
        Dim vform As New ListOperattion1
        'gSQLString = "SELECT ISNULL(SLCODE,0) AS SLCODE, ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER "
        'gSQLString = "SELECT ISNULL(VENDORCODE,'') AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER "
        gSQLString = "SELECT DISTINCT ISNULL(VENDORCODE,'') AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME  FROM vendoritem "
        gSQLString = "SELECT DISTINCT ISNULL(VENDORCODE,'') AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME  FROM Invitem_VendorMaster 
         
        M_WhereCondition = "where itemcode In  (Select itemcode from AUTO_DI where dOCNO='" & txt_docno.Text & "'and ditype='MANUAL')"
        If Trim(search) = " " Then
        Else


        End If
        vform.Field = " VENDORNAME,VENDORCODE  "
        vform.vFormatstring = "     VENDOR CODE     |                   VENDOR NAME          "
        vform.vCaption = "VENDOR MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Vcode.Text = Trim(vform.keyfield & "")
            Txt_Vname.Text = Trim(vform.keyfield1 & "")
            Txt_Vcode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_docno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_docno.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmddochelp.Enabled = True Then
                    search = Trim(txt_docno.Text)
                    Call cmddochelp_Click(cmddochelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_docno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_docno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_docno.Text) = "" Then
                    Call cmddochelp_Click(cmddochelp, e)
                Else
                    txt_docno_Validated(txt_docno, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_docno_TextChanged(sender As Object, e As EventArgs) Handles txt_docno.TextChanged

    End Sub

    Private Sub txt_docno_Validated(sender As Object, e As EventArgs) Handles txt_docno.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, remarks, STRITEMCODE, STRITEMUOM As String
        Dim vTypeseqno, Clsquantity, vGroupseqno, AVBL, AVBLQTY, CURENTQTY As Double

        If txt_docno.Text <> "" Then



            sqlstring = "SELECT  * FROM AUTO_DI WHERE DOCNO='" & txt_docno.Text & "' "
            gconnection.getDataSet(sqlstring, "AUTO_DI")
            If gdataset.Tables("AUTO_DI").Rows.Count > 0 Then
                cbo_dept.Text = Trim(gdataset.Tables("AUTO_DI").Rows(0).Item("OPSTORELOCATIONCODE") & "")
                For i = 1 To gdataset.Tables("AUTO_DI").Rows.Count


                    ssgrid.SetText(1, i, Trim(gdataset.Tables("AUTO_DI").Rows(j).Item("ITEMCODE")))
                    STRITEMCODE = Trim(gdataset.Tables("AUTO_DI").Rows(j).Item("ITEMCODE"))


                    gSQLString = "SELECT [dbo].GETREMAINGQUANTITYFORPO ('" + Trim(txt_docno.Text) + "','" + STRITEMCODE + "')"
                    gconnection.getDataSet(gSQLString, "QQTTY")
                   



                    ssgrid.SetText(2, i, Trim(gdataset.Tables("AUTO_DI").Rows(j).Item("ITEMNAME")))
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("AUTO_DI").Rows(j).Item("UOM"))
                    STRITEMUOM = Trim(gdataset.Tables("AUTO_DI").Rows(j).Item("UOM"))
                    ssgrid.Text = Trim(gdataset.Tables("AUTO_DI").Rows(j).Item("UOM"))
                    'ssgrid.SetText(4, i, Val(gdataset.Tables("AUTO_DI").Rows(j).Item("QTY")))
                    'ssgrid.Col = 4
                    'ssgrid.Row = i
                    'ssgrid.Text = CURENTQTY
                    If gdataset.Tables("QQTTY").Rows.Count > 0 Then
                        ssgrid.SetText(4, i, Val(gdataset.Tables("QQTTY").Rows(0).Item(0)))
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Lock = False
                    Else
                        ssgrid.DeleteRows(i, 1)
                    End If
                    ssgrid.SetText(12, i, Format(Val(gdataset.Tables("AUTO_DI").Rows(j).Item("QTY")), "0.000"))
                    ssgrid.SetText(5, i, Format(Val(gdataset.Tables("AUTO_DI").Rows(j).Item("RATE")), "0.00"))
                    ssgrid.SetText(6, i, Format(Val(gdataset.Tables("AUTO_DI").Rows(j).Item("AMOUNT")), "0.00"))

                    j = j + 1
                Next
            End If
        End If
        Call Calculate()
    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Private Sub txt_Totalamount_TextChanged(sender As Object, e As EventArgs) Handles txt_Totalamount.TextChanged

    End Sub

    Private Sub txt_qty_TextChanged(sender As Object, e As EventArgs) Handles txt_qty.TextChanged

    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub AmendmentGrid_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles AmendmentGrid.Advance

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub Chk_Amendment_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Amendment.CheckedChanged

    End Sub

    Private Sub Chk_Followup_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Followup.CheckedChanged

    End Sub

    Private Sub Label48_Click(sender As Object, e As EventArgs) Handles Label48.Click

    End Sub

    Private Sub FollowupGrid_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles FollowupGrid.Advance

    End Sub

    Private Sub Grp_amend_Follow_Enter(sender As Object, e As EventArgs) Handles Grp_amend_Follow.Enter

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click

    End Sub

    Private Sub Cmd_Ok_Click(sender As Object, e As EventArgs) Handles Cmd_Ok.Click

    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click

    End Sub

    Private Sub Cmd_WarrantyCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_WarrantyCodeHelp.Click

    End Sub

    Private Sub Txt_WarrantyCode_TextChanged(sender As Object, e As EventArgs) Handles Txt_WarrantyCode.TextChanged

    End Sub

    Private Sub Cmd_OtherTermCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_OtherTermCodeHelp.Click

    End Sub

    Private Sub Txt_OtherTermCode_TextChanged(sender As Object, e As EventArgs) Handles Txt_OtherTermCode.TextChanged

    End Sub

    Private Sub Ssgrid_reference_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles Ssgrid_reference.Advance

    End Sub

    Private Sub Ssgrid_subject_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles Ssgrid_subject.Advance

    End Sub

    Private Sub Ssgrid_body_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles Ssgrid_body.Advance

    End Sub

    Private Sub Group_MC_Enter(sender As Object, e As EventArgs) Handles Group_MC.Enter

    End Sub

    Private Sub Lbl_Marquee_Click(sender As Object, e As EventArgs) Handles Lbl_Marquee.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click

    End Sub

    Private Sub Cmb_CSTForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_CSTForm.SelectedIndexChanged

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click

    End Sub

    Private Sub Cbo_Closure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_Closure.SelectedIndexChanged

    End Sub

    Private Sub Txt_CreditDays_TextChanged(sender As Object, e As EventArgs) Handles Txt_CreditDays.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub grp_cstform_Enter(sender As Object, e As EventArgs) Handles grp_cstform.Enter

    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Txt_Encl_TextChanged(sender As Object, e As EventArgs) Handles Txt_Encl.TextChanged

    End Sub

    Private Sub Chk_MC_Form_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_MC_Form.CheckedChanged

    End Sub

    Private Sub grp_encl_Enter(sender As Object, e As EventArgs) Handles grp_encl.Enter

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub Cmb_delivery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_delivery.SelectedIndexChanged

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Cmb_despatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_despatch.SelectedIndexChanged

    End Sub

    Private Sub Cmb_shipping_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_shipping.SelectedIndexChanged

    End Sub

    Private Sub Lbl_Freight_Click(sender As Object, e As EventArgs) Handles Lbl_Freight.Click

    End Sub

    Private Sub Cmb_Freight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Freight.SelectedIndexChanged

    End Sub

    Private Sub grp_freight_Enter(sender As Object, e As EventArgs) Handles grp_freight.Enter

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub lbl_GroupCode_Click(sender As Object, e As EventArgs) Handles lbl_GroupCode.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Txt_Vname_TextChanged(sender As Object, e As EventArgs) Handles Txt_Vname.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Txt_Vcode_TextChanged(sender As Object, e As EventArgs) Handles Txt_Vcode.TextChanged

    End Sub

    Private Sub Cbo_PODate_ValueChanged(sender As Object, e As EventArgs) Handles Cbo_PODate.ValueChanged

    End Sub

    Private Sub cbo_dept_TextChanged(sender As Object, e As EventArgs) Handles cbo_dept.TextChanged

    End Sub

    Private Sub Label52_Click(sender As Object, e As EventArgs) Handles Label52.Click

    End Sub

    Private Sub lbl_Heading_Click(sender As Object, e As EventArgs) Handles lbl_Heading.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

  
End Class