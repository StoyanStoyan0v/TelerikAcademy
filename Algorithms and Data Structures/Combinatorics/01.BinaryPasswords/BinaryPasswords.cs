namespace _01.BinaryPasswords
{
    using System;
    using System.Linq;
    
    internal class BinaryPasswords
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numberOfStars = input.Count(s => s == '*');
            long variations = 1;

            for (int i = 0; i < numberOfStars; i++)
            {
                variations *= 2;
            }

            Console.WriteLine(variations);
        }
    }
}