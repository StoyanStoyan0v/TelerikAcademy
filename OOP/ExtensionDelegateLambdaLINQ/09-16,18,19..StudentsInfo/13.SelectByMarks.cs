namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SelectByMarks
    {
        /* Select all students that have at least one mark Excellent (6) into a new anonymous class 
         * that has properties – FullName and Marks. Use LINQ.*/

        private static List<Students> students = new List<Students>();

        static SelectByMarks()
        {
            students.Add(new Students("Ivan", "Petrov") { Marks = new List<int>() { 5, 3, 4, 2, 4, 4, 5 } });
            students.Add(new Students("Petar", "Georgiev") { Marks = new List<int>() { 6, 5, 6, 6, 4, 4, 6 } });
            students.Add(new Students("Petya", "Petrova") { Marks = new List<int>() { 3, 4, 4, 5, 5, 4, 6 } });
            students.Add(new Students("Ilarion", "Garibaldi") { Marks = new List<int>() { 5, 3, 5, 2, 4, 4, 5 } });
            students.Add(new Students("Mario", "Ivanov") { Marks = new List<int>() { 3, 4, 3, 3, 3 } });
            students.Add(new Students("George", "Stoyanov") { Marks = new List<int>() { 6, 6, 6, 6, 6, 6, 6 } });
        }

        public static void ExecuteTest()
        {
            var selected =
                from i in students
                where i.Marks.Any(x => x == 6)
                select new { i, Marks = string.Join(" ", i.Marks) };

            Students.PrintCollection(selected);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
