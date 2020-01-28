namespace ClothingStoreApp.BAL.StoreLogger
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogDebug(string message);

        void LogWarn(string message);

        void LogError(string message);

        void LogFatal(string message);

        void LogTrace(string message);
    }
}
