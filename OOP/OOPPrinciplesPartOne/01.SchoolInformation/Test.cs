namespace SchoolInformation
{
    using System;

    class Test
    {
        static void Main()
        {
            Teacher firstTeacher = new Teacher("Peter Ivanov");
            Teacher secondTeacher = new Teacher("George Stoyanov");
            firstTeacher.AddDisciplines(new Discipline("Maths", 30, 30), new Discipline("Arts", 25, 25));
            secondTeacher.AddDisciplines(new Discipline("Physics", 40, 40), new Discipline("Biology", 35, 35));

            Class firstClass = new Class("12B");
            firstClass.AddTeacher(firstTeacher, secondTeacher);
            firstClass.Comment = "The best class ever!";

            School school = new School();
            school.AddClass(firstClass);
            Console.WriteLine(school);
            Console.WriteLine();

            Student student = new Student("Ivan Ivanov", 105902);
            student.Comment = "Adskiq manqk!";
            Console.WriteLine(student);
        }
    }
}
