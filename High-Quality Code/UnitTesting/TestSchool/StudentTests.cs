namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void NameTest()
        {
            Student student = new Student("Pesho", 12345);
            Assert.AreEqual(student.Name, "Pesho");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullNameTest()
        {
            Student student = new Student(null, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyNameTest()
        {
            Student student = new Student("", 12345);
        }

        [TestMethod]
        public void IdTest()
        {
            Student student = new Student("Ivan", 12345);
            Assert.AreEqual(student.Id, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IdNegativeTest()
        {
            Student student = new Student("Ivan", -12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IdLowerTest()
        {
            Student student = new Student("Ivan", 5000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IdHigherTest()
        {
            Student student = new Student("Ivan", 120000);
        }

        [TestMethod]
        public void TestStudentEquality()
        {
            Student student = new Student("Maya", 34000);
            Student otherStudent = new Student("Pesho", 34000);
            Assert.IsTrue(student.Equals(otherStudent));
        }


        [TestMethod]
        public void ToStringTest()
        {
            Student student = new Student("Maya", 34000);
            var studentStr = student.ToString();
            Assert.AreEqual(studentStr, "Maya 34000");
        }
    }
}