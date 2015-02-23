namespace IAmNotified.Common.Log
{
    public interface ILoggerFactory
    {
        ILogger GetLogger(string name);
        ILogger GetLogger();
    }
}