using System;
using System.Xml.Serialization;

namespace IAmNotified.IAmNotifiedService.Implementation.Configuration
{
    public class MailSetting
    {
        public int Id { get; set; }
        [XmlElement] public String SmtpServer { get; set; }
        [XmlElement] public bool SmtpDefaultCredentials { get; set; }
        /// <summary> only required when SmtpDefaultCredentials = false </summary>
        [XmlElement] public String SmtpServerUser { get; set; }
        /// <summary> only required when SmtpDefaultCredentials = false </summary>
        [XmlElement] public String SmtpServerWw { get; set; }
        [XmlElement] public String DefaultFromName { get; set; }
        [XmlElement] public String DefaultFromMail { get; set; }
    }
}