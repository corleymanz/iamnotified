using System;
using IAmNotified.Common.Serialize;
using S=IAmNotified.Schema;

namespace IAmNotified.ClientSDK.Notification
{
    public class WebNotification : NotificationBase
    {
        private readonly S.WebNotification _notification;

        private string _message;
        public override string Message
        {
            get
            {
                if (_message == null)
                {
                    _message = Json.Serialize(_notification);
                }
                return _message;
            }
        }

        public override string QueueName
        {
            get
            {
                //TODO : Use applicationID.Username as queuename
                throw new System.NotImplementedException();
            }
        }

        public WebNotification(S.WebNotification notification)
        {
            _notification = notification;
        }

        public WebNotification(string message, string type)
            : this(new S.WebNotification { Message = message, Type = type })
        {
        }
    }
}
