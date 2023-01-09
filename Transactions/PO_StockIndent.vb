Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail

Public Class PO_StockIndent
    Inherits System.Windows.Forms.Form
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
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents dtp_Excisepassdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Grndate As System.Windows.Forms.Label
    Friend WithEvents lbl_Grnno As System.Windows.Forms.Label
    Friend WithEvents lbl_Excisepassno As System.Windows.Forms.Label
    Friend WithEvents lbl_Excisepassdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents lbl_Suppliercode As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents txt_Excisepassno As System.Windows.Forms.TextBox
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents grp_Grngroup1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdValueby As System.Windows.Forms.Button
    Friend WithEvents OptPercentage As System.Windows.Forms.RadioButton
    Friend WithEvents OptValue As System.Windows.Forms.RadioButton
    Friend WithEvents txtChangeValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRoundoff As System.Windows.Forms.Button
    Friend WithEvents OptNearest As System.Windows.Forms.RadioButton
    Friend WithEvents OptNone As System.Windows.Forms.RadioButton
    Friend WithEvents grp_StockGrndetails As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_StockGrndetails As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_StockGrnprint As System.Windows.Forms.Button
    Friend WithEvents Cmd_StockGrnView As System.Windows.Forms.Button
    Friend WithEvents Cmd_StockGrnexit As System.Windows.Forms.Button
    Friend WithEvents Cmd_StockGrnClear As System.Windows.Forms.Button
    Friend WithEvents grp_Billingdetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grp_Excisedetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Trucknumber As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Stockindate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Trucknumber As System.Windows.Forms.Label
    Friend WithEvents lbl_Stockindate As System.Windows.Forms.Label
    Friend WithEvents ssgrid_billdetails As AxFPSpreadADO.AxfpSpread
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_ToDocno As System.Windows.Forms.Button
    Friend WithEvents Cmd_FromDocno As System.Windows.Forms.Button
    Friend WithEvents txt_ToDocno As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromDocno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ToDocno As System.Windows.Forms.Label
    Friend WithEvents lbl_FromDocno As System.Windows.Forms.Label
    Friend WithEvents txt_storeDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents txt_storecode As System.Windows.Forms.TextBox
    Friend WithEvents txt_IndentNo As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Indentdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmd_indentnoHelp As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmd_Print As System.Windows.Forms.Button
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXT_FROMSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromStorename As System.Windows.Forms.TextBox
    Friend WithEvents cmd_fromStorecodeHelp As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_qty As System.Windows.Forms.TextBox
    Friend WithEvents txt_Totalamount As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PO_StockIndent))
        Me.dtp_Excisepassdate = New System.Windows.Forms.DateTimePicker()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.lbl_Suppliercode = New System.Windows.Forms.Label()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.cmd_Print = New System.Windows.Forms.Button()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_FREEZE = New System.Windows.Forms.Button()
        Me.cmd_Add = New System.Windows.Forms.Button()
        Me.cmd_View = New System.Windows.Forms.Button()
        Me.dtp_Indentdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.lbl_Grndate = New System.Windows.Forms.Label()
        Me.lbl_Grnno = New System.Windows.Forms.Label()
        Me.grp_Grngroup1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_IndentNo = New System.Windows.Forms.TextBox()
        Me.txt_storecode = New System.Windows.Forms.TextBox()
        Me.TXT_FROMSTORECODE = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_FromStorename = New System.Windows.Forms.TextBox()
        Me.cmd_fromStorecodeHelp = New System.Windows.Forms.Button()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_storeDesc = New System.Windows.Forms.TextBox()
        Me.cmd_indentnoHelp = New System.Windows.Forms.Button()
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox()
        Me.lbl_Excisepassno = New System.Windows.Forms.Label()
        Me.lbl_Excisepassdate = New System.Windows.Forms.Label()
        Me.txt_Excisepassno = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdRoundoff = New System.Windows.Forms.Button()
        Me.OptNearest = New System.Windows.Forms.RadioButton()
        Me.OptNone = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdValueby = New System.Windows.Forms.Button()
        Me.OptPercentage = New System.Windows.Forms.RadioButton()
        Me.OptValue = New System.Windows.Forms.RadioButton()
        Me.txtChangeValue = New System.Windows.Forms.TextBox()
        Me.grp_StockGrndetails = New System.Windows.Forms.GroupBox()
        Me.lbl_StockGrndetails = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Cmd_StockGrnprint = New System.Windows.Forms.Button()
        Me.Cmd_StockGrnView = New System.Windows.Forms.Button()
        Me.Cmd_StockGrnexit = New System.Windows.Forms.Button()
        Me.Cmd_StockGrnClear = New System.Windows.Forms.Button()
        Me.lbl_FromDocno = New System.Windows.Forms.Label()
        Me.txt_FromDocno = New System.Windows.Forms.TextBox()
        Me.Cmd_FromDocno = New System.Windows.Forms.Button()
        Me.txt_ToDocno = New System.Windows.Forms.TextBox()
        Me.Cmd_ToDocno = New System.Windows.Forms.Button()
        Me.lbl_ToDocno = New System.Windows.Forms.Label()
        Me.grp_Billingdetails = New System.Windows.Forms.GroupBox()
        Me.ssgrid_billdetails = New AxFPSpreadADO.AxfpSpread()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grp_Excisedetails = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Trucknumber = New System.Windows.Forms.TextBox()
        Me.dtp_Stockindate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Trucknumber = New System.Windows.Forms.Label()
        Me.lbl_Stockindate = New System.Windows.Forms.Label()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txt_qty = New System.Windows.Forms.TextBox()
        Me.txt_Totalamount = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.frmbut.SuspendLayout()
        Me.grp_Grngroup1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grp_StockGrndetails.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grp_Billingdetails.SuspendLayout()
        CType(Me.ssgrid_billdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Excisedetails.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp_Excisepassdate
        '
        Me.dtp_Excisepassdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Excisepassdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Excisepassdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Excisepassdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Excisepassdate.Location = New System.Drawing.Point(288, 148)
        Me.dtp_Excisepassdate.Name = "dtp_Excisepassdate"
        Me.dtp_Excisepassdate.Size = New System.Drawing.Size(259, 35)
        Me.dtp_Excisepassdate.TabIndex = 2
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Remarks.Location = New System.Drawing.Point(125, 22)
        Me.txt_Remarks.MaxLength = 200
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(489, 37)
        Me.txt_Remarks.TabIndex = 8
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(19, 17)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(101, 21)
        Me.lbl_Remarks.TabIndex = 43
        Me.lbl_Remarks.Text = "REMARKS"
        '
        'lbl_Suppliercode
        '
        Me.lbl_Suppliercode.AutoSize = True
        Me.lbl_Suppliercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Suppliercode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Suppliercode.Location = New System.Drawing.Point(51, 66)
        Me.lbl_Suppliercode.Name = "lbl_Suppliercode"
        Me.lbl_Suppliercode.Size = New System.Drawing.Size(109, 21)
        Me.lbl_Suppliercode.TabIndex = 28
        Me.lbl_Suppliercode.Text = "INDENT NO"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.cmd_export)
        Me.frmbut.Controls.Add(Me.cmd_Print)
        Me.frmbut.Controls.Add(Me.cmd_Exit)
        Me.frmbut.Controls.Add(Me.cmd_Clear)
        Me.frmbut.Controls.Add(Me.Cmd_FREEZE)
        Me.frmbut.Controls.Add(Me.cmd_Add)
        Me.frmbut.Controls.Add(Me.cmd_View)
        Me.frmbut.Location = New System.Drawing.Point(912, 217)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(143, 307)
        Me.frmbut.TabIndex = 25
        Me.frmbut.TabStop = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = Global.SmartCard.My.Resources.Resources.excel
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(11, 229)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(123, 47)
        Me.cmd_export.TabIndex = 14
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
        '
        'cmd_Print
        '
        Me.cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.cmd_Print.Image = Global.SmartCard.My.Resources.Resources.print
        Me.cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Print.Location = New System.Drawing.Point(11, 229)
        Me.cmd_Print.Name = "cmd_Print"
        Me.cmd_Print.Size = New System.Drawing.Size(123, 47)
        Me.cmd_Print.TabIndex = 13
        Me.cmd_Print.Text = "Print[F10]"
        Me.cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Print.UseVisualStyleBackColor = False
        Me.cmd_Print.Visible = False
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.cmd_Exit.Image = Global.SmartCard.My.Resources.Resources._Exit
        Me.cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Exit.Location = New System.Drawing.Point(11, 229)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(123, 47)
        Me.cmd_Exit.TabIndex = 17
        Me.cmd_Exit.Text = "Exit[F11]"
        Me.cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Exit.UseVisualStyleBackColor = False
        '
        'cmd_Clear
        '
        Me.cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.cmd_Clear.Image = Global.SmartCard.My.Resources.Resources.Clear
        Me.cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Clear.Location = New System.Drawing.Point(11, 17)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(123, 47)
        Me.cmd_Clear.TabIndex = 11
        Me.cmd_Clear.Text = "Clear[F6]"
        Me.cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_FREEZE
        '
        Me.Cmd_FREEZE.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_FREEZE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_FREEZE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_FREEZE.ForeColor = System.Drawing.Color.Black
        Me.Cmd_FREEZE.Image = Global.SmartCard.My.Resources.Resources.Delete
        Me.Cmd_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_FREEZE.Location = New System.Drawing.Point(11, 123)
        Me.Cmd_FREEZE.Name = "Cmd_FREEZE"
        Me.Cmd_FREEZE.Size = New System.Drawing.Size(123, 47)
        Me.Cmd_FREEZE.TabIndex = 12
        Me.Cmd_FREEZE.Text = "Void[F8]"
        Me.Cmd_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_FREEZE.UseVisualStyleBackColor = False
        '
        'cmd_Add
        '
        Me.cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.cmd_Add.Image = Global.SmartCard.My.Resources.Resources.save
        Me.cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Add.Location = New System.Drawing.Point(11, 70)
        Me.cmd_Add.Name = "cmd_Add"
        Me.cmd_Add.Size = New System.Drawing.Size(123, 47)
        Me.cmd_Add.TabIndex = 9
        Me.cmd_Add.Text = "Add [F7]"
        Me.cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Add.UseVisualStyleBackColor = False
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.Black
        Me.cmd_View.Image = Global.SmartCard.My.Resources.Resources.view
        Me.cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_View.Location = New System.Drawing.Point(11, 176)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(123, 47)
        Me.cmd_View.TabIndex = 10
        Me.cmd_View.Text = " View[F9]"
        Me.cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_View.UseVisualStyleBackColor = False
        '
        'dtp_Indentdate
        '
        Me.dtp_Indentdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Indentdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_Indentdate.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.dtp_Indentdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Indentdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Indentdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Indentdate.Location = New System.Drawing.Point(614, 21)
        Me.dtp_Indentdate.Name = "dtp_Indentdate"
        Me.dtp_Indentdate.Size = New System.Drawing.Size(125, 28)
        Me.dtp_Indentdate.TabIndex = 2
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(190, 9)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(129, 33)
        Me.lbl_Heading.TabIndex = 21
        Me.lbl_Heading.Text = "INDENT"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(563, 55)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(374, 29)
        Me.lbl_Freeze.TabIndex = 47
        Me.lbl_Freeze.Text = " "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'lbl_Grndate
        '
        Me.lbl_Grndate.AutoSize = True
        Me.lbl_Grndate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grndate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grndate.Location = New System.Drawing.Point(479, 23)
        Me.lbl_Grndate.Name = "lbl_Grndate"
        Me.lbl_Grndate.Size = New System.Drawing.Size(130, 21)
        Me.lbl_Grndate.TabIndex = 25
        Me.lbl_Grndate.Text = "INDENT DATE"
        '
        'lbl_Grnno
        '
        Me.lbl_Grnno.AutoSize = True
        Me.lbl_Grnno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grnno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grnno.Location = New System.Drawing.Point(51, 24)
        Me.lbl_Grnno.Name = "lbl_Grnno"
        Me.lbl_Grnno.Size = New System.Drawing.Size(72, 21)
        Me.lbl_Grnno.TabIndex = 23
        Me.lbl_Grnno.Text = "STORE"
        '
        'grp_Grngroup1
        '
        Me.grp_Grngroup1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Grngroup1.Controls.Add(Me.PictureBox2)
        Me.grp_Grngroup1.Controls.Add(Me.Label1)
        Me.grp_Grngroup1.Controls.Add(Me.txt_IndentNo)
        Me.grp_Grngroup1.Controls.Add(Me.txt_storecode)
        Me.grp_Grngroup1.Controls.Add(Me.lbl_Suppliercode)
        Me.grp_Grngroup1.Controls.Add(Me.TXT_FROMSTORECODE)
        Me.grp_Grngroup1.Controls.Add(Me.lbl_Grndate)
        Me.grp_Grngroup1.Controls.Add(Me.Label16)
        Me.grp_Grngroup1.Controls.Add(Me.txt_FromStorename)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_fromStorecodeHelp)
        Me.grp_Grngroup1.Controls.Add(Me.lbl_Grnno)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_storecode)
        Me.grp_Grngroup1.Controls.Add(Me.txt_storeDesc)
        Me.grp_Grngroup1.Controls.Add(Me.dtp_Indentdate)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_indentnoHelp)
        Me.grp_Grngroup1.Location = New System.Drawing.Point(18, 97)
        Me.grp_Grngroup1.Name = "grp_Grngroup1"
        Me.grp_Grngroup1.Size = New System.Drawing.Size(756, 104)
        Me.grp_Grngroup1.TabIndex = 22
        Me.grp_Grngroup1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(571, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 37)
        Me.PictureBox2.TabIndex = 473
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 21)
        Me.Label1.TabIndex = 395
        Me.Label1.Text = "ISSUE STORE"
        Me.Label1.Visible = False
        '
        'txt_IndentNo
        '
        Me.txt_IndentNo.BackColor = System.Drawing.Color.Wheat
        Me.txt_IndentNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_IndentNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IndentNo.Location = New System.Drawing.Point(125, 61)
        Me.txt_IndentNo.MaxLength = 50
        Me.txt_IndentNo.Name = "txt_IndentNo"
        Me.txt_IndentNo.Size = New System.Drawing.Size(154, 28)
        Me.txt_IndentNo.TabIndex = 20000
        '
        'txt_storecode
        '
        Me.txt_storecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storecode.Location = New System.Drawing.Point(125, 21)
        Me.txt_storecode.MaxLength = 50
        Me.txt_storecode.Name = "txt_storecode"
        Me.txt_storecode.Size = New System.Drawing.Size(58, 28)
        Me.txt_storecode.TabIndex = 3
        '
        'TXT_FROMSTORECODE
        '
        Me.TXT_FROMSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROMSTORECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROMSTORECODE.Enabled = False
        Me.TXT_FROMSTORECODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROMSTORECODE.Location = New System.Drawing.Point(125, 100)
        Me.TXT_FROMSTORECODE.MaxLength = 50
        Me.TXT_FROMSTORECODE.Name = "TXT_FROMSTORECODE"
        Me.TXT_FROMSTORECODE.Size = New System.Drawing.Size(58, 28)
        Me.TXT_FROMSTORECODE.TabIndex = 5
        Me.TXT_FROMSTORECODE.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(316, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 28)
        Me.Label16.TabIndex = 472
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'txt_FromStorename
        '
        Me.txt_FromStorename.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromStorename.Enabled = False
        Me.txt_FromStorename.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromStorename.Location = New System.Drawing.Point(215, 98)
        Me.txt_FromStorename.MaxLength = 50
        Me.txt_FromStorename.Name = "txt_FromStorename"
        Me.txt_FromStorename.Size = New System.Drawing.Size(250, 28)
        Me.txt_FromStorename.TabIndex = 39200
        Me.txt_FromStorename.Visible = False
        '
        'cmd_fromStorecodeHelp
        '
        Me.cmd_fromStorecodeHelp.Enabled = False
        Me.cmd_fromStorecodeHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_fromStorecodeHelp.Image = CType(resources.GetObject("cmd_fromStorecodeHelp.Image"), System.Drawing.Image)
        Me.cmd_fromStorecodeHelp.Location = New System.Drawing.Point(184, 96)
        Me.cmd_fromStorecodeHelp.Name = "cmd_fromStorecodeHelp"
        Me.cmd_fromStorecodeHelp.Size = New System.Drawing.Size(29, 30)
        Me.cmd_fromStorecodeHelp.TabIndex = 6
        Me.cmd_fromStorecodeHelp.Visible = False
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(184, 18)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(29, 30)
        Me.cmd_storecode.TabIndex = 4
        '
        'txt_storeDesc
        '
        Me.txt_storeDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_storeDesc.Enabled = False
        Me.txt_storeDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storeDesc.Location = New System.Drawing.Point(215, 21)
        Me.txt_storeDesc.MaxLength = 50
        Me.txt_storeDesc.Name = "txt_storeDesc"
        Me.txt_storeDesc.Size = New System.Drawing.Size(250, 28)
        Me.txt_storeDesc.TabIndex = 4
        '
        'cmd_indentnoHelp
        '
        Me.cmd_indentnoHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_indentnoHelp.Image = CType(resources.GetObject("cmd_indentnoHelp.Image"), System.Drawing.Image)
        Me.cmd_indentnoHelp.Location = New System.Drawing.Point(283, 59)
        Me.cmd_indentnoHelp.Name = "cmd_indentnoHelp"
        Me.cmd_indentnoHelp.Size = New System.Drawing.Size(28, 30)
        Me.cmd_indentnoHelp.TabIndex = 1
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Storelocation.Location = New System.Drawing.Point(941, 1154)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(230, 31)
        Me.cbo_Storelocation.TabIndex = 8
        '
        'lbl_Excisepassno
        '
        Me.lbl_Excisepassno.AutoSize = True
        Me.lbl_Excisepassno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Excisepassno.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Excisepassno.Location = New System.Drawing.Point(77, 102)
        Me.lbl_Excisepassno.Name = "lbl_Excisepassno"
        Me.lbl_Excisepassno.Size = New System.Drawing.Size(248, 25)
        Me.lbl_Excisepassno.TabIndex = 5
        Me.lbl_Excisepassno.Text = "EXCISE PASS NO       :"
        '
        'lbl_Excisepassdate
        '
        Me.lbl_Excisepassdate.AutoSize = True
        Me.lbl_Excisepassdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Excisepassdate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Excisepassdate.Location = New System.Drawing.Point(77, 148)
        Me.lbl_Excisepassdate.Name = "lbl_Excisepassdate"
        Me.lbl_Excisepassdate.Size = New System.Drawing.Size(250, 25)
        Me.lbl_Excisepassdate.TabIndex = 6
        Me.lbl_Excisepassdate.Text = "EXCISE PASS DATE   :"
        '
        'txt_Excisepassno
        '
        Me.txt_Excisepassno.BackColor = System.Drawing.Color.White
        Me.txt_Excisepassno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Excisepassno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Excisepassno.Location = New System.Drawing.Point(288, 102)
        Me.txt_Excisepassno.MaxLength = 15
        Me.txt_Excisepassno.Name = "txt_Excisepassno"
        Me.txt_Excisepassno.Size = New System.Drawing.Size(259, 35)
        Me.txt_Excisepassno.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(86, 1154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 148)
        Me.GroupBox1.TabIndex = 352
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdRoundoff)
        Me.GroupBox2.Controls.Add(Me.OptNearest)
        Me.GroupBox2.Controls.Add(Me.OptNone)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(317, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(249, 102)
        Me.GroupBox2.TabIndex = 353
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rounded Off"
        '
        'cmdRoundoff
        '
        Me.cmdRoundoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRoundoff.ForeColor = System.Drawing.Color.Blue
        Me.cmdRoundoff.Location = New System.Drawing.Point(163, 18)
        Me.cmdRoundoff.Name = "cmdRoundoff"
        Me.cmdRoundoff.Size = New System.Drawing.Size(67, 45)
        Me.cmdRoundoff.TabIndex = 2
        Me.cmdRoundoff.Text = "Round Off"
        '
        'OptNearest
        '
        Me.OptNearest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptNearest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptNearest.Location = New System.Drawing.Point(29, 51)
        Me.OptNearest.Name = "OptNearest"
        Me.OptNearest.Size = New System.Drawing.Size(102, 18)
        Me.OptNearest.TabIndex = 2
        Me.OptNearest.Text = "Nearest Rs"
        '
        'OptNone
        '
        Me.OptNone.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptNone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptNone.Location = New System.Drawing.Point(29, 21)
        Me.OptNone.Name = "OptNone"
        Me.OptNone.Size = New System.Drawing.Size(105, 18)
        Me.OptNone.TabIndex = 1
        Me.OptNone.Text = "None"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdValueby)
        Me.GroupBox3.Controls.Add(Me.OptPercentage)
        Me.GroupBox3.Controls.Add(Me.OptValue)
        Me.GroupBox3.Controls.Add(Me.txtChangeValue)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(10, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(297, 102)
        Me.GroupBox3.TabIndex = 352
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Discount Amount"
        '
        'cmdValueby
        '
        Me.cmdValueby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdValueby.ForeColor = System.Drawing.Color.Blue
        Me.cmdValueby.Location = New System.Drawing.Point(229, 18)
        Me.cmdValueby.Name = "cmdValueby"
        Me.cmdValueby.Size = New System.Drawing.Size(58, 47)
        Me.cmdValueby.TabIndex = 3
        Me.cmdValueby.Text = "Value Chg"
        '
        'OptPercentage
        '
        Me.OptPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptPercentage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptPercentage.Location = New System.Drawing.Point(12, 65)
        Me.OptPercentage.Name = "OptPercentage"
        Me.OptPercentage.Size = New System.Drawing.Size(104, 18)
        Me.OptPercentage.TabIndex = 2
        Me.OptPercentage.Text = "Percentage"
        '
        'OptValue
        '
        Me.OptValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptValue.Location = New System.Drawing.Point(12, 28)
        Me.OptValue.Name = "OptValue"
        Me.OptValue.Size = New System.Drawing.Size(96, 18)
        Me.OptValue.TabIndex = 1
        Me.OptValue.Text = "Value"
        '
        'txtChangeValue
        '
        Me.txtChangeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeValue.Location = New System.Drawing.Point(120, 65)
        Me.txtChangeValue.MaxLength = 10
        Me.txtChangeValue.Name = "txtChangeValue"
        Me.txtChangeValue.Size = New System.Drawing.Size(110, 26)
        Me.txtChangeValue.TabIndex = 3
        '
        'grp_StockGrndetails
        '
        Me.grp_StockGrndetails.Controls.Add(Me.lbl_StockGrndetails)
        Me.grp_StockGrndetails.Controls.Add(Me.GroupBox5)
        Me.grp_StockGrndetails.Controls.Add(Me.lbl_FromDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.txt_FromDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.Cmd_FromDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.txt_ToDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.Cmd_ToDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.lbl_ToDocno)
        Me.grp_StockGrndetails.Location = New System.Drawing.Point(266, 1154)
        Me.grp_StockGrndetails.Name = "grp_StockGrndetails"
        Me.grp_StockGrndetails.Size = New System.Drawing.Size(617, 274)
        Me.grp_StockGrndetails.TabIndex = 361
        Me.grp_StockGrndetails.TabStop = False
        '
        'lbl_StockGrndetails
        '
        Me.lbl_StockGrndetails.BackColor = System.Drawing.Color.Maroon
        Me.lbl_StockGrndetails.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StockGrndetails.ForeColor = System.Drawing.Color.White
        Me.lbl_StockGrndetails.Location = New System.Drawing.Point(0, 8)
        Me.lbl_StockGrndetails.Name = "lbl_StockGrndetails"
        Me.lbl_StockGrndetails.Size = New System.Drawing.Size(624, 29)
        Me.lbl_StockGrndetails.TabIndex = 26
        Me.lbl_StockGrndetails.Text = "GRN CHECKLIST"
        Me.lbl_StockGrndetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnprint)
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnView)
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnexit)
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnClear)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 194)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(595, 64)
        Me.GroupBox5.TabIndex = 25
        Me.GroupBox5.TabStop = False
        '
        'Cmd_StockGrnprint
        '
        Me.Cmd_StockGrnprint.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnprint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnprint.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnprint.Location = New System.Drawing.Point(307, 18)
        Me.Cmd_StockGrnprint.Name = "Cmd_StockGrnprint"
        Me.Cmd_StockGrnprint.Size = New System.Drawing.Size(125, 37)
        Me.Cmd_StockGrnprint.TabIndex = 25
        Me.Cmd_StockGrnprint.Text = "Print [F10]"
        Me.Cmd_StockGrnprint.UseVisualStyleBackColor = False
        '
        'Cmd_StockGrnView
        '
        Me.Cmd_StockGrnView.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnView.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnView.Location = New System.Drawing.Point(154, 18)
        Me.Cmd_StockGrnView.Name = "Cmd_StockGrnView"
        Me.Cmd_StockGrnView.Size = New System.Drawing.Size(124, 37)
        Me.Cmd_StockGrnView.TabIndex = 13
        Me.Cmd_StockGrnView.Text = "View [F9]"
        Me.Cmd_StockGrnView.UseVisualStyleBackColor = False
        '
        'Cmd_StockGrnexit
        '
        Me.Cmd_StockGrnexit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnexit.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnexit.Location = New System.Drawing.Point(451, 18)
        Me.Cmd_StockGrnexit.Name = "Cmd_StockGrnexit"
        Me.Cmd_StockGrnexit.Size = New System.Drawing.Size(125, 37)
        Me.Cmd_StockGrnexit.TabIndex = 15
        Me.Cmd_StockGrnexit.Text = "Exit[F11]"
        Me.Cmd_StockGrnexit.UseVisualStyleBackColor = False
        '
        'Cmd_StockGrnClear
        '
        Me.Cmd_StockGrnClear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnClear.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnClear.Location = New System.Drawing.Point(10, 18)
        Me.Cmd_StockGrnClear.Name = "Cmd_StockGrnClear"
        Me.Cmd_StockGrnClear.Size = New System.Drawing.Size(124, 37)
        Me.Cmd_StockGrnClear.TabIndex = 24
        Me.Cmd_StockGrnClear.Text = "Clear[F6]"
        Me.Cmd_StockGrnClear.UseVisualStyleBackColor = False
        '
        'lbl_FromDocno
        '
        Me.lbl_FromDocno.AutoSize = True
        Me.lbl_FromDocno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_FromDocno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FromDocno.Location = New System.Drawing.Point(46, 77)
        Me.lbl_FromDocno.Name = "lbl_FromDocno"
        Me.lbl_FromDocno.Size = New System.Drawing.Size(200, 26)
        Me.lbl_FromDocno.TabIndex = 2
        Me.lbl_FromDocno.Text = "FROM GRN NO :"
        '
        'txt_FromDocno
        '
        Me.txt_FromDocno.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromDocno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromDocno.Location = New System.Drawing.Point(221, 74)
        Me.txt_FromDocno.Name = "txt_FromDocno"
        Me.txt_FromDocno.Size = New System.Drawing.Size(249, 40)
        Me.txt_FromDocno.TabIndex = 4
        '
        'Cmd_FromDocno
        '
        Me.Cmd_FromDocno.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_FromDocno.Location = New System.Drawing.Point(470, 74)
        Me.Cmd_FromDocno.Name = "Cmd_FromDocno"
        Me.Cmd_FromDocno.Size = New System.Drawing.Size(28, 33)
        Me.Cmd_FromDocno.TabIndex = 38
        Me.Cmd_FromDocno.UseVisualStyleBackColor = False
        '
        'txt_ToDocno
        '
        Me.txt_ToDocno.BackColor = System.Drawing.Color.Wheat
        Me.txt_ToDocno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ToDocno.Location = New System.Drawing.Point(221, 129)
        Me.txt_ToDocno.Name = "txt_ToDocno"
        Me.txt_ToDocno.Size = New System.Drawing.Size(249, 40)
        Me.txt_ToDocno.TabIndex = 5
        '
        'Cmd_ToDocno
        '
        Me.Cmd_ToDocno.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_ToDocno.Location = New System.Drawing.Point(470, 129)
        Me.Cmd_ToDocno.Name = "Cmd_ToDocno"
        Me.Cmd_ToDocno.Size = New System.Drawing.Size(28, 34)
        Me.Cmd_ToDocno.TabIndex = 39
        Me.Cmd_ToDocno.UseVisualStyleBackColor = False
        '
        'lbl_ToDocno
        '
        Me.lbl_ToDocno.AutoSize = True
        Me.lbl_ToDocno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ToDocno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ToDocno.Location = New System.Drawing.Point(77, 132)
        Me.lbl_ToDocno.Name = "lbl_ToDocno"
        Me.lbl_ToDocno.Size = New System.Drawing.Size(160, 26)
        Me.lbl_ToDocno.TabIndex = 3
        Me.lbl_ToDocno.Text = "TO GRN NO :"
        '
        'grp_Billingdetails
        '
        Me.grp_Billingdetails.BackColor = System.Drawing.SystemColors.Control
        Me.grp_Billingdetails.Controls.Add(Me.ssgrid_billdetails)
        Me.grp_Billingdetails.Controls.Add(Me.Label2)
        Me.grp_Billingdetails.Location = New System.Drawing.Point(19, 1154)
        Me.grp_Billingdetails.Name = "grp_Billingdetails"
        Me.grp_Billingdetails.Size = New System.Drawing.Size(797, 358)
        Me.grp_Billingdetails.TabIndex = 364
        Me.grp_Billingdetails.TabStop = False
        '
        'ssgrid_billdetails
        '
        Me.ssgrid_billdetails.DataSource = Nothing
        Me.ssgrid_billdetails.Location = New System.Drawing.Point(29, 55)
        Me.ssgrid_billdetails.Name = "ssgrid_billdetails"
        Me.ssgrid_billdetails.OcxState = CType(resources.GetObject("ssgrid_billdetails.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_billdetails.Size = New System.Drawing.Size(1368, 537)
        Me.ssgrid_billdetails.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(793, 28)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "BILLING DETAILS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_Excisedetails
        '
        Me.grp_Excisedetails.Controls.Add(Me.Label5)
        Me.grp_Excisedetails.Controls.Add(Me.txt_Trucknumber)
        Me.grp_Excisedetails.Controls.Add(Me.dtp_Stockindate)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Trucknumber)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Stockindate)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Excisepassno)
        Me.grp_Excisedetails.Controls.Add(Me.txt_Excisepassno)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Excisepassdate)
        Me.grp_Excisedetails.Controls.Add(Me.dtp_Excisepassdate)
        Me.grp_Excisedetails.Location = New System.Drawing.Point(259, 1154)
        Me.grp_Excisedetails.Name = "grp_Excisedetails"
        Me.grp_Excisedetails.Size = New System.Drawing.Size(615, 238)
        Me.grp_Excisedetails.TabIndex = 366
        Me.grp_Excisedetails.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Maroon
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(607, 28)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "EXCISE DETAILS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Trucknumber
        '
        Me.txt_Trucknumber.BackColor = System.Drawing.Color.White
        Me.txt_Trucknumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Trucknumber.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Trucknumber.Location = New System.Drawing.Point(288, 194)
        Me.txt_Trucknumber.MaxLength = 15
        Me.txt_Trucknumber.Name = "txt_Trucknumber"
        Me.txt_Trucknumber.Size = New System.Drawing.Size(259, 35)
        Me.txt_Trucknumber.TabIndex = 3
        '
        'dtp_Stockindate
        '
        Me.dtp_Stockindate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Stockindate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Stockindate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Stockindate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Stockindate.Location = New System.Drawing.Point(288, 55)
        Me.dtp_Stockindate.Name = "dtp_Stockindate"
        Me.dtp_Stockindate.Size = New System.Drawing.Size(259, 35)
        Me.dtp_Stockindate.TabIndex = 0
        '
        'lbl_Trucknumber
        '
        Me.lbl_Trucknumber.AutoSize = True
        Me.lbl_Trucknumber.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Trucknumber.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Trucknumber.Location = New System.Drawing.Point(77, 194)
        Me.lbl_Trucknumber.Name = "lbl_Trucknumber"
        Me.lbl_Trucknumber.Size = New System.Drawing.Size(251, 25)
        Me.lbl_Trucknumber.TabIndex = 7
        Me.lbl_Trucknumber.Text = "TRUCK NUMBER      :"
        '
        'lbl_Stockindate
        '
        Me.lbl_Stockindate.AutoSize = True
        Me.lbl_Stockindate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Stockindate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Stockindate.Location = New System.Drawing.Point(77, 55)
        Me.lbl_Stockindate.Name = "lbl_Stockindate"
        Me.lbl_Stockindate.Size = New System.Drawing.Size(248, 25)
        Me.lbl_Stockindate.TabIndex = 4
        Me.lbl_Stockindate.Text = "STOCK IN DATE        :"
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(28, 236)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(873, 252)
        Me.ssgrid.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(584, -102)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 102)
        Me.Button1.TabIndex = 383
        Me.Button1.Text = "Print[F10]"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(19, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(205, 26)
        Me.Label10.TabIndex = 465
        Me.Label10.Text = "[F3 DELETE A ROW IN GRID]"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txt_Remarks)
        Me.GroupBox4.Controls.Add(Me.lbl_Remarks)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 492)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(820, 67)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Wheat
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(634, 37)
        Me.TextBox1.MaxLength = 50
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(154, 28)
        Me.TextBox1.TabIndex = 39201
        Me.TextBox1.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(19, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 27)
        Me.Label20.TabIndex = 477
        Me.Label20.Text = "ALT+ R"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_qty)
        Me.GroupBox6.Controls.Add(Me.txt_Totalamount)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Location = New System.Drawing.Point(18, 430)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(820, 56)
        Me.GroupBox6.TabIndex = 475
        Me.GroupBox6.TabStop = False
        '
        'txt_qty
        '
        Me.txt_qty.BackColor = System.Drawing.Color.Wheat
        Me.txt_qty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_qty.Enabled = False
        Me.txt_qty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qty.Location = New System.Drawing.Point(551, 21)
        Me.txt_qty.MaxLength = 15
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_qty.Size = New System.Drawing.Size(105, 30)
        Me.txt_qty.TabIndex = 398
        '
        'txt_Totalamount
        '
        Me.txt_Totalamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamount.Enabled = False
        Me.txt_Totalamount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalamount.Location = New System.Drawing.Point(671, 20)
        Me.txt_Totalamount.MaxLength = 15
        Me.txt_Totalamount.Name = "txt_Totalamount"
        Me.txt_Totalamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Totalamount.Size = New System.Drawing.Size(125, 30)
        Me.txt_Totalamount.TabIndex = 397
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Location = New System.Drawing.Point(17, 221)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(854, 196)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Location = New System.Drawing.Point(780, 97)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(255, 126)
        Me.GroupBox8.TabIndex = 476
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Authoriser Details"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(92, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Label11"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 20)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Mobile :-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(92, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Label8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Email :- "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(92, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "User Name :-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(92, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "User id : -"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(57, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 28)
        Me.Label13.TabIndex = 39201
        '
        'PO_StockIndent
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.SmartCard.My.Resources.Resources.Chs_Background_form_new
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1072, 639)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grp_StockGrndetails)
        Me.Controls.Add(Me.grp_Billingdetails)
        Me.Controls.Add(Me.grp_Excisedetails)
        Me.Controls.Add(Me.cbo_Storelocation)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_Grngroup1)
        Me.Controls.Add(Me.GroupBox7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PO_StockIndent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRANSACTION[STOCK INDENT]"
        Me.frmbut.ResumeLayout(False)
        Me.grp_Grngroup1.ResumeLayout(False)
        Me.grp_Grngroup1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grp_StockGrndetails.ResumeLayout(False)
        Me.grp_StockGrndetails.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.grp_Billingdetails.ResumeLayout(False)
        CType(Me.ssgrid_billdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Excisedetails.ResumeLayout(False)
        Me.grp_Excisedetails.PerformLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public i, TotalCount, billrow As Integer
    Dim GRNno(), sqlstring, Sql, Gr As String
    Dim gconnection As New GlobalClass
    Dim vsearch, vitem, accountcode, sstr As String
    Dim docno, transferdocno, doctype, docno1() As String
    Public Listbox As System.Windows.Forms.ListBox
    Dim boolchk, costcentercodestatus, slcodestatus, blnchkupdateclsbal, Dupchk As Boolean
    Dim CATEGORY As String
    Private Sub PO_StockIndent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        'ssgrid.BringToFront()

        'ssgrid.Location = New Point(190, 330)
        ssgrid.Visible = True
        GroupBox8.Visible = False
        With ssgrid
            .Col = 8
            .Row = i
            .ColHidden = True
            .Col = 9
            .Row = i
            .ColHidden = True
            .Col = 10
            .Row = i
            .ColHidden = True
        End With



        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If Not String.IsNullOrEmpty(gAuditFlg) Then
            If gAuditFlg.ToUpper = "Y" Then
                Me.cmd_Add.Enabled = False
                Me.Cmd_FREEZE.Enabled = False
            End If
        End If
        Call autogenerate()
        txt_IndentNo.ReadOnly = True
        If gindentno = "Y" Then
            txt_storecode.Show()
            txt_storecode.Focus()
            Me.cmd_Clear_Click(sender, e)
        Else
            txt_IndentNo.Select()
        End If
        GETMAINSTORE()
    End Sub

    Private Sub GETMAINSTORE()
        gSQLString = "SELECT * FROM STOREMASTER WHERE STORESTATUS='M' AND ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(gSQLString, "INVENTORYWALECAHCHA")
        If gdataset.Tables("INVENTORYWALECAHCHA").Rows.Count > 0 Then

            TXT_FROMSTORECODE.Text = gdataset.Tables("INVENTORYWALECAHCHA").Rows(0).Item("STORECODE")
        End If
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FREEZE.Click
        Try
            Call checkValidation() ''-->Check Validation
            Dim insert(0) As String
            Dim EMAIL, MMOBILE, MOBILE, sqlstring, sqlstring1, datefrom, MCODE As String
            Dim OUTSTANDING As Double
            Dim MODULENAME, yearname, deptcode, deptname, indentno, username, orderno, hours, userid, auth As String
            Dim FS, FD As Integer
            Dim date1, fstart, fend, OUTSTANDDATE, Cdate1, FS1 As Date
            If boolchk = False Then Exit Sub

            'sqlstring = "SELECT authorised, * FROM PO_STOCKINDENTAUTH_DET WHERE docno='" & Trim(txt_IndentNo.Text) & "'AND  authorised in ('Y','N')"
            'gconnection.getDataSet(sqlstring, "PO_STOCKINDENTAUTH_DET")
            'If gdataset.Tables("PO_STOCKINDENTAUTH_DET").Rows.Count > 0 Then
            '    auth = gdataset.Tables("PO_STOCKINDENTAUTH_DET").Rows(0).Item("authorised")
            '    If auth = "Y" Then

            '        MessageBox.Show("Indent already Authorized ,You Can't Void It.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Else

            '        MessageBox.Show("Indent Rejected,You Can't Void It.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    End If
            '    Exit Sub
            'End If

            If Mid(Me.Cmd_FREEZE.Text, 1, 1) = "V" Then

                If MsgBox("Are you Sure to Freeze the Record..", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If


                '''*****************************************Checking if this indent is already Issued or Not **************************'''
                'Dim Sqlstring = "Select * from Stockissuedetail  where IndentNo='" & Trim(txt_IndentNo.Text) & "'"
                'gconnection.getDataSet(Sqlstring, "INDENTISSUE")
                'If gdataset.Tables("INDENTISSUE").Rows.Count > 0 Then
                '    MsgBox("Sorry ! This Indent Stock  is Already Issued............")
                '    Exit Sub
                'End If

                ''***************************************** Checking if this indent is already Issued or Not  **************************'''
                ''***************************************** Void the INDENT in IND_header **************************'''
                sqlstring = "UPDATE  PO_INDENTHDR "
                sqlstring = sqlstring & " SET Void= 'Y',"
                sqlstring = sqlstring & " UPDATEuser='" & Trim(gUsername) & " ',"
                sqlstring = sqlstring & " UPdatetime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE INDENT_NO = '" & Trim(txt_IndentNo.Text) & "'"
                insert(0) = sqlstring
                ''***************************************** Void the INDENT in Complete **********************************'''
                ''***************************************** Void the INDENT in INDENT_details **************************'''
                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        sqlstring = "UPDATE  PO_INDENTDET "
                        sqlstring = sqlstring & " SET Void= 'Y',"
                        sqlstring = sqlstring & " FREEZEuser='" & Trim(gUsername) & " ',"
                        sqlstring = sqlstring & " FREEZEDATEtime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                        sqlstring = sqlstring & " WHERE INDENT_NO = '" & Trim(txt_IndentNo.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                    End With
                Next i
                ''***************************************** Void the INDENT is Complete **********************************'''
                ''***************************************** Void the INDENT in INDENT_header **************************'''

                sqlstring = "UPDATE  Indent_Used set freeze='Y' WHERE INDENT_NO = '" & Trim(txt_IndentNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                gconnection.MoreTrans(insert)

                cmd_Add.Text = "Add [F7]"

                sqlstring = "SELECT USERID, * FROM USER_MAIL_LOG WHERE INDENTNO='" & Trim(txt_IndentNo.Text) & "'AND  STATUS='Y'"
                gconnection.getDataSet(sqlstring, "USER_MAIL_LOG")
                If gdataset.Tables("USER_MAIL_LOG").Rows.Count > 0 Then
                    userid = gdataset.Tables("USER_MAIL_LOG").Rows(0).Item("USERID")
                    sqlstring = "SELECT * FROM authuser_dept_timewese  WHERE USERID='" & userid & "'"
                    gconnection.getDataSet(sqlstring, "EMAILSETUP")
                    If gdataset.Tables("EMAILSETUP").Rows.Count > 0 Then
                        For i = 0 To gdataset.Tables("EMAILSETUP").Rows.Count - 1
                            EMAIL = gdataset.Tables("EMAILSETUP").Rows(i).Item("Email")
                            deptcode = gdataset.Tables("EMAILSETUP").Rows(i).Item("Store")
                            deptname = gdataset.Tables("EMAILSETUP").Rows(i).Item("STOREDESC")
                            indentno = txt_IndentNo.Text
                            userid = gdataset.Tables("EMAILSETUP").Rows(i).Item("userid")
                            username = gdataset.Tables("EMAILSETUP").Rows(i).Item("UserName")
                            orderno = gdataset.Tables("EMAILSETUP").Rows(i).Item("OrderNo")
                            hours = 1
                            If EMAIL <> "" Then
                                Call GETDASHBOARDEMAIL_ALL(EMAIL, deptcode, deptname, indentno, username, orderno, hours, userid)
                            End If
                        Next i
                    End If
                End If
            End If
            Me.cmd_Clear_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_FREEZE" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GETDASHBOARDEMAIL_ALL(ByVal EMAIL As String, ByVal deptcode As String, ByVal deptname As String, ByVal indentno As String, ByVal username As String, ByVal orderno As String, ByVal Hours As String, ByVal userid As String)
        Try
            Dim Message, message1, sql5 As String
            message1 = ""
            Message = "Indent Need to Authorized"
            Dim T1, T2, T3, T4, T5, T6 As String
            T1 = "Dear Mr." & username & " <br>"
            T2 = "Indent number " & indentno & " for the department of " & deptname & " is cancelled therefore we request you to not to put your effort for authorising. <br>"
            'T3 = "This indent has to be authorised in " & Hours & " Min/day.  <br>"
            T4 = "Warm Regards <br> "
            T5 = "Admin <br>"
            T6 = "United club. <br>"
            TextBox1.Text = T1 & vbCr + T2 & vbCr + T4 & vbCr + T5 & vbCr + T6
            message1 = TextBox1.Text
            gconnection.GMailconfig(EMAIL, Message, message1)
          
        Catch ex As Exception

        End Try
    End Sub
    Public Function GMailconfig(ByVal emailid As String, ByVal message As String, ByVal message1 As String)
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            Dim str As String = ""
            Dim state As Boolean
            state = False
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
            Dim setup, ssql, Email, Pwd As String
            Email = "dashboard.clubman@gmail.com"
            Pwd = "raju@#king"
          
            SmtpServer.Credentials = New Net.NetworkCredential(Email, Pwd)

            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.EnableSsl = True
            SmtpServer.Timeout = 100000
            mail = New MailMessage()
           
            mail.From = New MailAddress(Email)
            mail.To.Add(emailid)
            mail.Subject = message
            mail.Body = message1
            mail.IsBodyHtml = True
            SmtpServer.Send(mail)

        Catch ex As Exception
            MsgBox(ex.Message)
            
        End Try
    End Function

    Function printoperation()
        Try
            Dim i As Integer
            Dim Sqlstring = Sqlstring & " SELECT 	ISNULL(HDR.INDENT_NO,'') INDENT_NO, ISNULL(HDR.INDENT_DATE,'')  INDENT_DATE,"
            Sqlstring = Sqlstring & " ISNULL(HDR.FROMSTORECODE,'') FROMSTORECODE , ISNULL(HDR.STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(HDR.STORELOCATIONNAME,'') STORELOCATIONNAME,"
            Sqlstring = Sqlstring & " ISNULL(HDR.PRODUCT_TYPE,'') PRODUCT_TYPE, ISNULL(HDR.REMARKS,'') REMARKS,ISNULL(HDR.updsign,'') updsign,ISNULL(HDR.updfooter,'') updfooter,"
            Sqlstring = Sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            Sqlstring = Sqlstring & " ISNULL(QTY,0) QTY, ISNULL(RATE,0) RATE, ISNULL(AMOUNT,0) AMOUNT, ISNULL(CLSQTY,0) CLSQTY"
            Sqlstring = Sqlstring & " FROM PO_INDENTHDR HDR"
            Sqlstring = Sqlstring & " INNER JOIN PO_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            Sqlstring = Sqlstring & " WHERE HDR.INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "'"

            Dim heading() As String = {"INDENT DETAILS"}
            ReportDetails(Sqlstring, heading, txt_IndentNo.Text, txt_IndentNo.Text)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Printoperation " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        Try
            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_Indentbill_
            sqlstring = sqlstring & " SELECT 	ISNULL(INDENT_NO,'') INDENT_NO, ISNULL(INDENT_DATE,'')  INDENT_DATE,"
            sqlstring = sqlstring & " ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(STORELOCATIONNAME,'') STORELOCATIONNAME,"
            sqlstring = sqlstring & " ISNULL(PRODUCT_TYPE,'') PRODUCT_TYPE, ISNULL(REMARKS,'') REMARKS,ISNULL(updsign,'') updsign,ISNULL(updfooter,'') updfooter,"
            sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            sqlstring = sqlstring & " ISNULL(QTY,0) QTY, ISNULL(RATE,0) RATE, ISNULL(AMOUNT,0) AMOUNT, ISNULL(CLSQTY,0) CLSQTY, ISNULL(ADDDATE,'') ADDDATE "
            If UCase(gcompname) = "CSC" Then
                sqlstring = sqlstring & ",adduser"
            End If

            sqlstring = sqlstring & " FROM VW_PO_IDENTBILL"
            ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            sqlstring = sqlstring & " WHERE INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "'"

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
                'Dim textobj As TextObject
                'textobj = r.ReportDefinition.ReportObjects("Text17")
                'textobj.Text = FROMSTORE
                Dim textobj7 As TextObject
                textobj7 = r.ReportDefinition.ReportObjects("Text28")
                'If gcompname <> "" Then
                '    textobj7.Text = ""
                'End If
                If UCase(gcompname) <> "CSC" Then
                    textobj7.Text = ""
                End If
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
                If gFax = "" Then
                    textobj5.Text = "Tel:" & GPHONE & " , Email:" & gEmail & "" & ", Web:" & gWebsite
                Else
                    textobj5.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & "" & ", Web:" & gWebsite
                End If

                Dim TEXTOBJ6 As TextObject
                TEXTOBJ6 = r.ReportDefinition.ReportObjects("Text25")
                If gTinNo = "" Then
                    TEXTOBJ6.Text = "GSTIN :" & gServiceTax & " "
                Else
                    TEXTOBJ6.Text = "GSTIN :" & gServiceTax & " , Tin No.:" & gTinNo
                End If

                TEXTOBJ6 = r.ReportDefinition.ReportObjects("txt_indentorname")
                If UCase(gcompname) = "CSC" Then
                    TEXTOBJ6.Text = gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("addUser")
                Else
                    TEXTOBJ6.Text = gUsername

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

        'follow the same design'

    End Sub
    Private Sub Indent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call cmd_Clear_Click(cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 And Cmd_FREEZE.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_FREEZE, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_IndentNo.Text = ""
                txt_IndentNo.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 And cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And cmd_View.Enabled = True Then
                Call Cmd_View_Click(cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call cmd_Exit_Click(cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call cmd_Exit_Click(cmd_Exit, e)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                Me.txt_Remarks.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.G Then
                Me.ssgrid.Focus()
                Me.ssgrid.SetActiveCell(1, 1)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Indent_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub checkValidation()
        Try
            boolchk = False
            ''**************************************** Check DATEVALIDATION *******************************************''
            Call Checkdatevalidate(Format(dtp_Indentdate.Value, "dd-MMM-yyyy"))
            If chkdatevalidate = False Then Exit Sub
            ''**************************************** Check GRN NO. can't be blank *******************************************''
            If Trim(txt_IndentNo.Text) = "" Then
                MessageBox.Show("INDENT NO. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_IndentNo.Focus()
                Exit Sub
            End If
            ''**************************************** Check Storecode can't be blank *******************************************''
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                'MessageBox.Show("Storecode. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'txt_storecode.Focus()
                'Exit Sub
            End If
            ''**************************************** Check storedesc can't be blank *******************************************''
            If Trim(txt_FromStorename.Text) = "" Then
                'MessageBox.Show("StoreDesc Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'txt_storeDesc.Focus()
                'Exit Sub
            End If
            ''**************************************** Check Type can't be blank *******************************************''
            ''If Trim(cbo_type.Text) = "" Then
            ''    MessageBox.Show("Product Type Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ''    cbo_type.Focus()
            ''    Exit Sub
            ''End If
            ''********************************************* Check ssgrid value can't be blank ********************************************'''
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 1
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Item Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If

                Call check_In_Inventory(Trim(ssgrid.Text))
                If Dupchk = True Then
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
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : checkValidation" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub updateoperatioN()

        Dim sqlstring, Itemcode, Insert(0) As String
        Dim FromStorecode, ToStorecode As String
        sqlstring = "SELECT INDENTNO, * FROM USER_MAIL_LOG WHERE INDENTNO='" & Trim(txt_IndentNo.Text) & "'"
        gconnection.getDataSet(sqlstring, "USER_MAIL_LOG")
        If gdataset.Tables("USER_MAIL_LOG").Rows.Count > 0 Then

            MessageBox.Show("Mail Has Sent To Authorizer You Cant Update It.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        sqlstring = "UPDATE  PO_INDENTHDR SET "
        If gindentno = "Y" Then
            docno1 = Split(Trim(txt_IndentNo.Text), "/")
            sqlstring = sqlstring & "  INDENT_DATE='" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
        Else
            sqlstring = sqlstring & "  INDENT_DATE='" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
        End If
        sqlstring = sqlstring & " fromStoreCode='" & Trim(TXT_FROMSTORECODE.Text) & "',Storelocationcode='" & Trim(txt_storecode.Text) & "',"
        sqlstring = sqlstring & " Storelocationname='" & Trim(txt_storeDesc.Text) & "',Product_type='""',"
        sqlstring = sqlstring & "Remarks= '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,Void='N',"
        sqlstring = sqlstring & " updateuser='" & Trim(gUsername) & "',updatetime=getdate() where INDENT_NO='" & Trim(txt_IndentNo.Text) & "'"

        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sqlstring


        'For i = 1 To ssgrid.DataRowCnt
        '    ssgrid.Row = i
        '    ssgrid.Col = 3
        '    sqlstring = "UPDATE  po_indent_qty SET uom='" & Trim(ssgrid.Text) & "',"
        '    ssgrid.Row = i
        '    ssgrid.Col = 4
        '    sqlstring = sqlstring & "qty='" & Format(Val(ssgrid.Text), "0.000") & "' INDENT_NO='" & Trim(txt_IndentNo.Text) & "'"
        '    ReDim Preserve Insert(Insert.Length)
        '    Insert(Insert.Length - 1) = sqlstring
        'Next i

        sqlstring = "DELETE FROM PO_INDENTDET WHERE INDENT_NO='" & Trim(txt_IndentNo.Text) & "' "
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sqlstring


        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            ssgrid.Col = 1
            sqlstring = "INSERT INTO PO_INDENTDET(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,Rate,Amount,CLSQTY,"
            sqlstring = sqlstring & " VOID,Adduser,adddatetime,ind_qty)"
            sqlstring = sqlstring & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"

            ssgrid.Col = 1
            Itemcode = Trim(ssgrid.Text)
            sqlstring = sqlstring & "'" & Trim(Itemcode) & "',"
            ssgrid.Col = 2
            sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
            ssgrid.Col = 3
            sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
            ssgrid.Col = 4
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","
            ssgrid.Col = 5
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
            ssgrid.Col = 6
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
            ssgrid.Col = 7
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","

            sqlstring = sqlstring & "'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
            ssgrid.Col = 4
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ")"

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
        Next i

        sqlstring = "INSERT INTO PO_INDENTHDR_LOG(DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname,Product_type, "
        sqlstring = sqlstring & " Remarks,Void,Adduser,Adddatetime,updfooter,updsign)"
        If gindentno = "Y" Then
            docno1 = Split(Trim(txt_IndentNo.Text), "/")
            sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
        Else
            docno1 = Split(Trim(txt_IndentNo.Text), "/")
            sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
        End If
        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_storecode.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(txt_storeDesc.Text) & "','""',"
        sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
        sqlstring = sqlstring & " '','')"

        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sqlstring
        '''******************************************************** Insert into Indentdet **********************************'''
        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            ssgrid.Col = 1
            sqlstring = "INSERT INTO PO_INDENTDET_LOG(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,Rate,Amount,CLSQTY,"
            sqlstring = sqlstring & " VOID,Adduser,adddatetime,ind_qty)"
            sqlstring = sqlstring & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"

            ssgrid.Col = 1
            ssgrid.Row = i
            Itemcode = Trim(ssgrid.Text)
            sqlstring = sqlstring & "'" & Trim(Itemcode) & "',"
            ssgrid.Col = 2
            ssgrid.Row = i
            sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
            ssgrid.Col = 3
            ssgrid.Row = i
            sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
            ssgrid.Col = 4
            ssgrid.Row = i
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","
            ssgrid.Col = 5
            ssgrid.Row = i
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
            ssgrid.Col = 6
            ssgrid.Row = i
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
            ssgrid.Col = 7
            ssgrid.Row = i
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","

            sqlstring = sqlstring & "'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
            ssgrid.Col = 4
            ssgrid.Row = i
            sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ")"

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
        Next i

        gconnection.MoreTrans(Insert)

    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Add.Click
        Try
            Dim MODULENAME, yearname, deptcode, deptname, indentno, username, orderno, hours, EMAIL, userid As String
            Dim phno As Double
            Dim sqlstring, Itemcode, Insert(0) As String
            Dim FromStorecode, DD, ToStorecode As String

            Dim i, j As Integer
            FromStorecode = Trim(TXT_FROMSTORECODE.Text)
            ToStorecode = Trim(txt_storecode.Text)
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub


            sqlstring = "SELECT PREMIUM_DATE  FROM PARTY_PREMIUMDATE_MASTER  "
            gconnection.getDataSet(sqlstring, "PARTY_PREMIUMDATE_MASTER")
            If gdataset.Tables("PARTY_PREMIUMDATE_MASTER").Rows.Count > 0 Then
                DD = gdataset.Tables("PARTY_PREMIUMDATE_MASTER").Rows(0).Item("PREMIUM_DATE")
                If dtp_Indentdate.Text = DD Then
                    If MsgBox("Today Is holiday Do You Want To Create Indent", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    Else
                        Exit Sub
                    End If
                    End If
                End If




                ''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
                ''*********************************************************** Case-1 : Add [F7] *******************************************'''
                If cmd_Add.Text = "Add [F7]" Then
                    sqlstring = "INSERT INTO PO_INDENTHDR(DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname,Product_type, "
                    sqlstring = sqlstring & " Remarks,Void,Adduser,Adddatetime,updfooter,updsign)"
                    If gindentno = "Y" Then
                        docno1 = Split(Trim(txt_IndentNo.Text), "/")
                        sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
                    Else
                        docno1 = Split(Trim(txt_IndentNo.Text), "/")
                        sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
                    End If
                    sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_storecode.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_storeDesc.Text) & "','""',"
                    sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N',"
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
                    sqlstring = sqlstring & " '','')"

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                    '''******************************************************** Insert into Indentdet **********************************'''
                    For i = 1 To ssgrid.DataRowCnt
                        ssgrid.Row = i
                        ssgrid.Col = 1
                        sqlstring = "INSERT INTO PO_INDENTDET(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,Rate,Amount,CLSQTY,"
                        sqlstring = sqlstring & " VOID,Adduser,adddatetime,ind_qty)"
                        sqlstring = sqlstring & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"

                        ssgrid.Col = 1
                        ssgrid.Row = i
                        Itemcode = Trim(ssgrid.Text)
                        sqlstring = sqlstring & "'" & Trim(Itemcode) & "',"
                        ssgrid.Col = 2
                        ssgrid.Row = i
                        sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                        ssgrid.Col = 3
                        ssgrid.Row = i
                        sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","
                        ssgrid.Col = 5
                        ssgrid.Row = i
                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                        ssgrid.Col = 6
                        ssgrid.Row = i
                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                        ssgrid.Col = 7
                        ssgrid.Row = i
                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","

                        sqlstring = sqlstring & "'N',"
                        sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ")"

                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                Next i


                sqlstring = "INSERT INTO PO_INDENTHDR_LOG(DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname,Product_type, "
                sqlstring = sqlstring & " Remarks,Void,Adduser,Adddatetime,updfooter,updsign)"
                If gindentno = "Y" Then
                    docno1 = Split(Trim(txt_IndentNo.Text), "/")
                    sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
                Else
                    docno1 = Split(Trim(txt_IndentNo.Text), "/")
                    sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
                End If
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_storecode.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(txt_storeDesc.Text) & "','""',"
                sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
                sqlstring = sqlstring & " '','')"

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                '''******************************************************** Insert into Indentdet **********************************'''
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    sqlstring = "INSERT INTO PO_INDENTDET_LOG(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,Rate,Amount,CLSQTY,"
                    sqlstring = sqlstring & " VOID,Adduser,adddatetime,ind_qty)"
                    sqlstring = sqlstring & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"

                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Itemcode = Trim(ssgrid.Text)
                    sqlstring = sqlstring & "'" & Trim(Itemcode) & "',"
                    ssgrid.Col = 2
                    ssgrid.Row = i
                    sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","
                    ssgrid.Col = 5
                    ssgrid.Row = i
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    ssgrid.Row = i
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 7
                    ssgrid.Row = i
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ","

                    sqlstring = sqlstring & "'N',"
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate(),"
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.000") & ")"

                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next i

           
                gconnection.MoreTrans(Insert)

                sqlstring = "select * from indentauth a inner join authuser_dept_timewese b  on b.store=a.STORELOCATIONCODE where  b.OrderNo=1  and  INDENT_NO='" & txt_IndentNo.Text & "'"
                gconnection.getDataSet(sqlstring, "EMAILSETUP")
                If gdataset.Tables("EMAILSETUP").Rows.Count > 0 Then
                    GroupBox8.Visible = True
                    Label4.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("userid")
                    Label6.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("UserName")
                    Label8.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("Email")
                    Label11.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("Mobile")
                End If


            Else
                updateoperatioN()


            End If
            cmd_Add.Text = "Add [F7]"
            If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                Call Cmd_View_Click(cmd_View, e)
                Call cmd_Clear_Click(sender, e)
            Else
                Call cmd_Clear_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ssgrid_EditError(sender As Object, e As AxFPSpreadADO._DSpreadEvents_EditErrorEvent) Handles ssgrid.EditError

    End Sub






    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim i, j, k As Integer
        Dim Rate, clsquantity, AMOUNT, purrate As Double
        Dim Itemcode, Itemdesc, UOM As String
        Try
            If e.keyCode = Keys.F1 Then
                Dim frmSrc As New frmSearch
                frmSrc.farPoint = ssgrid
                frmSrc.ShowDialog(Me)
            End If

            If e.keyCode = Keys.Enter Then
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        Dim temp, TEMP1 As String
                        temp = 0
                        TEMP1 = ""
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        temp = ssgrid.Text
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        If Val(temp) = 0 Then
                            If Trim(ssgrid.Text) = "" Then
                                'Call fillmenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                                Call FillMenuNew()
                            Else
                                Itemcode = Trim(ssgrid.Text)
                                ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                                ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''

                                sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.UOM,'') AS STOCKUOM ,prate AS PURCHASERATE "
                                sqlstring = sqlstring & " FROM REG_INDENT AS I "
                                sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "' "
                                gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                                If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                    Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                    If Dupchk = True Then
                                        ssgrid.Col = 1
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = ""
                                        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                        ssgrid.Focus()
                                        Exit Sub
                                    End If
                                    Call check_In_Inventory(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                    If Dupchk = True Then
                                        ssgrid.Col = 1
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = ""
                                        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                        ssgrid.Focus()
                                        Exit Sub
                                    End If
                                    Call GridUOM(i) ''---> Fill the UOM feild
                                    ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                    ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                    ssgrid.Col = 3
                                    ssgrid.Row = i
                                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                    UOM = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                    'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                    If gsalerate = "Y" Then
                                        ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                    Else
                                        ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                    End If

                                    'Rate = CalAverageRate_new(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text)
                                    'ssgrid.SetText(5, i, Format(Val(Rate), "0.00"))
                                    If Trim(txt_storecode.Text) <> "" Then
                                        If gInventoryVersion = "N" Then
                                            Dim closingqty As Double
                                            If gCompanyShortName = "CSC" Then
                                                clsquantity = gconnection.ClosingQuantityCSC(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text))

                                            Else
                                                gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "")

                                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                                    clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                                Else
                                                    clsquantity = 0
                                                End If
                                            End If
                                           
                                           
                                        Else
                                            clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                        End If


                                    Else
                                        clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                    End If


                                    ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                    Call GridRowLock(i)
                                    ssgrid.Col = 3
                                    Dim SqlQuery As String
                                    If gCompanyShortName = "CSC" Then
                                        SqlQuery = "SELECT DISTINCT ISNULL(STOCKUOM,'') AS Tranuom  FROM  INVENTORYITEMMASTER  WHERE ISNULL(PURCHASERATE,0)>0 AND Itemcode ='" & Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))) & "' AND STORECODE='" & Trim(TXT_FROMSTORECODE.Text) & "' "

                                    Else
                                        SqlQuery = "SELECT DISTINCT ISNULL(UOM,'') AS Tranuom  FROM  CLOSINGQTY  WHERE ISNULL(RATE,0)>0 AND Itemcode ='" & Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))) & "' "

                                    End If
                                     gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                                    If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
                                        ' Call FillTransUOM(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))))
                                        ssgrid.Col = 3
                                        ssgrid.Row = i
                                        'ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                        For i = 0 To gdataset.Tables("InventoryItemUOM").Rows.Count - 1

                                            ssgrid.TypeComboBoxList.Insert(i, gdataset.Tables("InventoryItemUOM").Rows(i).Item(0))
                                        Next

                                    ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                        ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                    Else
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))
                                    End If
                                    Dim STRITEMUOM As String
                                    ssgrid.Col = 3
                                    ssgrid.Row = ssgrid.ActiveRow
                                    STRITEMUOM = ssgrid.Text
                                    ssgrid.SetText(13, i, clsquantity)
                                    ssgrid.Col = 7
                                    ssgrid.Row = ssgrid.ActiveRow
                                    Dim INDDATE As Date
                                    INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
                                    ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                    Dim grndate1 As DateTime
                                    Dim curuom As String
                                    Dim currate, prate As Double
                                    'SqlQuery = "select max(grndate) as grndate,itemcode from grn_details WHERE Itemcode ='" & Trim(Itemcode) & "' AND grndate <='" & Format(CDate(dtp_Indentdate.Text), "yyyy-MM-dd") & "' group by itemcode"
                                    'gconnection.getDataSet(SqlQuery, "temp")
                                    'If gdataset.Tables("temp").Rows.Count > 0 Then
                                    '    grndate1 = gdataset.Tables("temp").Rows(0).Item("grndate")
                                    '    'grndate1 = Format(CDate(grndate1), "yyyy/MM/dd")

                                    '    'Else
                                    '    '    SqlQuery = "select rate = rate * b.convvalue from inventory_transconversion b, grn_details where itemcode = '" & Trim(Itemcode) & "' and grn_details.grndate = '" & Format(CDate(grndate1), "yyyy-MM-dd") & "' and b. baseuom = '" & Trim(curuom) & "' and b.transuom = grn_details.uom "
                                    '    '    gconnection.getDataSet(SqlQuery, "temp2")
                                    '    '    If gdataset.Tables("temp2").Rows.Count > 0 Then
                                    '    '        prate = gdataset.Tables("temp2").Rows(0).Item("rate")
                                    '    '        ssgrid.Col = 5
                                    '    '        ssgrid.Row = ssgrid.ActiveRow
                                    '    '        ssgrid.Text = Format(Val(prate), "0.00")
                                    '    '        'ssgrid.Text = "0.00"
                                    '    '        ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                                    '    '        ssgrid.Focus()
                                    '    '    End If
                                    '    'End If
                                    'Else
                                    '    ssgrid.Col = 5
                                    '    ssgrid.Row = ssgrid.ActiveRow
                                    '    ssgrid.Text = Format(Val(purrate), "0.00")
                                    'End If
                                    ssgrid.Col = 3
                                    ssgrid.Row = ssgrid.ActiveRow
                                    curuom = Trim(ssgrid.Text)
                                    If gCompanyShortName = "CSC" Then
                                        SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(Itemcode) & "' , '" & Trim(UOM) & "'," & clsquantity & ",'" & Trim(TXT_FROMSTORECODE.Text) & "'"

                                    Else
                                        SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(Itemcode) & "' , '" & Trim(UOM) & "'"
                                    End If

                                   
                                    gconnection.getDataSet(SqlQuery, "temp1")
                                    If gdataset.Tables("temp1").Rows.Count > 0 Then
                                        currate = gdataset.Tables("temp1").Rows(0).Item("rate")
                                        ssgrid.Col = 5
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = Format(Val(currate), "0.00")
                                    End If
                                    ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
                                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        Else
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            Call SelectText()
                        End If
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenuNew() '' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(ssgrid.Text)
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.UOM,'') AS STOCKUOM ,prate AS PURCHASERATE "
                            sqlstring = sqlstring & " FROM REG_INDENT AS I "
                            sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "' "

                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                                Call check_In_Inventory(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                                Call GridUOM(i) ''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = i
                                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                UOM = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                If gsalerate = "Y" Then
                                    ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                Else
                                    ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                End If

                                If Trim(txt_storecode.Text) <> "" Then
                                    If gInventoryVersion = "N" Then
                                        gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "")
                                        Dim closingqty As Double
                                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                            clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                        Else
                                            clsquantity = 0
                                        End If
                                    Else
                                        clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                    End If


                                Else
                                    clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                End If


                                ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                Call GridRowLock(i)
                                ssgrid.Col = 3
                                Dim SqlQuery As String
                                SqlQuery = "SELECT DISTINCT ISNULL(UOM,'') AS Tranuom  FROM  CLOSINGQTY  WHERE ISNULL(RATE,0)>0 AND Itemcode ='" & Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))) & "' "
                                gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                                If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
                                    Call FillTransUOM(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))))
                                ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                    ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                Else
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))
                                End If
                                Dim STRITEMUOM As String
                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                STRITEMUOM = ssgrid.Text
                                ssgrid.SetText(13, i, clsquantity)
                                ssgrid.Col = 7
                                ssgrid.Row = ssgrid.ActiveRow
                                Dim INDDATE As Date
                                INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
                                ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                Dim grndate1 As DateTime
                                Dim curuom As String
                                Dim currate, prate As Double

                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                curuom = Trim(ssgrid.Text)
                                SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(Itemcode) & "' , '" & Trim(UOM) & "'"
                                gconnection.getDataSet(SqlQuery, "temp1")
                                If gdataset.Tables("temp1").Rows.Count > 0 Then
                                    currate = gdataset.Tables("temp1").Rows(0).Item("rate")
                                    ssgrid.Col = 5
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = Format(Val(currate), "0.00")
                                End If
                                ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
                                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                ssgrid.Focus()
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 4 Then

                    Dim sqlrol, rolitem As String
                    Dim mqty, CQty, ROLQty As Double
                    mqty = 0 : CQty = 0 : ROLQty = 0

                    ssgrid.Col = 7
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    CQty = Val(ssgrid.Text)

                    ssgrid.Col = 1
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    rolitem = Trim(ssgrid.Text)

                    sqlrol = "select isnull(minqty,0) as minqty, isnull(reorderlevel,0) as reorderlevel from inventoryitemmaster where itemcode ='" & Trim(rolitem) & "' and storecode ='" & TXT_FROMSTORECODE.Text & "'"
                    gconnection.getDataSet(sqlrol, "INVENTORYROL")
                    'If gdataset.Tables("inventoryrol").Rows.Count > 0 Then
                    '    mqty = gdataset.Tables("inventoryrol").Rows(0).Item("minqty")
                    '    ROLQty = gdataset.Tables("inventoryrol").Rows(0).Item("reorderlevel")
                    'End If

                    'If ROLQty <> 0 Then
                    '    If CQty < mqty Then
                    '        If CQty >= ROLQty Then
                    '            MsgBox("Your Stock Reached ReorderLevel Qty")
                    '        End If
                    '    End If
                    'End If

                    'If mqty <> 0 Then
                    '    If CQty >= mqty Then
                    '        MsgBox("Your Stock Reached Minimumlevel Qty")
                    '    End If
                    'End If

                    ssgrid.Col = 4
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            'ElseIf Val(ssgrid.Text) > CQty Then
                            '    MsgBox("ISSUING QTY CANNOT BE GREATER THAN CLOSING QTY")
                            '    ssgrid.Text = 0
                            '    ssgrid.Focus()
                            '    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            '    Exit Sub
                        Else
                            Call Calculate() ''CALC TOTAL AMOUNT
                            ssgrid.Col = 5
                            Rate = ssgrid.Text
                            ssgrid.Col = 4
                            ssgrid.Row = ssgrid.ActiveRow + 1
                            ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 5 Then
                ElseIf ssgrid.ActiveCol = 6 Then

                ElseIf ssgrid.ActiveCol = 7 Then

                End If
            ElseIf e.keyCode = Keys.F4 Then
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        ssgrid.Col = 1
                        ssgrid.Row = ssgrid.ActiveRow
                        search = Trim(ssgrid.Text)
                        Call fillmenu()
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssgrid.Col = ssgrid.ActiveCol
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    With ssgrid
                        .Row = .ActiveRow
                        .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                        .DeleteRows(.ActiveRow, 1)
                        Call Calculate()
                        .SetActiveCell(1, ssgrid.ActiveRow)
                        .Focus()
                    End With
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FillMenuNew()
        Try
            Dim Avgrate, clsquantity, PURCHASERATE As Double
            Dim K As Integer
            Dim vform As New ListOperattion1


            gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME ,UOM"
            gSQLString = gSQLString & "  FROM REG_INDENT AS I  "
            If Trim(vsearch) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " WHERE  " & "I.ITEMCODE LIKE '" & Trim(vsearch) & "%' "
            End If



            vform.Field = "ITEMNAME,ITEMCODE"
            vform.vFormatstring = "   ITEMCODE    |             ITEMNAME               | STOCKUOM |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 4
            vform.Keypos3 = 5
            vform.keypos4 = 6
            vform.Keypos5 = 7
            vform.Keypos6 = 8
            vform.Keypos7 = 9
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ' Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield)
                Call check_Duplicate(vform.keyfield)
                If Dupchk = True Then
                    ssgrid.Col = 1
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = ""
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                Call check_In_Inventory(vform.keyfield)
                If Dupchk = True Then
                    ssgrid.Col = 1
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = ""
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                Dim SqlQuery As String
                ssgrid.Col = 2
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield1)
                ssgrid.Col = 3
                SqlQuery = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(vform.keyfield) & "'"
                gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
                    Call FillTransUOM(Trim(vform.keyfield))
                ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                    ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                Else
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = Trim(vform.keyfield2)
                End If
                Dim CURUOM1 As String
                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                CURUOM1 = Trim(ssgrid.Text)
                'clsquantity = ClosingQuantity_FORINDENT((vform.keyfield), TXT_FROMSTORECODE.Text, (CURUOM1))
                If gCompanyShortName = "CSC" Then
                    clsquantity = gconnection.ClosingQuantityCSC(Trim((vform.keyfield)), Trim(TXT_FROMSTORECODE.Text))

                Else
                    gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), (vform.keyfield), Trim(TXT_FROMSTORECODE.Text), "")

                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    Else
                        clsquantity = 0
                    End If
                End If

                'gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), (vform.keyfield), Trim(TXT_FROMSTORECODE.Text), "")
                'If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                '    clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                'Else
                '    clsquantity = 0
                'End If
                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield3), "0.00")
                Dim STRITEMUOM As String
                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                STRITEMUOM = ssgrid.Text
                ssgrid.Col = 13
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = clsquantity
                'ssgrid.SetText(13, ssgrid.ActiveRow, clsquantity)
                ssgrid.Col = 7
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = clsquantity
                Dim INDDATE As Date
                INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
                ssgrid.Text = Format(Val(clsquantity), "0.00")
                ''ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))


                Dim grndate1 As DateTime
                Dim curuom As String
                Dim currate, prate As Double

                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                curuom = Trim(ssgrid.Text)
                If gCompanyShortName = "CSC" Then
                    SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(vform.keyfield) & "' , '" & Trim(curuom) & "'," & clsquantity & ",'" & Trim(TXT_FROMSTORECODE.Text) & "'"

                Else
                    SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(vform.keyfield) & "' , '" & Trim(curuom) & "'"
                End If

                ' SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(vform.keyfield) & "' , '" & Trim(curuom) & "'"
                M_WhereCondition = ""
                gconnection.getDataSet(SqlQuery, "temp1")
                If gdataset.Tables("temp1").Rows.Count > 0 Then
                    currate = gdataset.Tables("temp1").Rows(0).Item("rate")
                    ssgrid.Col = 5
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = Format(Val(currate), "0.00")
                End If
                ssgrid.Col = 8
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield4)
                ssgrid.Col = 9
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield5), "0.00")
                ssgrid.Col = 10
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield6)
                ssgrid.Col = 11
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield7)
                ssgrid.Col = 7
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = clsquantity
                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub
    Private Sub FillTransUOM(ByVal itemcode As String)
        gSQLString = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK WHERE Itemcode ='" & itemcode & "' "
        If Trim(search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " AND  Tranuom LIKE '" & Trim(search) & "%'"
        End If
        Dim vform1 As New ListOperattion1
        vform1.Field = "TRANUOM"
        vform1.vFormatstring = "     TRANS UOM                                                                                                   "
        vform1.vCaption = " PURCHASE UOMMASTER HELP"
        vform1.KeyPos = 0
        vform1.ShowDialog(Me)
        If Trim(vform1.keyfield & "") <> "" Then
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform1.keyfield & "")
            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ssgrid.Focus()
        End If
        vform1.Close()
        vform1 = Nothing

    End Sub

    Function SelectText() ''-->Select text in cell
        SendKeys.Send("Space")
        SendKeys.Send("{Home}")
        SendKeys.Send("+{End}")
    End Function
    Private Function GridRowLock(ByVal rnum As Integer)

        With ssgrid
            .Row = rnum

            .Col = 2
            .Lock = True

            .Col = 3
            .Lock = True

            .Col = 5
            .Lock = True

            .Col = 6
            .Lock = True

            .Col = 7
            .Lock = True
        End With

    End Function
    Private Function GridLock()
        Dim i As Integer

        With ssgrid
            For i = 1 To .DataRowCnt
                .Row = i
                '.Col = 1
                '.Lock = True

                .Col = 2
                .Lock = True

                .Col = 3
                .Lock = True

                .Col = 5
                .Lock = True

                .Col = 6
                .Lock = True

                .Col = 7
                .Lock = True
            Next i
        End With
    End Function
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
    Private Function check_Duplicate(ByVal Itemcode As String)
        Dim i As Integer
        Dupchk = False
        ssgrid.Col = 1
        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            If i <> ssgrid.ActiveRow Then
                If Trim(ssgrid.Text) = Itemcode Then
                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Dupchk = True
                End If
            End If
        Next
    End Function

    Private Function check_In_Inventory(ByVal Itemcode As String)
        'Dim SqlQuery, Insert(0) As String
        'Dupchk = False

        '    SqlQuery = " select * from iNV_inventoryitemmaster where itemcode='" & Itemcode & "' and isnull(VOID,'')<>'Y'"


        'gconnection.getDataSet(SqlQuery, "inv")
        'If gdataset.Tables("inv").Rows.Count > 0 Then

        'Else

        'sqlstring = " select itemcode,itemname,ISNULL(groupcode,'')groupcode,ISNULL(groupname,'')groupname,ISNULL(subgroupcode,'')subgroupcode,ISNULL(subgroupname,'')subgroupname,ISNULL(subsubgroupcode,'')subsubgroupcode,ISNULL(subsubgroupname,'')subsubgroupname,"
        'sqlstring = sqlstring & " ISNULL(reorderlevel,0)reorderlevel,ISNULL(minqty,0)minqty,ISNULL(maxqty,0)maxqty,ISNULL(valuation,0)valuation,ISNULL(purchaserate,0)purchaserate,ISNULL(salerate,0)salerate,ISNULL(stockuom,'')stockuom,ISNULL(receiveuom,'')receiveuom,"
        'sqlstring = sqlstring & " ISNULL( saleuom,'')saleuom, ISNULL(leadtime,'0')leadtime, ISNULL(doubleuom,'')doubleuom, ISNULL(opstock,0)opstock, ISNULL(opvalue,0)opvalue, ISNULL(convvalue,0)convvalue, ISNULL(Freeze,'N')Freeze, ISNULL(adduser,'')adduser, ISNULL(adddate,'')adddate, ISNULL(storecode,'')storecode, ISNULL(closingqty,0)closingqty, ISNULL(closingval,0)closingval, ISNULL(abc,'A')abc, "
        'sqlstring = sqlstring & " ISNULL(CATEGORY,'')CATEGORY, ISNULL(selectopt,'')selectopt,"
        'sqlstring = sqlstring & " ISNULL(taxrebate,0)taxrebate, ISNULL(baserate,0)baserate,ISNULL(INVITMTransQty,0)INVITMTransQty, ISNULL(invitmtransvalue,0)invitmtransvalue, ISNULL(invitmtransrate,0)invitmtransrate,ISNULL(invitmstockuom,'')invitmstockuom,  ISNULL(profitper,0)profitper,"

        'sqlstring = sqlstring & " ISNULL(taxper,0)taxper,ISNULL(partno,'')partno,ISNULL(hsnno,'')hsnno,ISNULL(taxtype,'')taxtype,ISNULL(taxgroupcode,'')taxgroupcode,ISNULL(splcess,0)splcess"
        'sqlstring = sqlstring & " from inventoryitemmaster where itemcode='" & Itemcode & "'  and isnull(freeze,'')<>'Y'"
        'gconnection.getDataSet(sqlstring, "stroemiss")
        'If gdataset.Tables("stroemiss").Rows.Count > 0 Then
        '    sqlstring = "insert into inventoryitemmaster (itemcode,itemname,groupcode,groupname,subgroupcode,subgroupname,subsubgroupcode,subsubgroupname,reorderlevel,minqty,maxqty,valuation,purchaserate,salerate,stockuom,receiveuom,"
        '    sqlstring = sqlstring & "  saleuom, leadtime, doubleuom, opstock, opvalue, convvalue, Freeze, adduser, adddate, storecode, closingqty, closingval, abc, CATEGORY, selectopt, taxrebate, baserate,INVITMTransQty, invitmtransvalue, invitmtransrate,invitmstockuom,  profitper"
        '    sqlstring = sqlstring & " ,taxper,partno,hsnno,taxtype,taxgroupcode,splcess)"

        '    sqlstring = sqlstring & " values ( '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("itemcode")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("itemname")) & "',"
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("groupcode")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("groupname")) & "' , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("subgroupcode")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("subgroupname")) & "' , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("subsubgroupcode")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("subsubgroupname")) & "' , "
        '    'sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("subsubgroupcode")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("subsubgroupname")) & "' , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("reorderlevel")) & " , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("minqty")) & " , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("maxqty")) & " , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("valuation")) & "' , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("purchaserate")) & " , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("salerate")) & " , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("stockuom")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("receiveuom")) & "' , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("saleuom")) & "' , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("leadtime")) & " , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("doubleuom")) & "' , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("opstock")) & " , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("opvalue")) & " , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("convvalue")) & " , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("Freeze")) & "' , '" & gUsername & "' , "
        '    sqlstring = sqlstring & "    getdate(), '" & txt_storecode.Text & "' , "
        '    sqlstring = sqlstring & "  0 , 0 , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("abc")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("CATEGORY")) & "' , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("selectopt")) & "' , '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("taxrebate")) & "' , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("baserate")) & " , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("INVITMTransQty")) & " , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("invitmtransvalue")) & " , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("invitmtransrate")) & " , "
        '    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("invitmstockuom")) & "' , " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("profitper")) & " , "
        '    sqlstring = sqlstring & "  " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("taxper")) & "  , "
        '    sqlstring = sqlstring & "   '', '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("hsnno")) & "' , "
        '    sqlstring = sqlstring & "   '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("taxtype")) & "', '" & Trim(gdataset.Tables("stroemiss").Rows(0).Item("taxgroupcode")) & "' , "
        '    sqlstring = sqlstring & "   " & Trim(gdataset.Tables("stroemiss").Rows(0).Item("splcess")) & " ) "

        '    ReDim Preserve Insert(Insert.Length)
        '    Insert(Insert.Length - 1) = sqlstring
        '    gconnection.MoreTrans1(Insert)
        'Else


        'MsgBox("Item Code not exists in Inventory. Please create item in inventory with same itemcode.", MsgBoxStyle.Critical, "Duplicate")
        'Dupchk = True

        'End If



        'End If
    End Function

    Private Function fillmenu()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        Dim vform As New ListOperattion1
        chkClsQty = True
        Dupchk = False
        chkStorecode = Trim(txt_storecode.Text & "")
        ''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
        gSQLString = gSQLString & " ISNULL(clstock,0) AS clstock ,ISNULL(PURCHASERATE,0) AS PURCHASERATE  FROM INVENTORYITEMMASTER AS I "

        If Trim(vsearch) = " " Then
            M_WhereCondition = "WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' "
        Else
            M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
        End If
        vform.Field = "ITEMNAME,ITEMCODE"
        vform.vFormatstring = "   ITEMCODE   |                         ITEMNAME                         |    STOCKUOM     | Clstock   |BASERATE  "
        vform.vCaption = "INVENTORY ITEM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Call check_Duplicate(Trim(vform.keyfield))
            If Dupchk = True Then
                Exit Function
            End If
            'Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield)
            ssgrid.Col = 2
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield1)
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield2)
            ssgrid.Col = 5
            ssgrid.Row = ssgrid.ActiveRow

            '    Avgrate = CalAverageRate_new(Trim(vform.keyfield), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text, Trim(vform.keyfield2))
            ssgrid.SetText(5, ssgrid.ActiveRow, Format(Val(Avgrate), "0.00"))

            If Trim(txt_storecode.Text) <> "" Then
                If gInventoryVersion = "N" Then
                    gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), "")
                    Dim closingqty As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    Else
                        clsquantity = 0
                    End If
                Else
                    clsquantity = ClosingQuantity(Trim(vform.keyfield), TXT_FROMSTORECODE.Text)
                End If


            Else
                clsquantity = 0
            End If


            If clsquantity <= 0 Then
                MsgBox("Please Note Stock is Zero", MsgBoxStyle.Information, "Inventory")
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                ssgrid.Focus()
            End If
            ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ssgrid.Focus()
        Else
            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            Exit Function
        End If
        vform.Close()
        vform = Nothing
    End Function
    Private Sub GridUOM(ByVal i As Integer)
        Try
            Dim Z As Integer
            sqlstring = "SELECT ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMASTER WHERE ISNULL(FREEZE,'') <> 'Y'"
            gconnection.getDataSet(sqlstring, "UOMMASTER1")
            If gdataset.Tables("UOMMASTER1").Rows.Count > 0 Then
                For Z = 0 To gdataset.Tables("UOMMASTER1").Rows.Count - 1
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMASTER1").Rows(Z).Item("UOMDESC"))
                    ssgrid.Text = Trim(gdataset.Tables("UOMMASTER1").Rows(Z).Item("UOMDESC"))
                    ssgrid.Lock = True
                Next Z
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_storecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM STOREMASTER   "
        If gCompanyShortName = "CSC" Then
            M_WhereCondition = " where freeze <> 'Y'  and storecode in (select store from Indent_Auth_List)  "
        Else
            M_WhereCondition = " where freeze <> 'Y' AND STORESTATUS<>'M' and storecode in (select store from Indent_Auth_List)  "
        End If

        Dim vform As New LIST_OPERATION1
        vform.Field = "STOREDESC,STORECODE"

        'vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "DEPARTMENT MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_storecode.Text = Trim(vform.keyfield & "")
            txt_storeDesc.Text = Trim(vform.keyfield1 & "")

        End If
        If gindentno = "Y" Then
            doctype = Trim(txt_storecode.Text)
            Call autogenerate()
            TXT_FROMSTORECODE.Focus()
        Else
            TXT_FROMSTORECODE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_IndentNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_IndentNo.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmd_indentnoHelp.Enabled = True Then
                    search = Trim(txt_IndentNo.Text)
                    Call cmd_indentnoHelp_Click(cmd_indentnoHelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_IndentNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_IndentNo.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_IndentNo.Text) = "" Then
                    Call cmd_indentnoHelp_Click(cmd_indentnoHelp, e)
                Else
                    txt_IndentNo_Validated(txt_IndentNo, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub cmd_indentnoHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_indentnoHelp.Click
        Try



            gSQLString = "SELECT indent_no,indent_date FROM PO_indenthdr"
            If txt_storecode.Text <> "" Then
                M_WhereCondition = " WHERE FROMSTORECODE='" & txt_storecode.Text & "' "
            Else
                M_WhereCondition = ""
            End If
            'ElseIf TXT_FROMSTORECODE.Text <> "" And txt_storecode.Text <> "" Then
            '    M_WhereCondition = " WHERE FROMSTORECODE='" & TXT_FROMSTORECODE.Text & "' and STORELOCATIONCODE='" & txt_storecode.Text & "' "
            'ElseIf TXT_FROMSTORECODE.Text = "" And txt_storecode.Text <> "" Then
            '    M_WhereCondition = " WHERE STORELOCATIONCODE='" & txt_storecode.Text & "' "
            'Else
            '    M_WhereCondition = "  "
            'End If

            M_ORDERBY = " order by indent_date desc "
            Dim vform As New ListOperattion1
            vform.Field = "INDENT_NO,INDENT_DATE"
            vform.vFormatstring = "       INDENT_NO                  |     INDENT_DATE                                                           "
            vform.vCaption = "STOCK INDENT HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_IndentNo.Text = Trim(vform.keyfield & "")
                ssgrid.ClearRange(1, 1, -1, -1, True)
                Call txt_IndentNo_Validated(txt_IndentNo, e)
                'dtp_Indentdate.Focus()
            End If
            vform.Close()
            vform = Nothing
            M_ORDERBY = ""
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub






    Private Sub txt_IndentNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_IndentNo.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, sqlstring1, remarks As String
        Dim vTypeseqno, Clsquantity, vGroupseqno As Double

        Dim strsql As String
        Dim STRITEMCODE, STRITEMUOM As String
        Try
            Label13.Visible = False
            If Trim(txt_IndentNo.Text) <> "" Then
                sqlstring = " SELECT ISNULL(H.INDENT_NO,'') AS INDENT_NO,H.INDENT_DATE AS INDENT_DATE,ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
                sqlstring = sqlstring & " ISNULL(H.STORELOCATIONNAME,'') AS STORELOCATIONNAME,ISNULL(H.PRODUCT_TYPE,'') AS PRODUCT_TYPE,"
                sqlstring = sqlstring & " ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(H.VOID,'') AS VOID,"
                sqlstring = sqlstring & " ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATETIME,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME , isnull(updfooter,'') as updfooter,isnull(updsign,'') as updsign "
                sqlstring = sqlstring & " FROM PO_INDENTHDR AS H "
                sqlstring = sqlstring & " WHERE INDENT_NO='" & txt_IndentNo.Text & "'"
                gconnection.getDataSet(sqlstring, "INDENTHDR")
                '''************************************************* SELECT RECORD FROM INDENTHDR *********************************************''''                
                If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                    cmd_Add.Text = "Update[F7]"
                    Me.txt_IndentNo.ReadOnly = True
                    'VSTRDOCNO = Trim(txt_Docno.Text)
                    txt_IndentNo.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_NO") & "")
                    dtp_Indentdate.Value = gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_DATE")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("fromStoreCode") & "")
                    Call TXT_FROMSTORECODE_Validated(txt_IndentNo.Text, e)
                    txt_storecode.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONCODE"))
                    txt_storeDesc.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONNAME"))

                    remarks = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("REMARKS"))
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    'Txt_footer.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("updfooter"))
                    'Txt_signature.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("updsign"))
                    If gdataset.Tables("INDENTHDR").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = "Record Freezed On " & Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("UPDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_FREEZE.Enabled = True
                        Me.cmd_Add.Enabled = False
                        ' Me.Cmd_FREEZE.Text = "UnVoid[F8]"
                        Cmd_FREEZE.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_FREEZE.Enabled = True
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_FREEZE.Text = "Void[F8]"
                    End If
                    '''************************************************* SELECT RECORD FROM INDENTDETAILS *********************************************''''                
                    sqlstring = "SELECT * from PO_STOCKINDENTAUTH_DET where docno='" & Trim(txt_IndentNo.Text) & "'"
                    gconnection.getDataSet(sqlstring, "PO_STOCKINDENTAUTH_DET")
                    If gdataset.Tables("PO_STOCKINDENTAUTH_DET").Rows.Count > 0 Then

                        sqlstring = "SELECT ISNULL(a.ITEMCODE,'') AS ITEMCODE,ISNULL(a.ITEMNAME,'') AS ITEMNAME,ISNULL(a.UOM,'') AS UOM,ISNULL(a.QTY,0) AS QTY,ISNULL(a.RATE,0) AS RATE ,ISNULL(a.AMOUNT,0) AS AMOUNT , ISNULL(a.CLSQTY,0) CLSQTY,ISNULL(b.QTY,0) AS AuthQTY,ISNULL(b.Amount,0) AS AuthAmount,ISNULL(b.AUTHORISED,'') AS AUTHORIZE FROM PO_INDENTDET A ,PO_STOCKINDENTAUTH_DET B WHERE a.indent_no=b.indentno and a.itemcode=b.itemcode and INDENT_NO='" & Trim(txt_IndentNo.Text) & "' ORDER BY a.AUTOID"
                    Else
                        sqlstring = "SELECT ISNULL(a.ITEMCODE,'') AS ITEMCODE,ISNULL(a.ITEMNAME,'') AS ITEMNAME,ISNULL(a.UOM,'') AS UOM,ISNULL(a.QTY,0) AS QTY,ISNULL(a.RATE,0) AS RATE ,ISNULL(a.AMOUNT,0) AS AMOUNT , ISNULL(a.CLSQTY,0) CLSQTY FROM PO_INDENTDET A where INDENT_NO='" & Trim(txt_IndentNo.Text) & "' ORDER BY a.AUTOID"

                        sqlstring1 = "select isnull(a.UserId,'')UserId,isnull(UserName,'')as UserName,	isnull(Mobile,0)Mobile,isnull(Email,'')Email from Indent_Auth_List a,user_mail_log  b where a.UserId=b.userid and  b.status='Y'and indentno='" & txt_IndentNo.Text & "'"

                        gconnection.getDataSet(sqlstring1, "EMAILSETUP")
                        If gdataset.Tables("EMAILSETUP").Rows.Count > 0 Then
                            GroupBox8.Visible = True
                            Label4.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("userid")
                            Label6.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("UserName")
                            Label8.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("Email")
                            Label11.Text = gdataset.Tables("EMAILSETUP").Rows(0).Item("Mobile")
                        End If


                    End If


                    gconnection.getDataSet(sqlstring, "INDENTDETAILS")
                    If gdataset.Tables("INDENTDETAILS").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("INDENTDETAILS").Rows.Count
                            Call GridUOM(i) '''---> FILL GRID UOM
                            ssgrid.SetText(1, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")))
                            STRITEMCODE = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE"))
                            ssgrid.SetText(2, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMNAME")))
                            ssgrid.Col = 3
                            ssgrid.Row = i
                            ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            STRITEMUOM = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            ssgrid.Text = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            ssgrid.SetText(4, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))
                            ssgrid.SetText(12, i, Format(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")), "0.000"))
                            ssgrid.SetText(5, i, Format(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("RATE")), "0.00"))
                            ssgrid.SetText(6, i, Format(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("AMOUNT")), "0.00"))

                            Dim INDDATE As Date
                            'INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
                            ssgrid.SetText(7, i, Format(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("clsqty")), "0.00"))
                            'Dim a As String
                            'a = dtp_Indentdate.Value
                            ' Clsquantity = ClosingQuantity_Date(STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), STRITEMUOM, INDDATE)
                            If gdataset.Tables("PO_STOCKINDENTAUTH_DET").Rows.Count > 0 Then
                                With ssgrid
                                    .Col = 8
                                    .Row = i
                                    .ColHidden = False
                                    .Col = 9
                                    .Row = i
                                    .ColHidden = False
                                    .Col = 10
                                    .Row = i
                                    .ColHidden = False
                                End With
                                ssgrid.SetText(8, i, Format(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("AuthQTY")), "0.00"))
                                ssgrid.SetText(9, i, Format(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("AuthAmount")), "0.00"))
                                ssgrid.SetText(10, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("AUTHORIZE")))

                                If Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("AUTHORIZE") = "Y") Then
                                    Label13.Visible = True
                                    Label13.Text = "Authorised"
                                    Label13.ForeColor = Color.Red
                                Else
                                    Label13.Visible = True
                                    Label13.Text = "Rejected"
                                    Label13.ForeColor = Color.Green
                                End If
                            Else
                                With ssgrid
                                    .Col = 8
                                    .Row = i
                                    .ColHidden = True
                                    .Col = 9
                                    .Row = i
                                    .ColHidden = True
                                    .Col = 10
                                    .Row = i
                                    .ColHidden = True
                                End With
                            End If

                            j = j + 1
                        Next
                    End If

                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    If Not String.IsNullOrEmpty(gAuditFlg) Then
                        If gAuditFlg.ToUpper = "Y" Then
                            Me.cmd_Add.Enabled = False
                            Me.Cmd_FREEZE.Enabled = False
                        End If
                    End If
                    ' ssgrid.Focus()
                    'dtp_Indentdate.Focus()
                    ssgrid.SetActiveCell(1, 1)
                    Call Calculate()
                Else
                    dtp_Indentdate.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillMenuItem()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        Dim vform As New ListOperattion1
        ''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 

        gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
        gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM FROM INVENTORYITEMMASTER AS I "

        If Trim(vsearch) = " " Then
            M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' "
        Else
            M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND I.ITEMNAME LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
        End If
        vform.Field = "I.ITEMNAME,I.ITEMCODE"
        vform.vFormatstring = "   ITEMCODE    |                      ITEMNAME              | STOCKUOM    "
        vform.vCaption = "INVENTORY ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield)
            ssgrid.Col = 2
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield1)
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 5
            ssgrid.Row = ssgrid.ActiveRow


            'Avgrate = CalAverageRate_new(Trim(vform.keyfield), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text)
            ssgrid.Text = Format(Val(Avgrate), "0.00")
            If gInventoryVersion = "N" Then
                gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), "")
                Dim closingqty, rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                Else
                    clsquantity = 0
                End If
            Else
                clsquantity = ClosingQuantity(Trim(vform.keyfield), TXT_FROMSTORECODE.Text)
            End If



            ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ssgrid.Focus()
        Else
            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub FillMenuItemNew()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        Dim vform As New ListOperattion1
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 

        gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
        gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM FROM INVENTORYITEMMASTER AS I "

        If Trim(vsearch) = " " Then
            M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' "
        Else
            M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND I.ITEMNAME LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
        End If
        vform.Field = "I.ITEMNAME,I.ITEMCODE"
        vform.vFormatstring = "   ITEMCODE    |                      ITEMNAME              | STOCKUOM    "
        vform.vCaption = "INVENTORY ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield)
            ssgrid.Col = 2
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield1)
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 5
            ssgrid.Row = ssgrid.ActiveRow

            'Avgrate = CalAverageRate_new(Trim(vform.keyfield), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text)
            ssgrid.Text = Format(Val(Avgrate), "0.00")
            'clsquantity = ClosingQuantity(Trim(vform.keyfield), TXT_FROMSTORECODE.Text)
            If gInventoryVersion = "N" Then
                gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), "")
                Dim closingqty, rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                Else
                    clsquantity = 0
                End If
            Else
                clsquantity = ClosingQuantity(Trim(vform.keyfield), TXT_FROMSTORECODE.Text)
            End If

            ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ssgrid.Focus()
        Else
            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub


    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub dtp_Indentdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Indentdate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_storecode.Focus()
        End If
    End Sub

    Private Sub cbo_type_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ssgrid.Focus()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PURCHASE ORDER' AND MODULENAME LIKE 'Indent' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_Add.Enabled = False
        Me.Cmd_FREEZE.Enabled = False
        Me.cmd_View.Enabled = False
        Me.cmd_Print.Enabled = False
        Me.cmd_export.Enabled = False

        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add.Enabled = True
                    Me.Cmd_FREEZE.Enabled = True
                    Me.cmd_View.Enabled = True

                    Me.cmd_export.Enabled = True
                    Me.cmd_Print.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_FREEZE.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                    'Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then

                End If
                If Right(x) = "P" Then
                    Me.cmd_Print.Enabled = True
                End If
            Next
        End If


    End Sub
    Private Sub cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Clear.Click
        Try
            Dim temp, temp1 As String
            txt_IndentNo.Text = ""
            txt_storecode.Text = ""
            txt_storeDesc.Text = ""
            TXT_FROMSTORECODE.Text = ""
            txt_FromStorename.Text = ""
            temp = Trim(TXT_FROMSTORECODE.Text)
            temp1 = Trim(txt_FromStorename.Text)
            Call clearform(Me)
            TXT_FROMSTORECODE.Text = temp
            txt_FromStorename.Text = temp1
            txt_IndentNo.ReadOnly = False
            Cmd_FREEZE.Enabled = True
            GroupBox8.Visible = False
            With ssgrid
                .Col = 8
                .Row = i
                .ColHidden = True
                .Col = 9
                .Row = i
                .ColHidden = True
                .Col = 10
                .Row = i
                .ColHidden = True
            End With

            Me.lbl_Freeze.Visible = False
            Me.dtp_Indentdate.Value = Format(Now, "dd/MM/yyyy")
            Me.lbl_Freeze.Text = "Record Void  On "
            Call GridRowUnLock()
            txt_Remarks.Text = ""
            ssgrid.ClearRange(1, 1, -1, -1, True)
            Me.Cmd_FREEZE.Text = "Void [F8]"
            cmd_Add.Text = "Add [F7]"
            ssgrid.SetActiveCell(1, 1)
            cmd_Add.Enabled = True
            Cmd_FREEZE.Enabled = True
            Me.Cmd_FREEZE.Enabled = True
            txt_qty.Text = ""
            txt_Totalamount.Text = ""
            Call autogenerate1()
            If gindentno = "Y" Then
                txt_storecode.Focus()
            Else
                txt_IndentNo.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            If Not String.IsNullOrEmpty(gAuditFlg) Then
                If gAuditFlg.ToUpper = "Y" Then
                    Me.cmd_Add.Enabled = False
                    Me.Cmd_FREEZE.Enabled = False
                End If
            End If
            Show()
            gPrint = False
            GETMAINSTORE()
            Label13.Visible = False
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub autogenerate()
        Try
            Dim sqlstring, financalyear As String
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            docno = txt_storecode.Text
            sqlstring = "SELECT MAX(SUBSTRING(DOCNO,1,5)) FROM PO_INDENTHDR WHERE storelocationcode ='" & docno & "'"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_IndentNo.Text = docno & "/00001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_IndentNo.Text = docno & "/" & Format(gdreader(0) + 1, "00000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_IndentNo.Text = docno & "/00001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_storecode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_storecode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_storecode.Text = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
                TXT_FROMSTORECODE.Focus()
            Else
                sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER "
                sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "' AND freeze <> 'Y' AND STORESTATUS<>'M' "
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")
                    TXT_FROMSTORECODE.Focus()
                Else
                    txt_storecode.Text = ""
                    txt_IndentNo.Text = ""
                    txt_storecode.Focus()
                End If
            End If
            If gindentno = "Y" Then
                If Trim(txt_storecode.Text) <> "" Then
                    doctype = Trim(txt_storecode.Text)
                    Call autogenerate()
                    TXT_FROMSTORECODE.Focus()
                Else
                    txt_storecode.Focus()
                End If
            Else
                Call autogenerate()
                TXT_FROMSTORECODE.Focus()
            End If
        End If
    End Sub
    Public Function ReportDetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMNO As String, ByVal TONO As String)
        Dim DBLDOCTOTAL, DBLGROUPTOTAL, DBLGRANDTOTAL, TOTQTY As Double
        Dim dbltaxamount As Double
        Dim FROMSTORE, STROEDESC, DOCDETAILS, SSql As String
        Dim STOREBOOL, DOCBOOL As Boolean
        Dim I, J, K, CC, ItemCnt As Integer
        Dim dr As DataRow
        Dim dc As DataColumn
        Dim pageno As Integer
        Dim pagesize As Integer
        Dim gconnection As New GlobalClass

        Try
            ItemCnt = 0
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            DBLGRANDTOTAL = 0
            TOTQTY = 0
            gconnection.getDataSet(SQLSTRING, "INDENT")

            If gdataset.Tables("INDENT").Rows.Count > 0 Then
                SSql = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & gdataset.Tables("INDENT").Rows(0).Item("FROMSTORECODE") & "' "
                gconnection.getDataSet(SSql, "FROMSTORE")
                If gdataset.Tables("FROMSTORE").Rows.Count > 0 Then
                    FROMSTORE = gdataset.Tables("FROMSTORE").Rows(0).Item("STOREDESC")
                End If
            Else
                MsgBox("NO DATA FOUND", MsgBoxStyle.Critical, "INVENTORY")
                Exit Function
            End If

            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine(Space(50) & Chr(14) & Chr(15) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 5
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(18) & Chr(27) & "E")
            Filewrite.WriteLine(Space(39 - Len(Trim(Mid(MyCompanyName, 1, 30))) / 2) & Mid(MyCompanyName, 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(39 - Len(Trim(Mid(PAGEHEAD(0), 1, 30))) / 2) & Trim(Mid(PAGEHEAD(0), 1, 30)))
            pagesize = pagesize + 1

            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(43) & "INDENT NO   : " & Space(12 - Len(Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("INDENT_NO"))), 1, 12))) & Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("INDENT_NO"))), 1, 12))
            Filewrite.WriteLine(Space(43) & "INDENT DATE : " & Space(12 - Len(Mid(Format(CDate(gdataset.Tables("INDENT").Rows(K).Item("INDENT_DATE")), "dd/MM/yyyy"), 1, 12))) & Mid(Format(CDate(gdataset.Tables("INDENT").Rows(K).Item("INDENT_DATE")), "dd/MM/yyyy"), 1, 12))
            pagesize = pagesize + 2
            Filewrite.WriteLine()
            pagesize = pagesize + 1

            Filewrite.WriteLine(" FROM : -" & Space(34) & "TO : -" & Chr(27) & "F")
            Filewrite.Write(Chr(27) & "E" & " DEPT CODE : " & Chr(27) & "F" & Trim(gdataset.Tables("INDENT").Rows(0).Item("FROMSTORECODE")))
            Filewrite.Write(Space(30 - Len(Trim(gdataset.Tables("INDENT").Rows(0).Item("FROMSTORECODE")))))
            Filewrite.WriteLine(Chr(27) & "E" & " DEPT CODE : " & Chr(27) & "F" & Trim(gdataset.Tables("INDENT").Rows(0).Item("STORELOCATIONCODE")))

            Filewrite.Write(Chr(27) & "E" & " DEPT NAME : " & Chr(27) & "F" & FROMSTORE & Space(30 - Len(FROMSTORE)))
            Filewrite.WriteLine(Chr(27) & "E" & " DEPT NAME : " & Chr(27) & "F" & Trim(gdataset.Tables("INDENT").Rows(0).Item("STORELOCATIONNAME")))
            Filewrite.WriteLine()
            pagesize = pagesize + 4

            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 4
            Filewrite.WriteLine("SNO CODE     ITEM NAME                 UOM         QTY       RATE        AMOUNT ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1

            If gdataset.Tables("INDENT").Rows.Count > 0 Then
                For K = 0 To gdataset.Tables("INDENT").Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.WriteLine(StrDup(82, "-"))
                        Filewrite.WriteLine(Chr(12))
                        pagesize = 0

                        Filewrite.WriteLine()
                        Filewrite.WriteLine()
                        Filewrite.WriteLine()
                        Filewrite.WriteLine()

                        Filewrite.WriteLine(StrDup(80, "-"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("SNO CODE       ITEM NAME                 UOM         QTY       RATE        AMOUNT ")

                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(80, "-"))
                        pagesize = pagesize + 1
                        pageno = pageno + 1
                    End If

                    SSql = Space(3 - Len(Trim(Mid(CStr(K + 1), 1, 3)))) & Trim(Mid(CStr(K + 1), 1, 3)) & Space(1)
                    SSql = SSql & Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("ITEMCODE"))), 1, 8) & Space(8 - Len(Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("ITEMCODE"))), 1, 8))) & Space(1)
                    SSql = SSql & Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("ITEMNAME"))), 1, 25) & Space(25 - Len(Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("ITEMNAME"))), 1, 25))) & Space(1)
                    SSql = SSql & Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("UOM"))), 1, 5) & Space(5 - Len(Mid(Trim(CStr(gdataset.Tables("INDENT").Rows(K).Item("UOM"))), 1, 5))) & Space(1)
                    SSql = SSql & Space(10 - Len(Mid(Format(Val(gdataset.Tables("INDENT").Rows(K).Item("QTY")), "0.000"), 1, 10))) & Mid(Format(Val(gdataset.Tables("INDENT").Rows(K).Item("QTY")), "0.000"), 1, 10) & Space(1)
                    SSql = SSql & Space(10 - Len(Mid(Format(Val(gdataset.Tables("INDENT").Rows(K).Item("RATE")), "0.00"), 1, 10))) & Mid(Format(Val(gdataset.Tables("INDENT").Rows(K).Item("RATE")), "0.00"), 1, 10) & Space(1)
                    SSql = SSql & Space(12 - Len(Mid(Format(Val(gdataset.Tables("INDENT").Rows(K).Item("AMOUNT")), "##,##0.00"), 1, 12))) & Mid(Format(Val(gdataset.Tables("INDENT").Rows(K).Item("AMOUNT")), "##,##0.00"), 1, 12)

                    DBLGRANDTOTAL = DBLGRANDTOTAL + Val(gdataset.Tables("INDENT").Rows(K).Item("AMOUNT"))
                    TOTQTY = TOTQTY + Val(gdataset.Tables("INDENT").Rows(K).Item("QTY"))
                    Filewrite.WriteLine(SSql)

                    pagesize = pagesize + 1
                    ItemCnt = ItemCnt + 1

                Next K
                CC = 0
                Filewrite.WriteLine(StrDup(79, "-"))
                Filewrite.WriteLine(Chr(27) & "E" & Space(31) & "TOTAL :" & Space(15 - Len(Format(TOTQTY, "0.000"))) & Format(TOTQTY, "##,##0.00") & Space(12) & Space(12 - Len(Format(DBLGRANDTOTAL, "##,##0.00"))) & Format(DBLGRANDTOTAL, "##,##0.00") & Chr(27) & "F")
                Filewrite.WriteLine(StrDup(79, "-"))
                Filewrite.WriteLine("")
                Filewrite.WriteLine(Space(0) & " Remarks:" & Trim(gdataset.Tables("INDENT").Rows(0).Item("remarks")))
                pagesize = pagesize + 3
                If pagesize < 50 Then
                    For I = 0 To (50 - pagesize)
                        Filewrite.WriteLine()
                    Next
                End If

                If gdataset.Tables("INDENT").Rows(0).Item("updfooter") <> "" And gdataset.Tables("INDENT").Rows(0).Item("FROMSTORECODE") <> "DRR" Then
                    Filewrite.WriteLine(Chr(27) & "E" & Trim(gdataset.Tables("INDENT").Rows(0).Item("updfooter")) & Chr(27) & "F")
                    Filewrite.WriteLine(Chr(12))
                Else
                    Filewrite.WriteLine(Chr(27) & "E" & " Indent By         Supervisor          Initials of Issues         Received by " & Chr(27) & "F")
                    Filewrite.WriteLine(Chr(12))
                End If
            Else
                MessageBox.Show("NO RECORD TO BE DISPLAYED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function

    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Print.Click
        ''''Try
        ''''    gPrint = True
        ''''    Call printoperation()
        ''''Catch ex As Exception
        ''''    MessageBox.Show("Plz Check Error : Print Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        ''''    Exit Sub
        ''''End Try

        Try
            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_Indentbill_
            sqlstring = sqlstring & " SELECT 	ISNULL(INDENT_NO,'') INDENT_NO, ISNULL(INDENT_DATE,'')  INDENT_DATE,"
            sqlstring = sqlstring & " ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(STORELOCATIONNAME,'') STORELOCATIONNAME,"
            sqlstring = sqlstring & " ISNULL(PRODUCT_TYPE,'') PRODUCT_TYPE, ISNULL(REMARKS,'') REMARKS,ISNULL(updsign,'') updsign,ISNULL(updfooter,'') updfooter,"
            sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            sqlstring = sqlstring & " ISNULL(QTY,0) QTY, ISNULL(RATE,0) RATE, ISNULL(AMOUNT,0) AMOUNT, ISNULL(CLSQTY,0) CLSQTY"
            sqlstring = sqlstring & " FROM VW_PO_IDENTBILL"
            ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            sqlstring = sqlstring & " WHERE INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "'"

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
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text21")
                textobj2.Text = gUsername
                Dim textobj As TextObject
                textobj = r.ReportDefinition.ReportObjects("Text17")
                textobj.Text = FROMSTORE
                rViewer.Show()
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub TXT_FROMSTORECODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_FROMSTORECODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                Call cmd_fromStorecodeHelp_Click(TXT_FROMSTORECODE.Text, e)
            Else
                Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
            End If
        End If
    End Sub

    Private Sub cmd_fromStorecodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_fromStorecodeHelp.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y' and STORESTATUS='M'"
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_FROMSTORECODE.Text = Trim(vform.keyfield & "")
            txt_FromStorename.Text = Trim(vform.keyfield1 & "")
        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXT_FROMSTORECODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.Validated
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then
            sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(Freeze,'') <> 'Y' and STORESTATUS='M'"
            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                ssgrid.Focus()
                ssgrid.SetActiveCell(1, 1)
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
        End If
    End Sub

    'Private Sub txt_IndentNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_IndentNo.GotFocus
    '    txt_IndentNo.BackColor = Color.Gold
    '    Label16.Visible = True
    'End Sub

    'Private Sub txt_IndentNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_IndentNo.LostFocus
    '    txt_IndentNo.BackColor = Color.Wheat
    '    Label16.Visible = False
    'End Sub

    Private Sub txt_storecode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_storecode.GotFocus
        txt_storecode.BackColor = Color.Gold
    End Sub

    Private Sub txt_storecode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_storecode.LostFocus
        txt_storecode.BackColor = Color.Wheat
    End Sub
    Private Sub TXT_FROMSTORECODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.GotFocus
        TXT_FROMSTORECODE.BackColor = Color.Gold
    End Sub

    Private Sub TXT_FROMSTORECODE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.LostFocus
        TXT_FROMSTORECODE.BackColor = Color.Wheat
    End Sub

    'Private Sub dtp_Indentdate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_Indentdate.GotFocus
    '    dtp_Indentdate.BackColor = Color.Gold
    'End Sub

    'Private Sub dtp_Indentdate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_Indentdate.LostFocus
    '    dtp_Indentdate.BackColor = Color.Wheat
    'End Sub

    Private Sub ssgrid_EnterRow(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_EnterRowEvent) Handles ssgrid.EnterRow
        MsgBox("enter row")
    End Sub

    

 
    Private Sub Txt_signature_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then

        End If
    End Sub
 

    Private Sub ssgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub

    Private Sub txt_IndentNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_IndentNo.TextChanged

    End Sub

    Private Sub TXT_FROMSTORECODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.TextChanged

    End Sub

    Private Sub ssgrid_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles ssgrid.Invalidated

    End Sub


    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VW_PO_IDENTBILL"
        sqlstring = "select * from VW_PO_IDENTBILL"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub CMD_AUTH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM PO_INDENTDET WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PO_INDENTDET WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PO_INDENTDET set  ", "INDENT_NO", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM PO_INDENTDET WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PO_INDENTDET WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PO_INDENTDET set  ", "INDENT_NO", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM PO_INDENTDET WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='PURCHASE ORDER' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PO_INDENTDET WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PO_INDENTDET set  ", "INDENT_NO", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 734
        K = 1034
        Me.ResizeRedraw = True
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "frmbut" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'Dim FRM As New ReportDesigner
        'If txt_IndentNo.Text.Length > 0 Then
        '    tables = " FROM VW_PO_IDENTBILL WHERE INDENT_NO ='" & txt_IndentNo.Text & "' "
        'Else
        '    tables = "FROM VW_PO_IDENTBILL"
        'End If
        'Gheader = "INDENT DETAILS"
        'FRM.DataGridView1.ColumnCount = 2
        'FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        'FRM.DataGridView1.Columns(0).Width = 300
        'FRM.DataGridView1.Columns(1).Name = "SIZE"
        'FRM.DataGridView1.Columns(1).Width = 100

        'Dim ROW As String() = New String() {"INDENT_NO", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"INDENT_DATE", "20"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"FROMSTORECODE", "5"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"STORELOCATIONCODE", "19"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"STORELOCATIONNAME", "25"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"PRODUCT_TYPE", "12"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"REMARKS", "25"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDSIGN", "12 "}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDFOOTER", "6 "}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"ITEMCODE", "8"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"ITEMNAME", "18"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UOM", "7"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"QTY", "7"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"RATE", "7"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"AMOUNT", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"CLSQTY", "11"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"ADDDATE", "20"}
        'FRM.DataGridView1.Rows.Add(ROW)

        'Dim CHK As New DataGridViewCheckBoxColumn()
        ''Dim CHK As New VIEWHDR
        'FRM.DataGridView1.Columns.Insert(0, CHK)
        'CHK.HeaderText = "CHECK"
        'CHK.Name = "CHK"
        'FRM.ShowDialog(Me)
        Dim obj1 As New VIEWHDR
        Dim sqlstr As String
        Dim childsql As String
        sqlstr = "select DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname,Product_type, "
        sqlstr = sqlstr & " Remarks,Void,Adduser,Adddatetime,updfooter,updsign from PO_INDENTHDR order by  cast(INDENT_DATE as dAtE)  DEsC"
        childsql = "select INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,Rate,Amount,CLSQTY,"
        childsql = childsql & " VOID,Adduser,adddatetime,ind_qty from PO_INDENTDET order by  cast(INDENT_DATE as dAtE)  DEsC"
        gconnection.getDataSet(sqlstr, "PO_INDENTHDR")
        obj1.LOADGRID(gdataset.Tables("PO_INDENTHDR"), True, "po_stockindent", childsql, "INDENT_NO", 1)
        obj1.Show()
    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub


    Private Sub autogenerate1()
        Dim sqlstring, financalyear As String
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            sqlstring = " SELECT MAX(isnull(cast(docno as numeric),0)) FROM PO_INDENTHDR WhErE STORELOCATIONCODE<>'AUTO' AND DOCNO IS NOT NULL"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    '  txt_IndentNo.Text = "IND/000001/" & financalyear
                    ' txt_IndentNo.Text =
                    txt_IndentNo.Text = Format(1, "00000000")
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    '  txt_IndentNo.Text = "IND/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    txt_IndentNo.Text = Format(gdreader(0) + 1, "00000000")
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_IndentNo.Text = Format(1, "00000000")
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


    Private Sub cmd_fromStorecodeHelp_Validated(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Validated
        ssgrid.SetActiveCell(1, 1)
    End Sub


    Private Function Mail_softcopy(dtl As String, subject As String)
        Try

            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_Indentbill_
            sqlstring = sqlstring & " SELECT 	ISNULL(INDENT_NO,'') INDENT_NO, ISNULL(INDENT_DATE,'')  INDENT_DATE,"
            sqlstring = sqlstring & " ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(STORELOCATIONNAME,'') STORELOCATIONNAME,"
            sqlstring = sqlstring & " ISNULL(PRODUCT_TYPE,'') PRODUCT_TYPE, ISNULL(REMARKS,'') REMARKS,ISNULL(updsign,'') updsign,ISNULL(updfooter,'') updfooter,"
            sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            sqlstring = sqlstring & " ISNULL(QTY,0) QTY, ISNULL(RATE,0) RATE, ISNULL(AMOUNT,0) AMOUNT, ISNULL(CLSQTY,0) CLSQTY, ISNULL(ADDDATE,'') ADDDATE "
            sqlstring = sqlstring & " FROM VW_PO_IDENTBILL"
            ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            sqlstring = sqlstring & " WHERE INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "'"

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
                textobj = r.ReportDefinition.ReportObjects("Text17")
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
                ' textobj5.Text = "Tel:" & GPHONE & " ,40090019, Fax:" & gFax & ", Email:" & gEmail & "" & ", Web:" & gWebsite
                If gFax = "" Then
                    textobj5.Text = "Tel:" & GPHONE & " , Email:" & gEmail & "" & ", Web:" & gWebsite
                Else
                    textobj5.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & "" & ", Web:" & gWebsite
                End If
                Dim TEXTOBJ6 As TextObject
                TEXTOBJ6 = r.ReportDefinition.ReportObjects("Text25")
                TEXTOBJ6.Text = "GSTIN :" & gServiceTax & " , Tin No.:" & gTinNo


                rViewer.Show()



                If gpdf = "" Then
                    MessageBox.Show("Pls Provide PDF Path in Dbs key..")
                    Exit Function
                End If

                If Directory.Exists(gpdf) Then
                Else
                    MessageBox.Show(gpdf & " not exists")
                    Exit Function
                End If
                If Directory.Exists(gpdf & "\" & gFinancalyearStart & "-" & gFinancialyearEnd) Then
                Else
                    Directory.CreateDirectory(gpdf & "\" & gFinancalyearStart & "-" & gFinancialyearEnd)
                End If


                Dim FILEPATH As String
                Dim AFILE As File

                FILEPATH = gpdf & "\" & gFinancalyearStart & "-" & gFinancialyearEnd & "\" & Trim(txt_IndentNo.Text) & ".PDF"

                If AFILE.Exists(FILEPATH) Then
                    AFILE.Delete(FILEPATH)
                End If

                Dim CREXPORTOPTIONS As ExportOptions
                Dim CRDISKFILEDESTINATIONOPTIONS As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                CRDISKFILEDESTINATIONOPTIONS.DiskFileName = FILEPATH
                CREXPORTOPTIONS = r.ExportOptions
                With CREXPORTOPTIONS
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = CRDISKFILEDESTINATIONOPTIONS
                    .FormatOptions = CrFormatTypeOptions
                End With

                r.Export()

                rViewer.Close()


                id()
                If mailid <> "" Then

                    Call mail(mailid, FILEPATH, "", "Dear Sir," & vbCrLf & vbCrLf & "Please Find the attached indent for your Approval." & vbCrLf & vbCrLf & dtl & "." & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UCase(txt_storeDesc.Text), subject)

                Else

                End If

            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If

 
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function

    Sub id()
        Dim PrinterConn As New OleDb.OleDbConnection
        Dim Printercmd As New OleDb.OleDbDataAdapter
        Dim GetPrinter As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            PrinterConn.ConnectionString = sql
            PrinterConn.Open()
            ssql = "SELECT email from email"
            Printercmd = New OleDb.OleDbDataAdapter(ssql, PrinterConn)
            Printercmd.Fill(GetPrinter)
            If GetPrinter.Tables(0).Rows.Count > 0 Then
                For I = 0 To GetPrinter.Tables(0).Rows.Count - 1

                    If mailid = "" Then
                        mailid = Trim(GetPrinter.Tables(0).Rows(i).Item(0) & "")
                    Else
                        mailid = mailid & "," & Trim(GetPrinter.Tables(0).Rows(i).Item(0) & "")
                    End If

                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Connect To Computer Printer", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            PrinterConn.Close()
        End Try
    End Sub

    Public Function mail(ByVal emailid As String, ByVal FILEPATH As String, ByVal MailMessage As String, ByVal filename As String, ByVal subject As String)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()

        Try
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("erp@kga.in", "h4?WW.tq9*TD")
            Smtp_Server.Port = 587

            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "mail.kga.in"


            e_mail = New MailMessage()
            e_mail.From = New MailAddress("erp@kga.in", "KGA Inventory Service")

            e_mail.To.Add(emailid)


            If subject = "" Then
                e_mail.Subject = gCompanyShortName & " DEPT." & UCase(txt_storeDesc.Text) & " PO INDENT."
            Else
                e_mail.Subject = subject
            End If


            e_mail.IsBodyHtml = False

            e_mail.Body = filename
            e_mail.Attachments.Add(New Attachment(FILEPATH))
            Smtp_Server.Send(e_mail)


            sqlstring = "delete from sendmail  where indentno ='" & txt_IndentNo.Text & "'"
            gconnection.GetValues(sqlstring)
            sqlstring = "insert into sendmail (emailid,sentdate,indentno,username) values ('" & emailid & "',getdate(),'" & txt_IndentNo.Text & "','" & gUsername & "')"
            gconnection.GetValues(sqlstring)
        Catch ex As Exception
            MsgBox(ex.Message, "Mail sending process failed. Kindly check your internet connection and Credential", "Dear User")
            sqlstring = "delete from sendmail  where indentno ='" & txt_IndentNo.Text & "'"
            gconnection.GetValues(sqlstring)
            Exit Function


        End Try


    End Function

    Private Sub grp_Grngroup1_Enter(sender As Object, e As EventArgs) Handles grp_Grngroup1.Enter

    End Sub

    Private Sub txt_storecode_TextChanged(sender As Object, e As EventArgs) Handles txt_storecode.TextChanged
        If Mid(cmd_Add.Text, 1, 1) = "A" Then
            TXT_FROMSTORECODE.Text = txt_storecode.Text
            Call autogenerate()
        End If

    End Sub

    Private Sub ssgrid_Validated(sender As Object, e As EventArgs) Handles ssgrid.Validated
        'Dim i, j, k As Integer
        'Dim Rate, clsquantity, AMOUNT, purrate As Double
        'Dim Itemcode, Itemdesc, UOM As String
        'Try

        '        i = ssgrid.ActiveRow
        '        If ssgrid.ActiveCol = 1 Then
        '            ssgrid.Col = 1
        '            ssgrid.Row = i
        '            If ssgrid.Lock = False Then
        '                Dim temp, TEMP1 As String
        '                temp = 0
        '                TEMP1 = ""
        '                ssgrid.Col = 1
        '                ssgrid.Row = i
        '                ssgrid.Col = 4
        '                ssgrid.Row = i
        '                temp = ssgrid.Text
        '                ssgrid.Col = 1
        '                ssgrid.Row = i
        '                If Val(temp) = 0 Then
        '                    If Trim(ssgrid.Text) = "" Then
        '                        'Call fillmenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
        '                        Call FillMenuNew()
        '                    Else
        '                        Itemcode = Trim(ssgrid.Text)
        '                        ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
        '                        ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
        '                        'sqlstring = sqlstring & "SELECT DISTINCT ISNULL(P.ITEMCODE,'') AS ITEMCODE, ISNULL(P.ITEMNAME,'') AS ITEMNAME,'' AS STOCKUOM,'' as PURCHASERATE,ISNULL(P.salerate,0) AS SALERATE FROM PO_ITEMMASTER AS P"
        '                        'sqlstring = sqlstring & "where ISNULL(P.FREEZE,'') <> 'Y'"
        '                        'sqlstring = sqlstring & " union all "
        '                        sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.UOM,'') AS STOCKUOM ,prate AS PURCHASERATE "
        '                        sqlstring = sqlstring & " FROM REG_INDENT AS I "
        '                        sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "' "
        '                        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
        '                        If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
        '                            Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
        '                            If Dupchk = True Then
        '                                ssgrid.Col = 1
        '                                ssgrid.Row = ssgrid.ActiveRow
        '                                ssgrid.Text = ""
        '                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
        '                                ssgrid.Focus()
        '                                Exit Sub
        '                            End If
        '                            Call check_In_Inventory(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
        '                            If Dupchk = True Then
        '                                ssgrid.Col = 1
        '                                ssgrid.Row = ssgrid.ActiveRow
        '                                ssgrid.Text = ""
        '                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
        '                                ssgrid.Focus()
        '                                Exit Sub
        '                            End If
        '                            Call GridUOM(i) ''---> Fill the UOM feild
        '                            ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
        '                            ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
        '                            ssgrid.Col = 3
        '                            ssgrid.Row = i
        '                            ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
        '                            UOM = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
        '                            'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
        '                            If gsalerate = "Y" Then
        '                                ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
        '                            Else
        '                                ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
        '                            End If

        '                            'Rate = CalAverageRate_new(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text)
        '                            'ssgrid.SetText(5, i, Format(Val(Rate), "0.00"))
        '                            If Trim(txt_storecode.Text) <> "" Then
        '                                If gInventoryVersion = "N" Then
        '                                    gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "")
        '                                    Dim closingqty As Double
        '                                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                                        clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                                    Else
        '                                        clsquantity = 0
        '                                    End If
        '                                Else
        '                                    clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
        '                                End If


        '                            Else
        '                                clsquantity = 0
        '                            End If
        '                            ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

        '                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '                            Call GridRowLock(i)
        '                            ssgrid.Col = 3
        '                            Dim SqlQuery As String
        '                            SqlQuery = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))) & "' "
        '                            gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
        '                            If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
        '                                Call FillTransUOM(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))))
        '                            ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
        '                                ssgrid.Row = ssgrid.ActiveRow
        '                                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
        '                                ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
        '                            Else
        '                                ssgrid.Row = ssgrid.ActiveRow
        '                                ssgrid.Text = Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))
        '                            End If
        '                            Dim STRITEMUOM As String
        '                            ssgrid.Col = 3
        '                            ssgrid.Row = ssgrid.ActiveRow
        '                            STRITEMUOM = ssgrid.Text
        '                            ssgrid.SetText(13, i, clsquantity)
        '                            ssgrid.Col = 7
        '                            ssgrid.Row = ssgrid.ActiveRow
        '                            Dim INDDATE As Date
        '                            INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
        '                            ' clsquantity = ClosingQuantity_Date(Itemcode, Trim(TXT_FROMSTORECODE.Text), STRITEMUOM, INDDATE)
        '                            ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
        '                            'If Val(clsquantity) <= 0 Then
        '                            '    MsgBox("Item Has No Stock", MsgBoxStyle.Information, MyCompanyName)
        '                            '    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
        '                            '    ssgrid.Text = ""
        '                            '    ssgrid.Focus()
        '                            '    Exit Sub
        '                            'End If
        '                            'Rate = CalAverageRate_new(Itemcode, Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text, STRITEMUOM)
        '                            'ssgrid.SetText = (5, i, Format(Val(Rate), "0.00"))
        '                            'ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))

        '                            'ssgrid.Col = 2
        '                            'ssgrid.Row = ssgrid.ActiveRow
        '                            'ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
        '                            'ssgrid.Col = 3
        '                            Dim grndate1 As DateTime
        '                            Dim curuom As String
        '                            Dim currate, prate As Double
        '                            SqlQuery = "select max(grndate) as grndate,itemcode from grn_details WHERE Itemcode ='" & Trim(Itemcode) & "' AND grndate <='" & Format(CDate(dtp_Indentdate.Text), "yyyy-MM-dd") & "' group by itemcode"
        '                            gconnection.getDataSet(SqlQuery, "temp")
        '                            If gdataset.Tables("temp").Rows.Count > 0 Then
        '                                grndate1 = gdataset.Tables("temp").Rows(0).Item("grndate")
        '                                'grndate1 = Format(CDate(grndate1), "yyyy/MM/dd")
        '                                ssgrid.Col = 3
        '                                ssgrid.Row = ssgrid.ActiveRow
        '                                curuom = Trim(ssgrid.Text)
        '                                SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(Itemcode) & "' , '" & Trim(UOM) & "'"
        '                                gconnection.getDataSet(SqlQuery, "temp1")
        '                                If gdataset.Tables("temp1").Rows.Count > 0 Then
        '                                    currate = gdataset.Tables("temp1").Rows(0).Item("rate")
        '                                    ssgrid.Col = 5
        '                                    ssgrid.Row = ssgrid.ActiveRow
        '                                    ssgrid.Text = Format(Val(currate), "0.00")
        '                                End If
        '                                'Else
        '                                '    SqlQuery = "select rate = rate * b.convvalue from inventory_transconversion b, grn_details where itemcode = '" & Trim(Itemcode) & "' and grn_details.grndate = '" & Format(CDate(grndate1), "yyyy-MM-dd") & "' and b. baseuom = '" & Trim(curuom) & "' and b.transuom = grn_details.uom "
        '                                '    gconnection.getDataSet(SqlQuery, "temp2")
        '                                '    If gdataset.Tables("temp2").Rows.Count > 0 Then
        '                                '        prate = gdataset.Tables("temp2").Rows(0).Item("rate")
        '                                '        ssgrid.Col = 5
        '                                '        ssgrid.Row = ssgrid.ActiveRow
        '                                '        ssgrid.Text = Format(Val(prate), "0.00")
        '                                '        'ssgrid.Text = "0.00"
        '                                '        ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
        '                                '        ssgrid.Focus()
        '                                '    End If
        '                                'End If
        '                            Else
        '                                ssgrid.Col = 5
        '                                ssgrid.Row = ssgrid.ActiveRow
        '                                ssgrid.Text = Format(Val(purrate), "0.00")
        '                            End If

        '                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '                            ssgrid.Focus()
        '                        Else
        '                            MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
        '                            ssgrid.Text = ""
        '                            ssgrid.Focus()
        '                            Exit Sub
        '                        End If
        '                    End If
        '                Else
        '                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '                    Call SelectText()
        '                End If
        '            Else
        '                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
        '            End If
        '        ElseIf ssgrid.ActiveCol = 2 Then
        '            ssgrid.Col = 2
        '            i = ssgrid.ActiveRow
        '            ssgrid.Row = i
        '            If ssgrid.Lock = False Then
        '                If Trim(ssgrid.Text) = "" Then
        '                    Call FillMenuNew() '' IT WILL SHOW A POPUP MENU FOR ITEM CODE
        '                Else
        '                    Itemdesc = Trim(ssgrid.Text)
        '                    ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
        '                    ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
        '                    sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM ,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE"
        '                    sqlstring = sqlstring & " FROM INVENTORYITEMMASTER AS I"
        '                    sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y' AND ISNULL(I.STORECODE,'')='" & Trim(TXT_FROMSTORECODE.Text) & "'"
        '                    gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
        '                    If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
        '                        Call GridUOM(i) ''---> Fill the UOM feild
        '                        ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

        '                        Call check_In_Inventory(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
        '                        If Dupchk = True Then
        '                            ssgrid.Col = 1
        '                            ssgrid.Row = ssgrid.ActiveRow
        '                            ssgrid.Text = ""
        '                            ssgrid.Col = 2
        '                            ssgrid.Row = ssgrid.ActiveRow
        '                            ssgrid.Text = ""
        '                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
        '                            ssgrid.Focus()
        '                            Exit Sub
        '                        End If

        '                        ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))

        '                        ssgrid.Col = 3
        '                        ssgrid.Row = i
        '                        ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
        '                        ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
        '                        'Rate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
        '                        ' Rate = CalAverageRate_new(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), dtp_Indentdate.Text, TXT_FROMSTORECODE.Text)
        '                        Rate = gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")
        '                        ssgrid.SetText(5, i, Format(Val(Rate), "0.00"))
        '                        'clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), GetMainStore())
        '                        If Trim(txt_storecode.Text) <> "" Then
        '                            If Trim(txt_storecode.Text) <> "" Then
        '                                If gInventoryVersion = "N" Then
        '                                    gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "")
        '                                    Dim closingqty As Double
        '                                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                                        clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                                    Else
        '                                        clsquantity = 0
        '                                    End If
        '                                Else
        '                                    clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text)
        '                                End If


        '                            Else
        '                                clsquantity = 0
        '                            End If

        '                            ' clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text)
        '                        Else
        '                            clsquantity = 0
        '                        End If
        '                        'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
        '                        'If Val(clsquantity) <= 0 Then
        '                        '    MsgBox("Item Has No Stock", MsgBoxStyle.Information, MyCompanyName)
        '                        '    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
        '                        '    ssgrid.Text = ""
        '                        '    ssgrid.Focus()
        '                        '    Exit Sub
        '                        'End If
        '                        ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
        '                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '                        Call GridRowLock(i)
        '                    Else
        '                        MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
        '                        ssgrid.Text = ""
        '                        ssgrid.Focus()
        '                        Exit Sub
        '                    End If
        '                End If
        '            End If
        '        ElseIf ssgrid.ActiveCol = 4 Then

        '            Dim sqlrol, rolitem As String
        '            Dim mqty, CQty, ROLQty As Double
        '            mqty = 0 : CQty = 0 : ROLQty = 0
        '        ssgrid.Col = 3
        '        i = ssgrid.ActiveRow
        '        ssgrid.Row = i
        '        UOM = ssgrid.Text
        '        clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
        '            ssgrid.Col = 7
        '            i = ssgrid.ActiveRow
        '            ssgrid.Row = i
        '            CQty = Val(ssgrid.Text)

        '            ssgrid.Col = 1
        '            i = ssgrid.ActiveRow
        '            ssgrid.Row = i
        '            rolitem = Trim(ssgrid.Text)

        '            sqlrol = "select isnull(minqty,0) as minqty, isnull(reorderlevel,0) as reorderlevel from inventoryitemmaster where itemcode ='" & Trim(rolitem) & "' and storecode ='" & TXT_FROMSTORECODE.Text & "'"
        '            gconnection.getDataSet(sqlrol, "INVENTORYROL")
        '            'If gdataset.Tables("inventoryrol").Rows.Count > 0 Then
        '            '    mqty = gdataset.Tables("inventoryrol").Rows(0).Item("minqty")
        '            '    ROLQty = gdataset.Tables("inventoryrol").Rows(0).Item("reorderlevel")
        '            'End If

        '            'If ROLQty <> 0 Then
        '            '    If CQty < mqty Then
        '            '        If CQty >= ROLQty Then
        '            '            MsgBox("Your Stock Reached ReorderLevel Qty")
        '            '        End If
        '            '    End If
        '            'End If

        '            'If mqty <> 0 Then
        '            '    If CQty >= mqty Then
        '            '        MsgBox("Your Stock Reached Minimumlevel Qty")
        '            '    End If
        '            'End If

        '            ssgrid.Col = 4
        '            i = ssgrid.ActiveRow
        '            ssgrid.Row = i
        '            If ssgrid.Lock = False Then
        '                If Val(ssgrid.Text) = 0 Then
        '                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '                    'ElseIf Val(ssgrid.Text) > CQty Then
        '                    '    MsgBox("ISSUING QTY CANNOT BE GREATER THAN CLOSING QTY")
        '                    '    ssgrid.Text = 0
        '                    '    ssgrid.Focus()
        '                    '    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '                    '    Exit Sub
        '                Else
        '                    Call Calculate() ''CALC TOTAL AMOUNT
        '                    ssgrid.Col = 5
        '                    Rate = ssgrid.Text
        '                    ssgrid.Col = 4
        '                    ssgrid.Row = ssgrid.ActiveRow + 1
        '                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
        '                End If
        '            End If
        '        ElseIf ssgrid.ActiveCol = 5 Then
        '        ElseIf ssgrid.ActiveCol = 6 Then

        '        ElseIf ssgrid.ActiveCol = 7 Then

        '        End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub ssgrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim i, j, k As Integer
        Dim Rate, clsquantity, AMOUNT, purrate As Double
        Dim Itemcode, Itemdesc, UOM As String
        Try
           
             
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        Dim temp, TEMP1 As String
                        temp = 0
                        TEMP1 = ""
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        temp = ssgrid.Text
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        If Val(temp) = 0 Then
                            If Trim(ssgrid.Text) = "" Then
                                'Call fillmenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                            'Call FillMenuNew()
                            Else
                                Itemcode = Trim(ssgrid.Text)
                                ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                                ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''

                                sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.UOM,'') AS STOCKUOM ,prate AS PURCHASERATE "
                                sqlstring = sqlstring & " FROM REG_INDENT AS I "
                                sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "' "
                                gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                                If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                    Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                    If Dupchk = True Then
                                        ssgrid.Col = 1
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = ""
                                        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                        ssgrid.Focus()
                                        Exit Sub
                                    End If
                                    Call check_In_Inventory(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                    If Dupchk = True Then
                                        ssgrid.Col = 1
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = ""
                                        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                        ssgrid.Focus()
                                        Exit Sub
                                    End If
                                    Call GridUOM(i) ''---> Fill the UOM feild
                                    ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                    ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                    ssgrid.Col = 3
                                    ssgrid.Row = i
                                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                    UOM = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                    'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                    If gsalerate = "Y" Then
                                        ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                    Else
                                        ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                    End If

                                    'Rate = CalAverageRate_new(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), TXT_FROMSTORECODE.Text)
                                    'ssgrid.SetText(5, i, Format(Val(Rate), "0.00"))
                                    If Trim(txt_storecode.Text) <> "" Then
                                        If gInventoryVersion = "N" Then
                                            gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "")
                                            Dim closingqty As Double
                                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                                clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                            Else
                                                clsquantity = 0
                                            End If
                                        Else
                                            clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                        End If


                                    Else
                                        clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                    End If


                                    ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                    Call GridRowLock(i)
                                    ssgrid.Col = 3
                                    Dim SqlQuery As String
                                SqlQuery = "SELECT DISTINCT ISNULL(UOM,'') AS Tranuom  FROM  CLOSINGQTY  WHERE ISNULL(RATE,0)>0 AND Itemcode ='" & Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))) & "' "
                                    gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                                    If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
                                        Call FillTransUOM(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))))
                                    ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                        ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                    Else
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))
                                    End If
                                    Dim STRITEMUOM As String
                                    ssgrid.Col = 3
                                    ssgrid.Row = ssgrid.ActiveRow
                                    STRITEMUOM = ssgrid.Text
                                    ssgrid.SetText(13, i, clsquantity)
                                    ssgrid.Col = 7
                                    ssgrid.Row = ssgrid.ActiveRow
                                    Dim INDDATE As Date
                                    INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
                                    ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                    Dim grndate1 As DateTime
                                    Dim curuom As String
                                    Dim currate, prate As Double
                                    'SqlQuery = "select max(grndate) as grndate,itemcode from grn_details WHERE Itemcode ='" & Trim(Itemcode) & "' AND grndate <='" & Format(CDate(dtp_Indentdate.Text), "yyyy-MM-dd") & "' group by itemcode"
                                    'gconnection.getDataSet(SqlQuery, "temp")
                                    'If gdataset.Tables("temp").Rows.Count > 0 Then
                                    '    grndate1 = gdataset.Tables("temp").Rows(0).Item("grndate")
                                    '    'grndate1 = Format(CDate(grndate1), "yyyy/MM/dd")

                                    '    'Else
                                    '    '    SqlQuery = "select rate = rate * b.convvalue from inventory_transconversion b, grn_details where itemcode = '" & Trim(Itemcode) & "' and grn_details.grndate = '" & Format(CDate(grndate1), "yyyy-MM-dd") & "' and b. baseuom = '" & Trim(curuom) & "' and b.transuom = grn_details.uom "
                                    '    '    gconnection.getDataSet(SqlQuery, "temp2")
                                    '    '    If gdataset.Tables("temp2").Rows.Count > 0 Then
                                    '    '        prate = gdataset.Tables("temp2").Rows(0).Item("rate")
                                    '    '        ssgrid.Col = 5
                                    '    '        ssgrid.Row = ssgrid.ActiveRow
                                    '    '        ssgrid.Text = Format(Val(prate), "0.00")
                                    '    '        'ssgrid.Text = "0.00"
                                    '    '        ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                                    '    '        ssgrid.Focus()
                                    '    '    End If
                                    '    'End If
                                    'Else
                                    '    ssgrid.Col = 5
                                    '    ssgrid.Row = ssgrid.ActiveRow
                                    '    ssgrid.Text = Format(Val(purrate), "0.00")
                                    'End If
                                    ssgrid.Col = 3
                                    ssgrid.Row = ssgrid.ActiveRow
                                    curuom = Trim(ssgrid.Text)
                                SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(Itemcode) & "' , '" & Trim(UOM) & "'"
                                M_WhereCondition = ""
                                    gconnection.getDataSet(SqlQuery, "temp1")
                                    If gdataset.Tables("temp1").Rows.Count > 0 Then
                                        currate = gdataset.Tables("temp1").Rows(0).Item("rate")
                                        ssgrid.Col = 5
                                        ssgrid.Row = ssgrid.ActiveRow
                                        ssgrid.Text = Format(Val(currate), "0.00")
                                    End If
                                    ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
                                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        Else
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            Call SelectText()
                        End If
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenuNew() '' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(ssgrid.Text)
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            ''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.UOM,'') AS STOCKUOM ,prate AS PURCHASERATE "
                            sqlstring = sqlstring & " FROM REG_INDENT AS I "
                            sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "' "

                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                                Call check_In_Inventory(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                                Call GridUOM(i) ''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = i
                                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                UOM = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                If gsalerate = "Y" Then
                                    ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                Else
                                    ssgrid.SetText(5, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("PURCHASERATE")))
                                End If

                                If Trim(txt_storecode.Text) <> "" Then
                                    If gInventoryVersion = "N" Then
                                        gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), "")
                                        Dim closingqty As Double
                                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                            clsquantity = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                        Else
                                            clsquantity = 0
                                        End If
                                    Else
                                        clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                    End If


                                Else
                                    clsquantity = ClosingQuantity_FORINDENT(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), TXT_FROMSTORECODE.Text, UOM)
                                End If


                                ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                Call GridRowLock(i)
                                ssgrid.Col = 3
                                Dim SqlQuery As String
                            SqlQuery = "SELECT DISTINCT ISNULL(UOM,'') AS Tranuom  FROM  CLOSINGQTY  WHERE ISNULL(RATE,0)>0 AND Itemcode ='" & Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))) & "' "
                                gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                                If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
                                    Call FillTransUOM(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))))
                                ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                    ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
                                Else
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))
                                End If
                                Dim STRITEMUOM As String
                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                STRITEMUOM = ssgrid.Text
                                ssgrid.SetText(13, i, clsquantity)
                                ssgrid.Col = 7
                                ssgrid.Row = ssgrid.ActiveRow
                                Dim INDDATE As Date
                                INDDATE = Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy")
                                ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))

                                Dim grndate1 As DateTime
                                Dim curuom As String
                                Dim currate, prate As Double

                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                curuom = Trim(ssgrid.Text)
                            SqlQuery = "EXEC  PROC_Indent_getitemrate '" & Trim(Itemcode) & "' , '" & Trim(UOM) & "'"
                            M_WhereCondition = ""
                                gconnection.getDataSet(SqlQuery, "temp1")
                                If gdataset.Tables("temp1").Rows.Count > 0 Then
                                    currate = gdataset.Tables("temp1").Rows(0).Item("rate")
                                    ssgrid.Col = 5
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = Format(Val(currate), "0.00")
                                End If
                                ssgrid.SetText(7, ssgrid.ActiveRow, Format(Val(clsquantity), "0.000"))
                                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                ssgrid.Focus()
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 4 Then

                    Dim sqlrol, rolitem As String
                    Dim mqty, CQty, ROLQty As Double
                    mqty = 0 : CQty = 0 : ROLQty = 0

                    ssgrid.Col = 7
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    CQty = Val(ssgrid.Text)

                    ssgrid.Col = 1
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    rolitem = Trim(ssgrid.Text)

                    sqlrol = "select isnull(minqty,0) as minqty, isnull(reorderlevel,0) as reorderlevel from inventoryitemmaster where itemcode ='" & Trim(rolitem) & "' and storecode ='" & TXT_FROMSTORECODE.Text & "'"
                    gconnection.getDataSet(sqlrol, "INVENTORYROL")
                    'If gdataset.Tables("inventoryrol").Rows.Count > 0 Then
                    '    mqty = gdataset.Tables("inventoryrol").Rows(0).Item("minqty")
                    '    ROLQty = gdataset.Tables("inventoryrol").Rows(0).Item("reorderlevel")
                    'End If

                    'If ROLQty <> 0 Then
                    '    If CQty < mqty Then
                    '        If CQty >= ROLQty Then
                    '            MsgBox("Your Stock Reached ReorderLevel Qty")
                    '        End If
                    '    End If
                    'End If

                    'If mqty <> 0 Then
                    '    If CQty >= mqty Then
                    '        MsgBox("Your Stock Reached Minimumlevel Qty")
                    '    End If
                    'End If

                    ssgrid.Col = 4
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            'ElseIf Val(ssgrid.Text) > CQty Then
                            '    MsgBox("ISSUING QTY CANNOT BE GREATER THAN CLOSING QTY")
                            '    ssgrid.Text = 0
                            '    ssgrid.Focus()
                            '    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            '    Exit Sub
                        Else
                            Call Calculate() ''CALC TOTAL AMOUNT
                            ssgrid.Col = 5
                            Rate = ssgrid.Text
                            ssgrid.Col = 4
                            ssgrid.Row = ssgrid.ActiveRow + 1
                            ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 5 Then
                ElseIf ssgrid.ActiveCol = 6 Then

                ElseIf ssgrid.ActiveCol = 7 Then

                End If
             
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ssgrid_MouseCaptureChanged(sender As Object, e As EventArgs) Handles ssgrid.MouseCaptureChanged

    End Sub
End Class
