namespace PersonInfo
{
    using System;
    using System.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person("Dimitar Ivanov", 25);
            Person secondPerson = new Person("Kebapcho Nadenichkov");
            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
        }
    }
}