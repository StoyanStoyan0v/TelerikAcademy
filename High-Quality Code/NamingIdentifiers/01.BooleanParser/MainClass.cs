namespace RefactoringClass
{
    using System;

    class MainClass
    {
        private const int MAX_COUNT = 6;

        class BooleanParser
        {
            public void Parse(bool variable)
            {
                string variableAsString = variable.ToString();
                Console.WriteLine(variableAsString);
            }
        }

        public static void Main()
        {
            BooleanParser parser = new BooleanParser();
            parser.Parse(true);
        }
    }
}