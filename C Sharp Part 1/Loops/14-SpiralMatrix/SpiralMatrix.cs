using System;

class SpiralMatrix
{
    static void Main()
    {
        int n=0 ;
        while (n < 1 || n >= 20)
        {
            Console.Write("Enter number between 1 and 19: ");
            string input = Console.ReadLine();
            n = int.Parse(input);
        }
        Console.WriteLine();

        //Create the matrix grid that's going to be filled...
        int[,] matrix = new int[n,n];

        int counter = 1; //Keep the numbers that is going to be in the matrix cells and increase them...

        //Keep the row or col starting/ending positions and incease/decrease their value to shrink the matrix filling...
        int startPosition = 0;
        int endPosition = n-1;

        while(startPosition<=endPosition)
        {
            //Fill right and down...
            for (int col = startPosition; col <= endPosition; col++)
            {
                matrix[col, startPosition] = counter;
                counter++;
            }
            for (int row = startPosition+1; row <= endPosition; row++)
            {
                matrix[endPosition, row] = counter;
                counter++;
            }

            //Fill left and up...
            for (int col = endPosition-1; col >= startPosition; col--)
            {
                matrix[col, endPosition] = counter;
                counter++;
            }
            for (int row = endPosition-1; row >= startPosition+1; row--)
            {
                matrix[startPosition, row] = counter;
                counter++;
            }
            //Now shrink...
            startPosition++;
            endPosition--;
        }
      
        //Now print the matrix...
        Console.WriteLine("Spiral matrix: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4}",matrix[j,i]);
            }
            Console.WriteLine();
        }
    }
}

