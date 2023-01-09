Imports x = Microsoft.Office.Interop.Excel
Imports System.Linq
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Net
Imports System.Web.HttpApplication
Imports System.ApplicationIdentity

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Web.HttpApplication


Public Class AUTHORISATION
    Dim DETAIL As Boolean
    Dim VCONN As New GlobalClass
    Dim SSQL, KEYFIELD As String
    Dim frmt As Form
    Dim COLUMNSEQ, finallevel As Integer
    Dim PONOD As String
    Dim LD As Boolean
    Dim DataGridViewCheckBoxColumn, strSqlString As String
    Dim ctrlname1 As Integer
    Dim gconnection As New GlobalClass
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim dgData As DataGridView = DirectCast(DTAUTH, DataGridView)
        With SaveExcelFileDialog
            .Filter = "Excel|*.xlsx"
            .Title = "Save griddata in Excel"
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Dim o As New ExcelExporter
                Dim b = exportnew(dgData, .FileName)
                MsgBox("EXPORT COMPLETED SUCCESSFULY")
            End If
            .Dispose()
        End With
    End Sub
    Private Function exportnew(ByRef dgv As DataGridView, ByVal Path As String) As Boolean
        Dim i, j As Integer
        Dim default_location As String = Path & ".xls"
        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i = 0 To dgv.ColumnCount - 1
            dset.Tables(0).Columns.Add(dgv.Columns(i).HeaderText)
        Next
        'add rows to the table
        Dim dr1 As DataRow
        For i = 0 To dgv.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j = 0 To dgv.Columns.Count - 1
                dr1(j) = dgv.Rows(i).Cells(j).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        Dim xp As New x.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        xp.Visible = True
        xp.UserControl = True

        wBook = xp.Workbooks.Add(System.Reflection.Missing.Value)
        wSheet = wBook.Sheets("sheet1")
        xp.Range("A50:I50").EntireColumn.AutoFit()
        With wBook
            .Sheets("Sheet1").Select()
            .Sheets(1).Name = "NameYourSheet"
        End With

        Dim dt As System.Data.DataTable = dset.Tables(0)
        wSheet.Cells(1).value = Path
        ' Dim i As Integer
        Dim s As String
        Dim colcount = 0
        Dim ColNames As Generic.List(Of String) = (From col As DataGridViewColumn _
                                           In dgv.Columns.Cast(Of DataGridViewColumn)() _
                                           Where (col.Visible = True) _
                                           Order By col.DisplayIndex _
                                           Select col.Name).ToList
        For Each s In ColNames
            colcount += 1
            wSheet.Cells(1, colcount) = dgv.Columns.Item(s).HeaderText
        Next
        For i = 0 To dgv.RowCount - 2
            For j = 0 To dgv.ColumnCount - 2
                If IsDBNull(dgv.Rows(i).Cells(j).Value) = False Or dgv.Rows(i).Cells(j).Value.ToString() <> Nothing Then
                    wSheet.Cells(i + 2, j + 1).value = dgv.Rows(i).Cells(j).Value.ToString()
                Else
                    wSheet.Cells(i + 2, j + 1).value = ""
                End If

            Next j
        Next i

        wSheet.Columns.AutoFit()
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(default_location)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(default_location) Then
            System.IO.File.Delete(default_location)
        End If

        wBook.SaveAs(default_location)
        xp.Workbooks.Open(default_location)
        xp.Visible = True
    End Function

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim dt As DataTable
        Dim message1, sql5 As String
        Dim T1, T2, T3, T4, T5, T6 As String
        Dim i, J As Integer
        Dim EMAIL, MMOBILE, MOBILE, sqlstring, sqlstring1, datefrom, MCODE As String
        Dim OUTSTANDING As Double
        Dim MODULENAME, yearname, deptcode, deptname, indentno, username, orderno, hours, userid, PHNO, MESSAGE As String
        Dim insert(0) As String
        J = DTAUTH.Columns.Count - 1
        For i = 0 To DTAUTH.Rows.Count - 1
            If DTAUTH.Rows(i).Cells(12).Value = True Then
                strSqlString = SSQL & " "
                If KEYFIELD = "PONO" Then
                    strSqlString = strSqlString & " AUTHORISE_USER1 ='" & gUsername & "',AUTHORISE_DATE1 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(1).Value.ToString() & "' "

                Else

                    strSqlString = strSqlString & " AUTHORISE_USER1 ='" & gUsername & "',AUTHORISE_DATE1 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'AND ITEMCODE='" & DTAUTH.Rows(i).Cells(6).Value.ToString() & "'"
                End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSqlString
                If finallevel = ctrlname1 Then
                    If KEYFIELD = "PONO" Then
                        strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(1).Value.ToString() & "' "

                    Else
                        strSqlString = SSQL & " AUTHORISED='Y' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'AND ITEMCODE='" & DTAUTH.Rows(i).Cells(6).Value.ToString() & "'"
                    End If
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = strSqlString
                End If
            Else
                MsgBox("Please Select Atleast One item from Grid")
                Exit Sub

                strSqlString = SSQL & " "
                If KEYFIELD = "PONO" Then
                    strSqlString = strSqlString & " AUTHORISE_USER1 ='" & gUsername & "',AUTHORISE_DATE1 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(1).Value.ToString() & "' "

                Else

                    strSqlString = strSqlString & " AUTHORISE_USER1 ='" & gUsername & "',AUTHORISE_DATE1 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'AND ITEMCODE='" & DTAUTH.Rows(i).Cells(6).Value.ToString() & "'"
                End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSqlString
                If finallevel = ctrlname1 Then
                    If KEYFIELD = "PONO" Then
                        strSqlString = SSQL & " AUTHORISED='N' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(1).Value.ToString() & "' "

                    Else
                        strSqlString = SSQL & " AUTHORISED='N' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'AND ITEMCODE='" & DTAUTH.Rows(i).Cells(6).Value.ToString() & "'"
                    End If
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = strSqlString
                End If
            End If
        Next
        gconnection.MoreTrans(insert)
        Dim indno1 As New ArrayList
        Dim k As Integer
        For k = 0 To DTAUTH.RowCount - 1

          
            If indno1.Contains(DTAUTH.Rows(k).Cells(1).Value.ToString()) Then
            Else
                indno1.Add(DTAUTH.Rows(k).Cells(1).Value.ToString())
            End If
        Next



        For i = 0 To indno1.Count - 1

            strSqlString = " SELECT DISTINCT DOCNO FROM PO_STOCKINDENTAUTH_DET WHERE ISNULL(AUTHORISED,'')='Y' and docno='" + indno1(i) + "' "
            gconnection.getDataSet(strSqlString, "AUTHORIZEL")
            indentno = indno1(i)
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then

                strSqlString = " select * from INDENT_AUTH_LIST WHERE TYPEOFSERVICE='ISSUE' "
                gconnection.getDataSet(strSqlString, "EMAILSETUP")
                If gdataset.Tables("EMAILSETUP").Rows.Count > 0 Then
                    PHNO = gdataset.Tables("EMAILSETUP").Rows(0).Item("MOBILE")
                    username = gdataset.Tables("EMAILSETUP").Rows(0).Item("USERNAME")
                    deptname = gdataset.Tables("EMAILSETUP").Rows(0).Item("STORE")

                    T1 = "Dear Mr./Miss." & username & " "
                    T2 = "Indent is authorised ,Your Immediate attension is required for acting on indent no : " & indentno & " "
                    T3 = "For Details Please check report of peding indent from inventory module"
                    T4 = "Warm Regards "
                    T5 = "Admin"
                    T6 = "United club."
                    message1 = T1 & vbCr + T2 & vbCr + T3 & vbCr + T4 & vbCr + T5 & vbCr + T6
                    SENDSMSFORAUTHORIZATION(PHNO, message1, indentno, username, "Indent")
                End If
            End If


        Next




        Call Button3_Click(sender, e)



    End Sub
    Private Sub SENDSMSFORAUTHORIZATION(ByVal phno As String, ByVal message As String, ByVal DOCNO As String, ByVal USERNAME As String, ByVal doctype As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String
        'message = message.Replace("<br>"
        Dim reader As StreamReader
        url = "http://bulksms.impactgroup.in/sendurlcomma.aspx?user=20078511&pwd=kaushal2501p&senderid=UNITED&mobileno=" & phno & "&msgtext=" & message & "&smstype=0"

        request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())
        gSQLString = "insert into  User_sms_log (doctype,docno,username,mobile,message) select  '" + doctype + "','" + DOCNO + "','" + USERNAME + "','" + phno + "','" + message + "' "
        gconnection.dataOperation(6, gSQLString, "maillog1")

    End Sub


    Private Sub AUTHORISATION_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub LOADGRID(ByVal DC As DataTable, ByVal DET As Boolean, ByVal FORMNM As Form, ByVal SQL As String, ByVal KEYFILD As String, ByVal auth As Integer, ByVal LEVEL As Integer, ByVal COLUMSEQ As Integer)
        LD = False
        DETAIL = DET
        SSQL = SQL
        KEYFIELD = KEYFILD
        COLUMNSEQ = COLUMSEQ
        frmt = FORMNM
        finallevel = auth
        ctrlname1 = LEVEL
        DTAUTH.DataSource = DC
        Dim CHECKCOL As New DataGridViewCheckBoxColumn
        CHECKCOL.HeaderText = "SELECT"
        DTAUTH.Columns.Add(CHECKCOL)
    End Sub

    Private Sub DTAUTH_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DTAUTH.CellContentClick

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Dim I As Integer
            For I = 0 To DTAUTH.Rows.Count - 1
                DTAUTH.Rows(I).Cells(12).Value = True

            Next
        Else
            Dim I As Integer
            For I = 0 To DTAUTH.Rows.Count - 1
                DTAUTH.Rows(I).Cells(12).Value = False
            Next

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i, J As Integer
        Dim insert(0) As String

        If MessageBox.Show("Do You Want To Reject All ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then



            J = DTAUTH.Columns.Count - 1

            strSqlString = SSQL & " "

            strSqlString = strSqlString & " AUTHORISE_USER1 ='" & gUsername & "',AUTHORISE_DATE1 =getdate() where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = strSqlString
            If finallevel = ctrlname1 Then
                strSqlString = SSQL & " AUTHORISED='N' where " & KEYFIELD & " ='" & DTAUTH.Rows(i).Cells(COLUMNSEQ).Value.ToString() & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSqlString
            End If

            gconnection.MoreTrans(insert)
            Call Button3_Click(sender, e)
        Else
            Call Button3_Click(sender, e)
        End If
    End Sub
End Class