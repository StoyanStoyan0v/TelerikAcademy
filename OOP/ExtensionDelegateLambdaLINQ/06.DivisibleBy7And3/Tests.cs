using System;
using DivisibleByNums;

/*Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
 * Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.*/

class Tests
{
    static void Main()
    {
        int[] numbers = { 3,7,21,43,42 ,5,8,630};
        var divisable = numbers.GetNumbers(3, 7);
        Console.WriteLine("With lambda and extensions: " + string.Join(" ", divisable));
        var div = numbers.GetNumbersByLinq(2, 21);
        Console.WriteLine("With LINQ queries: " + string.Join(" ", div));
    }
}

