using System;
using System.Collections.Generic;
using System.Text;
using IAmNotified.ClientSDK.Configuration;
using IAmNotified.ClientSDK.Notification;
using RabbitMQ.Client;

namespace IAmNotified.ClientSDK
{
    public class QueueService : IQueueService
    {
        object lockObj;

        private readonly Dictionary<string, List<NotificationBase>> _notification = new Dictionary<string, List<NotificationBase>>();
        public Dictionary<string, List<NotificationBase>> Notifications 
        {
            get { return _notification; }
        }

        public void Add(string queuename, NotificationBase notification)
        {
            lock (lockObj)
            {
                if (!_notification.ContainsKey(queuename))
                {
                    _notification.Add(queuename, new List<NotificationBase>());
                }
            }

            lock (lockObj)
            {
                var nb = _notification[queuename];
                nb.Add(notification);
            }
        }
    }
}