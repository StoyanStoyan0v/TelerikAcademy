using System;

namespace BookmarkingSite.Controllers
{
    public interface ILogger
    {
        void LogLine(string message);

        void Log(string message);
    }
}