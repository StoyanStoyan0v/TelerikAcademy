using System;

class QuickSort
{
    //Here we keep a methpd for swaping all the elements below in order to avoid repetitive code.
    static void SwapElements(ref double firstElement, ref double secondElement)
    {
        double tempElement = firstElement;
        firstElement = secondElement;
        secondElement = tempElement;
    }

    //Here is the recursive sorting of all subarrays recieved from the left and right sides of the current pivot(random) number.
    static void QuickSortMethod(double[] arr, int left, int right)
    {

        if (left < right)
        {
            int pivotIndex = left;//Our current pivot index...
            int pivotNewIndex = PivotIndex(arr, left, right, pivotIndex); //Put it in the right position with the method below.

            //Recursively give this method new left and right positions of the next subarray and repeat until the positions are even.
            //If they are even we have our last  subarray with length 1 which is sorted already and recursion stops.
            QuickSortMethod(arr, left, pivotNewIndex - 1); 
            QuickSortMethod(arr, pivotNewIndex + 1, right);
        }
    }

    //Here we chose a pivot anelement from our subarray and put all lesser elements in the left and greater in the right.
    static int PivotIndex(double[] arr, int left, int right, int pivotIndex)
    {
        double pivotValue = arr[pivotIndex];//Keep the value of our chosen pivot element.

        SwapElements(ref arr[pivotIndex], ref arr[right]); //Swap our element with the end one.

        int storeIndex = left; //Keep the beginnign index.
        for (int i = left; i < right; i++)
        {
            if (arr[i] <= pivotValue) 
            {
                //If element is lesser than our pivot element, swap it with the kept beginning index.
                SwapElements(ref arr[i], ref arr[storeIndex]);
                storeIndex++; //Increase the beginning index.
            }
        }
        //When the subarray is checked, swap the maximal kept beginning index with the pivot in the end, and we have our lesser in
        //left and greater in the right...
        SwapElements(ref arr[storeIndex], ref arr[right]);
        return storeIndex; //Recieve the index of the pivot and give it to the recursion...
    }

    

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[] unsortedArray = new double[n];

        for (int i = 0; i < n; i++)
        {
            unsortedArray[i] = double.Parse(Console.ReadLine());
        }

        QuickSortMethod(unsortedArray, 0, unsortedArray.Length-1);

        Console.WriteLine(string.Join(" ", unsortedArray));
    }
}

