namespace LinkedList
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {


            LinkedList<int> someList = new LinkedList<int>();

            for (int i = 10; i >= 0; i--)
            {
                someList.AddLast(i);
                someList.AddFirst(i);
            }

            foreach (var item in someList)
            {
                Console.Write(item + " ");
            }


            Console.WriteLine();
            Console.WriteLine("List count: " + someList.Count);

            someList.Remove(10);
            Console.WriteLine(string.Join(" ",someList));

            Console.WriteLine("Does the list contains the number 10 yet? "+someList.Contains(10));
            Console.WriteLine("Does the list contains the number 25? "+someList.Contains(25));

            someList.Clear();
            Console.WriteLine("List count after being cleared: " + someList.Count);
            
        }
    }
}