namespace Stack
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            Stack<string> names = new Stack<string>(2);

            try
            {
                string ops = names.Pop();                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                string opa = names.Peek();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            names.Push("Pesho");
            names.Push("Mitko");
            names.Push("Stamat");
            names.Push("Pencho");
            names.Push("Pesho");

            Print(names);
            Console.WriteLine("The count of names is " + names.Count);

            Console.WriteLine("The top name in the stack is (poped): " + names.Pop());

            Print(names);

            Console.WriteLine("The top name in the stack is (peeked): " + names.Peek());

            Print(names);

            Console.WriteLine("Is the name of Mitko in it? " + names.Contains("Mitko"));

            //Pop Pencho up...
            names.Pop();
            Console.WriteLine("Pencho is removed!");
            Print(names);
            Console.WriteLine("Is the name of Pencho in it? " + names.Contains("Pencho"));

            names.Clear();
            Console.WriteLine("Count of names after being cleared: " + names.Count);
        }

        static void Print(Stack<string> names)
        {
            Console.Write("The stack: ");
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }
    }
}