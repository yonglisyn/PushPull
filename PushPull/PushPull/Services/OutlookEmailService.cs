using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PushPull.Services
{
    public class OutlookEmailService : IIdentityMessageService
    {
        private readonly SmtpClient _OutlookSmtpClient =new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };
        private const string _PushpullRegisterOutlookCom = "pushpull.register@outlook.com";
        private const string _SentFrom = "pushpull.register@outlook.com";
        private const string _Password = "Pu$hPuLL@8.10";

        public Task SendAsync(IdentityMessage message)
        {
            var credentials =
                new NetworkCredential(_PushpullRegisterOutlookCom, _Password);
            _OutlookSmtpClient.EnableSsl = true;
            _OutlookSmtpClient.Credentials = credentials;
            var mail =
                new MailMessage(_SentFrom, message.Destination) 
                {Subject = message.Subject, Body = message.Body};
            return _OutlookSmtpClient.SendMailAsync(mail);
        }
    }
}