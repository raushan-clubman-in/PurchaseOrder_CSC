Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports outlook = Microsoft.Office.Interop.Outlook
Imports Org.BouncyCastle.Asn1.Ocsp
Imports Microsoft.Office.Interop
Imports System.Net
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class GlobalClass
    Public sqlconnection, sqlconnection1 As String
    Public Myconn As New SqlConnection
    Dim MyTrans As SqlTransaction
    Dim Cmd As New SqlCommand
    Dim DataString As String
    Dim ssql As String
    Public Enum genum
        Add = 1
        Update = 2
        Freeze = 3
        unFreeze = 4
        View = 5
        Delete = 6
    End Enum
    Public Function closingStock(ByVal trndate As String, ByVal itemcode As String, ByVal storecode As String, ByVal uom1 As String) As DataSet
        Dim sql11 As String = "select TOP 1 ISNULL(AUTOID,0) as AUTOID, ISNULL(closingstock,0) AS closingstock, uom,isnull(closingvalue,0) as closingvalue,isnull(TRNS_SEQ,0) as TRNS_SEQ,isnull(batchyn,'N') as batchyn,isnull(rate,0) as rate from closingqty where itemcode='" + itemcode + "' and storecode='" + storecode + "' and cast(convert(varchar(11),trndate,106)as datetime)<= '" + trndate + "' order by TRNS_SEQ desc"
        getDataSet(sql11, "closingStock")

    End Function
    Public Function ClosingQuantityCSC(ByVal ITEMCODE As String, ByVal STORECODE As String) As Double
        Dim AdjustQty, ClsQty, MainstockQty, TransQty, TransFromQty, TransToQty As Double
        Dim OpQty, GrnQty, IssueQty, ReturnQty, ReturnFromQty, ReturnToQty, IssueToQty, IssueFromQty, ConsumedQty As Double
        Dim sqlstring As String
        Dim i As Integer
        sqlstring = "SELECT ISNULL(OPSTOCK,0) * ISNULL(CONVVALUE,0) AS OPSTOCK1,ISNULL(OPSTOCK,0) AS OPSTOCK FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & Trim(STORECODE) & "'"
        getDataSet(sqlstring, "INVENTORYITEM")
        If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
            OpQty = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
        Else
            OpQty = 0
        End If
        sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,(ISNULL(SUM(QTY),0)) AS QTY  FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'  AND STORECODE='" & Trim(STORECODE) & "'"
        getDataSet(sqlstring, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
            GrnQty = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            GrnQty = 0
        End If
        MainstockQty = GrnQty + OpQty
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKISSUEDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y'"
        getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            IssueFromQty = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("QTY")), "0.000")
        Else
            IssueFromQty = 0
        End If

        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKISSUEDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND OPSTORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y'"
        getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            IssueToQty = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("QTY")), "0.000")
        Else
            IssueToQty = 0
        End If
        IssueQty = IssueToQty - IssueFromQty

        ''''********************************* FROM STOCKADJUSTMENT ***************************************'''
        sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY FROM STOCKADJUSTDETAILS "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y'"
        getDataSet(sqlstring, "STOCKADJUSTDETAILS")
        If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
            AdjustQty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            AdjustQty = 0
        End If
        '''********************************* FROM STOCK TRANSFER *****************************************'''
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND FROMSTORECODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        getDataSet(sqlstring, "STOCKTRANSDETAILS")
        If gdataset.Tables("STOCKTRANSDETAILS").Rows.Count > 0 Then
            TransFromQty = Format(Val(gdataset.Tables("STOCKTRANSDETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            TransFromQty = 0
        End If
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM STOCKTRANSFERDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND TOSTORECODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        getDataSet(sqlstring, "STOCKTRANSDETAILS1")
        If gdataset.Tables("STOCKTRANSDETAILS1").Rows.Count > 0 Then
            TransToQty = Format(Val(gdataset.Tables("STOCKTRANSDETAILS1").Rows(0).Item("QTY")), "0.000")
        Else
            TransToQty = 0
        End If
        TransQty = TransToQty - TransFromQty
        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM SUBSTORECONSUMPTIONDETAIL "
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        getDataSet(sqlstring, "STORECONSUMPTIONDETAILS")
        If gdataset.Tables("STORECONSUMPTIONDETAILS").Rows.Count > 0 Then
            ConsumedQty = Format(Val(gdataset.Tables("STORECONSUMPTIONDETAILS").Rows(0).Item("QTY")), "0.000")
        Else
            ConsumedQty = 0
        End If
        'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(QTY),0) AS QTY FROM SUBSTORECONSUMPTIONDETAILraw "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y'"
        'getDataSet(sqlstring, "STORECONSUMPTIONDETAILS")
        'If gdataset.Tables("STORECONSUMPTIONDETAILS").Rows.Count > 0 Then
        '    ConsumedQty = ConsumedQty + Format(Val(gdataset.Tables("STORECONSUMPTIONDETAILS").Rows(0).Item("QTY")), "0.000")
        'Else
        '    ConsumedQty = ConsumedQty + 0
        'End If
        ClsQty = (Val(MainstockQty) + Val(AdjustQty)) + Val(IssueQty) + Val(TransQty) - Val(ConsumedQty)

        Return ClsQty
    End Function


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
    Function getvalue(ByVal QryString As String)
        Dim objVariable As Object
        Try
            Myconn.Open()
            Cmd.Connection = Myconn
            Cmd.CommandText = QryString
            Cmd.CommandType = CommandType.Text
            objVariable = Cmd.ExecuteScalar()
            Myconn.Close()
            Return objVariable
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            Myconn.Close()
        End Try
    End Function
    Function getdata(ByVal qry As String, ByVal qrytab As String)
        Dim datatb As New DataSet
        openConnection()
        Dim daa As New SqlDataAdapter(qry, Myconn)
        daa.Fill(datatb, qrytab)
        Myconn.Close()
        Return datatb
    End Function
    Public Function getDataSet(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            openConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 999999999
            gadapter.Fill(dt)
            dt.TableName = Tabname

            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function getCompanyinfo(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable

        Try
            Call GetfrontConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.Fill(dt)
            dt.TableName = Tabname

            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    'Public Function MoreTrans(ByVal str() As String)
    '    Dim i As Integer
    '    Try
    '        'Myconn.Open()
    '        openConnection()
    '        MyTrans = Myconn.BeginTransaction()
    '        Cmd.Transaction = MyTrans
    '        Cmd.Connection = Myconn
    '        For i = 0 To str.Length - 1
    '            If str(i) Is Nothing = False Then
    '                Cmd.CommandText = str(i)
    '                Cmd.CommandType = CommandType.Text
    '                Cmd.ExecuteNonQuery()
    '            End If
    '        Next i
    '        MyTrans.Commit()
    '        MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Myconn.Close()
    '    Catch ex As Exception
    '        MyTrans.Rollback()
    '        Myconn.Close()
    '        MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Function
    '    End Try
    'End Function

    Public Sub dataOperation(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            openConnection()
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
                Case 1
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Sub openConnection()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Else
                sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            End If
            Myconn.ConnectionString = sqlconnection
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Function openConnectionnew(con As SqlConnection) As SqlConnection
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Else
                sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            End If
            con.ConnectionString = sqlconnection
            con.Open()
            Return con
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Public Sub GetfrontConnection()
        Try
            If Trim(gserver & "") <> "" Then

                sqlconnection1 = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= MASTER;"
                'sqlconnection1 = "Data Source=" & gserver & ";Persist Security Info=False;User ID=asca;pwd=asca;Initial Catalog= MASTER;"
            Else
                sqlconnection1 = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= MASTER;"
                'sqlconnection1 = "Data Source= (local);Persist Security Info=False;User ID=asca;pwd=asca;Initial Catalog= MASTER;"
            End If
            Myconn.ConnectionString = sqlconnection1
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub closeConnection()
        Myconn.Close()
    End Sub
    Public Function GetValues(ByVal ssql As String) As DataTable
        Dim Dt As New DataTable
        Dim Sqladapter As New SqlDataAdapter(ssql, Myconn)
        Try
            openConnection()
            Sqladapter.Fill(Dt)
            Return Dt
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function ExcuteStoreProcedure(ByVal qry As String)
        Dim i As Integer
        Myconn.ConnectionString = sqlconnection
        Try
            Myconn.Open()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTransnew(ByVal str() As String) As Boolean
        Dim i As Integer
        Try
            Dim strs As String
            strs = ""
            'Myconn.Open()
            openConnection()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    'Cmd.CommandText = str(i)
                    'Cmd.CommandType = CommandType.Text
                    'Cmd.ExecuteNonQuery()
                    strs = strs & str(i)
                End If
            Next i
            If strs <> "" Then
                Cmd.CommandText = "addtran"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@txt", SqlDbType.Text).Value = strs
                Cmd.ExecuteNonQuery()
            End If
            MyTrans.Commit()
            MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTrans(ByVal str() As String) As Boolean
        Dim i As Integer
        Try
            'Myconn.Open()
            openConnection()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTrans12(ByVal str() As String) As Boolean
        Dim i As Integer
        Try
            'Myconn.Open()
            openConnection()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            'MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Shared Function StripNonAlphaNumeric(value As String) As String
        Dim regex = New Regex("[^0-9a-zA-Z]", RegexOptions.None)
        Dim result As String = ""
        If regex.IsMatch(value) Then
            result = regex.Replace(value, "")
        Else
            result = value
        End If

        Return result
    End Function
    Public Function IsPhoneNumberValid(phoneNumber As String) As Boolean
        Dim result As String = ""
        Dim count As Integer
        Dim chars As Char() = phoneNumber.ToCharArray()
        For count = 0 To chars.GetLength(0) - 1
            Dim tempChar As Char = chars(count)
            If [Char].IsDigit(tempChar) Or "()+-., ".Contains(tempChar.ToString()) Then

                result += StripNonAlphaNumeric(tempChar)
            Else
                Return False
            End If

        Next

        Return result.Length = 10 'Length of US phone numbers is 10
    End Function
    Public Function MoreTrans2(ByVal str() As String) As Boolean
        Dim i As Integer
        Try
            'Myconn.Open()
            openConnection()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            'MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTransallow(ByVal str() As String) As Boolean
        Dim i As Integer
        Try
            Dim stra As String
            stra = ""
            'Myconn.Open()
            openConnection()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    ' Cmd.CommandText = str(i)
                    ' Cmd.CommandType = CommandType.Text
                    ' Cmd.ExecuteNonQuery()
                    stra = stra & str(i)
                End If
            Next i
            If stra <> "" Then
                Cmd.CommandText = "exec addcomma"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Clear()
                ' If Not (Parms Is Nothing) Then
                '  For Each sqlParm As SqlParameter In Parms
                Cmd.Parameters.Add(New SqlParameter("@TEXT", stra))
                '  Next
                'End If
                '  Cmd.Parameters.Add(New SqlParameter("@Value", SqlDbType.VarChar)).Value = stra
                'Cmd.Parameters.AddWithValue("@TEXT", stra)
                Cmd.ExecuteNonQuery()
            End If
            MyTrans.Commit()
            MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTrans1(ByVal str() As String) As Boolean
        Dim i As Integer
        Try
            'Myconn.Open()
            openConnection()
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            ' MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function Getconnection() As String
        Try
            sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Return sqlconnection
        Catch ex As Exception
            'MessageBox.Show("!! Warning !!Your system is not connected with SERVER, Bcoz " & ex.Message.ToString, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    'Public Sub subPrintVoucherHeader(ByVal strCaption As String, ByVal intLength As Int16)
    '    Dim strHead As String
    '    Filewrite.WriteLine(Trim(Mid(gMAINCompanyname, 1, 50)) & Space(intLength - Len(Trim(Mid(gMAINCompanyname, 1, 50)))))
    '    intRowcount = 1
    '    If Trim(gCompanyAddress(0)) <> "" Then
    '        Filewrite.WriteLine(gCompanyAddress(0))
    '    End If
    '    If Trim(gCompanyAddress(1)) <> "" Then
    '        strHead = gCompanyAddress(1)
    '    End If
    '    If Trim(gCompanyAddress(2)) <> "" Then
    '        Filewrite.WriteLine(strHead & "," & Trim(gCompanyAddress(2)))
    '    Else
    '        If Trim(strHead) <> "" Then
    '            Filewrite.WriteLine(gCompanyAddress(1))
    '        End If
    '    End If
    '    If Trim(gCompanyAddress(3)) <> "" Then
    '        Filewrite.WriteLine(gCompanyAddress(3))
    '    End If
    '    Filewrite.WriteLine()
    '    Filewrite.WriteLine(Chr(14) & Chr(15) & strCaption & Chr(18))
    '    vrowcnt = 6
    'End Sub
    Public Sub subPrintVoucherFooter(ByVal intLength As Int16, ByVal INTPAGENO As Integer)
        Dim strFoot As String
        'Filewrite.WriteLine(Space(57) & "  For Secunderabad Club   ")
        Filewrite.WriteLine(Space(8) & "Store keeper" & Space(15) & "Asst. Manager Purchase" & Space(10) & "       Secretary      ")
        'strFoot = "User :- " & gUsername & Space(((intLength / 2) - 5) - Len("USER :- " & gUsername))
        'strFoot = strFoot & Space(intLength - (Len(strFoot) + 22)) & CStr(Format(DateValue(Now()), "dd/MMM/yyyy")) & " " & Trim(Now.ToShortTimeString()) & Chr(12)
        Filewrite.WriteLine()
        Filewrite.WriteLine(strFoot)
        'ssql = Space(38)
        'ssql = ssql & "PAGE NO. : " & INTPAGENO
        'Filewrite.WriteLine(ssql)
    End Sub

    Public Sub dataOperation1(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''

                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub





End Class
