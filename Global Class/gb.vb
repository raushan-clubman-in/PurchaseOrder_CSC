Imports System.Net.Mail



Public Class gb

   
    Public Function isValid(ByVal emailAddress As String,
                                   Optional ByVal disallowLocalDomain As Boolean = True,
                                   Optional ByVal allowAlerts As Boolean = True
                                   ) As Boolean
        Try
            Dim mailParts() As String = emailAddress.Split("@")
            If mailParts.Length <> 2 Then
                If allowAlerts Then
                    MsgBox("Valid email addresses are formatted [sample@domain.tld]. " &
                           "Your address is missing a header [i.e. ""@domain.tld""].",
                           MsgBoxStyle.Exclamation, "No Header Specified")
                End If
                Return False
            End If
            If mailParts(mailParts.GetLowerBound(0)) = "" Then
                If allowAlerts Then
                    MsgBox("Valid email addresses are formatted [sample@domain.tld]. " &
                           "The username portion of the e-mail address you provided (before the @ symbol) is empty.",
                           MsgBoxStyle.Exclamation, "Invalid Email User")
                End If
                Return False
            End If
            Dim headerParts() As String = mailParts(mailParts.GetUpperBound(0)).Split(".")
            If disallowLocalDomain AndAlso headerParts.Length < 2 Then
                If allowAlerts Then
                    MsgBox("Valid email addresses are formatted [sample@domain.tld]. " &
                           "Although addresses formatted like [sample@domain] are valid, " &
                           "only addresses with headers like ""sample.org"", ""sample.com"", and etc. " &
                           "[i.e. @domain.org] are accepted.",
                           MsgBoxStyle.Exclamation, "Invalid Header")
                End If
                Return False
            ElseIf headerParts(headerParts.GetLowerBound(0)) = "" Or
                   headerParts(headerParts.GetUpperBound(0)) = "" Then
                If allowAlerts Then
                    MsgBox("Valid email addresses are formatted [sample@domain.tld]. " &
                           "Your header """ & mailParts(mailParts.GetUpperBound(0)) & """ is invalid.",
                           MsgBoxStyle.Exclamation, "Invalid Header")
                End If
                Return False
            End If
            Dim address As MailAddress = New MailAddress(emailAddress)
        Catch ex As Exception
            If allowAlerts Then
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Invalid Email Address")
            End If
            Return False
        End Try
        Return True
    End Function

End Class
