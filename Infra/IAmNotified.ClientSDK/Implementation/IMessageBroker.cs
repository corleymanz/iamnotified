using IAmNotified.ClientSDK.Notification;

namespace IAmNotified.ClientSDK
{
    public interface IMessageBroker
    {
        void SendNotifications();
    }
}