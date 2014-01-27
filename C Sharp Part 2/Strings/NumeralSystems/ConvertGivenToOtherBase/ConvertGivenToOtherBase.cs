using System;
using System.Collections.Generic;

class ConvertGivenToOtherBase
{
    //Validate the number according to the base given.
    static string ValidNumber(int s)
    {
        string numberS = null;
        bool isValidNumber = true;
        do
        {
            isValidNumber = true;
            numberS = Console.ReadLine();
            for (int i = 0; i < numberS.Length; i++)
            {
                int maxBase = 0;

                switch (numberS[i])
                {
                    case 'A': maxBase = 11; break;
                    case 'B': maxBase = 12; break;
                    case 'C': maxBase = 13; break;
                    case 'D': maxBase = 14; break;
                    case 'E': maxBase = 15; break;
                    case 'F': maxBase = 16; break;
                    case 'a': maxBase = 11; break;
                    case 'b': maxBase = 12; break;
                    case 'c': maxBase = 13; break;
                    case 'd': maxBase = 14; break;
                    case 'e': maxBase = 15; break;
                    case 'f': maxBase = 16; break;
                    default: maxBase = int.Parse(numberS[i].ToString()); break;

                }
                //If the digit value is larger than the numeral base, the number is not valid.
                if (maxBase > s)
                {
                    isValidNumber = false;
                }
                
            }

            if (isValidNumber == false)
            {
                Console.WriteLine("You have entered an invalid digit for base {0}!", s);
                Console.Write("Enter a new number: ");
            }
        }
        while (!isValidNumber);
        return numberS;
    }

    static int DigitValue(string numberS, int i)
    {
        int digitValue = 0;
        switch (numberS[i])
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
            default: digitValue = int.Parse(numberS[i].ToString()); break;
        }
        return digitValue;
    }

    static int ConvertSToDecimal(string numberS,int s)
    {
        int decNumber = 0;

        for (int i = numberS.Length-1,pow=1; i >= 0; i--,pow*=s)
        {
            int digitValue = DigitValue(numberS, i); //Get the decimal value of the digit in base s.
            decNumber += digitValue * pow; //Add the product of the decimal digit with the power of s, starting with s^0.
        }

        return decNumber;
    }

    static string ConvertDecimalToD(int decNum,int d)
    {
        string numberD = null;

        do
        {
            //Recieve the digit value in numeral base d.
            switch (decNum %d) 
            {
                case 10: numberD += "A"; break;
                case 11: numberD += "B"; break;
                case 12: numberD += "C"; break;
                case 13: numberD += "D"; break;
                case 14: numberD += "E"; break;
                case 15: numberD += "F"; break;
                default: numberD += decNum % d; break;
            }
            
            decNum /= d;
        }
        while (decNum != 0);

        //Reverse array.
        char[] numberDAsChars = numberD.ToCharArray();
        Array.Reverse(numberDAsChars);

        return new string(numberDAsChars);
    }
    
    static void Main()
    {
        Console.Write("Enter the numeral base to convert from: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter the number to be converted: ");
        string numberS = ValidNumber(s);
        Console.Write("Enter the numeral base to convert to: ");
        int d = int.Parse(Console.ReadLine());
        int decimalNumber = ConvertSToDecimal(numberS, s);
        string numberD = ConvertDecimalToD(decimalNumber, d);
        Console.WriteLine("The number in base {0} is: {1}",d,numberD);
    }

    
}

