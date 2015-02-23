using System;

namespace IAmNotified.ClientSDK
{
    public class SmsNotifier
    {
        private const String QueueName = "SMSQueue";

        private IQueueHelper _queueHelper;
        public IQueueHelper QueueHelper
        {
            get
            {
                if (_queueHelper == null)
                {
                    _queueHelper = new QueueHelper(QueueName);
                }
                return _queueHelper;
            }
        }

        public void Push()
        {

        }
    }
}