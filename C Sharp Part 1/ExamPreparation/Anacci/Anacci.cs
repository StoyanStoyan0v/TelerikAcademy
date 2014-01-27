using System;

class Anacci
{       
    static void Main()
    {
        string first = Console.ReadLine();
        int firstANacci=0;
        switch (first)
        {
            case "A": firstANacci = 1; break;
            case "B": firstANacci = 2; break;
            case "C": firstANacci = 3; break;
            case "D": firstANacci = 4; break;
            case "E": firstANacci = 5; break;
            case "F": firstANacci = 6; break;
            case "G": firstANacci = 7; break;
            case "H": firstANacci = 8; break;
            case "I": firstANacci = 9; break;
            case "J": firstANacci = 10; break;
            case "K": firstANacci = 11; break;
            case "L": firstANacci = 12; break;
            case "M": firstANacci = 13; break;
            case "N": firstANacci = 14; break;
            case "O": firstANacci = 15; break;
            case "P": firstANacci = 16; break;
            case "Q": firstANacci = 17; break;
            case "R": firstANacci = 18; break;
            case "S": firstANacci = 19; break;
            case "T": firstANacci = 20; break;
            case "U": firstANacci = 21; break;
            case "V": firstANacci = 22; break;
            case "W": firstANacci = 23; break;
            case "X": firstANacci = 24; break;
            case "Y": firstANacci = 25; break;
            case "Z": firstANacci = 26; break;
            default: break;
        }
        string second = Console.ReadLine();
        int secondANacci = 0;
        switch (second)
        {
            case "A": secondANacci = 1; break;
            case "B": secondANacci = 2; break;
            case "C": secondANacci = 3; break;
            case "D": secondANacci = 4; break;
            case "E": secondANacci = 5; break;
            case "F": secondANacci = 6; break;
            case "G": secondANacci = 7; break;
            case "H": secondANacci = 8; break;
            case "I": secondANacci = 9; break;
            case "J": secondANacci = 10; break;
            case "K": secondANacci = 11; break;
            case "L": secondANacci = 12; break;
            case "M": secondANacci = 13; break;
            case "N": secondANacci = 14; break;
            case "O": secondANacci = 15; break;
            case "P": secondANacci = 16; break;
            case "Q": secondANacci = 17; break;
            case "R": secondANacci = 18; break;
            case "S": secondANacci = 19; break;
            case "T": secondANacci = 20; break;
            case "U": secondANacci = 21; break;
            case "V": secondANacci = 22; break;
            case "W": secondANacci = 23; break;
            case "X": secondANacci = 24; break;
            case "Y": secondANacci = 25; break;
            case "Z": secondANacci = 26; break;
            default: break;
        }

        int n = int.Parse(Console.ReadLine());
        int nextANacci = 0;
        string next = null;


        Console.WriteLine(first);
        if (n > 1)
        {           

            Console.Write(second);
            nextANacci = firstANacci + secondANacci;
            int temp = nextANacci; 

            switch (nextANacci)
            {
                case 1: next = "A"; break;
                case 2: next = "B"; break;
                case 3: next = "C"; break;
                case 4: next = "D"; break;
                case 5: next = "E"; break;
                case 6: next = "F"; break;
                case 7: next = "G"; break;
                case 8: next = "H"; break;
                case 9: next = "I"; break;
                case 10: next = "J"; break;
                case 11: next = "K"; break;
                case 12: next = "L"; break;
                case 13: next = "M"; break;
                case 14: next = "N"; break;
                case 15: next = "O"; break;
                case 16: next = "P"; break;
                case 17: next = "Q"; break;
                case 18: next = "R"; break;
                case 19: next = "S"; break;
                case 20: next = "T"; break;
                case 21: next = "U"; break;
                case 22: next = "V"; break;
                case 23: next = "W"; break;
                case 24: next = "X"; break;
                case 25: next = "Y"; break;
                case 26: next = "Z"; break;
                default:
                    {
                        nextANacci %=26;
                        switch (nextANacci)
                        {
                            case 1: next = "A"; break;
                            case 2: next = "B"; break;
                            case 3: next = "C"; break;
                            case 4: next = "D"; break;
                            case 5: next = "E"; break;
                            case 6: next = "F"; break;
                            case 7: next = "G"; break;
                            case 8: next = "H"; break;
                            case 9: next = "I"; break;
                            case 10: next = "J"; break;
                            case 11: next = "K"; break;
                            case 12: next = "L"; break;
                            case 13: next = "M"; break;
                            case 14: next = "N"; break;
                            case 15: next = "O"; break;
                            case 16: next = "P"; break;
                            case 17: next = "Q"; break;
                            case 18: next = "R"; break;
                            case 19: next = "S"; break;
                            case 20: next = "T"; break;
                            case 21: next = "U"; break;
                            case 22: next = "V"; break;
                            case 23: next = "W"; break;
                            case 24: next = "X"; break;
                            case 25: next = "Y"; break;
                            case 26: next = "Z"; break;
                            default: break;
                        }
                    }
                    break;
            }
            Console.WriteLine(next);

            for (int i = 2; i <= n-1; i++)
            {               
                nextANacci += secondANacci;
                secondANacci = nextANacci%26;
                switch (nextANacci)
                {
                    case 1: next = "A"; break;
                    case 2: next = "B"; break;
                    case 3: next = "C"; break;
                    case 4: next = "D"; break;
                    case 5: next = "E"; break;
                    case 6: next = "F"; break;
                    case 7: next = "G"; break;
                    case 8: next = "H"; break;
                    case 9: next = "I"; break;
                    case 10: next = "J"; break;
                    case 11: next = "K"; break;
                    case 12: next = "L"; break;
                    case 13: next = "M"; break;
                    case 14: next = "N"; break;
                    case 15: next = "O"; break;
                    case 16: next = "P"; break;
                    case 17: next = "Q"; break;
                    case 18: next = "R"; break;
                    case 19: next = "S"; break;
                    case 20: next = "T"; break;
                    case 21: next = "U"; break;
                    case 22: next = "V"; break;
                    case 23: next = "W"; break;
                    case 24: next = "X"; break;
                    case 25: next = "Y"; break;
                    case 26: next = "Z"; break;
                    default:
                        {
                            nextANacci %= 26;
                            switch (nextANacci)
                            {
                                case 1: next = "A"; break;
                                case 2: next = "B"; break;
                                case 3: next = "C"; break;
                                case 4: next = "D"; break;
                                case 5: next = "E"; break;
                                case 6: next = "F"; break;
                                case 7: next = "G"; break;
                                case 8: next = "H"; break;
                                case 9: next = "I"; break;
                                case 10: next = "J"; break;
                                case 11: next = "K"; break;
                                case 12: next = "L"; break;
                                case 13: next = "M"; break;
                                case 14: next = "N"; break;
                                case 15: next = "O"; break;
                                case 16: next = "P"; break;
                                case 17: next = "Q"; break;
                                case 18: next = "R"; break;
                                case 19: next = "S"; break;
                                case 20: next = "T"; break;
                                case 21: next = "U"; break;
                                case 22: next = "V"; break;
                                case 23: next = "W"; break;
                                case 24: next = "X"; break;
                                case 25: next = "Y"; break;
                                case 26: next = "Z"; break;
                                default: break;
                            }
                        }
                        break;
                }

                Console.Write(next);
                Console.Write(new string(' ', i - 1));


                nextANacci += temp; 
                temp= nextANacci%26;
                switch (nextANacci)
                {
                    case 1: next = "A"; break;
                    case 2: next = "B"; break;
                    case 3: next = "C"; break;
                    case 4: next = "D"; break;
                    case 5: next = "E"; break;
                    case 6: next = "F"; break;
                    case 7: next = "G"; break;
                    case 8: next = "H"; break;
                    case 9: next = "I"; break;
                    case 10: next = "J"; break;
                    case 11: next = "K"; break;
                    case 12: next = "L"; break;
                    case 13: next = "M"; break;
                    case 14: next = "N"; break;
                    case 15: next = "O"; break;
                    case 16: next = "P"; break;
                    case 17: next = "Q"; break;
                    case 18: next = "R"; break;
                    case 19: next = "S"; break;
                    case 20: next = "T"; break;
                    case 21: next = "U"; break;
                    case 22: next = "V"; break;
                    case 23: next = "W"; break;
                    case 24: next = "X"; break;
                    case 25: next = "Y"; break;
                    case 26: next = "Z"; break;
                    default:
                        {
                            nextANacci %= 26;
                            switch (nextANacci)
                            {
                                case 1: next = "A"; break;
                                case 2: next = "B"; break;
                                case 3: next = "C"; break;
                                case 4: next = "D"; break;
                                case 5: next = "E"; break;
                                case 6: next = "F"; break;
                                case 7: next = "G"; break;
                                case 8: next = "H"; break;
                                case 9: next = "I"; break;
                                case 10: next = "J"; break;
                                case 11: next = "K"; break;
                                case 12: next = "L"; break;
                                case 13: next = "M"; break;
                                case 14: next = "N"; break;
                                case 15: next = "O"; break;
                                case 16: next = "P"; break;
                                case 17: next = "Q"; break;
                                case 18: next = "R"; break;
                                case 19: next = "S"; break;
                                case 20: next = "T"; break;
                                case 21: next = "U"; break;
                                case 22: next = "V"; break;
                                case 23: next = "W"; break;
                                case 24: next = "X"; break;
                                case 25: next = "Y"; break;
                                case 26: next = "Z"; break;
                                default: break;
                            }
                        }
                        break;                      
                }
                Console.Write(next);
                Console.WriteLine();
            }
        }
    }
}

