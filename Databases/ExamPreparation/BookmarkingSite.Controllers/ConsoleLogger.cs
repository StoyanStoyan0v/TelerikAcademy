namespace BookmarkingSite.Controllers
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}