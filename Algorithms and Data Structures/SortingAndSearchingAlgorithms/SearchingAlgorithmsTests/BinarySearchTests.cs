namespace SearchingAlgorithmsTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;
    
    [TestClass]
    public class BinarySearchTests
    {
        private static int[] intCollection;
        private static string[] stringCollection;

        [ClassInitialize]
        public static void InitializeCollections(TestContext context)
        {
            intCollection = new int[1000000];
            stringCollection = new string[1000000];

            for (int i = 0; i < 1000000; i++)
            {
                intCollection[i] = i + 1;
                stringCollection[i] = "string" + (i + 1);
            }
        }

        [TestMethod]
        public void SearchingForNonExistingNumber()
        {
            var collection = new SortableCollection<int>(intCollection);
            bool isFound = collection.BinarySearch(-20);
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void SearchingForNonExistingString()
        {
            var collection = new SortableCollection<string>(stringCollection);
            bool isFound = collection.BinarySearch("string 01");
            Assert.IsFalse(isFound);
        }

        [TestMethod]
        public void SearchingForExistingNumber()
        {
            var collection = new SortableCollection<int>(intCollection);
            bool isFound = collection.BinarySearch(750000);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void SearchingForExistingString()
        {
            var collection = new SortableCollection<string>(stringCollection);
            bool isFound = collection.BinarySearch("string400000");
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void SearchingForExistingNumber2()
        {
            var collection = new SortableCollection<int>(intCollection);
            bool isFound = collection.BinarySearch(1000000);
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void SearchingForExistingString2()
        {
            var collection = new SortableCollection<string>(stringCollection);
            bool isFound = collection.BinarySearch("string999999");
            Assert.IsTrue(isFound);
        }
    }
}