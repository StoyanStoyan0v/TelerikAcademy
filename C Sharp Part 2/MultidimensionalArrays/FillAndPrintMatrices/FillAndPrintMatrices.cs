using System;

class FillAndPrintMatrices
{
    static void PrintArray(int[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            Console.Write("|");
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write("{0,3} |",arr[row,col]);
            }
            Console.WriteLine();
        }
    }

    static int[,] TopToBotomColumnsFilling(int[,] arr)
    {
        int counter = 1;
        for (int col = 0; col < arr.GetLength(1); col++)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                arr[row, col] = counter;
                counter++;
            }
        }
        return arr;
    }

    static int[,] UpAndDownFilling(int[,] arr)
    {
        int counter = 1;
        for (int col = 0; col < arr.GetLength(1); col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < arr.GetLength(0); row++)
                {
                    arr[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = arr.GetLength(0)-1; row >= 0; row--)
                {
                    arr[row, col] = counter;
                    counter++;
                }
            }
        }
        return arr;
    }

    static int[,] DiagonalFilling(int[,] arr)
    {        
        int counter=1;
        for (int row = arr.GetLength(0)-1; row >= 0; row--)
        {
            for (int i = row,col=0; i < arr.GetLength(0); i++,col++)
            {
                arr[i, col] = counter;
                counter++;
            }
        }
        for (int col = 1; col < arr.GetLength(1); col++)
        {
            for (int i = col,row=0; i < arr.GetLength(0); i++,row++)
            {
                arr[row, i] = counter;
                counter++;
            }
        }
        return arr;
    }

    static int[,] SpiralFilling(int[,] arr)
    {
        int startPosition = 0;
        int endPosition = arr.GetLength(0) - 1;
        int counter = 1;

        while (startPosition <= endPosition)
        {
            //Fill bot and right...
            for (int row = startPosition; row <= endPosition; row++)
            {
                arr[row, startPosition] = counter;
                counter++;
            }
            for (int col = startPosition + 1; col <= endPosition; col++)
            {
                arr[endPosition, col] = counter;
                counter++;
            }

            //Fill left and up...
            for (int row = endPosition - 1; row >= startPosition; row--)
            {
                arr[row, endPosition] = counter;
                counter++;
            }
            for (int col = endPosition - 1; col >= startPosition + 1; col--)
            {
                arr[startPosition, col] = counter;
                counter++;
            }
            //Now shrink...
            startPosition++;
            endPosition--;
        }
        return arr;
    }

    static void Main()
    {
        int dimensions=int.Parse(Console.ReadLine());        

        Console.WriteLine("Matrix with top-to-bottom column filling: "); 
        int[,] firstMatrix = new int[dimensions, dimensions];
        firstMatrix = TopToBotomColumnsFilling(firstMatrix);
        PrintArray(firstMatrix);
        Console.WriteLine();

        Console.WriteLine("Matrix with up-down collumn filling: ");
        int[,] secondMatrix = new int[dimensions,dimensions];
        secondMatrix = UpAndDownFilling(secondMatrix);
        PrintArray(secondMatrix);
        Console.WriteLine();

        Console.WriteLine("Matrix with diagonal filling: ");
        int[,] thirdMatrix = new int[dimensions, dimensions];
        thirdMatrix = DiagonalFilling(thirdMatrix);
        PrintArray(thirdMatrix);
        Console.WriteLine();

        Console.WriteLine("MatrixWithSpiralFilling: ");
        int[,] fourthMatrix = new int[dimensions, dimensions];
        fourthMatrix = SpiralFilling(fourthMatrix);
        PrintArray(fourthMatrix);
        Console.WriteLine();

    }
}

