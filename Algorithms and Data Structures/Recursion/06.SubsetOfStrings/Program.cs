namespace SubsetOfStrings
{
    using System;
    
    class Program
    {
        static int k;
        static string[] words;
        
        static void Main(string[] args)
        {
            words = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (!int.TryParse(Console.ReadLine(), out k) || k > words.Length)
            {
                Console.WriteLine("Enter subset length not bigger than {0}.", words.Length);
            }

            Variations(new string[words.Length], 0, 0);
        }

        private static void Variations(string[] arr, int index, int currentElement)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = currentElement; i < arr.Length; i++)
                {
                    arr[index] = words[i];                
                    Variations(arr, index + 1,++currentElement);
                }
            }
        }
    }
}