using System;
using System.Collections.Generic;

class SubsetOfS
{
    //Method to return if there is subset found.
    static bool SubSetExtractor(int s, List<int> subset, int[] nums)
    {
        int currentSum = 0; //Keep the current sum of numbers.
        bool isSubSetFound = false; //Keep if a subset is found.
        int startPos = nums.Length - 1; 

        while (startPos >= 0)
        {
            //Start adding elements to the previous one (we take the last one) and check the sum.
            for (int i = startPos; i >= 0; i--)
            {
                currentSum += nums[i]; //Add the next element to the sum and check.
                if (currentSum < s) //If the current sum is lesser than the targeted one we add the element to the subset.
                {
                    subset.Add(nums[i]);
                }
                else if (currentSum == s)//If it is equial we add the element to the subset, change the variable to true and exit the loop.
                {
                    subset.Add(nums[i]);
                    isSubSetFound = true;
                    break;
                }
                else //If it is greater, remove the element from the sum and continue with the next element.
                {
                    currentSum -= nums[i];
                }
            }

            //When the loop above is over, we check what is the value of the boolean and return the result.
            if (isSubSetFound == true)
            {
                break;
            }
            else
            {
                currentSum = 0;
                subset.Clear();
                startPos--;
            }
        }
        return isSubSetFound;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        List<int> subset = new List<int>();

        int[] nums = new int[n];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        bool isSubSetFound = SubSetExtractor(s, subset, nums); //Get the value if a subset is found.
        subset.Sort();//Sort the list for ascending subset result.

        //Print the resuilt according to the boolean.
        if (isSubSetFound == true)
        {
            string subsetString = string.Join("+", subset);
            Console.WriteLine("S= {0} -> Yes({1})", s, subsetString);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

