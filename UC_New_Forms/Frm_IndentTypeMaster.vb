Public Class Frm_IndentTypeMaster

    Dim gconnection As New GlobalClass
    Dim SQLSTRING As String
    Dim insert(0) As String
    Dim I, J, K As Integer
    Dim DTL As DataTable

    Private Sub Frm_IndentTypeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCategorydetails()
        bindUSERlist()
    End Sub


    Private Sub FillCategorydetails()
        Dim i As Integer
        Dim sqlstring As String
        chk_cat.Items.Clear()
        sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select CATEGORYCODE from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    chk_cat.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))) & " --> " & Trim(CStr(.Item("CATEGORYDESC"))))
                End With
            Next
            chk_cat.Sorted = True
        End If
    End Sub

    Private Sub bindUSERlist()
        chk_user.Items.Clear()

        Dim sqlstring = "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where Maingroup='Inventory'"
        sqlstring = sqlstring & "    union "
        sqlstring = sqlstring & "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where category='S'"

        gconnection.getDataSet(sqlstring, "UserAdmin")
        If (gdataset.Tables("UserAdmin").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("UserAdmin").Rows.Count - 1
                chk_user.Items.Add(gdataset.Tables("UserAdmin").Rows(i).Item("USERNAME"))
            Next
        End If
        chk_user.Sorted = True
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

        Try

            SQLSTRING = Nothing

            Dim CATEGORY() As String

            If Mid(UCase(btn_add.Text), 1, 1) = "A" Then


                SQLSTRING = "INSERT INTO PO_INDENTTYPE (CODE,NAME,ADDDATE,ADDUSER )"
                SQLSTRING = SQLSTRING & " VALUES ('" & Trim(TXT_INDENTCODE.Text) & "','" & Trim(TXT_INDENTNAME.Text) & "',GETDATE(),'" & gUsername & "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING


                For I = 0 To chk_cat.CheckedItems.Count - 1
                    CATEGORY = Split(chk_cat.CheckedItems(I), " --> ")
                    SQLSTRING = "INSERT INTO PO_INDENTTYPE_CAT (CODE,NAME,CATEGORY,ADDDATE,ADDUSER )"
                    SQLSTRING = SQLSTRING & " VALUES ('" & Trim(TXT_INDENTCODE.Text) & "','" & Trim(TXT_INDENTNAME.Text) & "','" & CATEGORY(0) & "',GETDATE(),'" & gUsername & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQLSTRING
                Next

                For I = 0 To chk_user.CheckedItems.Count - 1

                    SQLSTRING = "INSERT INTO PO_INDENTTYPE_USER (CODE,NAME,USERNAME,ADDDATE,ADDUSER )"
                    SQLSTRING = SQLSTRING & " VALUES ('" & Trim(TXT_INDENTCODE.Text) & "','" & Trim(TXT_INDENTNAME.Text) & "','" & chk_user.CheckedItems(I) & "',GETDATE(),'" & gUsername & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQLSTRING
                Next

                gconnection.MoreTrans(insert)
                BTN_CLEAR_Click(sender, e)
            Else

                SQLSTRING = "UPDATE PO_INDENTTYPE SET NAME='" & Trim(TXT_INDENTNAME.Text) & "',UPDATEDATE=GETDATE(),UPDATEUSER='" & gUsername & "' WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING

                SQLSTRING = "DELETE FROM PO_INDENTTYPE_CAT WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING

                SQLSTRING = "DELETE FROM PO_INDENTTYPE_USER WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING

                For I = 0 To chk_cat.CheckedItems.Count - 1
                    CATEGORY = Split(chk_cat.CheckedItems(I), " --> ")
                    SQLSTRING = "INSERT INTO PO_INDENTTYPE_CAT (CODE,NAME,CATEGORY,ADDDATE,ADDUSER )"
                    SQLSTRING = SQLSTRING & " VALUES ('" & Trim(TXT_INDENTCODE.Text) & "','" & Trim(TXT_INDENTNAME.Text) & "','" & CATEGORY(0) & "',GETDATE(),'" & gUsername & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQLSTRING
                Next

                For I = 0 To chk_user.CheckedItems.Count - 1

                    SQLSTRING = "INSERT INTO PO_INDENTTYPE_USER (CODE,NAME,USERNAME,ADDDATE,ADDUSER )"
                    SQLSTRING = SQLSTRING & " VALUES ('" & Trim(TXT_INDENTCODE.Text) & "','" & Trim(TXT_INDENTNAME.Text) & "','" & chk_user.CheckedItems(I) & "',GETDATE(),'" & gUsername & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQLSTRING
                Next

                gconnection.MoreTrans(insert)
                BTN_CLEAR_Click(sender, e)

            End If

            Array.Clear(insert, 0, insert.Length)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTN_VOID_Click(sender As Object, e As EventArgs) Handles BTN_VOID.Click
        Try

            SQLSTRING = "SELECT CODE FROM PO_INDENTTYPE WHERE VOID='N' AND CODE='" & TXT_INDENTCODE.Text & "'"
            DTL = gconnection.GetValues(SQLSTRING)
            If DTL.Rows.Count > 0 Then
                SQLSTRING = "UPDATE PO_INDENTTYPE SET UPDATEDATE=GETDATE(),UPDATEUSER='" & gUsername & "',VOID='Y' WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING
                SQLSTRING = "UPDATE PO_INDENTTYPE_CAT SET  VOID='Y' WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING
                SQLSTRING = "UPDATE PO_INDENTTYPE_USER SET  VOID='Y' WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQLSTRING
                gconnection.MoreTrans(insert)
                BTN_CLEAR_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

     
    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        TXT_INDENTCODE.Text = ""
        TXT_INDENTCODE.ReadOnly = False
        TXT_INDENTNAME.Text = ""
        FillCategorydetails()
        bindUSERlist()
        btn_add.Text = "ADD"
    End Sub

    Private Sub btn_hlp_Click(sender As Object, e As EventArgs) Handles btn_hlp.Click
        Try
            gSQLString = ""
            gSQLString = "SELECT ISNULL(CODE,'') AS INDENTTYPECODE,ISNULL(NAME,'') AS  TYPENAME,VOID FROM  PO_INDENTTYPE"
            M_WhereCondition = ""
            M_ORDERBY = " Order by CODE,NAME "
            Dim vform As New ListOperattion1
            vform.Field = "CODE,NAME"
            vform.vFormatstring = "     INDENT TYPE CODE                      |                    INDENT NAME           |    VOID                 "
            vform.vCaption = "INDENT TYPE MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_INDENTCODE.Text = Trim(vform.keyfield & "")

                Call TXT_INDENTCODE_Validated(TXT_INDENTCODE.Text, e)
                btn_add.Text = "UPDATE"
            End If
            vform.Close()
            vform = Nothing
            M_ORDERBY = ""
        Catch ex As Exception
            MsgBox(Err.Description & Err.Source & "Err in Operation", MsgBoxStyle.Information, "Customer Code Help Click")
        End Try
    End Sub

    Private Sub TXT_INDENTCODE_Validated(sender As Object, e As EventArgs) Handles TXT_INDENTCODE.Validated
        Dim CAT, CH_CAT(), USER, CH_USER() As String
        Try
            SQLSTRING = "SELECT * FROM PO_INDENTTYPE WHERE CODE='" & Trim(TXT_INDENTCODE.Text) & "'"
            DTL = gconnection.GetValues(SQLSTRING)
            If DTL.Rows.Count > 0 Then
                TXT_INDENTNAME.Text = DTL.Rows(0).Item("NAME").ToString
                If DTL.Rows(0).Item("void").ToString = "Y" Then
                    btn_add.Enabled = False
                    BTN_VOID.Enabled = False
                Else
                    btn_add.Enabled = True
                    BTN_VOID.Enabled = True
                End If
                SQLSTRING = "SELECT * FROM PO_INDENTTYPE_CAT WHERE CODE='" & Trim(TXT_INDENTCODE.Text) & "'"
                DTL = gconnection.GetValues(SQLSTRING)
                If DTL.Rows.Count > 0 Then
                    For I = 0 To DTL.Rows.Count - 1
                        CAT = Trim(DTL.Rows(I).Item("CATEGORY").ToString)
                        For J = 0 To chk_cat.Items.Count - 1
                            CH_CAT = Split(chk_cat.Items(J).ToString(), " --> ")
                            If CH_CAT(0) = CAT Then
                                chk_cat.SetItemCheckState(J, CheckState.Checked)
                                Exit For
                            End If
                        Next
                    Next
                End If
                SQLSTRING = "SELECT * FROM PO_INDENTTYPE_USER WHERE CODE='" & Trim(TXT_INDENTCODE.Text) & "'"
                DTL = gconnection.GetValues(SQLSTRING)
                If DTL.Rows.Count > 0 Then
                    For I = 0 To DTL.Rows.Count - 1
                        USER = Trim(DTL.Rows(I).Item("USERNAME").ToString)
                        For J = 0 To chk_user.Items.Count - 1

                            If Trim(DTL.Rows(I).Item("USERNAME").ToString) = USER Then
                                chk_user.SetItemCheckState(J, CheckState.Checked)
                                Exit For
                            End If
                        Next
                    Next
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXT_INDENTCODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_INDENTCODE.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(TXT_INDENTCODE.Text) <> "" Then
                    SQLSTRING = "SELECT ISNULL(CODE,'') AS TYPECODE FROM PO_INDENTTYPE WHERE CODE='" & TXT_INDENTCODE.Text & "'"
                    gconnection.getDataSet(SQLSTRING, "INVENTORYCATEGORYMASTER")
                    If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
                        TXT_INDENTCODE_Validated(sender, e)
                    Else
                        TXT_INDENTNAME.Focus()
                    End If
                Else
                    TXT_INDENTCODE.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXT_INDENTCODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_INDENTCODE.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TXT_INDENTCODE_Validated(sender, e)
        End If
    End Sub

    Private Sub chk_all_cat_KeyDown(sender As Object, e As KeyEventArgs) Handles chk_all_cat.KeyDown
        If e.KeyCode = Keys.Enter Then
            chk_cat.Focus()
        End If
    End Sub

    Private Sub chk_all_cat_CheckedChanged(sender As Object, e As EventArgs) Handles chk_all_cat.CheckedChanged
        Dim i As Integer
        If chk_all_cat.Checked = True Then
            For i = 0 To chk_cat.Items.Count - 1
                chk_cat.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chk_cat.Items.Count - 1
                chk_cat.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chk_all_user_CheckedChanged(sender As Object, e As EventArgs) Handles chk_all_user.CheckedChanged
        Dim i As Integer
        If chk_all_user.Checked = True Then
            For i = 0 To chk_user.Items.Count - 1
                chk_user.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chk_user.Items.Count - 1
                chk_user.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chk_all_user_KeyDown(sender As Object, e As KeyEventArgs) Handles chk_all_user.KeyDown
        If e.KeyCode = Keys.Enter Then
            chk_user.Focus()
        End If
    End Sub

    Private Sub BTN_EXIT_Click(sender As Object, e As EventArgs) Handles BTN_EXIT.Click
        Me.Close()
    End Sub
End Class