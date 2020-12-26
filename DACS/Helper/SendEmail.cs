using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DACS.Helper
{
    public static class SendMail
    {
        public static string EmailUser;
        public static string EmailPassword;
        public static string EmailName;
        public static string EmailSMTP = "smtp.gmail.com";
        public static string EmailSMTPPort = "578";

        public static void Send(string toEmail, string subject, string body)
        {
            if (String.IsNullOrEmpty(EmailUser) || String.IsNullOrEmpty(EmailPassword) || String.IsNullOrEmpty(EmailSMTP) || String.IsNullOrEmpty(EmailSMTPPort)) throw new Exception("Kỹ thuật viên chưa truyền dữ liệu email");
            //bool IsSendMail = SendMailTest();
            var smtp = new SmtpClient
            {
                Host = EmailSMTP,
                Port = int.Parse(EmailSMTPPort),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailUser, EmailPassword)
            };

            // add from,to mailaddresses
            MailAddress from = new MailAddress(EmailUser, EmailName);
            MailAddress to = new MailAddress(toEmail);
            MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

            // set subject and encoding
            myMail.Subject = subject;
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;
            // set body-message and encoding
            myMail.Body = body;
            myMail.BodyEncoding = System.Text.Encoding.UTF8;

            // text or html
            myMail.IsBodyHtml = true;

            smtp.Send(myMail);
        }
        //public static bool SendMailTest()
        //{
        //    MailMessage mail = new MailMessage();
        //    MailAddress fromAddress = new MailAddress("royaldragonit@gmail.com");
        //    MailAddress toAddress = null;
        //    mail.From = fromAddress;
        //    toAddress = new MailAddress(EmailUser, EmailName);
        //    mail.Subject = "Chúc Mừng Bạn Đã Tạo Tài Khoản Thành Công";
        //    mail.Body = "<h3 style='color:red'>THÔNG TIN TÀI KHOẢN</h3><b style='color:blue;width:80px'>Tài Khoản: </b><b style='color:green;'>" + user + "</b><br/><b style='width:80px;color:blue;'>Mật Khẩu: </b><b style='color:green;'>" + password + "</b><br/><b style='color:blue;width:80px'>Email: </b><b style='color:green;'>" + email + "</b><br/><b style='color:blue;width:80px'>Số Điện Thoại: </b><b style='color:green;'>" + phone + "</b><br/><b style='width:80px;color:blue;'>Thời Gian Đăng Ký: </b><b style='color:green;'>" + DateTime.Now + "</b><br/>";
        //    mail.To.Add(toAddress);
        //    mail.IsBodyHtml = true;
        //    SmtpClient smtpClient = new SmtpClient();
        //    smtpClient.Host = "smtp.gmail.com";
        //    smtpClient.Port = 587;
        //    smtpClient.EnableSsl = true; 
        //    smtpClient.Credentials = new NetworkCredential(EmailUser, EmailPassword);
        //    smtpClient.Send(mail);
        //    return true;
        //}
    }
}