using System;
using System.Text;
using IAmNotified.ClientSDK.Configuration;
using RabbitMQ.Client;

namespace IAmNotified.ClientSDK
{
    public class QueueHelper : IQueueHelper
    {
        private readonly string _queueName;

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

        public QueueHelper(string queueName)
        {
            _queueName = queueName;
        }

        public void Push(string message)
        {
            var factory = new ConnectionFactory() { HostName = Settings.RabbitmqServer };
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
}