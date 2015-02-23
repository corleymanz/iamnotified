using NLog;

namespace IAmNotified.Common.Log
{
    public class LoggerFactory : ILoggerFactory
    {  
        public ILogger GetLogger(string name)
        {
            return new NLogLogger(LogManager.GetLogger(name));
        }

        public ILogger GetLogger()
        {
            return new NLogLogger(LogManager.GetCurrentClassLogger());
        }
    }
}
