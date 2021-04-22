using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using DemoSendEmails.Interfaces;
using DemoSendEmails.Models;

namespace DemoSendEmails.Services
{
    public class SendEmailService : ISendEmailService
    {
        public SendEmailService()
        {
        }

        public void SendEmail(string to, Email model)
        {
            var from = model.From;
            var host = model.Host;
            var port = model.Port;
            var password = model.Password;
            var enableSsl = model.EnableSSL;
            var subject = model.Subject;
            var body = model.Body;

            MailAddress mailFrom = new MailAddress(from);
            MailAddress mailTo = new MailAddress(to);
            MailMessage message = new MailMessage(mailFrom, mailTo);
            message.Body = body;
            message.IsBodyHtml = true;
            message.Body += Environment.NewLine;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;

            using (var client = new SmtpClient(host, port))
            {
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = enableSsl;

                client.Send(message);
                message.Dispose();
            }
        }
    }
}