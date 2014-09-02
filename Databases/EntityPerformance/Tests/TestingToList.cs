using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelerikDatabase;

namespace Tests
{
    [TestClass]
    public class TestingToList
    {
        private static readonly TelerikAcademyEntities context = new TelerikAcademyEntities();

        [TestMethod]
        public void TestNormal()
        {
            var isTownSofia = context.Employees
                                     .Select(e => e.Address)
                                     .Select(a => a.Town)
                                     .First()
                                     .Name == "Sofia";
            Console.WriteLine("Is the town Sofia? {0}", isTownSofia);
        }

        [TestMethod]
        public void TestToList()
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