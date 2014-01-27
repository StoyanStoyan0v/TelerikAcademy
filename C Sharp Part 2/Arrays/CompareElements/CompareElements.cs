using System;

class CompareElements
{
    static void Main()
    {
        Console.Write("First array length: ");
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        Console.Write("Second array length: ");
        int m = int.Parse(Console.ReadLine());
        int[] secondArray = new int[m];

        for (int i = 0; i < n; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
            
        }

        Console.WriteLine();

        for (int i = 0; i < m; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool areTheArraysEquial = true;
        string suffix = null;

        for (int i = 0; i < Math.Min(m,n); i++)
        {
            //Here we chose the suffix after the sequential number of the two elements... just for fun. :)
            if (i == 0)
            {
                suffix = "st";
            }
            else if (i == 1)
            {
                suffix = "nd";
            }
            else if (i == 2)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
                   

            //Now compare them...
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("The {0}{1} two element of the array are equial!", i + 1,suffix);
            }
            else
            {
                Console.WriteLine("The {0}{1} two element of the array are not equial!", i + 1,suffix);
                areTheArraysEquial = false;
            }
        }

        
        //Here we can return the result of comparsion for the whole arrays...  
        if (areTheArraysEquial && m == n)
        {
            Console.WriteLine("The arrays are equial!");
        }
        else
        {
            Console.WriteLine("The arrays are not equial!");
        }
    }
}

