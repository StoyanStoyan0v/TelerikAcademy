using System;

class HexToDecimal
{
    static int ConvertHexToDecimal(string hex)
    {
        int decimalNumber = 0;

        for (int i = hex.Length - 1, pow = 1; i >= 0; i--, pow *= 16)
        {
            int digitValue = DigitValue(hex, i);
            //Add the product of the hexadecimal digit with the power of 16, starting with 16^0.
            decimalNumber +=  digitValue* pow;
        }

        return decimalNumber;
    }

    static int DigitValue(string hex, int i)
    {
        //Recieve the decimal value of the hexadecimal digit.
        int digitValue = 0;
        switch (hex[i])
        {
            case 'A': digitValue = 10; break;
            case 'B': digitValue = 11; break;
            case 'C': digitValue = 12; break;
            case 'D': digitValue = 13; break;
            case 'E': digitValue = 14; break;
            case 'F': digitValue = 15; break;
            case 'a': digitValue = 10; break;
            case 'b': digitValue = 11; break;
            case 'c': digitValue = 12; break;
            case 'd': digitValue = 13; break;
            case 'e': digitValue = 14; break;
            case 'f': digitValue = 15; break;
            default: digitValue = int.Parse(hex[i].ToString()); break;
        }
        return digitValue;
    }

    static void Main()
    {
        Console.Write("Enter hexadecimal number: ");
        string hex = Console.ReadLine();
        int decimalNumber = ConvertHexToDecimal(hex);
        Console.WriteLine("Decimal number: " + decimalNumber);
    }
}

