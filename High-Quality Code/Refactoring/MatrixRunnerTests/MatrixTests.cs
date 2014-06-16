namespace MatrixRunnerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MatrixUtils;
    
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void MatrixIndexerTest()
        {
            Matrix matrix = new Matrix(5);

            var cell = matrix[2, 2];
            Assert.AreEqual(0, cell);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MatrixIndexerTest2()
        {
            Matrix matrix = new Matrix(5);

            var cell = matrix[5, 5];
            Assert.AreEqual(0, cell);
        }

        [TestMethod]
        public void MatrixFillerTest()
        {
            Matrix matrix = new Matrix(3);
            matrix.FillMatrix();
            string expected = "  1  7  8\n  6  2  9\n  5  4  3";

            Assert.AreEqual(expected, matrix.ToString());
        }

        [TestMethod]
        public void MatrixFillerTest2()
        {
            Matrix matrix = new Matrix(3);
            matrix.FillMatrix();
            string expected = "  1  8  7\n  2  6  9\n  4  5  3";

            Assert.AreNotEqual(expected, matrix.ToString());
        }
    }
}