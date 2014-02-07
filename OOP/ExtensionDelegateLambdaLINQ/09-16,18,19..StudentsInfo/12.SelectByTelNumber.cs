namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SelectByTelNumber
    {
        //Extract all students with phones in Sofia. Use LINQ.

        private static List<Students> students = new List<Students>();

        static SelectByTelNumber()
        {
            students.Add(new Students("Ivan", "Petrov") { Tel = "042/321563" });
            students.Add(new Students("Petar", "Georgiev") { Tel = "02/606326" });
            students.Add(new Students("Petya", "Petrova") { Tel = "02/221321 " });
            students.Add(new Students("Ilarion", "Garibaldi") { Tel = "032/213092" });
            students.Add(new Students("Mario", "Ivanov") { Tel = "042/359231" });
            students.Add(new Students("George", "Stoyanov") { Tel = "02/632901" });
        }

        public static void ExecuteTest()
        {
            var selected =
                from i in students
                where i.Tel.StartsWith("02/")
                select i + " | Tel number: " + i.Tel;

            Students.PrintCollection(selected);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
