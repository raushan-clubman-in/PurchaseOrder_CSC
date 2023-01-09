Public Class UserAuthorization
    Dim gconnection As New GlobalClass
    Dim emailvalid As New gb
    Dim sqlstring As String
    Dim gset As DataRowCollection
    Private Sub UserAuthorization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''  addorderno()
        load_desig()
        load_grid()
    End Sub
    Private Sub checkalpha(sender As Object, e As KeyPressEventArgs)
        If AscW(e.KeyChar) > 64 And AscW(e.KeyChar) < 91 Or AscW(e.KeyChar) > 96 And AscW(e.KeyChar) < 123 Or AscW(e.KeyChar) = 8 Or AscW(e.KeyChar) = 32 Then
        Else
            e.KeyChar = Nothing
        End If
    End Sub
    Private Sub checknumeric(sender As Object, e As KeyPressEventArgs)
        If ((e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub
    Private Sub load_desig()
        Dim i As Integer
        Try
            sqlstring = "select name from Designation"
            gconnection.getDataSet(sqlstring, "Designation")
            gset = gdataset.Tables("Designation").Rows
            If gset.Count > 0 Then
                combo_desig.Items.Clear()
                For i = 0 To gset.Count - 1
                    combo_desig.Items.Add(gset(i).Item("name"))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
 

    Private Sub txt_limit_TextChanged(sender As Object, e As EventArgs) Handles txt_limit.TextChanged
        ''If txt_limit.Text <> "" And txt_store.Text <> "" Then
        ''    validatestoreorder()
        ''End If
    End Sub
    Private Function Help(qry As String, wherecon As String, field As String, caption As String, sender As Object) As String
        Dim vform As New List_Operation
        Dim res As String = ""
        gSQLString = qry
        M_WhereCondition = wherecon

        vform.Field = field
        vform.vCaption = caption
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            'clearoperation()
            res = Trim(vform.keyfield & "")
        End If
        Return res
        vform.Close()
        vform = Nothing
    End Function

    Private Sub help_userid_Click(sender As Object, e As EventArgs) Handles help_userid.Click
        Dim qry, wherecon, field, caption As String
        Try

            qry = "select distinct(USERNAME) as UserId from useradmin where category='S' union all select distinct(USERNAME) as UserId from useradmin    "
            ''   qry = "select distinct(username) as Userid from useradmin where "
            'wherecon = " Where isnull(void,'')<>'Y' and isnull(active,'Y')='Y' "
            wherecon = "WHERE MainGroup='Purchase Order'"
            field = "username"
            caption = "UserId HELP"
            clearoperation()
            txt_userid.Text = Help(qry, wherecon, field, caption, sender)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Private Sub clearoperation()
        For Each ctrl As Object In Panel1.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = ""
            End If
            If TypeOf ctrl Is ComboBox Then
                ctrl.Text = ""
            End If
        Next
        '' combo_order.SelectedIndex = 0
        combo_status.SelectedIndex = 0
        combo_service.Text = ""
        txt_username.ReadOnly = False
        Label8.Visible = True
        txt_store.Visible = True
        load_desig()
        btn_save.Text = "Save"
        lbl_fromdate.Visible = False
        lbl_todate.Visible = False
        dtp_fromdate.Visible = False
        dtp_todate.Visible = False
        load_desig()
        load_grid()
        '' combo_order.Enabled = False
    End Sub

    Private Sub txt_userid_TextChanged(sender As Object, e As EventArgs) Handles txt_userid.TextChanged
        If sender.Text <> "" Then
            load_userDet(sender.Text)
        End If
    End Sub
    Private Sub reloadorder()
        Dim i As Integer
        combo_order.Items.Clear()
        For i = 1 To 4
            combo_order.Items.Add(i)
        Next
    End Sub
    
    Private Sub load_userDet(txt As String)
        Dim fgd As DataRowCollection
        Try
            sqlstring = "select * from indent_auth_list where userid='" & txt & "' order by orderno"
            ''sqlstring = "if exists(select * from indent_auth_list where UserId='" & txt & "') select distinct(userid),userpassword,username,mobile,email,store,Designation,limit,orderno,status,'yes' exist,fromdate,todate,fromdate,todate,typeofservice from indent_auth_list where UserId='" & txt & "' else select top 1 userpassword,'' as username,phoneno as mobile,emailid as email,'' store,'' Designation,'' limit,'' orderno,'' status,'no' exist,'' typeofservice from master..useradmin where username='" & txt & "'"
            gconnection.getDataSet(sqlstring, "loaduser")
            fgd = gdataset.Tables("loaduser").Rows
            If fgd.Count > 0 Then
                reloadorder()
                ''If fgd(0).Item("userpassword") <> "" Then ' userpassword 
                ''    txt_password.Text = fgd(0).Item("userpassword")
                ''End If
                If fgd(0).Item("username") <> "" Then '  username
                    txt_username.Text = fgd(0).Item("username")
                    txt_username.ReadOnly = True
                End If
                If Not IsDBNull(fgd(0).Item("mobile")) Then '  mobile
                    txt_mobileno.Text = fgd(0).Item("mobile")
                End If
                If Not IsDBNull(fgd(0).Item("email")) Then '  mobile
                    txt_email.Text = fgd(0).Item("email")
                End If
                If fgd(0).Item("Designation") <> "" Then '  Designation
                    combo_desig.Text = fgd(0).Item("Designation").ToString()
                End If
                If fgd(0).Item("store") <> "" Then '  store
                    txt_store.Text = fgd(0).Item("store")
                End If
                If fgd(0).Item("limit").ToString() <> "" Then '  limit
                    txt_limit.Text = fgd(0).Item("limit")
                End If
                If fgd(0).Item("orderno").ToString() <> "" Then '  orderno

                    txt_orderno.Text = fgd(0).Item("orderno")
                End If
                If fgd(0).Item("Typeofservice").ToString() <> "" Then '  typeofservice
                    combo_service.Text = fgd(0).Item("Typeofservice")
                End If
                If fgd(0).Item("status") <> "" Then '  status
                    combo_status.Text = fgd(0).Item("status")
                    If LCase(fgd(0).Item("status")) = "outofoffice" Then
                        If Not IsNothing(fgd(0).Item("fromdate")) Then '  fromdate
                            dtp_fromdate.Value = Format(CDate(fgd(0).Item("fromdate")), "dd/MM/yyyy")
                        End If
                        If Not IsNothing(fgd(0).Item("todate")) Then '  todate
                            dtp_todate.Value = Format(CDate(fgd(0).Item("todate")), "dd/MM/yyyy")
                        End If
                    ElseIf LCase(fgd(0).Item("status")) = "inactive" Then
                        If Not IsNothing(fgd(0).Item("fromdate")) Then '  fromdate
                            dtp_fromdate.Value = Format(CDate(fgd(0).Item("fromdate")), "dd/MM/yyyy")
                        End If
                    End If
                End If

                btn_save.Text = "Update"
          
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub help_store_Click(sender As Object, e As EventArgs) Handles help_store.Click
        Dim qry, wherecon, field, caption As String
        Try
            qry = "Select distinct(storecode),storedesc from StoreMaster "
            wherecon = " where isnull(Freeze,'N') <> 'Y'"
            field = "storecode,storedesc"
            caption = "Store HELP "

            txt_store.Text = Help(qry, wherecon, field, caption, sender)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        clearoperation()
    End Sub
    Public Function ValidateEmail(strCheck As String) As Boolean
        Try
            Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function validatestoreorder() As Boolean
        Try
            sqlstring = "select count(userid) as cnt from indent_auth_list where store='" & txt_store.Text & "' and cast(Limit as varchar(30))=cast('" & txt_limit.Text & "' as numeric(18,2))"
            gconnection.getDataSet(sqlstring, "validatestoreorder")
            If gdataset.Tables("validatestoreorder").Rows.Count > 0 Then
                If gdataset.Tables("validatestoreorder").Rows(0).Item("cnt") = 0 Then
                    combo_order.SelectedIndex = 0
                    combo_order.Enabled = False
                Else
                    combo_order.Enabled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
            Return False
        End Try
    End Function

    Private Sub txt_store_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_store.KeyDown
        If (e.KeyCode = Keys.Enter) Then

        End If
    End Sub
    Private Sub txt_store_TextChanged(sender As Object, e As EventArgs) Handles txt_store.TextChanged
        If txt_limit.Text <> "" And txt_store.Text <> "" Then
            validatestoreorder()
        End If
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        saveoperation()
    End Sub
    Private Sub saveoperation()
        Dim insert(0), fd, td As String
        Dim ORDERNO As Integer
        Try
            If checkvalidation() = True Then
                If LCase(combo_status.Text) = "outofoffice" Then
                    fd = dtp_fromdate.Value.ToString("dd/MMM/yyyy")
                    td = dtp_todate.Value.ToString("dd/MMM/yyyy")
                ElseIf LCase(combo_status.Text) = "inactive" Then
                    fd = dtp_fromdate.Value.ToString("dd/MMM/yyyy")
                    td = ""
                Else
                    fd = ""
                    td = ""
                End If

                If (LCase(btn_save.Text) = "save") Then
                    sqlstring = " SELECT ORDERNO AS ORDERNO FROM indent_auth_list WHERE STORE='" & txt_store.Text & "' AND LIMIT='" & txt_limit.Text & "' and Designation='" & combo_desig.Text & "'"
                    gconnection.getDataSet(sqlstring, "INDENTORDERNO")
                    If (gdataset.Tables("INDENTORDERNO").Rows.Count > 0) Then
                        ORDERNO = Integer.Parse(gdataset.Tables("INDENTORDERNO").Rows(0).Item("ORDERNO")) + 1
                    Else
                        ORDERNO = 1
                    End If
                    sqlstring = "insert into indent_auth_list(UserId,UserName,Mobile,Email,Store,Designation,Limit,OrderNo,Status,FromDate,ToDate,Typeofservice,AddUserId,AddDateTime) values('" & txt_userid.Text & "','" & txt_username.Text & "','" & txt_mobileno.Text & "','" & txt_email.Text & "','" & txt_store.Text & "','" & combo_desig.Text & "','" & txt_limit.Text & "','" & ORDERNO & "','" & combo_status.Text & "','" & fd & "','" & td & "','" & combo_service.Text & "','" & gUsername & "',getdate())"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                ElseIf (LCase(btn_save.Text) = "update") Then
                    sqlstring = " SELECT MAX(ORDERNO) AS ORDERNO FROM indent_auth_list WHERE STORE='" & txt_store.Text & "' AND LIMIT='" & txt_limit.Text & "' and orderno='" & txt_orderno.Text & "'"
                    gconnection.getDataSet(sqlstring, "INDENTORDERNO1")
                    If (gdataset.Tables("INDENTORDERNO1").Rows.Count > 0) Then
                        sqlstring = "update indent_auth_list set orderno='100' FROM indent_auth_list WHERE STORE='" & txt_store.Text & "' AND LIMIT='" & txt_limit.Text & "' and Designation='" & combo_desig.Text & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                        '' gconnection.dataOperation(5, sqlstring, "indent_auth_list")
                    End If

                    sqlstring = "update indent_auth_list set UserName='" & txt_username.Text & "',Mobile=" & txt_mobileno.Text & ",Email='" & txt_email.Text & "',Store='" & txt_store.Text & "',Designation='" & combo_desig.Text & "',Limit=" & txt_limit.Text & ",OrderNo=" & txt_orderno.Text & ",Status='" & combo_status.Text & "',FromDate='" & fd & "',ToDate='" & td & "',Typeofservice='" & combo_service.Text & "',UpdateDateTime=getdate(),UpdateUserId='" & gUsername & "' where UserId='" & txt_userid.Text & "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                    sqlstring = " SELECT ORDERNO AS ORDERNO FROM indent_auth_list WHERE STORE='" & txt_store.Text & "' AND LIMIT='" & txt_limit.Text & "' and Designation='" & combo_desig.Text & "'"
                    gconnection.getDataSet(sqlstring, "INDENTORDERNO")
                    If (gdataset.Tables("INDENTORDERNO").Rows.Count > 0) Then
                        ORDERNO = Integer.Parse(gdataset.Tables("INDENTORDERNO").Rows(0).Item("ORDERNO")) + 1
                    Else
                        ORDERNO = 1
                    End If
                    sqlstring = "update indent_auth_list set orderno='" & ORDERNO & "' FROM indent_auth_list WHERE STORE='" & txt_store.Text & "' AND LIMIT='" & txt_limit.Text & "' and orderno='100'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                End If
                sqlstring = "insert into indent_auth_list_Log(UserId,UserPassword,UserName,Mobile,Email,Store,Designation,Limit,OrderNo,Status,FromDate,ToDate,typeofservice,AddUserId,AddDateTime,UpdateUserId,UpdateDateTime) select UserId,UserPassword,UserName,Mobile,Email,Store,Designation,Limit,OrderNo,Status,FromDate,ToDate,typeofservice,AddUserId,AddDateTime,UpdateUserId,UpdateDateTime from indent_auth_list where UserId='" & txt_userid.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                gconnection.MoreTrans(insert)
                'clearoperation()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        clearoperation()
    End Sub
    Private Function checkvalidation() As Boolean
        If IsNothing(txt_userid.Text) Then
            MsgBox("User id cannot be blank !!!")
            txt_userid.Focus()
            Return False
        End If
        If IsNothing(txt_username.Text) Then
            MsgBox("User Name Cannot be Blank")
            txt_username.Focus()
            Return False
        End If
        If IsNothing(txt_password.Text) Then
            MsgBox("Password Cannot be Blank")
            txt_password.Focus()
            Return False
        End If
        If IsNothing(txt_mobileno.Text) Then
            MsgBox("mobile number Cannot be Blank")
            txt_mobileno.Focus()
            Return False
        End If
        If gconnection.IsPhoneNumberValid(txt_mobileno.Text) = False Then
            MsgBox("Pls Enter Valid Mobile Number")
            txt_mobileno.Focus()
            Return False
        End If
       
        If IsNothing(txt_email.Text) Then
            MsgBox("Mail id Cannot be Blank")
            txt_email.Focus()
            Return False
        End If
        If emailvalid.isValid(txt_email.Text) = False Then
            Return False
        End If
        If IsNothing(combo_desig.Text) Then
            MsgBox("Designation Cannot be Blank")
            combo_desig.Focus()
            Return False
        End If
        If IsNothing(combo_service.Text) Then
            MsgBox("Type of service Cannot be Blank")
            combo_desig.Focus()
            Return False
        End If
        If combo_desig.Text <> "GM" Or combo_desig.Text <> "Secretary" Or combo_desig.Text <> "Asst.Secretary" Or combo_desig.Text <> "Treasurer" Or combo_desig.Text <> "President" Then
            If IsNothing(txt_store.Text) Then
                MsgBox("Store Cannot be Blank")
                txt_store.Focus()
                Return False
            End If
            If IsNothing(txt_limit.Text) Then
                MsgBox("Limit Cannot be Blank")
                txt_limit.Focus()
                Return False
            End If
            If IsNothing(combo_order.Text) Then
                MsgBox("Order Cannot be Blank")
                combo_order.Focus()
                Return False
            End If
        End If
        If IsNothing(combo_status.Text) Then
            MsgBox("Status Cannot be Blank")
            combo_status.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub combo_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_status.SelectedIndexChanged
        If LCase(combo_status.Text) = "outofoffice" Then
            lbl_fromdate.Visible = True
            lbl_todate.Visible = True
            dtp_fromdate.Visible = True
            dtp_todate.Visible = True
        ElseIf LCase(combo_status.Text) = "inactive" Then
            lbl_fromdate.Visible = True
            lbl_todate.Visible = False
            dtp_fromdate.Visible = True
            dtp_todate.Visible = False
        Else
            lbl_fromdate.Visible = False
            lbl_todate.Visible = False
            dtp_fromdate.Visible = False
            dtp_todate.Visible = False
        End If
    End Sub
    Private Sub load_grid()
        Dim Sql As String
        Try
            Sql = "select UserId,Typeofservice,UserName,Mobile,Email,Store,Designation,Limit,OrderNo,Status,FromDate,ToDate from indent_auth_list"

            gconnection.getDataSet(Sql, "funDet")

            grid_details.DataSource = Nothing
            If gdataset.Tables("funDet").Rows.Count > 0 Then
                grid_details.DataSource = gdataset.Tables("funDet")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Private Sub txt_username_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_username.KeyPress
        checkalpha(sender, e)
    End Sub

    Private Sub txt_mobileno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_mobileno.KeyPress
        checknumeric(sender, e)
    End Sub
    Private Sub combo_desig_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combo_desig.KeyPress
        checkalpha(sender, e)
    End Sub

    Private Sub txt_limit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_limit.KeyPress
        checknumeric(sender, e)
    End Sub

    Private Sub txt_email_LostFocus(sender As Object, e As EventArgs) Handles txt_email.LostFocus
        If sender.Text <> "" Then
            If ValidateEmail(sender.Text) = False Then
                MsgBox("Please Enter valid Mail id")
                txt_email.Text = ""
                txt_email.Focus()
            End If
        End If
    End Sub

    Private Sub combo_desig_TextChanged(sender As Object, e As EventArgs) Handles combo_desig.TextChanged

        Dim i As Integer
        Dim IDTYPE As String
        Try
            sqlstring = "select NAME from Designation WHERE NAME='" & combo_desig.Text & "'"
            gconnection.getDataSet(sqlstring, "Designation")
            If (gdataset.Tables("Designation").Rows.Count > 0) Then
                ''IDTYPE = gdataset.Tables("Designation").Rows(0).Item("NAME")
                ''If (IDTYPE = "PREDEFINED") Then
                Label8.Visible = False
                txt_store.Text = ""
                txt_store.Visible = False
            Else
                Label8.Visible = True
                txt_store.Visible = True
            End If



            ''Else
            ''Label8.Visible = True
            ''txt_store.Visible = True
            ''End If


        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        ''If combo_desig.Text <> "" Then
        ''    Label8.Visible = True
        ''    txt_store.Visible = True
        ''    ''  enabletextbox()
        ''    ''  checksamedesig()
        ''End If
    End Sub
    Private Sub checksamedesig()
        Dim drc As DataRowCollection
        Dim Sql As String
        Try
            If txt_userid.Text <> "" And combo_desig.Text <> "" Then
                Sql = "select * from indent_auth_list where userid='" & txt_userid.Text & "' and designation='" & combo_desig.Text & "'"
                gconnection.getDataSet(Sql, "checksamedesig")

                If gdataset.Tables("checksamedesig").Rows.Count = 0 Then
                    txt_store.Text = ""
                    combo_order.SelectedIndex = 0
                    txt_limit.Text = ""
                    combo_status.SelectedIndex = 0
                    dtp_fromdate.Value = Date.Now
                    dtp_todate.Value = Date.Now
                    btn_save.Text = "Save"
                    enabletextbox()
                Else
                    drc = gdataset.Tables("checksamedesig").Rows
                    loaddetbydesig(drc)
                End If
                validateorder()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Private Sub grid_details_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_details.CellDoubleClick
        '' load_userDet(grid_details.Item(0, grid_details.CurrentRow.Index).Value.ToString())
        Call LOADUSERDET()

    End Sub
    Public Sub LOADUSERDET()
        txt_userid.Text = grid_details.Item(0, grid_details.CurrentRow.Index).Value.ToString()
        combo_service.Text = grid_details.Item(1, grid_details.CurrentRow.Index).Value.ToString()

        txt_username.Text = grid_details.Item(2, grid_details.CurrentRow.Index).Value.ToString()
        txt_mobileno.Text = grid_details.Item(3, grid_details.CurrentRow.Index).Value.ToString()
        txt_store.Text = grid_details.Item(5, grid_details.CurrentRow.Index).Value.ToString()
        txt_email.Text = grid_details.Item(4, grid_details.CurrentRow.Index).Value.ToString()
        combo_desig.Text = grid_details.Item(6, grid_details.CurrentRow.Index).Value.ToString()
        txt_limit.Text = grid_details.Item(7, grid_details.CurrentRow.Index).Value.ToString()
        txt_orderno.Text = grid_details.Item(8, grid_details.CurrentRow.Index).Value.ToString()
    End Sub

    Public Sub enabletextbox()
        If combo_desig.Text = "GM" Or combo_desig.Text = "Secretary" Or combo_desig.Text = "Asst.Secretary" Or combo_desig.Text = "Treasurer" Or combo_desig.Text = "President" Then
            txt_store.Enabled = False
            txt_limit.Enabled = False
            combo_order.Enabled = False
            help_store.Enabled = False
        Else
            txt_store.Enabled = True
            txt_limit.Enabled = True
            combo_order.Enabled = True
            help_store.Enabled = True
        End If
    End Sub
    Private Sub loaddetbydesig(drc As DataRowCollection)
        Try
            If drc(0).Item("store") <> "" Then '  store
                txt_store.Text = drc(0).Item("store")
            End If
            If drc(0).Item("limit").ToString() <> "" Then '  limit
                txt_limit.Text = drc(0).Item("limit")
            End If
            If drc(0).Item("orderno").ToString() <> "" Then '  orderno
                combo_order.Text = drc(0).Item("orderno")
            End If
            If drc(0).Item("typeofservice").ToString() <> "" Then '  typeofservice
                combo_service.Text = drc(0).Item("typeofservice")
            End If
            If drc(0).Item("status") <> "" Then '  status
                combo_status.Text = drc(0).Item("status")
                If LCase(drc(0).Item("status")) = "outofoffice" Then
                    If Not IsNothing(drc(0).Item("fromdate")) Then '  fromdate
                        dtp_fromdate.Value = Format(CDate(drc(0).Item("fromdate")), "dd/MM/yyyy")
                    End If
                    If Not IsNothing(drc(0).Item("todate")) Then '  todate
                        dtp_todate.Value = Format(CDate(drc(0).Item("todate")), "dd/MM/yyyy")
                    End If
                ElseIf LCase(drc(0).Item("status")) = "inactive" Then
                    If Not IsNothing(drc(0).Item("fromdate")) Then '  fromdate
                        dtp_fromdate.Value = Format(CDate(drc(0).Item("fromdate")), "dd/MM/yyyy")
                    End If
                End If
            End If
            btn_save.Text = "Update"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub validateorder()
        Dim i, ind As Integer
        Dim ordervalue As String
        Try
            sqlstring = "select * from indent_auth_list where  designation='" & combo_desig.Text & "'"
            gconnection.getDataSet(sqlstring, "validateorder")
            If gdataset.Tables("validateorder").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("validateorder").Rows.Count - 1
                    ordervalue = gdataset.Tables("validateorder").Rows(i).Item("OrderNo").ToString()
                    If combo_order.Items.Contains(Convert.ToInt32(ordervalue)) = True Then
                        ind = combo_order.Items.IndexOf(Convert.ToInt32(ordervalue))
                        combo_order.Items.RemoveAt(ind)
                    End If
                Next
            Else
                combo_order.Items.Clear()
                For i = 1 To 4
                    combo_order.Items.Add(i)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub addorderno()
        Dim i As Integer
        combo_order.Items.Clear()
        For i = 1 To 4
            combo_order.Items.Add(i)
        Next
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub combo_service_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_service.SelectedIndexChanged
        Dim IDTYPE As String
        If (combo_service.Text = "PO") Then
            Label8.Visible = False
            txt_store.Visible = False
        ElseIf (combo_service.Text = "Indent") Then
            If (combo_desig.Text <> "") Then
                Try
                    sqlstring = "select NAME from Designation WHERE NAME='" & combo_desig.Text & "'"
                    gconnection.getDataSet(sqlstring, "Designation")
                    If (gdataset.Tables("Designation").Rows.Count > 0) Then
                        '' IDTYPE = gdataset.Tables("Designation").Rows(0).Item("NAME").ToString
                        '' If (IDTYPE = "PREDEFINED") Then
                        Label8.Visible = False
                        txt_store.Text = ""
                        txt_store.Visible = False
                    Else
                        Label8.Visible = True
                        txt_store.Visible = True

                    End If
                    ''Else
                    ''Label8.Visible = True
                    ''txt_store.Visible = True
                    ''End If


                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            End If
           
            ''Label8.Visible = True
            ''txt_store.Visible = True
        End If
        If (LCase(btn_save.Text) = "update") Then
            sqlstring = "SELECT ORDERNO FROM indent_auth_list WHERE LIMIT='" & txt_limit.Text & "' and Designation='" & combo_desig.Text & "' AND Typeofservice='" & combo_service.Text & "'"
            gconnection.getDataSet(sqlstring, "indent_auth_list")
            If (gdataset.Tables("indent_auth_list").Rows.Count > 0) Then
                btn_save.Text = "Update"
            Else
                btn_save.Text = "Save"
            End If
        End If
    End Sub

    Private Sub combo_desig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_desig.SelectedIndexChanged
        Dim i As Integer
        Dim IDTYPE, SQLSTRING As String
        Try
            SQLSTRING = "select NAME from Designation WHERE NAME='" & combo_desig.Text & "'"
            gconnection.getDataSet(SQLSTRING, "Designation")
            If (gdataset.Tables("Designation").Rows.Count > 0) Then
                ''IDTYPE = gdataset.Tables("Designation").Rows(0).Item("NAME").ToString
                ''If (IDTYPE = "PREDEFINED") Then
                Label8.Visible = False
                txt_store.Text = ""
                txt_store.Visible = False
            Else
                Label8.Visible = True
                txt_store.Visible = True

            End If
            ''Else
            ''Label8.Visible = True
            ''txt_store.Visible = True
            ''End If
          
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub grid_details_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_details.CellContentClick

    End Sub
End Class