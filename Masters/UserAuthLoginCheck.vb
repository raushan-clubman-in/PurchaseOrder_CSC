Public Class UserAuthLoginCheck
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            If LCase(gUserCategory) = "s" Then
                If txt_password.Text <> "" Then
                    sqlstring = "select count(USERNAME) as cnt from master..useradmin where USERNAME='" & gUsername & "' and USERPASSWORD='" & abcdADD(txt_password.Text) & "'and category='S'"
                    gconnection.getDataSet(sqlstring, "loaduser")
                    If gdataset.Tables("loaduser").Rows.Count > 0 Then
                        If gdataset.Tables("loaduser").Rows(0).Item("cnt") = 0 Then
                            MsgBox("Entered Password is wrong. Please enter correct password")
                            Me.Close()
                        Else
                            Me.Close()
                            GmoduleName = "User Authorization"
                            Dim ua As New UserAuthorization
                            ua.MdiParent = MDIParentobj
                            ua.Show()
                        End If
                    End If
                Else
                    MsgBox("Password Field cannot be blank")
                End If
            Else
                MsgBox("You are not Authorized to access this form")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class