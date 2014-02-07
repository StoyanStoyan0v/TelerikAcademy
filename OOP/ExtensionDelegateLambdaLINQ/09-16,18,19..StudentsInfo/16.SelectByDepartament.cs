namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SelectByDepartament
    {
        private static List<Students> students = new List<Students>();
        private static List<Group> departaments = new List<Group>()
            {
                new Group(1, "Medicine"),
                new Group(2, "Mathematics"),
                new Group(3, "Informatics"),
                new Group(4, "Law"),
                new Group(5, "History")
            };

        static SelectByDepartament()
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
            var selected =
                from student in students
                join gr in departaments on student.GroupNumber equals gr.GroupNumber
                where  gr.DepartamentName=="Mathematics"
                select student;
            Console.WriteLine("Students from the Mathematics departament: ");
            Students.PrintCollection(selected);

            Console.WriteLine("----------------------------------------------");
        }
    }
}
