﻿using System;
using System.Xml.Serialization;

namespace IAmNotified.IAmNotifiedService.Implementation.Configuration
{
    [XmlType("myApplication")]
    public class CustomSettings
    {
        public MailSetting MailSetting { get; set; }
        public String RabbitmqServer { get; set; }
        public String MailQueue { get; set; }
    }
}
