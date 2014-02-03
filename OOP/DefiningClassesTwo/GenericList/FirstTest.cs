namespace GenericList
{
    using System;

    public static class FirstTest
    {
        private static GenericList<string> animals = new GenericList<string>(-1);

        static FirstTest ()
        {
            animals.Add("Giraffe");
            animals.Add("Elephant");
            animals.Add("Tiger");
            animals.Insert("Lion", 1);
            animals.Add("Cat");
            animals.Add("Dog");
            animals.RemoveAt(2);
            animals.Insert("Monkey", 5);
        }

        public static void ExecuteFirstTest()
        {
            Console.WriteLine("Initial list: " + animals);
            Console.WriteLine("Some elements of the array:\nIndex {0} -> {1}\nIndex {2} -> {3}\nIndex {4} -> {5}",
                2, animals[1], 4, animals[3], 6, animals[5]);
            Console.WriteLine("The index of \"Dog\" is: {0}",animals.IndexOf("Dog"));
            ClearList();
            Console.WriteLine("Final list: "+animals+"\nThe list is empty!");
        }      

        private static void ClearList()
        {
             animals.Clear();
        }
           
    }
}
