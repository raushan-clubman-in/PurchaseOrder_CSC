Imports System.Data.SqlClient
Imports System
Public Class Premium_Date_Master
    Dim gconnection As New GlobalClass
    Dim TRANSNO As Integer
    'Dim rs As New Resizer1
    Public Sub checkValidation()
        Try
            boolchk = False

            If Desc_txtbox.Text = "" Then
                MessageBox.Show("Description cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Desc_txtbox.Focus()
                Exit Sub
            End If

            boolchk = True
        Catch EX As Exception
            MsgBox(EX.ToString)
        End Try
    End Sub
    Public Sub resizeFormResolution()
        Dim T, U As Integer
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
    End Sub

    Private Sub clearoperation()
        Try

            Desc_txtbox.Clear()
            'Premiumdate.Value = Format(DateTime.Now, "dd/MMM/yyyy")
            Premiumdate.Value = DateTime.Now

            BTN_SAVE.Text = "Save"
            BTN_SAVE.Enabled = True
            BTN_FREEZE.Text = "Freeze"
            BTN_FREEZE.Enabled = True
            Label_Freeze.Visible = False
            'Desc_txtbox.Text = GenerateCode()
        Catch ex As Exception

        End Try


    End Sub
    Private Function GenerateCode() As Integer
        Try
            'gSQLString = "SELECT ISNULL(MAX(CODE),0)+1 FROM PARTY_HSN_MASTER"
            'gconnection.getDataSet(gSQLString, "S")
            'If gdataset.Tables("S").Rows.Count > 0 Then
            '    Return gdataset.Tables("S").Rows(0).Item(0)
            'End If
        Catch ex As Exception

        End Try
        Return 0

    End Function
    Private Sub SaveOperation()
        Try
            checkValidation()
            If boolchk = False Then
                Exit Sub
            End If
            If Mid(BTN_SAVE.Text, 1, 1) = "S" Then
                gSQLString = "SELECT DESCRIPTION,PREMIUM_DATE FROM  PARTY_PREMIUMDATE_MASTER WHERE DESCRIPTION='" + Desc_txtbox.Text + "' AND PREMIUM_DATE='" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "'"
                gconnection.getDataSet(gSQLString, "ss")
                If gdataset.Tables("ss").Rows.Count > 0 Then
                    MsgBox("Duplicate Entry is not allowed")
                    clearoperation()
                    Exit Sub
                End If
                ' gconnection.getserverdatetime()
                TRANSNO = GenerateCode()
                gSQLString = "INSERT INTO PARTY_PREMIUMDATE_MASTER (PREMIUM_DATE,DESCRIPTION,ADDUSERID,ADDDATETIME) values('" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "','" + Desc_txtbox.Text + "','" + gUsername + "',getdate())"
                gconnection.dataOperation(1, gSQLString)
                'operationLog(TRANSNO, "Insert")


                clearoperation()
            ElseIf Mid(BTN_SAVE.Text, 1, 1) = "U" Then
                gSQLString = "SELECT count(*)as count FROM  PARTY_PREMIUMDATE_MASTER WHERE DESCRIPTION='" + Desc_txtbox.Text + "'"
                gconnection.getDataSet(gSQLString, "ss")
                If gdataset.Tables("ss").Rows.Count > 0 Then
                    If gdataset.Tables("ss").Rows(0).Item("count") = 0 Then
                        MsgBox("Record Not Found!")
                        clearoperation()
                        Exit Sub
                    End If

                End If

                gSQLString = "SELECT count(*)as count FROM  PARTY_PREMIUMDATE_MASTER WHERE DESCRIPTION NOT IN ('" + Desc_txtbox.Text + "') AND PREMIUM_DATE='" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "'"
                gconnection.getDataSet(gSQLString, "ss")
                If gdataset.Tables("ss").Rows.Count > 0 Then
                    If gdataset.Tables("ss").Rows(0).Item("count") > 0 Then
                        MsgBox("Duplicate Entry is not allowed!")
                        clearoperation()
                        Exit Sub
                    End If

                End If

                gSQLString = "UPDATE PARTY_PREMIUMDATE_MASTER SET PREMIUM_DATE  ='" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "',DESCRIPTION ='" + Desc_txtbox.Text + "',UPDATEUSERID='" + gUsername + "',UPDATEDATETIME=GETDATE() WHERE DESCRIPTION='" + Desc_txtbox.Text + "'"
                gconnection.dataOperation(1, gSQLString)
                'operationLog(TRANSNO, "Update")


                clearoperation()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
    Private Sub FreezeOperation()
        Try

        Catch ex As Exception

        End Try
        checkValidation()
        If boolchk = False Then
            Exit Sub
        End If
        If Mid(BTN_FREEZE.Text, 1, 1) = "F" Then
            gSQLString = "SELECT count(*)as count FROM  PARTY_PREMIUMDATE_MASTER WHERE DESCRIPTION='" + Desc_txtbox.Text + "'"
            gconnection.getDataSet(gSQLString, "ss")
            If gdataset.Tables("ss").Rows.Count > 0 Then
                If gdataset.Tables("ss").Rows(0).Item("count") = 0 Then
                    MsgBox("Record Not Found!")
                    clearoperation()
                    Exit Sub
                End If

            End If
            gSQLString = "UPDATE PARTY_PREMIUMDATE_MASTER SET VOID='Y' ,VOIDUSERID='" + gUsername + "',VOIDDATETIME=GETDATE() WHERE DESCRIPTION='" + Desc_txtbox.Text + "'"
            gconnection.dataOperation(1, gSQLString)
            'operationLog(TRANSNO, "Freeze")

            clearoperation()
        ElseIf Mid(BTN_FREEZE.Text, 1, 1) = "U" Then
            gSQLString = "SELECT count(*)as count FROM  PARTY_PREMIUMDATE_MASTER WHERE DESCRIPTION='" + Desc_txtbox.Text + "'"
            gconnection.getDataSet(gSQLString, "ss")
            If gdataset.Tables("ss").Rows.Count > 0 Then
                If gdataset.Tables("ss").Rows(0).Item("count") = 0 Then
                    MsgBox("Record Not Found!")
                    clearoperation()
                    Exit Sub
                End If

            End If

            gSQLString = "UPDATE PARTY_PREMIUMDATE_MASTER SET VOID='N' ,VOIDUSERID='" + gUsername + "',VOIDDATETIME=GETDATE() WHERE DESCRIPTION='" + Desc_txtbox.Text + "'"
            gconnection.dataOperation(1, gSQLString)
            ' operationLog(TRANSNO, "Unfreeze")

            clearoperation()
        End If
    End Sub
    'Private Sub operationLog(ByVal code As String, ByVal transtype As String)
    '    If transtype = "Insert" Then
    '        gSQLString = "INSERT INTO PARTY_PREMIUMDATE_MASTER_LOG (PREMIUM_DATE,DESCRIPTION,ADDUSERID,ADDDATETIME) values('" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "','" + Desc_txtbox.Text + "','" + gUsername + "',getdate())"
    '        gconnection.dataOperation_LO(1, gSQLString)
    '    ElseIf transtype = "Update" Then

    '        gSQLString = "INSERT INTO PARTY_PREMIUMDATE_MASTER_LOG (PREMIUM_DATE,DESCRIPTION,UPDATEUSERID, UPDATEDATETIME) values('" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "','" + Desc_txtbox.Text + "','" + gUsername + "',getdate())"
    '        gconnection.dataOperation_LOG(1, gSQLString)
    '    ElseIf transtype = "Freeze" Then

    '        gSQLString = "INSERT INTO PARTY_PREMIUMDATE_MASTER_LOG (PREMIUM_DATE,DESCRIPTION,VOID,VOIDUSERID,VOIDDATETIME) values('" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "','" + Desc_txtbox.Text + "','Y','" + gUsername + "',getdate())"

    '        gconnection.dataOperation_LOG(1, gSQLString)
    '    ElseIf transtype = "Unfreeze" Then
    '        gSQLString = "INSERT INTO PARTY_PREMIUMDATE_MASTER_LOG (PREMIUM_DATE,DESCRIPTION,VOID,VOIDUSERID,VOIDDATETIME) values('" + Format(Premiumdate.Value, "dd/MMM/yyyy") + "','" + Desc_txtbox.Text + "','N','" + gUsername + "',getdate())"

    '        gconnection.dataOperation_LOG(1, gSQLString)

    '    End If

    'End Sub



    Private Sub common_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.BackgroundImageLayout = ImageLayout.Stretch
        'rs.FindAllControls(Me)
        'Me.resizeFormResolution()

        'rs.ResizeAllControls(Me)
        'Me.WindowState = FormWindowState.Maximized

        Premiumdate.MinDate = DateTime.Now


        Me.DoubleBuffered = True
        Label_Freeze.Visible = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'Desc_txtbox.Text = GenerateCode()
        'Desc_txtbox.ReadOnly = True
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PURCHASE ORDER' AND MODULENAME LIKE 'Po Indent%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.BTN_SAVE.Enabled = False
        Me.BTN_FREEZE.Enabled = False
        'Me.cmd_View.Enabled = False
        'Me.cmd_Print.Enabled = False
        'Me.cmd_export.Enabled = False

        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.BTN_SAVE.Enabled = True
                    Me.BTN_FREEZE.Enabled = True

                    Exit Sub
                End If
                If UCase(Mid(Me.BTN_SAVE.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.BTN_SAVE.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.BTN_SAVE.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.BTN_SAVE.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.BTN_SAVE.Enabled = True
                    'Me.cmd_rpt.Enabled = True
                    'Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then

                End If
                If Right(x) = "P" Then
                    'Me.cmd_Print.Enabled = True
                End If
            Next
        End If


    End Sub

    Private Sub Cmd_CodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_CodeHelp.Click
        clearoperation()
        Dim vform As New LIST_OPERATION1
        gSQLString = ""
        gSQLString = "SELECT DESCRIPTION, PREMIUM_DATE ,ISNULL(VOID,'') VOID FROM PARTY_PREMIUMDATE_MASTER"
        If Trim(search) = " " Then
            M_WhereCondition = ""
        End If
        vform.Field = "DESCRIPTION, PREMIUM_DATE,VOID"
        ' vform.vFormatstring = "  MCODE    |   MNAME                    "
        vform.vCaption = "PREMIUMDATE MASTER HELP"
        '  vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Desc_txtbox.Text = Trim(vform.keyfield & "")
            Premiumdate.MinDate = Trim(CDate(vform.keyfield1) & "")
            Premiumdate.Value = Trim(vform.keyfield1 & "")

            If Trim(vform.keyfield2 & "") = "Y" Then
                Label_Freeze.Visible = True
                Label_Freeze.Text = "Freezed Record"
                Label_Freeze.BackColor = Color.Red
                BTN_SAVE.Enabled = False
                BTN_FREEZE.Text = "UnFreeze"
            Else
                BTN_SAVE.Text = "Update"
                Label_Freeze.Visible = False

            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub BTN_SAVE_Click(sender As Object, e As EventArgs) Handles BTN_SAVE.Click
        SaveOperation()
    End Sub

    Private Sub BTN_FREEZE_Click(sender As Object, e As EventArgs) Handles BTN_FREEZE.Click
        FreezeOperation()
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        clearoperation()
    End Sub

    Private Sub BTN_EXIT_Click(sender As Object, e As EventArgs) Handles BTN_EXIT.Click
        Me.Close()
    End Sub

    Private Sub TXT_NAME_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Desc_txtbox.Text = "" Then
                Cmd_CodeHelp_Click(sender, e)
                BTN_SAVE.Focus()
            Else
                Desc_txtbox.Focus()

            End If
        End If
    End Sub

    Private Sub Booking_Source_Master_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown


        If e.KeyCode = Keys.F6 Then
            Me.BTN_CLEAR_Click(sender, e)
        End If
        If e.KeyCode = Keys.F7 Then
            If Me.BTN_SAVE.Enabled = True Then
                Me.BTN_SAVE_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.F8 Then
            If Me.BTN_FREEZE.Enabled = True Then
                Me.BTN_FREEZE_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Me.BTN_EXIT_Click(sender, e)
        End If


    End Sub

    Private Sub Desc_txtbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Desc_txtbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Desc_txtbox.Text = "" Then
                Cmd_CodeHelp_Click(sender, e)


            End If
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            If Desc_txtbox.Text = "" Then

            Else
                BTN_SAVE.Focus()

            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class