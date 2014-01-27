using System;

class DecimalToHex
{
    static char[] ConvertDecimalToHex(int number)
    {
        string binaryNumber = null;

        do
        {
            switch (number & 15) //Calculating (bitwise) the remainder of dividing by 16.
            {
                case 10: binaryNumber += "A"; break;
                case 11: binaryNumber += "B"; break;
                case 12: binaryNumber += "C"; break;
                case 13: binaryNumber += "D"; break;
                case 14: binaryNumber += "E"; break;
                case 15: binaryNumber += "F"; break;
                default: binaryNumber += number & 15; break;
            }
            
            number >>= 4; //Divide (bitwise) by 16.
        }
        while (number != 0);

        //Reverse array.
        char[] binaryNumberAsChars = binaryNumber.ToCharArray();
        Array.Reverse(binaryNumberAsChars);

        return binaryNumberAsChars;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        char[] binaryNumber = ConvertDecimalToHex(number);
        Console.WriteLine("Number in hexadecimal: " + string.Join("", binaryNumber));
    }
}

