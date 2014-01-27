using System;

class FloatingPointBinary
{
    static string ConvertFloatToBinary(float number)
    {
        byte[] byteArray = BitConverter.GetBytes(number); //Convert the number in bytes.
        Array.Reverse(byteArray);
        string hex = BitConverter.ToString(byteArray); //Convert the bytes into string of hexadecimal digits.

        string binaryNumber = null; //Keep the binary representation.

        for (int i = 0; i < hex.Length; i++)
        {
            switch (hex[i])
            {
                case '0': binaryNumber += "0000"; break;
                case '1': binaryNumber += "0001"; break;
                case '2': binaryNumber += "0010"; break;
                case '3': binaryNumber += "0011"; break;
                case '4': binaryNumber += "0100"; break;
                case '5': binaryNumber += "0101"; break;
                case '6': binaryNumber += "0110"; break;
                case '7': binaryNumber += "0111"; break;
                case '8': binaryNumber += "1000"; break;
                case '9': binaryNumber += "1001"; break;
                case 'A': binaryNumber += "1010"; break;
                case 'B': binaryNumber += "1011"; break;
                case 'C': binaryNumber += "1100"; break;
                case 'D': binaryNumber += "1101"; break;
                case 'E': binaryNumber += "1110"; break;
                case 'F': binaryNumber += "1111"; break;
                case 'a': binaryNumber += "1010"; break;
                case 'b': binaryNumber += "1011"; break;
                case 'c': binaryNumber += "1100"; break;
                case 'd': binaryNumber += "1101"; break;
                case 'e': binaryNumber += "1110"; break;
                case 'f': binaryNumber += "1111"; break;
                default: break;
            }
        }

        return binaryNumber;
    }

    static string GetExponent(string binaryFloat)
    {
        //Gets the exponent: Bits from 1 to 8(incl) positions.
        string exponent = null;
        for (int i = 1; i < 9; i++)
        {
            exponent += binaryFloat[i];
        }
        return exponent;
    }

    static string GetMantissa(string binaryFloat)
    {
        //Get the mantissa: bits from 9 to the end positions.
        string mantissa = null;
        for (int i = 9; i < binaryFloat.Length; i++)
        {
            mantissa += binaryFloat[i];
        }
        return mantissa;
    }

    static int GetSign(float number)
    {
        //Get the sign: the bit of first position.
        int sign = 0;

        if (number<0)
        {
            sign = 1;
        }
        return sign;
    }

    static void Main()
    {
        Console.Write("Enter floating point number: ");
        float number = float.Parse(Console.ReadLine());
       
        string binaryFloat = ConvertFloatToBinary(number);
        Console.WriteLine("Number in binary representation: "+binaryFloat);
        
        int sign = GetSign(number);
        Console.WriteLine("Sign: "+sign);

        string exponent = GetExponent(binaryFloat);
        Console.WriteLine("Exponent: "+exponent);

        string mantissa = GetMantissa(binaryFloat);
        Console.WriteLine("Mantissa: "+mantissa);
        
    }
}

