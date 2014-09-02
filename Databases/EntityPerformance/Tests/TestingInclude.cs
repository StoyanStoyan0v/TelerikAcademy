using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelerikDatabase;

namespace Tests
{
    [TestClass]
    public class TestingInclude
    {
        private static readonly TelerikAcademyEntities context = new TelerikAcademyEntities();

        [TestMethod]
        public void TestInculde()
        {
            foreach (var employee in context.Employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("Employee: {0} Department: {1} Town: {2}", employee.FirstName + " " + employee.LastName,
                    employee.Department.Name, employee.Address.Town.Name);
            }
        }
        
        [TestMethod]
        public void TestNotInculde()
        {
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("Employee: {0} Department: {1} Town: {2}", employee.FirstName + " " + employee.LastName,
                    employee.Department.Name, employee.Address.Town.Name);
            }
        }
    }
}