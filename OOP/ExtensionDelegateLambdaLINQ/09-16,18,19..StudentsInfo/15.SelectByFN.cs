namespace StudentsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public static class SelectByFN
    {
        /*Extract all Marks of the students that enrolled in 2006. 
         * (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).*/

        private static List<Students> students = new List<Students>();

        static SelectByFN()
        {
            students.Add(new Students("Ivan", "Petrov") { FN = "342106213" , Marks = new List<int>() { 5, 3, 4, 2, 4, 4, 5 } });
            students.Add(new Students("Petar", "Georgiev") { FN = "253104244", Marks = new List<int>() { 6, 5, 6, 6, 4, 4, 6 } });
            students.Add(new Students("Petya", "Petrova") { FN = "105205341", Marks = new List<int>() { 3, 4, 4, 5, 5, 4, 6 } });
            students.Add(new Students("Ilarion", "Garibaldi") { FN = "105206312", Marks = new List<int>() { 5, 3, 5, 2, 4, 4, 5 } });
            students.Add(new Students("Mario", "Ivanov") { FN = "2129032121", Marks = new List<int>() { 3, 4, 3, 3, 3 } });
            students.Add(new Students("George", "Stoyanov") { FN = "109006329", Marks = new List<int>() { 6, 6, 6, 6, 6, 6, 6 } });
        }

        public static void ExecuteTest()
        {
            var selected =
                from i in students
                where i.FN.Substring(4,2) == "06"
                select i + " | FN: " + i.FN + " | Marks: " + string.Join(" ", i.Marks);

            Students.PrintCollection(selected);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
