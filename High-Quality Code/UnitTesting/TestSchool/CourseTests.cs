namespace TestSchool
{ 
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourceNullName()
        {
            Course course = new Course(null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourceEmptylName()
        {
            Course course = new Course("");
        }

        [TestMethod]
        public void TestCourseMethod()
        {
            Course course = new Course("JavaScript");
            Assert.AreEqual(course.Name, "JavaScript");
        }

        [TestMethod]
        public void TestCourseMethod2()
        {
            Course course = new Course("JavaScript");
            Assert.AreNotEqual(course.Name, "PHP");
        }
        
        [TestMethod]
        public void TestCourcesEquality()
        {
            Course someCourse = new Course("JavaScript");
            for (int i = 0; i < 3; i++)
            {
                someCourse.AddStudent(new Student("Pesho", 32320 + i));
            }
            Course someOtherCourse = new Course("JavaScript");
            for (int i = 0; i < 3; i++)
            {
                someOtherCourse.AddStudent(new Student("Pesho", 32325 + i));
            }

            Assert.IsFalse(someCourse.Equals(someOtherCourse));
        }

        [TestMethod]
        public void TestCourcesEquality2()
        {
            Course someCourse = new Course("JavaScript");
            for (int i = 0; i < 3; i++)
            {
                someCourse.AddStudent(new Student("Pesho", 32320 + i));
            }
            Course someOtherCourse = new Course("JavaScript");
            for (int i = 0; i < 3; i++)
            {
                someOtherCourse.AddStudent(new Student("Pesho", 32320 + i));
            }

            Assert.IsTrue(someCourse.Equals(someOtherCourse));
        }

        [TestMethod]
        public void TestAddStudent()
        {
            Course course = new Course("JavaScript");
            Student st = new Student("Ivan", 34343);
            course.AddStudent(st);
            Assert.AreEqual(course.StudentsCount, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistingStudent()
        {
            Course course = new Course("JavaScript");
            Student st = new Student("Pesho", 34343);
            course.AddStudent(st);
            st = new Student("Stamat", 34343);
            course.AddStudent(st);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddTooManyStudents()
        {
            Course course = new Course("JavaScript");
            course = new Course("JavaScript");
            for (int i = 0; i < 31; i++)
            {
                Student st = new Student("Pesho", 34343 + i);
                course.AddStudent(st);
            }
        }

        [TestMethod]
        public void TestRemoving()
        {
            Course someCourse = new Course("JavaScript");
            for (int i = 0; i < 3; i++)
            {
                someCourse.AddStudent(new Student("Pesho", 32320 + i));
            }
            someCourse.RemoveStudent(new Student("Pesho", 32322));
            Assert.AreEqual(someCourse.StudentsCount, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNonExistingRemoving()
        {
            Course someCourse = new Course("JavaScript");
            for (int i = 0; i < 3; i++)
            {
                someCourse.AddStudent(new Student("Pesho", 32320 + i));
            }
            someCourse.RemoveStudent(new Student("Pesho", 32325));
        }
    }
}