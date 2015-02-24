using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAmNotified.ClientSDK.Configuration;
using IAmNotified.ClientSDK.Notification;
using Microsoft.Win32.SafeHandles;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace IAmNotified.ClientSDK
{
    public class MessageBroker : IMessageBroker
    {
        private readonly IQueueService _queueService;

        private static ISettings _settings;
        public static ISettings Settings
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

        public MessageBroker(IQueueService queueService)
        {
            _queueService = queueService;
        }

        /// <summary>
        /// Send all notifications present in _queueService
        /// </summary>
        public void SendNotifications()
        {
            foreach (KeyValuePair<string, List<NotificationBase>> notification in _queueService.Notifications)
            {
                var queueName = notification.Key;
                var notifications = notification.Value;

                notifications.ForEach(i=> SendNotification(queueName, i));
            }
        }

        /// <summary>
        /// Send a single notification
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="notification"></param>
        public static void SendNotification(string queueName, INotification notification)
        {
            var props = new BasicProperties();
            if (notification.ExpirationTime.HasValue)
            {
                props.Expiration = notification.ExpirationTime.Value.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
            }

            var factory = new ConnectionFactory() { HostName = Settings.RabbitmqServer };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, true, null);
                    var body = Encoding.UTF8.GetBytes(notification.Message);

                    channel.BasicPublish("", queueName, props, body);
                }
            }
        }
    }
}
