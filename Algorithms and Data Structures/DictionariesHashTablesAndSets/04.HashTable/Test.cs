namespace HashTable
{
    using System;
    using System.Collections.Generic;

    class Test
    {
        static void Main(string[] args)
        {
            //04.Hash table.
            TestHashTable();

            //05.HashSet
            TestHashSet();
        }

        private static void TestHashSet()
        {
            MyHashSet<int> mySet = new MyHashSet<int>();

            mySet.Add(5);
            mySet.Add(10);
            mySet.Add(25);
            mySet.Add(15);
            mySet.Add(4);
            mySet.Add(10);
            mySet.Add(13);
            mySet.Add(21);
            Console.Write("HashSet: ");
            PrintCollection<int>(mySet);

            Console.WriteLine("Is there an element 4: " + mySet.Find(4));

            mySet.Remove(4);
            Console.Write("HashSet after 4 was removed: ");
            PrintCollection<int>(mySet);

            Console.WriteLine("Is there an element 4: " + mySet.Find(4));

            MyHashSet<int> otherSet = new MyHashSet<int>();
            otherSet.Add(5);
            otherSet.Add(10);
            otherSet.Add(25);
            otherSet.Add(15);
            otherSet.Add(41);
            otherSet.Add(33);
            Console.Write("Other HashSet: ");
            PrintCollection<int>(otherSet);

            var unitedSets = mySet.UnionWith(otherSet);
            Console.Write("United sets: ");
            PrintCollection<int>(unitedSets);

            var intersectedSets = mySet.IntersectWith(otherSet);
            Console.Write("Intersected sets: ");
            PrintCollection<int>(intersectedSets);
            Console.WriteLine("United sets' elements count: " + unitedSets.Count);
        }

        private static void TestHashTable()
        {
            HashTable<string, int> sampleHashTable = new HashTable<string, int>();

            sampleHashTable.Add("pesho", 5);
            sampleHashTable.Add("ivan", 5);
            sampleHashTable.Add("stamat", 10);
            sampleHashTable["ivan"] = 44;
            sampleHashTable["michael"] = 10;
            sampleHashTable.Remove("pesho");
            Console.WriteLine("dictionary.Find(\"ivan\") -> " + sampleHashTable.Find("ivan"));
            Console.WriteLine("dictionary[\"stamat\"] -> " + sampleHashTable["stamat"]);

            Console.Write("Dictionary key-value pairs: ");
            PrintCollection<KeyValuePair<string, int>>(sampleHashTable);

            Console.WriteLine("Keys: " + string.Join(" ", sampleHashTable.Keys));
            Console.WriteLine("Elements in the dictionary: " + sampleHashTable.Count);
            Console.WriteLine("Is there element with key 'michael': " + sampleHashTable.ContainsKey("michael"));
            Console.WriteLine();
        }

        private static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}