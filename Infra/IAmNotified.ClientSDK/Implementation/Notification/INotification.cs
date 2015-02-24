using System;

namespace IAmNotified.ClientSDK.Notification
{
    public interface INotification
    {
        string Message { get; }
        TimeSpan? ExpirationTime { get; set; }
    }
}