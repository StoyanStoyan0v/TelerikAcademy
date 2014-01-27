using System;

class MultiplyPolynoms
{
    static int[] MultiplyPolynomials(List<int>firstPoly,List<int>second)
    {
        for (int i = 0; i < firstPoly.Length; i++)
        {
            for (int j = 0; j < secondPoly.Length; j++)
            {
                int position = i + j;
                result[position] += (firstPoly[i] * secondPoly[j]);
            }
        }
        return result;
    }

    static void ReadArray(int[] arr)
    {
        string arrayAsString = Console.ReadLine();
        string[] numbersAsStrings = arrayAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            arr[i] = int.Parse(numbersAsStrings[i]);
        }
    }

    static void Main()
    {
        
    }
}

