namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SelectByGroup
    {
        /* 9.Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), 
         * GroupNumber. Create a List<Student> with sample students. Select only the students that are from group number 2. 
         * Use LINQ query. Order the students by FirstName.
         * 10. Implement the previous using the same query expressed with 
         * extension methods.*/

        private static List<Students> students = new List<Students>();

        static SelectByGroup()
        {
            students.Add(new Students("Ivan", "Petrov") { GroupNumber = 5 });
            students.Add(new Students("Petar", "Georgiev") { GroupNumber = 2 });
            students.Add(new Students("Petya", "Petrova") { GroupNumber = 4 });
            students.Add(new Students("Ilarion", "Garibaldi") { GroupNumber = 2 });
            students.Add(new Students("Mario", "Ivanov") { GroupNumber = 2 });
            students.Add(new Students("George", "Stoyanov") { GroupNumber = 1 });
        }

        public static void ExecuteTest()
        {
            //LINQ:
            var selected =
                from i in students
                where i.GroupNumber == 2
                orderby i.FirstName
                select i + " | Group number: " + i.GroupNumber;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("With LINQ:");
            Console.ResetColor();
            Students.PrintCollection(selected);

            //Lambda:
            selected = students.Where(i => i.GroupNumber == 2).OrderBy(i => i.FirstName).
                Select(i => i + " | Group number: " + i.GroupNumber);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("With LAMBDA and extensions:");
            Console.ResetColor();
            Students.PrintCollection(selected);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
