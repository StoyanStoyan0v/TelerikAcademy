using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public static class SecondTest
    {
        private static GenericList<string> names = new GenericList<string>();
        private static GenericList<double> nums = new GenericList<double>();

        static SecondTest()
        {
            //Add some values in the constructor. They will be initialized with when the class is used for a first time.
            names.Add("John");
            names.Add("Michael");
            names.Add("Pesho");
            names.Add("Jason");

            nums.Add(3.14);
            nums.Add(2.99);
            nums.Add(5);
            nums.Add(-0.999);
            nums.Add(0.1);
        }

       public static void ExecuteSecondTest()
       {
           string namesMax = names.Max();
           string namesMin = names.Min();
           double numsMax = nums.Max();
           double numsMin = nums.Min();
           Console.WriteLine("First name lexicographicaly is {0} and the last is {1}.",namesMin,namesMax);
           Console.WriteLine("The greatest number is {0} and the smalles is {1}.",numsMax,numsMin);
       }

    }
}
