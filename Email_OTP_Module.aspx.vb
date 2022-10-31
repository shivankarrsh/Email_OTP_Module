
Imports System.Net.Mail
Public Class _Default
    Inherits Page
    Dim OTP As String
    Dim count As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            btn_Search.Visible = False
            count = Session("count") 'For storing the count to check 10 counts
        Else
            Session("count") = 0 'For new session to start from zero
        End If
    End Sub
    Protected Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        lblErr.Text = ""
        If txtemail.Text = "" Then
            lblErr.Text = "Please enter EmailId"
        Else
            If txtemail.Text.Contains("@dso.org.sg") Then
                GenerateOTP()  ' generate OTP only when then sender is from dso.org.sg
                lblOTP.Visible = True
                txtOTP.Visible = True
                btn_confirmOtp.Visible = True
            Else
                lblErr.Text = " You have entered wrong Email Address"
                btn_Search.Visible = True

            End If
        End If
    End Sub
    Private Function GenerateOTP()
        Dim rand = New Random() ' for generating a random 6 digit for OTP
        OTP = rand.Next(100000, 999999).ToString
        Session("OTP") = OTP
        sendEmail()
    End Function
    Private Function sendEmail()
        Try
            Dim message As New System.Net.Mail.MailMessage()
            Dim senders As New MailAddress("abc@test.com")
            Dim smtpServer As New SmtpClient("smtp.freesmtpservers.com", 25) 'using a free server to check for email
            Dim ToAddr As String = txtemail.Text
            message.To.Add(ToAddr)
            message.From = senders
            message.IsBodyHtml = True
            message.Subject = "Emai Verification OTP code  "
            Dim mailBody As String = String.Empty
            mailBody &= "Hi ,                                           <br/>"
            mailBody &= "                                                   <br/>"
            mailBody &= "Your OTP code is : " & OTP & "                           <br/>"
            mailBody &= "Your OTP is Valid for 1 min only .                     <br/>"
            message.Body = (mailBody)
            smtpServer.Send(message)

        Catch ex As Exception
            Throw ex
        End Try
        Session("TIME") = System.DateTime.Now()

    End Function
    Protected Sub btn_confirmOtp_Click(sender As Object, e As EventArgs) Handles btn_confirmOtp.Click
        Dim currentdate As DateTime = DateTime.Now()
        Dim lasttime As DateTime = Session("TIME")
        Dim elasp = currentdate - lasttime

        If elasp.TotalSeconds > 60 Then
            lblErr.Text = "TIME OUT"
            txtOTP.Visible = False
        Else
            If txtOTP.Text = Session("OTP") Then
                lblErr.Text = "OTP is valid and checked"
            Else
                lblErr.Text = "Try Again"
                count += 1
                Session("count") = count
                If count = 10 Then
                    lblErr.Text = "OTP is wrong after 10 tries"
                    btn_confirmOtp.Visible = False
                    Exit Sub
                End If
            End If
        End If

    End Sub
End Class