using System;

class CompanyAndManagerInfo
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company adress: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Company phone number: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Company fax number: ");
        string companyFax = Console.ReadLine();
        Console.Write("Web site: ");
        string webSite = Console.ReadLine();
        Console.Write("Manager's first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager's last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager's age: ");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.Write("Manager's phone number: ");
        string managerPhone = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Company info: ");
        Console.WriteLine("Name: {0}",companyName);
        Console.WriteLine("Address: {0}",companyAddress);
        Console.WriteLine("Phone number: {0}",companyPhone);
        Console.WriteLine("Fax number: {0}", companyFax);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine();
        Console.WriteLine("Company manager info: ");
        Console.WriteLine("Full name: {0}",managerFirstName+" "+managerLastName);
        Console.WriteLine("Age: {0}",managerAge);
        Console.WriteLine("Phone: {0}",managerPhone);
    }
}

