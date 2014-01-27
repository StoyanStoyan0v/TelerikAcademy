using System;

class RecordOfEmpolyee
{
    static void Main()
    {
        bool isValid = true;
        string typeGender=null;

        Console.WriteLine("Information for the employee: ");

        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter family name: ");
        string familyName = Console.ReadLine();

        Console.Write("Enter age: ");
        byte age=0;
        do
        {
            try
            {
                age = byte.Parse(Console.ReadLine());
                isValid = true;
            }
            catch (FormatException)
            {
                isValid = false;
                Console.WriteLine("Enter valid number for age: ");
            }
            catch (OverflowException)
            {
                isValid = false;
                Console.WriteLine("Please enter a number between 0 and 255: ");
            }
        }
        while (!isValid);

        Console.Write("Enter gender: ");
        char gender='1';
        do
        {
            try
            {
                gender = char.Parse(Console.ReadLine());
                if (gender == 'm' || gender == 'f')
                {
                    isValid = true;
                    if(gender=='m')
                    {
                        typeGender="man";
                    }
                    else
                    {
                        typeGender="woman";
                    }
                }
                else
                {
                    isValid = false;
                }
            }
            catch (FormatException)
            {
                isValid = false;
                Console.WriteLine("Enter \"f\" or\"m'\" for gender: ");
            }
        }
        while(!isValid);

        Console.Write("Enter ID number: ");
        uint idNumber=0;
        do
        {
            try
            {
                idNumber = uint.Parse(Console.ReadLine());
                isValid = true;
            }
            catch (FormatException)
            {
                isValid = false;
                Console.WriteLine("Enter valid number:");
            }
            catch (OverflowException)
            {
                isValid = false;
                Console.WriteLine("Please enter a number between 0 and 2000000000: ");
            }
        }
        while (!isValid);

        Console.Write("Enter Unique employee number: ");
        int uniqueEmpoyeeNumber=0; 
        do
        {
            try
            {
                uniqueEmpoyeeNumber = int.Parse(Console.ReadLine());
                if (uniqueEmpoyeeNumber > 27560000 && uniqueEmpoyeeNumber < 27569999)         
                {
                    isValid = true;
                }
                else 
                {
                    isValid=false;
                    Console.Write("Enter unique number between 27650000 and 27659999: ");
                }
            }
            catch (FormatException)
            {
                isValid = false;
                Console.Write("Enter valid number:");
            }
            catch (OverflowException)
            {
                isValid = false;
                Console.Write("Enter valid number:");
            }
        }
        while (!isValid);

        Console.WriteLine("Hello,{0} {1}. You are {2} years old. You are {3}. Your ID is {4} and your unique number is {5}.",firstName,familyName,age,typeGender,idNumber,uniqueEmpoyeeNumber);
        
    }
}

