using System;
using System.Numerics;

class TheSecretsOfNumbers
{
    static void Main()
    {
        BigInteger num = BigInteger.Parse(Console.ReadLine());
        if (num < 0)
        {
            num *=-1;
        }
        string number = num.ToString();
        int specialSum = 0;

        if (number.Length % 2 != 0)
        {
            for (int i = 1; i <= number.Length; i++)
            {
                if (i % 2 != 0)
                {
                    specialSum += int.Parse((number[number.Length - i]).ToString()) * i * i;
                }
                else
                {
                    specialSum += int.Parse((number[number.Length - i]).ToString()) * int.Parse((number[number.Length - i]).ToString()) * i;
                }
            }
        }
        else
        {
            for (int i = 1; i <= number.Length; i++)
            {
                if (i % 2 != 0)
                {
                    specialSum += int.Parse((number[number.Length-i]).ToString()) * i * i;
                }
                else
                {
                    specialSum += int.Parse((number[number.Length - i]).ToString()) * int.Parse((number[number.Length - i]).ToString()) * i;
                }
            }
        }

        Console.WriteLine(specialSum);
        int sequenceLength = specialSum % 10;
        if (sequenceLength==0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", number);
        }
        else
        {
            int r = specialSum % 26;
            int firsLetter = r + 1;
            switch (firsLetter)
            {
                case 1: Console.Write("A"); break;
                case 2: Console.Write("B"); break;
                case 3: Console.Write("C"); break;
                case 4: Console.Write("D"); break;
                case 5: Console.Write("E"); break;
                case 6: Console.Write("F"); break;
                case 7: Console.Write("G"); break;
                case 8: Console.Write("H"); break;
                case 9: Console.Write("I"); break;
                case 10: Console.Write("J"); break;
                case 11: Console.Write("K"); break;
                case 12: Console.Write("L"); break;
                case 13: Console.Write("M"); break;
                case 14: Console.Write("N"); break;
                case 15: Console.Write("O"); break;
                case 16: Console.Write("P"); break;
                case 17: Console.Write("Q"); break;
                case 18: Console.Write("R"); break;
                case 19: Console.Write("S"); break;
                case 20: Console.Write("T"); break;
                case 21: Console.Write("U"); break;
                case 22: Console.Write("V"); break;
                case 23: Console.Write("W"); break;
                case 24: Console.Write("X"); break;
                case 25: Console.Write("Y"); break;
                case 26: Console.Write("Z"); break;
                default:
                    break;
            }
            for (int i = firsLetter+1; i < firsLetter+sequenceLength; i++)
            {
                switch (i%26)
                {
                    case 1: Console.Write("A"); break;
                    case 2: Console.Write("B"); break;
                    case 3: Console.Write("C"); break;
                    case 4: Console.Write("D"); break;
                    case 5: Console.Write("E"); break;
                    case 6: Console.Write("F"); break;
                    case 7: Console.Write("G"); break;
                    case 8: Console.Write("H"); break;
                    case 9: Console.Write("I"); break;
                    case 10: Console.Write("J"); break;
                    case 11: Console.Write("K"); break;
                    case 12: Console.Write("L"); break;
                    case 13: Console.Write("M"); break;
                    case 14: Console.Write("N"); break;
                    case 15: Console.Write("O"); break;
                    case 16: Console.Write("P"); break;
                    case 17: Console.Write("Q"); break;
                    case 18: Console.Write("R"); break;
                    case 19: Console.Write("S"); break;
                    case 20: Console.Write("T"); break;
                    case 21: Console.Write("U"); break;
                    case 22: Console.Write("V"); break;
                    case 23: Console.Write("W"); break;
                    case 24: Console.Write("X"); break;
                    case 25: Console.Write("Y"); break;
                    case 0: Console.Write("Z"); break;
                    default:
                        break;
                }  
            }
            Console.WriteLine();
        }
    }
}

