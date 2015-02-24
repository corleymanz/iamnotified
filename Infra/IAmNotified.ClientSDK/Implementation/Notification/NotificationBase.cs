using System;

namespace IAmNotified.ClientSDK.Notification
{
    public abstract class NotificationBase : INotification
    {
        abstract public String Message { get; }
        //TODO: not the right place for QueueName!
        public abstract String QueueName { get; }
        public TimeSpan? ExpirationTime { get; set; }
    }
}
