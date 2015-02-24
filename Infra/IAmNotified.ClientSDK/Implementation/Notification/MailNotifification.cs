using System.Collections.Generic;
using System.Threading;
using IAmNotified.ClientSDK.Configuration;
using IAmNotified.Common.Serialize;
using IAmNotified.Schema;

namespace IAmNotified.ClientSDK.Notification
{
    // wat zou je willen sturen?
    // 1 mail
    // mail naar alle afzenders als bcc
    public class MailNotifification : NotificationBase
    {
        private readonly MailSchema _mailSchema;

        private string _message;
        public override string Message
        {
            get
            {
                if (_message == null)
                {
                    _message = Json.Serialize(_mailSchema);
                }
                return _message;
            }
        }
        private readonly ISettings _settings;

        public override string QueueName
        {
            get { return _settings.MailQueue; }
        }

        
        public MailNotifification(MailSchema mailSchema)
            : this(Configuration.Settings.Instance, mailSchema)
        {
        }

        public MailNotifification(ISettings settings, MailSchema mailSchema)
        {
            _mailSchema = mailSchema;
            _settings = settings;
        }

        public MailNotifification(string subject, string content, string to)
            : this( new MailSchema
                    {
                        Content = content
                        , Subject = subject
                        , Tomail = new List<string> { to }
                    })
        {

        }
    }
}
