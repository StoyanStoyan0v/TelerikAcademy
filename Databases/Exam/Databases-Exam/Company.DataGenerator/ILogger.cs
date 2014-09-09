namespace Company.DataGenerator
{
    public  interface ILogger
    {
        void LogLine(string message = null);

        void Log(string message);
    }
}