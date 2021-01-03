using IQSoft.eCommerce.Entities.Core;
using SendGrid;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using SendGrid.Helpers.Mail;

namespace IQSoft.eCommerce.Utilities.Communication
{
    public static class EmailTemplates
    {
        public static void SendForgotPasswordEmail(string toEmailAddress, string userName, string temporaryPassword)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "IQSoft.eCommerce.Utilities.Templates.ForgotPassword.html";
                var template = default(string);

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }

                template = template.Replace(@"[TempPassword]", temporaryPassword);

                using (MailMessage message = new MailMessage())
                using (SmtpClient smtp = new SmtpClient(ConfigSettings.Instance.SmtpSettings.Host, ConfigSettings.Instance.SmtpSettings.PortNo))
                {
                    message.From = new MailAddress(ConfigSettings.Instance.SmtpSettings.FromEmail);
                    message.To.Add(new MailAddress(toEmailAddress));
                    message.Subject = "Forgot Password - V1 Solutions";
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body = template;

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(ConfigSettings.Instance.SmtpSettings.FromEmail, ConfigSettings.Instance.SmtpSettings.Password);
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        public static Response SendEmail(string fromEmailAddress, string subject, string toEmailAddress, string htmlContent)
        {            
            var apiKey = @"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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmailAddress);            
            var to = new EmailAddress(toEmailAddress);
            var plainTextContent = "";            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg).Result;
            return response;
        }
    }
}
