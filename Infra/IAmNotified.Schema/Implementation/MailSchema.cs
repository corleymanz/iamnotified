using System;
using System.Collections.Generic;

namespace IAmNotified.Schema
{
    public class MailSchema
    {
        public String FromName { get; set; }
        public String FromMail { get; set; }
        public String Subject { get; set; }
        public List<String> Tomail { get; set; }
        public List<String> Bcc { get; set; }
        public MailPriority? Priority { get; set; }
        public String Content { get; set; }
    }
}