using System;

class Signed16BitNumber
{
    static string ConvertDecimalToReversedBinary(int number)
    {
        string binaryNumber = null;

        do
        {
            binaryNumber += number & 1;
            number >>= 1;
        }
        while (number != 0);

        return binaryNumber;
    }

    static string ReverseString(string signedBinary)
    {
        char[] signedBinaryAsChars = signedBinary.ToCharArray();
        Array.Reverse(signedBinaryAsChars);
        string binaryNumber = new string(signedBinaryAsChars);
        return binaryNumber;
    }

    static string SignedBinaryRepresentation(short number)
    {
        string signedBinary = null;

        //If the number is positive, convert as usual.
        if (number >= 0)
        {
            string binaryNumber = ConvertDecimalToReversedBinary(number);

            for (int i = 0; i < binaryNumber.Length; i++)
            {
                signedBinary += binaryNumber[i];
            }

            for (int i = binaryNumber.Length; i < 16; i++)
            {
                signedBinary += '0';
            }

            binaryNumber = ReverseString(signedBinary);

            return binaryNumber;

        }
        else
        {
            //Get the bits that the absolute value of the number uses in binary.
            int bits = (int)Math.Log(Math.Abs((int)number), 2)+1;

            //Get the binary representation of the number = maximal number in the bits that your number uses - your number.
            string binaryNumber = ConvertDecimalToReversedBinary((int)Math.Pow(2, bits) + number).PadLeft(bits, '0');

            //Add the representation to the result.
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                signedBinary += binaryNumber[i];
            }

            //Fill the result with bits of 1 to the end(16th bit).
            for (int i = binaryNumber.Length; i < 15; i++)
            {
                signedBinary += '1';
            }

            if (number != -32768)
            {
                signedBinary += 1;
            }

            binaryNumber = ReverseString(signedBinary); //Reverse the binary string.

            return binaryNumber;
        }
    }
    
    static void Main()
    {
        Console.Write("Your 16-bit number: ");
        short number = short.Parse(Console.ReadLine());
        
        string binaryNumber=SignedBinaryRepresentation(number);
        Console.WriteLine("Signed binary representation of the number: "+binaryNumber);
    }  
}

