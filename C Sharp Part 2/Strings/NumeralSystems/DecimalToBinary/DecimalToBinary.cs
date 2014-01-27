using System;

class DecimalToBinary
{
    static char[] ConvertDecimalToBinary(int number)
    {
        string binaryNumber = null; //Keep the reversed binary numnber.

        do
        {
            binaryNumber += number & 1; //Calculate (bitwse) the remainder of dividing by 2 and add to the string.
            number >>= 1; // Divide (bitwise) by 2.
        }
        while (number != 0);

        //Reverse the binary number.
        char[] binaryNumberAsChars = binaryNumber.ToCharArray(); 
        Array.Reverse(binaryNumberAsChars);

        return binaryNumberAsChars;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        char[] binaryNumber = ConvertDecimalToBinary(number);
        Console.WriteLine("Number in binary: "+string.Join("",binaryNumber));
    }
}

