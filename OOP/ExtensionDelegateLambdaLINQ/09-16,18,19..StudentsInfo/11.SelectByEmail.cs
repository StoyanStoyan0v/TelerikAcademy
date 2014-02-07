namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SelectByEmail
    {
        //Extract all students that have email in abv.bg. Use string methods and LINQ.

        private static List<Students> students = new List<Students>();

        static SelectByEmail()
        {
            students.Add(new Students("Ivan", "Petrov") { Email = "i_petrov@gmail.com" });
            students.Add(new Students("Petar", "Georgiev") { Email = "georgiev@abv.bg" });
            students.Add(new Students("Petya", "Petrova") { Email = "petya@abv.bg " });
            students.Add(new Students("Ilarion", "Garibaldi") { Email = "lari_gari@yahoo.com" });
            students.Add(new Students("Mario", "Ivanov") { Email = "ivanov_mario@abv.bg" });
            students.Add(new Students("George", "Stoyanov") { Email = "george@mail.com" });
        }

        public static void ExecuteTest()
        {
            var selected =
                from i in students
                where i.Email.Contains("@abv.bg")
                select i + " | Email number: " + i.Email;

            Students.PrintCollection(selected);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
