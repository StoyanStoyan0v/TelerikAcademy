using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    internal class Program
    {
        private static readonly List<Product> solution = new List<Product>();

        private static Product[] products;

        private static int[,] valueTable;

        private static int[,] keptTable;

        private static int capacity;
        
        private static void Main(string[] args)
        {
            products = new Product[]
            {
                new Product("Beer",3,2),
                new Product("Vodka",8,12),
                new Product("Cheese",4,5),
                new Product("Nuts",1,4),
                new Product("Ham",2,3),
                new Product("Whiskey",8,13)
            };

            Console.WriteLine("Enter sack capacity: ");
            capacity = int.Parse(Console.ReadLine());
            valueTable = new int[products.Length + 1, capacity + 1];
            keptTable = new int[products.Length + 1, capacity + 1];

            //Dynamic programming
            GetValues();
            
            GetSolution();

            PrintSolution();
        }

        private static void GetValues()
        {
            for (int i = 1; i <= products.Length; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (products[i - 1].Weight <= j)
                    {
                        if (products[i - 1].Cost + valueTable[i - 1, j - products[i - 1].Weight] > valueTable[i - 1, j])
                        {
                            valueTable[i, j] = products[i - 1].Cost + valueTable[i - 1, j - products[i - 1].Weight];
                            keptTable[i, j] = 1;
                        }
                        else
                        {
                            valueTable[i, j] = valueTable[i - 1, j];
                        }
                    }
                }
            }
        }

        private static void GetSolution()
        {
            var itemsCount = products.Length;
            var capacityLeft = capacity;

            while (itemsCount > 0)
            {
                if (keptTable[itemsCount, capacityLeft] != 0)
                {
                    solution.Add(products[itemsCount - 1]);
                    capacityLeft -= products[itemsCount - 1].Weight;
                }

                itemsCount--;
            }
        }
        
        private static void PrintSolution()
        {
            Console.WriteLine(string.Format("Best value: {0}", valueTable[products.Length, capacity]));
            foreach (var item in products)
            {
                if (solution.Contains(item))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(item);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}