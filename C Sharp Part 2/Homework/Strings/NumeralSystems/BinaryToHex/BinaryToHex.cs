using System;

class BinaryToHex
{
    static string ConvertBinaryToHex(string binary)
    {
        int currentLen = 0;
        string hexNumber = null;
        for (int i = 0; i < binary.Length; )
        {
            string  currentDigit=null;//Keep the current 4 bits which are going to be converted in hexadecimal.

            //Put the length of the current 4 bits which represent the hexadecimal digit and then loop to it and recieve the binary.
            currentLen+=4; 
            while (i<binary.Length && i<currentLen )
            {
                currentDigit += binary[i];
                i++;
            }

            //Convert the bits into hexadecimal and add it to the string.
            currentDigit=DigitValue(currentDigit);
            hexNumber += currentDigit;
        }
        return hexNumber;
    }

    static string DigitValue(string currentDigit)
    {
        string digitValue = null;

        //Get the hexadecimal value of a digit represented in binary.
        switch (currentDigit)
        {
            case "0000": digitValue = "0"; break;
            case "0001": digitValue = "1"; break;
            case "0010": digitValue = "2"; break;
            case "0011": digitValue = "3"; break;
            case "0100": digitValue = "4"; break;
            case "0101": digitValue = "5"; break;
            case "0110": digitValue = "6"; break;
            case "0111": digitValue = "7"; break;
            case "1000": digitValue = "8"; break;
            case "1001": digitValue = "9"; break;
            case "1010": digitValue = "A"; break;
            case "1011": digitValue = "B"; break;
            case "1100": digitValue = "C"; break;
            case "1101": digitValue = "D"; break;
            case "1110": digitValue = "E"; break;
            case "1111": digitValue = "F"; break;
            default: break;
        }
        return digitValue;
    }

    static void Main()
    {
        Console.Write("Enter binary number: ");
        string binaryNumber = Console.ReadLine();
        if (binaryNumber.Length % 4 != 0)
        {
            binaryNumber = binaryNumber.PadLeft(4 - (binaryNumber.Length % 4) + binaryNumber.Length, '0');
        }
        string hexNumber = ConvertBinaryToHex(binaryNumber);
        Console.WriteLine("Hexadecimal number: "+hexNumber);
    }
}

