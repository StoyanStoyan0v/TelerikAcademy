using System;

class CompareCharArrays
{
    static void Main()
    {
        //Actualy, the string type is an array of variables of the char type, where you can recieve each char variable by using the index    
        //i.e. firstCharArray[2] so we input the text as a whole string insread of using iterations for each of the arrays...
        string firsCharArray = Console.ReadLine();
        string secondCharArray = Console.ReadLine();

        bool areStringsSame = true;
        for (int i = 0; i < Math.Min(firsCharArray.Length, secondCharArray.Length); i++)
        {
            if (Convert.ToInt32(firsCharArray[i]) < Convert.ToInt32(secondCharArray[i]))
            {
                Console.WriteLine("The word \"{0}\" is lexocigraphically before the word \"{1}\".",firsCharArray,secondCharArray );
                areStringsSame = false;
                break;
            }
            else if (Convert.ToInt32(firsCharArray[i]) > Convert.ToInt32(secondCharArray[i]))
            {
                Console.WriteLine("The word \"{0}\" is lexicographically before the word \"{1}\".", secondCharArray, firsCharArray);
                areStringsSame = false;
                break;
            }
            else
            {
                continue;
            }
        }
        if (areStringsSame)
        {
            if (firsCharArray.Length == secondCharArray.Length)
            {
                Console.WriteLine("The both worlds are absolutely the same lexicographically.");
            }
            else if (firsCharArray.Length < secondCharArray.Length)
            {
                Console.WriteLine("The word \"{0}\" is lexocigraphically before the word \"{1}\".", firsCharArray, secondCharArray);
            }
            else
            {
                Console.WriteLine("The word \"{0}\" is lexicographically before the word \"{1}\".", secondCharArray, firsCharArray);
            }
        }
        

    }
}

