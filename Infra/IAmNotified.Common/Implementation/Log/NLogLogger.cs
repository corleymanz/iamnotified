using NLog;

namespace IAmNotified.Common.Log
{
    public class NLogLogger : ILogger
    {

        private readonly Logger _logger;

        internal NLogLogger(Logger logger)
        {
          _logger = logger;
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Warning(string message, params object[] args)
        {
            _logger.Warn(message, args);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Debug(message, args);
        }
    }
}