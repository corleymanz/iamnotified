using System;
using System.Xml.Serialization;

namespace IAmNotified.ClientSDK.Configuration
{
    [XmlType("myApplication")]
    public class CustomSettings
    {
        public String RabbitmqServer { get; set; }
        public String MailQueue { get; set; }
    }
}