using System;
using System.Diagnostics;
using System.Linq;

namespace TelerikDatabase
{
    public static class Tester
    {
        public static void Diagnose(Action function)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            function();
            watch.Stop();
            Console.WriteLine("{0}: {1}", function.Method.Name, watch.Elapsed);
        }
    }
}