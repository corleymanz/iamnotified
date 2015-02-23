using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmNotified.ClientSDK.Configuration
{
    public class Settings : ISettings
    {
        private static readonly Settings _instance = new Settings();

        /// <summary>  get instance from ApplicationSetting  </summary>
        public static Settings Instance
        {
            get { return _instance; }
        }

        /// <summary>smtp server</summary>
        public String MailQueue { get; private set; }
        public String RabbitmqServer { get; private set; }

        Settings()
        {
            var set = SimpleConfig.Configuration.Load<CustomSettings>();
            MailQueue = set.MailQueue;
            RabbitmqServer = set.RabbitmqServer;
        }
    }
}