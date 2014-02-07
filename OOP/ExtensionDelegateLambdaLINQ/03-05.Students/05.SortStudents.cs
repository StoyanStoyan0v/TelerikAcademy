namespace Students
{
    using System;
    using System.Linq;

    /*Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students
     * by first name and last name in descending order. Rewrite the same with LINQ.*/

    public static class SortStudents
    {
        private static Student[] allStudents = new Student[] { new Student("John", "Ivanov"), new Student("Pesho", "Georgiev"),
                new Student("Pesho","Peshov")};

        public static void ExecuteTest()
        {
            var selectedStudents = allStudents.OrderByDescending(x=>x.FirstName).ThenByDescending(x=>x.LastName);

            Console.WriteLine("With lambda and extension methods: ");
            Student.PrintCollection(selectedStudents);            

            var selectedStudentsLinq =
                from student in allStudents
                orderby student.FirstName descending, student.LastName descending               
                select student;

            Console.WriteLine("With LINQ: ");
            Student.PrintCollection(selectedStudentsLinq);
        }        
    }
}
