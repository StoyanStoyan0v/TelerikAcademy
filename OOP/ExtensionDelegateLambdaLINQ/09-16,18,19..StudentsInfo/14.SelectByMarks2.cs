namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SelectByMarks2
    {
        //Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.

        private static List<Students> students = new List<Students>();

        static SelectByMarks2()
        {
            students.Add(new Students("Ivan", "Petrov") { Marks = new List<int>() { 5, 3, 4, 2, 2, 4, 5 } });
            students.Add(new Students("Petar", "Georgiev") { Marks = new List<int>() { 6, 5, 6, 6, 4, 4, 6 } });
            students.Add(new Students("Petya", "Petrova") { Marks = new List<int>() { 3, 4, 4, 5, 5, 4, 6 } });
            students.Add(new Students("Ilarion", "Garibaldi") { Marks = new List<int>() { 2, 3, 5, 2, 4, 4, 5 } });
            students.Add(new Students("Mario", "Ivanov") { Marks = new List<int>() { 3, 4, 3, 3, 3 } });
            students.Add(new Students("George", "Stoyanov") { Marks = new List<int>() { 6, 6, 6, 6, 6, 6, 6 } });
        }

        public static void ExecuteTest()
        {
            var selected = students.FindAll(x => x.Marks.FindAll(y => y == 2).Count() == 2).
                Select(student => student + " | Marks: " + string.Join(" ", student.Marks));

            Students.PrintCollection(selected);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
