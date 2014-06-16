namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void TestAddCourse()
        {
            School school = new School();
            Course course = CreateCourse();
            school.AddCourse(course);
            Course otherCourse = new Course("JavaScript");
            otherCourse.AddStudent(new Student("Gesho", 12315));
            otherCourse.AddStudent(new Student("Pesho", 18347));
            school.AddCourse(otherCourse);
            Assert.AreEqual(school.CoursesCount, 2);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestAddExistingCourse()
        {
            School school = new School();
            Course course = CreateCourse();
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void TestRemoveCourse()
        {
            School school = new School();
            Course course = CreateCourse();
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(school.CoursesCount, 0);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestRemoveNonExistingCourse()
        {
            School school = new School();
            Course course = CreateCourse();
            school.AddCourse(course);
            Course otherCourse = new Course("PHP");
            otherCourse.AddStudent(new Student("Ivan", 32329));
            school.RemoveCourse(otherCourse);
        }

        private Course CreateCourse()
        {
            Course course = new Course("JavaScript");
            course.AddStudent(new Student("Pesho", 12345));
            course.AddStudent(new Student("Pesho", 12347));
            return course;
        }
    }
}