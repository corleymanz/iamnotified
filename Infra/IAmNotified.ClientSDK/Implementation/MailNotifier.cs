using System;
using System.Collections.Generic;
using System.Text;
using Common.Implementation.Serialize;
using IAmNotified.Schema;
using RabbitMQ.Client;

namespace IAmNotified.ClientSDK
{
    // wat zou je willen sturen?
    // 1 mail
    // mail naar alle afzenders als bcc
    public class MailNotifier
    {
        private const String QueueName = "MailQueue";

        private IQueueHelper _queueHelper;
        public IQueueHelper QueueHelper
        {
            get
            {
                if (_queueHelper == null)
                {
                    _queueHelper = new QueueHelper(QueueName);
                    
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
        }

        public void Push(MailSchema mailschema)
        {
            string message = Json.Serialize(mailschema);

            QueueHelper.Push(message);
        }
    }

    public class SmsNotifier
    {
        private const String QueueName = "SMSQueue";

        private IQueueHelper _queueHelper;
        public IQueueHelper QueueHelper
        {
            get
            {
                if (_queueHelper == null)
                {
                    _queueHelper = new QueueHelper(QueueName);
                }
                return _queueHelper;
            }
        }

        public void Push()
        {

        }
    }

    public class QueueHelper : IQueueHelper
    {
        private readonly string _queueName;

        public QueueHelper(string queueName)
        {
            _queueName = queueName;
        }

        public void Push(string message)
        {
            var rabbitmqHost = "localhost";

            var factory = new ConnectionFactory() { HostName = rabbitmqHost };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(_queueName, false, false, false, null);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", _queueName, null, body);
                }
            }
        }
    }

    public interface IQueueHelper
    {
        void Push(string message);
    }
}
