namespace SortingAlgorithmTests
{
    using System;
    using System.Collections.Generic;
    using SortingHomework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class Selectionsorter
    {
        private static SelectionSorter<int> sorter;
        
        [ClassInitialize]
        public static void InitializaSorter(TestContext context)
        {
            sorter = new SelectionSorter<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortNullCollectionTest()
        {
            sorter.Sort(null);
        }

        [TestMethod]
        public void SortingTest1()
        {
            var collection = IntegerCollectionGenerator.Generate(1000);

            sorter.Sort(collection);

            Assert.IsTrue(IsCollectionSorted(collection));
        }

        [TestMethod]
        public void SortingTest2()
        {
            var collection = IntegerCollectionGenerator.Generate(10000);

            sorter.Sort(collection);

            Assert.IsTrue(IsCollectionSorted(collection));
        }
        
        //Extremely slow..

        [TestMethod]
        public void SortingTest3()
        {
           
            var collection = IntegerCollectionGenerator.Generate(20000);

            sorter.Sort(collection);

            Assert.IsTrue(IsCollectionSorted(collection));
        }

        private bool IsCollectionSorted(IList<int> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i] < collection[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}