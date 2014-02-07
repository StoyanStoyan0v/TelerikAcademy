namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GroupStudents
    {
        //18.Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
        //19.Rewrite the previous using extension methods.

        private static List<Students> students = new List<Students>();
        private static List<Group> departaments = new List<Group>()
            {
                new Group(1, "Medicine"),
                new Group(2, "Mathematics"),
                new Group(3, "Informatics"),
                new Group(4, "Law"),
                new Group(5, "History")
            };

        static GroupStudents()
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
            var groups =
                from student in students
                group student by student.GroupNumber into gr
                orderby gr.Key
                select gr;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("With LINQ: ");
            Console.ResetColor();
            Print(groups);     
            Console.WriteLine("----------------------------------------------");

            //Lambda:          
            groups = students.GroupBy(x=>x.GroupNumber).OrderBy(x=>x.Key);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("With Lambda: ");
            Console.ResetColor();
            Print(groups);          
        }

        private static void Print(IOrderedEnumerable<IGrouping<sbyte, Students>> groups)
        {
            foreach (var group in groups)
            {
                Console.WriteLine("Students from {0} departament: ", departaments[group.Key - 1].DepartamentName);

                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}",student.FirstName,student.LastName);
                }
                Console.WriteLine();
            }
        }
    }
}
