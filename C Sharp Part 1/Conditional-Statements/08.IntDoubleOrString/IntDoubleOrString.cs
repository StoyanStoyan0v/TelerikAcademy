using System;

class IntDoubleOrString
{
    static void Main()
    {
        //Enter int or double type for the variable.If input is something else it will assume it is string
        Console.Write("Enter the variable type - \"double\" or \"int\"(If input is something else, the variable will be string type: "); 
        string variableType = Console.ReadLine();
        Console.Write("Enter value for the variable: ");
        string variableValue = Console.ReadLine();
        switch (variableType)
        {
            case "int": int integerType = int.Parse(variableValue);
                integerType += 1;
                Console.WriteLine(integerType); break;
            case "double": double doubleType = double.Parse(variableValue);
                doubleType += 1.0;
                Console.WriteLine(doubleType); break;
            default: Console.WriteLine(variableValue + "*"); break;
        }
    }
}

