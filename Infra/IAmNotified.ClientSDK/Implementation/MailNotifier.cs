using System;
using System.Collections.Generic;
using Common.Implementation.Serialize;
using IAmNotified.ClientSDK.Configuration;
using IAmNotified.Schema;

namespace IAmNotified.ClientSDK
{
    // wat zou je willen sturen?
    // 1 mail
    // mail naar alle afzenders als bcc
    public class MailNotifier
    {
        private ISettings _settings;
        public ISettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Configuration.Settings.Instance;
                }
                return _settings;
            }
        }

        private IQueueHelper _queueHelper;
        public IQueueHelper QueueHelper
        {
            get
            {
                if (_queueHelper == null)
                {
                    _queueHelper = new QueueHelper(Settings.MailQueue);
                    
                }
                return _queueHelper;
            }
        }

        public void Push(string subject, string content, string to)
        {
            var mailschema = new MailSchema
            {
                  Content = content
                , Subject = subject
                , Tomail = new List<string>{to}
            };

            Push(mailschema);
        }

        public void Push(MailSchema mailschema)
        {
            string message = Json.Serialize(mailschema);

            QueueHelper.Push(message);
        }
    }
}
