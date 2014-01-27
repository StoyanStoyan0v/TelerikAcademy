using System;

class ArrayOfLetters
{

    //We use our binary search method from the previous excersize to recieve the indexes of each letter
    static int BinarySearchMethod( int element, int[] nums)
    {
        
        int mid = 0;
        int upper = nums.GetUpperBound(0);
        int lower = nums.GetLowerBound(0);
        while (upper >= lower)
        {
            mid = (lower + upper) / 2;
            if (nums[mid] == element)
            {
                return mid;
            }
            else if (nums[mid] > element)
            {
                upper = mid - 1;
            }
            else
            {
                lower = mid + 1;
            }
        }
        return -1;

    }
    static void Main()
    {
        Console.WriteLine("The indexes of the letters from A to Z are respectively from 0 to 25. Enter        a word(capital letters only) and check the index of each letter: ");
        int[] lettersNumbers = new int[26];
        string word = Console.ReadLine();

        //Initialize the array with numbers of the letters with the valuse from ASCII table...
        for (int i = 0, j = 65; i < lettersNumbers.Length; i++,j++)
        {
            lettersNumbers[i] = j;
        }

        for (int i = 0; i < word.Length; i++)
        {
            //Use binary search to search the ASCII value of the letter in the array we initialized above and return the letter number 
            int index= BinarySearchMethod((Convert.ToInt32(word[i])),lettersNumbers);                                                                                    
            Console.WriteLine("{0} -> {1}",word[i],index);
        }
    }
}

