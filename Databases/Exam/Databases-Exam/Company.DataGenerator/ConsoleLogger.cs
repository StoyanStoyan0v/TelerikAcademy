namespace Company.DataGenerator
{
    using System;

    internal class ConsoleLogger : ILogger
    {
        public void LogLine(string message=null)
        {
            if (message == null)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        public void Log(string message)
        {
            Console.Write(message);
        }
    }
}