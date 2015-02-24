using System;

namespace IAmNotified.ClientSDK.Notification
{
    public class SmsNotification : NotificationBase
    {
        public override string Message
        {
            get { throw new NotImplementedException(); }
        }
        public override string QueueName
        {
            get { return "SMSQueue"; }
        }

        public SmsNotification()
        {
            //TODO
        }
    }
}