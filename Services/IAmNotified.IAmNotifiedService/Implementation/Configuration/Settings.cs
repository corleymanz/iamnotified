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
 
        Settings()
        {
            Mail = SimpleConfig.Configuration.Load<CustomSettings>().MailSetting;
        }
    }
}