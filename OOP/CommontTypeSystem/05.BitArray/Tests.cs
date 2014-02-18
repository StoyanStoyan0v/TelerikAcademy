namespace BitArray
{
    using System;
    using System.Linq;
    
    class Tests
    {
        static void Main()
        {
            BitArray64 firstNum = new BitArray64(14538983112351289321);

            //Using the overriden ToString  method.
            Console.WriteLine("{0,-20}: {1}", firstNum.Number, firstNum);

            BitArray64 secondNum = new BitArray64(99999111999911);
            Console.Write(string.Format("{0,-20}: ", secondNum.Number));
            //Using the implemented enumerator.
            foreach (var bit in secondNum)
            {
                Console.Write(bit);
            }
            Console.WriteLine();

            BitArray64 thirdNum = new BitArray64(18446744073709551615);
            //Using the implemented indexer.
            Console.Write(string.Format("{0,-20}: ", thirdNum.Number));
            for (int i = 0; i < 64; i++)
            {
                Console.Write(thirdNum[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Are the first and the second number equal? {0}", firstNum == secondNum);
            Console.WriteLine("Are the second and the third number different? {0}", firstNum != secondNum);
        }
    }
}