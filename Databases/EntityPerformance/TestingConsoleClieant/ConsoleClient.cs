using System;
using System.Diagnostics;
using System.Linq;
using TelerikDatabase;

namespace TestingIncludeConsoleClient
{
    public class ConsoleClient
    {
        private static readonly TelerikAcademyEntities context = new TelerikAcademyEntities();

        static void Main(string[] args)
        { 
            //Comment the one of the methods when testing the other... stopwatch issues...
            Tester.Diagnose(TestNotInculde);
            Tester.Diagnose(TestInculde);            
        }

        private static void TestInculde()
        {
            foreach (var employee in context.Employees.Include("Department").Include("Address.Town"))
            {
                //Console.WriteLine("Employee: {0} Department: {1} Town: {2}", employee.FirstName + " " + employee.LastName,
                //    employee.Department.Name, employee.Address.Town.Name);
            }
        }

        private static void TestNotInculde()
        {
            foreach (var employee in context.Employees)
            {
                //Console.WriteLine("Employee: {0} Department: {1} Town: {2}", employee.FirstName + " " + employee.LastName,
                //    employee.Department.Name, employee.Address.Town.Name);
            }
        }
    }
}