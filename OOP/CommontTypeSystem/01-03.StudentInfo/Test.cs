namespace StudentInfo
{
    using System;
    using System.Linq;
    
    public static class Test
    {
        private static readonly Student student = new Student("Stoyan", "Ivanov", "Petrov", 9102147711, "Sofia, Gorno nanadolnishte str. 15",
            0888123456, "stoyan@abv.bg", 3, University.UNWE, Faculty.FinancialFaculty, Specialty.Finances);
        
        private static readonly Student otherStudent = new Student("Stoyan", "Ivanov", "Petrov", 8912125632, "Gorno Kamartzi, nanadolnishte str. 115",
            0876543210, "pussy_destroyer69@hotmail.com", 2, University.SofiaUniversity, Faculty.FMI, Specialty.ComputerScience);

        static void Main(string[] args)
        {
            /* 01. Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address,
            *  mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities
            *  and faculties. Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() 
            *  and operators == and !=.
            */
            ExecuteFirstTest();

            /* 02. Add implementations of the ICloneable interface. The Clone() method should 
            * deeply copy all object's fields into a new object of type Student.
            */
            ExecuteSecondTest();

            /* 03.Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
            * and by social security number (as second criteria, in increasing order).
            */
            ExecuteThirdTest();
        }

        private static void ExecuteFirstTest()
        {
            Console.WriteLine("Are the both students a same person? {0}", student == otherStudent);
            Console.WriteLine("First student's hash code: " + student.GetHashCode());
            Console.WriteLine("Second student's hash code: " + otherStudent.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("First student's info:\n" + student);
            Console.WriteLine("Second student's info:\n" + otherStudent);
            Console.WriteLine("--------------------");
        }

        private static void ExecuteSecondTest()
        {
            Student newStudent = student.Clone();
            newStudent.Course++;
            newStudent.Email = "st_petrov@yahoo.com";
            newStudent.Address = "In the middle of nowhere...";
            newStudent.LastName = "Ivanov";
            newStudent.University = University.MedicalUniversity;
            newStudent.Faculty = Faculty.DentalMedicineFaculty;
            newStudent.Specialty = Specialty.DentalMedicine;
            Console.WriteLine("New student's info:\n" + newStudent);  //New info updated in a new reference.
            Console.WriteLine("Old student's info:\n" + student);     //Old info kept in the old reference.
            Console.WriteLine("--------------------");
        }

        private static void ExecuteThirdTest()
        {
            //Sort students lexicographicaly by name or in ascending order by SSN (it uses the ComareTo method).
            Student[] students = new Student[] { student, otherStudent };
            Array.Sort(students);
            Console.WriteLine(string.Join<Student>("\n", students));
        }
    }
}