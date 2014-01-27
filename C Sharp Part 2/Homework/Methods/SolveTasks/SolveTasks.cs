using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class SolveTasks
{
    static void ReadArray(double[] arr)
    {
        string arrayAsString = Console.ReadLine();
        string[] numbersAsStrings = arrayAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            arr[i] = double.Parse(numbersAsStrings[i]);
        }
    }

    static void ReversedNumber()
    {
        Console.Write("Enter a valid number that is about to be reversed: ");
        string number = "-1";
        while (int.Parse(number)<0)
        {
            number = Console.ReadLine();
            if(int.Parse(number)<0)
            {
                Console.Write("Enter a positive number: ");
            }
        }

        char[] numberAsString = number.ToCharArray();
        Array.Reverse(numberAsString);
        number = new string(numberAsString);
        Console.WriteLine("Reversed number: " + number);
        Console.WriteLine();
    }

    static void AvarageOfSequence()
    {

        Console.Write("Enter the length of the sequence: ");
        int length = int.Parse(Console.ReadLine());
        Console.Write("Enter the sequence to calculate its avarage: ");
        double[] sequence = new double[length];
        double sum = 0.0;
        while (sum==0)
        {
            ReadArray(sequence);
            sum = 0.0;
            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }
            if(sum==0)
            {
                Console.WriteLine("You have entered an empty sequence. Enter a sequence with a number in it: ");
            }
        }
        double avarage = sum / sequence.Length;
        Console.WriteLine("The average of the sequence is: {0}", avarage);
        Console.WriteLine();
    }

    static void LinearEquationRoot()
    {
        Console.WriteLine("Enter the coefficients of the equation: ");
        Console.Write("a= ");
        double a = 0.0;
        while (a==0.0)
        {
            a = double.Parse(Console.ReadLine());
            if(a==0.0)
            {
                Console.Write("You cannot divide by zero! Enter value for a different from 0: ");
            }
        }

        Console.Write("b= ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Your equiation is: ");
        Console.WriteLine("{0}x+{1}=0",a,b);
        Console.WriteLine("The result of the equation is: {0}", -b/a);
        Console.WriteLine();
    }

    static void MenuWithChoices()
    {
        //Here we choose a task and invoke the respective method for each of the tasks.
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("Choose a task: ");
            Console.WriteLine("1. Reverse a number");
            Console.WriteLine("2. Calculate avarage of a sequence");
            Console.WriteLine("3. Solve a linear equation");
            Console.WriteLine("0. Exit the program");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                ReversedNumber();              
            }
            else if (choice == 2)
            {
                AvarageOfSequence();                
            }
            else if (choice == 3)
            {
                LinearEquationRoot();  
            }
            else if (choice == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter a valid choice number (0,1,2 or 3)!");
            }
        }
    }

    static void Main()
    {
        MenuWithChoices();
        Console.WriteLine("Thank you for your time! See you soon! :)");
    }   
}

