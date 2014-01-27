using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Indices
{
    static int[] nums;
    static StringBuilder output = new StringBuilder();
    static bool[] isVsited;

    static string GetOutPut(int index)
    {
        if (isVsited[index] == true)
        {
            int bracketIndex = output.ToString().IndexOf(index.ToString());
            output.Insert(bracketIndex, '(');
            output.Append(')');
            return output.ToString();
        }

        while (isVsited[index] == false)
        {
            output.Append(" " + index);
            isVsited[index] = true;
            try
            {
                GetOutPut(nums[index]);
            }
            catch (IndexOutOfRangeException)
            {

                return output.ToString();
            }
        }
        return output.ToString();

    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string numbers = Console.ReadLine();
        string[] numbersAsStrings = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        nums = new int[n];
        isVsited = new bool[n];

        for (int i = 0; i < isVsited.Length; i++)
        {
            isVsited[i] = false;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = int.Parse(numbersAsStrings[i]);
        }

        string outP = GetOutPut(0);
        if (outP.Contains("("))
        {
            int index = outP.IndexOf('(');
            string preO = outP.Substring(0, index).Trim();
            outP = outP.Substring(index);
            output.Clear();
            output.Append(preO);
            output.Append(outP);
        }
        Console.WriteLine(output.ToString().Trim());


    }
}
