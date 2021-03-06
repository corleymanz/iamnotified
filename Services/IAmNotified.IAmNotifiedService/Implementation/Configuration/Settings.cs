﻿using System;

namespace IAmNotified.IAmNotifiedService.Implementation.Configuration
{
    /// <summary>
    /// Access Application settings
    /// </summary>
    public  class Settings : ISettings
    {
        private static readonly Settings _instance = new Settings();

        /// <summary>  get instance from ApplicationSetting  </summary>
        public static Settings Instance
        {
            get { return _instance; }
        }
        
        /// <summary>smtp server</summary>
        public MailSetting Mail { get; private set; }

        public String MailQueue { get; private set; }

        public String RabbitmqServer { get; private set; }

        Settings()
        {
            var set = SimpleConfig.Configuration.Load<CustomSettings>();
            Mail = set.MailSetting;
            MailQueue = set.MailQueue;
            RabbitmqServer = set.RabbitmqServer;
        }
    }
}