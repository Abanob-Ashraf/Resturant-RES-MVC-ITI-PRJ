using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_RES_MVC_ITI_PRJ.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("ZMAN", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            string[] parts = message.To[0].ToString().Split('@');

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h1>Hello, Our dear Customer \n{1}</h1>\r\n  <br/> &nbsp;&nbsp; <a style='background-color:  #FFBC32;\r\n  border-color: #FFBC32;\r\nborder-radius: 3px;\r\nborder-style: solid;\r\ntext-decoration: none; \r\ntext-decoration-line: none;\r\n display: inline-block;\r\n  font-weight: 400;\r\n  line-height: 1.5;\r\n  color: #212529;\r\n  text-align: center;\r\n  text-decoration: none;\r\n  vertical-align: middle;\r\n  cursor: pointer;\r\n  user-select: none;\r\n  padding: 10px;\r\n  font-size: 16px;\r\n  border-radius: 0.25rem;'  href='{0}'>Reset Password</a>       <br /><br /><br/>     <table style=\"border-collapse: collapse;\">\r\n            <tr> \r\n                <td rowspan=\"2\"><img style=\"width: 150px;padding: 10px;text-align: left;\"\r\n                        src='https://user-images.githubusercontent.com/80596461/263403114-9b86e6c9-f144-439f-bcee-c5af2e13d4b0.png' />\r\n                </td>\r\n                <td style=\"font-weight: bold;padding: 10px;text-align: left;\"> Phone: 01099412326</td>\r\n            </tr>\r\n            <tr>\r\n                <td style=\"font-weight: bold;padding: 10px;text-align: left;\"> Email: Zmanrest@gmail.com</td>\r\n            </tr>\r\n        </table>", message.Content, parts[0].Substring(1)) };

            if (message.Attachments != null && message.Attachments.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
