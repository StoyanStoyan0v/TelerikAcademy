using System;

class StringAndObjectTypesDeclaration
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World!";
        object helloWorld = hello + " " + world;
        string helloWorldNew = helloWorld.ToString();
        Console.WriteLine(hello+" "+world);
        Console.WriteLine(helloWorld);
        Console.WriteLine(helloWorldNew);
    }
}
