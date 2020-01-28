using NLog;

namespace ClothingStoreApp.BAL.StoreLogger
{
    using System;

    public sealed class MyLogger : ILogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogInfoAndShowOnConsole(string message)
        {
            logger.Info(message);
            Console.WriteLine(message);
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogFatal(string message)
        {
            logger.Fatal(message);
        }

        public void LogTrace(string message)
        {
            logger.Trace(message);
        }
    }
}
