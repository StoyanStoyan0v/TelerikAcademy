using System;

class MergeSort
{
    static double[] MergeSortMethod(double[] a)
    {
        if (a.Length == 1)
        {
            return a; //If the left/right subarray reach a length of 1, this bottom of the recursion returns the array of 1 element...
        }

        //Split the array into two parts...
        int middle = a.Length / 2;
        double[] left = new double[middle];
        for (int i = 0; i < middle; i++)
        {
            left[i] = a[i];
        }
        double[] right = new double[a.Length - middle];
        for (int i = 0; i < a.Length - middle; i++)
        {
            right[i] = a[i + middle];
        }

        //Recursively invoke this method to split and merge every left and right subarray into two parts until their length is 1...
        left = MergeSortMethod(left);
        right = MergeSortMethod(right);

        int l = 0;
        int r = 0;

        //Here we merge the recieved  subarrays from the recursions in otder to merge them...
        //After all the parts are recursively splited and sorted, the first started method comes here and merge the first two already         
        // sorted arrays and finally returns the whole array sorted...
        double[] sorted = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (l < left.Length && r < right.Length)
            {
                if (left[l] < right[r])
                {
                    sorted[i] = left[l];
                    l++;
                }
                else
                {
                    sorted[i] = right[r];
                    r++;
                }
            }
            else
            {
                if (l < left.Length)
                {
                    sorted[i] = left[l];
                    l++;
                }
                else
                {
                    sorted[i] = right[r];
                    r++;
                }
            }
        }
        return sorted;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[] unsortedArray = new double[n];

        for (int i = 0; i < n; i++)
        {
            unsortedArray[i] = double.Parse(Console.ReadLine());
        }
        double[] sortedArray = MergeSortMethod(unsortedArray);        
        Console.WriteLine(string.Join(" ",sortedArray));       
    }
}

