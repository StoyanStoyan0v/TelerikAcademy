namespace HumanCLass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        private static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Petrov", 10));
            students.Add(new Student("Peter", "Georgiev", 12));
            students.Add(new Student("Stoyan", "Alexandrov", 9));
            students.Add(new Student("Kebapcho", "Nadenichkov", 6));
            students.Add(new Student("Mariya", "Ivanova", 11));
            students.Add(new Student("Petya", "Georgieva", 10));
            students.Add(new Student("Ivan", "Ivanov", 9));
            students.Add(new Student("Dimitar", "Marinov", 8));
            students.Add(new Student("Michael", "Scofield", 12));
            students.Add(new Student("Benjamin", "Franklin", 2));

            var studentInAscOrder = students.OrderBy(student => student.Grade);
            PrintCollection<Student>(studentInAscOrder);

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Ivan", "Petrov",125,6));
            workers.Add(new Worker("Peter", "Georgiev", 100.25m,4.5f));
            workers.Add(new Worker("Stoyan", "Alexandrov", 200,7.5f));
            workers.Add(new Worker("Kebapcho", "Nadenichkov", 155.75m,7));
            workers.Add(new Worker("Mariya", "Ivanova", 250,8.5f));
            workers.Add(new Worker("Petya", "Georgieva", 345,10));
            workers.Add(new Worker("Ivan", "Ivanov", 140,6.5f));
            workers.Add(new Worker("Dimitar", "Marinov",300, 8));
            workers.Add(new Worker("Michael", "Scofield", 95.75m,3.5f));
            workers.Add(new Worker("Benjamin", "Franklin", 1000,9.5f));

            var workersInDescOrder =
                from worker in workers
                orderby worker.MoneyPerHour descending
                select worker;
            PrintCollection(workersInDescOrder);
        }
    }
}
