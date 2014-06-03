namespace BiDictionary
{
    using System;

    class DictionaryTester
    {
        static void Main(string[] args)
        {
            BiDictionary<string, string, string> biDict = new BiDictionary<string, string, string>();

            FillDictionary(biDict);
            
            //Console.WriteLine("Elements with key 'Key1': " + string.Join(" ", biDict.GetByFirstKey("Key1")));
            Console.WriteLine("Elements with key 'Key220000': " + string.Join(" ", biDict.GetBySecondKey("Key220000")));
            Console.WriteLine("Elements with both 'Key1' and 'Key220000' keys: " +
                              string.Join(" ", biDict.GetByBothKeys("Key1", "Key220000")));
            //Console.WriteLine(string.Join(" ", biDict.GetByFirstKey("Stamat")));
        }

        private static void FillDictionary(BiDictionary<string, string, string> biDict)
        {
            for (int i = 1; i <= 2000000; i++)
            {
                biDict.Add("Key1", "Key2", "Value");
            }
        }
    }
}