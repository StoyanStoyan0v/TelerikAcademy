using System;
using System.Numerics;

class ExcelColumns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] columns = new string[n];
        BigInteger columnIndex = 0;
        BigInteger multiplier = 0;

        

        
        for (int i = n-1; i >= 0; i--)
        {
            columns[i] = Console.ReadLine();

            switch (columns[i])
            {
                case "A": multiplier = 1; break;
                case "B": multiplier = 2; break;
                case "C": multiplier = 3; break;
                case "D": multiplier = 4; break;
                case "E": multiplier = 5; break;
                case "F": multiplier = 6; break;
                case "G": multiplier = 7; break;
                case "H": multiplier = 8; break;
                case "I": multiplier = 9; break;
                case "J": multiplier = 10; break;
                case "K": multiplier = 11; break;
                case "L": multiplier = 12; break;
                case "M": multiplier = 13; break;
                case "N": multiplier = 14; break;
                case "O": multiplier = 15; break;
                case "P": multiplier = 16; break;
                case "Q": multiplier = 17; break;
                case "R": multiplier = 18; break;
                case "S": multiplier = 19; break;
                case "T": multiplier = 20; break;
                case "U": multiplier = 21; break;
                case "V": multiplier = 22; break;
                case "W": multiplier = 23; break;
                case "X": multiplier = 24; break;
                case "Y": multiplier = 25; break;
                case "Z": multiplier = 26; break;
                default: 
                    break;                    
            }
            if (i != 0)
            {
                columnIndex += (multiplier) * (BigInteger)(Math.Pow(26, i ));
            }
            else
            {
                columnIndex += multiplier;
            }

            
        }
        Console.WriteLine(columnIndex);
    }
}

