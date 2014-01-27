using System;

class BinaryToDecimal
{
    static int ConvertBinaryToDecimal(string binaryNumber)
    {
        int decimalNumber = 0;

        for (int i = binaryNumber.Length-1, pow = 1; i >= 0; i--,pow*=2)
        {
            ////Add product of the bit with the powers of 2, starting with 2^0.
            decimalNumber += int.Parse(binaryNumber[i].ToString()) * pow; 
        }

        return decimalNumber;
    }

    static void Main()
    {
        Console.Write("Enter binary number: ");
        string binaryNumber = Console.ReadLine();
        int decimalNumber = ConvertBinaryToDecimal(binaryNumber);
        Console.WriteLine("Decimal number: "+decimalNumber);
    }
}

