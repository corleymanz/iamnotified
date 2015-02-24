using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IAmNotified.ClientSDK.Notification;
using S = IAmNotified.Schema;

namespace IAmNotified.ClientSDK.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMultipleNotificationsExample();

            SendOneNotificationExample();
        }

        private static void SendMultipleNotificationsExample()
        {
            var ms = new S.MailSchema
            {
                Tomail = new List<string> { "you@you.nl" }
                , Priority = S.MailPriority.Low
                , Subject = "Onderwerp"
                , Content = "hierbij een linkje <a href='www.google.com'> veel plezier ermee"
            };

            // create queueService
            IQueueService service = new QueueService();
            service.Add("MailQueue", new MailNotifification(ms));
            service.Add("MailQueue", new MailNotifification("onderwerp", "inhoud", "you@mij.nl"));
            service.Add("klant1", new WebNotification("dit is een webbericht", "Type1"));

            // make broker to send multiple notifications
            IMessageBroker broker = new MessageBroker(service);
            broker.SendNotifications();
        }

        private static void SendOneNotificationExample()
        {
            MessageBroker.SendNotification("testqueue", new WebNotification("jajaj", "typetje"));

        }
    }
}
