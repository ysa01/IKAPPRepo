using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace IKAPP.Admin.Models
{
    public class EmployeeMailVM
    {
        public string ToMail { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public EmployeeMailVM(string _tomail,string _subject,string _body)
        {
            this.ToMail = _tomail;
            this.Subject = _subject;
            this.Body = _body;
        }



        public void SendMail()
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("turan@codintri.com", "360sistem Firması")
            };
            mail.IsBodyHtml = true;
            mail.To.Add(this.ToMail);
            mail.Subject = this.Subject;
            mail.Body = this.Body;

            SmtpClient client = new SmtpClient()
            {
                Port = 587,
                Host = "mail.codintri.com",
                EnableSsl = true
            };
            client.Credentials = new System.Net.NetworkCredential("turan@codintri.com", "tVAeZ2ff6#7n");
            client.Send(mail);

        }

    }
}