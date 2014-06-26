namespace Variations
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

            Variations(new string[words.Length], 0);
        }

        private static void Variations(string[] arr, int index)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[index] = words[i];                
                    Variations(arr, index+1);
                    
                }
            }
        }
    }
}