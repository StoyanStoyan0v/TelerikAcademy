namespace Students
{
    using System;
    using System.Linq;

    /*Write a method that from a given array of students finds all students 
     * whose first name is before its last name alphabetically. Use LINQ query operators.*/

    public static class StudentNamesTest
    {
        private static Student[] allStudents = new Student[] { new Student("John", "Lehnon"), new Student("Pesho", "Georgiev"),
                new Student("Adam","Peshov")};

        public static void ExecuteTest()
        {
            var selectedStudents =
                from student in allStudents
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            Student.PrintCollection(selectedStudents);
        }        
    }
}
