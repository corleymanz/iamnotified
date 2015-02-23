using System;

namespace IAmNotified.ClientSDK.Configuration
{
    public interface ISettings
    {
        String MailQueue { get; }
        String RabbitmqServer { get; }
    }
}