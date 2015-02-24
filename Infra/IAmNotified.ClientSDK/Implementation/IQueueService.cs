using System.Collections.Generic;
using IAmNotified.ClientSDK.Notification;

namespace IAmNotified.ClientSDK
{
    public interface IQueueService
    {
        void Add(string queuename, NotificationBase notification);
        /// <summary>
        /// List of Notifications per queue (Queuename is the key)
        /// </summary>
        Dictionary<string, List<NotificationBase>> Notifications { get; }
    }
}