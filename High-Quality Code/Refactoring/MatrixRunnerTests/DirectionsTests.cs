namespace MatrixRunnerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MatrixUtils;
    
    [TestClass]
    public class DirectionsTests
    {
        [TestMethod]
        public void TestInitialDirection()
        {
            var actual = Directions.GetInitialDirection();
            var expected = new Position(1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNotInitialDirection()
        {
            var actual = Directions.GetInitialDirection();
            var expected = new Position(0, 1);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestNextDirection()
        {
            var someDirection = new Position(0, 1);
            var nextDirectionActual = Directions.GetNextDirection(someDirection);
            var nextDirectionExpected = new Position(1, 1);
            Assert.AreEqual(nextDirectionActual, nextDirectionExpected);
        }

        [TestMethod]
        public void TestNextDirection2()
        {
            var someDirection = new Position(1, 0);
            var nextDirectionActual = Directions.GetNextDirection(someDirection);
            var nextDirectionExpected = new Position(1, -1);
            Assert.AreEqual(nextDirectionActual, nextDirectionExpected);
        }

        [TestMethod]
        public void TestNotNextDirection()
        {
            var someDirection = new Position(1, 0);
            var nextDirectionActual = Directions.GetNextDirection(someDirection);
            var nextDirectionExpected = new Position(-1, 1);
            Assert.AreNotEqual(nextDirectionActual, nextDirectionExpected);
        }

        [TestMethod]
        public void PositionEqualtyTest()
        {
            var pos1 = new Position(1, 5);
            var pos2 = new Position(1, 5);
            Assert.IsTrue(pos1.Equals(pos2));
        }

        [TestMethod]
        public void PositionEqualtyTest2()
        {
            var pos1 = new Position(1, 5);
            var pos2 = new Position(2, 5);
            Assert.IsFalse(pos1.Equals(pos2));
        }
    }
}