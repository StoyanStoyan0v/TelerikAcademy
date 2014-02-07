using System;
using System.Collections.Generic;
using IEnumerableExtensions;

internal static class Tests
{
    /*Implement a set of extension methods for IEnumerable<T> that implement the following 
     * group functions: sum, product, min, max, average.*/

    static void Main()
    {
        List<double> numsAsList = new List<double>() {1.25,5.01,7,-12.3334,4,3.14,0.9 };
        Console.WriteLine("Sum of the list: {0:0.0000}", numsAsList.Sum());
        Console.WriteLine("Average of the list: {0:0.0000}",numsAsList.Average());
        Console.WriteLine("Product of the list: {0:0.0000}",numsAsList.Product());
        Console.WriteLine("Smalles value in the list: {0}",numsAsList.Min());
        Console.WriteLine("Greatest value in the list: {0}",numsAsList.Max());
    }
}


