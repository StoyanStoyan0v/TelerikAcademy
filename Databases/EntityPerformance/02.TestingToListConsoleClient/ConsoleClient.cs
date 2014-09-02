using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TelerikDatabase;

namespace _02.TestingToListConsoleClient
{
    class ConsoleClient
    {
        private static readonly TelerikAcademyEntities context = new TelerikAcademyEntities();

        static void Main(string[] args)
        {
            //Comment the one of the methods when testing the other... stopwatch issues...
            Tester.Diagnose(TestNormal);
            Tester.Diagnose(TestToList);
        }
       
        private static void TestNormal()
        {
            var isTownSofia = context.Employees
                                     .Select(e => e.Address)
                                     .Select(a => a.Town)
                                     .First()
                                     .Name == "Sofia";
            Console.WriteLine("Is the town Sofia? {0}", isTownSofia);
        }

        private static void TestToList()
        {
            var isTownSofia = context.Employees
                                     .ToList()
                                     .Select(e => e.Address)
                                     .ToList()
                                     .Select(a => a.Town)
                                     .ToList()
                                     .First()
                                     .Name == "Sofia";
            
            Console.WriteLine("Is the town Sofia? {0}", isTownSofia);
        }
    }
}