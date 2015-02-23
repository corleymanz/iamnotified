using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using IAmNotified.Common.Log;
using IAmNotified.IAmNotifiedService.Implementation.Configuration;
using IAmNotified.Schema;
using MailPriority = System.Net.Mail.MailPriority;

namespace IAmNotified.IAmNotifiedService.Implementation
{
    public interface IMail
    {
        void SendMail(MailSchema mailSchema);
        void SendMail(string fromMail, string fromname, List<string> toMail, string subject, MailPriority? mailPriority, string bodyMessage, List<string> bcc);
    }

    class Mail : IMail
    {
        private ILogger _log;
        public Mail(ILogger log)
        {
            _log = log;
        }

        public Mail()
            : this(new LoggerFactory().GetLogger())
        {
        }

        public void SendMail(MailSchema mailSchema)
        {
            this.SendMail(
                  mailSchema.FromMail
                , mailSchema.FromName
                , mailSchema.Tomail
                , mailSchema.Subject
                , Map(mailSchema.Priority)
                , mailSchema.Content
                , mailSchema.Bcc);
        }

        public void SendMail(string fromMail, string fromname, List<string> toMail, string subject, MailPriority? priority, string bodyMessage, List<string> bcc = null)
        {
            var setting = Settings.Instance.Mail;
            var fromN = string.IsNullOrWhiteSpace(fromname) ? setting.DefaultFromName : fromname;
            var fromM = string.IsNullOrWhiteSpace(fromMail) ? setting.DefaultFromMail : fromMail;

            // maak smtp server aan
            var client = new SmtpClient(setting.SmtpServer);
            client.Credentials = (setting.SmtpDefaultCredentials) 
                ? CredentialCache.DefaultNetworkCredentials 
                : new NetworkCredential(setting.SmtpServerUser, setting.SmtpServerWw);

            // maak mail message
            using (var message = new MailMessage())
            {
                message.Sender = new MailAddress(fromM, fromN);
                message.From = new MailAddress(fromM, fromN);
                message.Subject = subject;
                message.Body = bodyMessage;
                message.IsBodyHtml = true;
                if (priority != null) message.Priority = priority.Value;
                if (bcc != null)
                {
                    bcc.ForEach(l => message.Bcc.Add(new MailAddress(l)));
                }
                toMail.ForEach(l => message.To.Add(new MailAddress(l)));

                client.Send(message);
            }
        }

        private MailPriority? Map(Schema.MailPriority? priority)
        {
            if (priority == null) return null;

            if (priority == Schema.MailPriority.High) return MailPriority.High;
            if (priority == Schema.MailPriority.Normal) return MailPriority.Normal;
            if (priority == Schema.MailPriority.Low) return MailPriority.Low;

            return MailPriority.Normal;
        }
    }
}