namespace DivisibleByNums
{
    using System.Collections.Generic;
    using System.Linq;

    public static class DivisibleNumbers
    {

        //Lambda:
        public static int[] GetNumbers(this IEnumerable<int> collection, int firstNumber, int secondNumber) 
        {
            return collection.Where(x => x % firstNumber == 0 && x % secondNumber == 0).ToArray();
        }

        //LINQ:
        public static int[] GetNumbersByLinq(this IEnumerable<int> collection, int firstNumber, int secondNumber)
        {
            return (from x in collection 
                    where x % firstNumber == 0 && x % secondNumber == 0 
                    select x).ToArray();
        }
    }
}
