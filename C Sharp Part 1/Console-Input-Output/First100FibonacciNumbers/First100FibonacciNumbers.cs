using System;

    class First100FibonacciNumbers
    {
        static void Main()
        {
            decimal firstFibonacci = 0;
            decimal secondFibonacci = 1;
            Console.WriteLine("First 100 members of the Fibonacci's row: ");
            Console.WriteLine("1 -> {0}",firstFibonacci);
            Console.WriteLine("2 -> {0}",secondFibonacci);
            for (int i = 3; i <= 99; i+=2)
            {                
                firstFibonacci += secondFibonacci;               
                secondFibonacci += firstFibonacci;
                Console.WriteLine("{0} -> {1} ",i,firstFibonacci);
                Console.WriteLine("{0} -> {1}",i+1, secondFibonacci);
            }
            Console.WriteLine();
        }
    }

