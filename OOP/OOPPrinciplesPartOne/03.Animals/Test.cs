namespace Animals
{
    using System;
    using System.Linq;

    class Test
    {
        static void Main(string[] args)
        {
            //Store all derivatives of the cat class in a siblge array. Polymorphism usage.
            Cat[] cats = new Cat[] { new Kitten ("Mariya", 5), new Tomcat("Pesho",3),new Kitten("Sarah",2) };
            Console.WriteLine("All cats' average age(both male and female): {0:F2} years.", cats.Average(cat => cat.Age));

            Dog[]dogs = new Dog[]{new Dog("Sharo",3,"male"),new Dog("Rex",2.5f,"male"), new Dog("Sarah",7,"female")};
            Console.WriteLine("All dogs' average age: {0:F2} years.",dogs.Average(dog=>dog.Age));

            Frog[] frogs = new Frog[] {new Frog("Gichka",1,"female"), new Frog("Kichka",0.5f,"female"), 
            new Frog("Karaman",0.5f,"male")};
            Console.WriteLine("All frogs' average age: {0:F2} years.",frogs.Average(frog=>frog.Age));
        }
    }
}
