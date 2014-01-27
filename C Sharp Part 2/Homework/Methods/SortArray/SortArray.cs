using System;

class SortArray
{
    static int[] arr;

    static void ReadArray()
    {
        string arrayAsString = Console.ReadLine();
        string[] numbersAsStrings = arrayAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            arr[i] = int.Parse(numbersAsStrings[i]);
        }
    }

    static void SwapElements(ref int firstElement,ref int seconeElement)
    {
        int temp = firstElement;
        firstElement = seconeElement;
        seconeElement = temp;
    }

    static int SubarrayMaxNum(int[] array, int startIndex, int endIndex)
    {
        int maxNumber = array[startIndex];
        int indexMax = startIndex;
        for (int i = startIndex; i <= endIndex; i++)
		{
            if (array[i] > maxNumber)
            {
                maxNumber = array[i];
                indexMax = i;
            }           
		}
        return indexMax;
    }

    static void DescendingArray(int[] array, int startIndex, int endIndex)
    {
        for (int i = startIndex; i < array.Length; i++)
        {
            int indexMax = SubarrayMaxNum(array,i,endIndex);
            SwapElements(ref array[i],ref array[indexMax]);
                
        }       
    }

    static void AscendingArray(int[] array, int startPos, int endPos)
    {
        while (startPos<endPos)
        {
            int indexMax = SubarrayMaxNum(array, startPos,endPos);
            SwapElements(ref array[indexMax], ref array[endPos]);
            endPos--;
        }       
    }

    static void PrintResult()
    {
        int[] descending = (int[])arr.Clone();
        DescendingArray(descending, 0, descending.Length - 1);
        Console.WriteLine("Sequence in descending order: " + string.Join(" ", descending));

        int[] ascending = (int[])arr.Clone();
        AscendingArray(ascending, 0, ascending.Length - 1);
        Console.WriteLine("Sequence in ascending order: " + string.Join(" ", ascending));
    }

    static void Main()
    {
        Console.Write("Enter the count of the number to be inputed: ");
        int numbersCount = int.Parse(Console.ReadLine());

        Console.Write("Enter the sequence: ");
        arr = new int[numbersCount];
        ReadArray();

        PrintResult();
    }   
}

