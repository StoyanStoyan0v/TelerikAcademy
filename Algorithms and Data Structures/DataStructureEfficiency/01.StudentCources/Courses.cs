namespace StudentCources
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class Courses
    {
        private class Person : IComparable<Person>
        {
            public string FName { get; private set; }

            public string LName { get; private set; }

            public Person(string fname, string lname)
            {
                this.FName = fname;
                this.LName = lname;
            }

            public int CompareTo(Person other)
            {
                if (this.LName.CompareTo(other.LName) != 0)
                {
                    return this.LName.CompareTo(other.LName);
                }
                else
                {
                    return this.FName.CompareTo(other.FName);
                }
            }

            public override string ToString()
            {
                return this.FName + " " + this.LName;
            }
        }

        static void Main(string[] args)
        {
            var courses = new SortedDictionary<string, SortedSet<Person>>();

            StreamReader reader = new StreamReader("students.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    words[0] = words[0].Trim();
                    words[1] = words[1].Trim();
                    words[2] = words[2].Trim();
                    if (!courses.ContainsKey(words[2]))
                    {
                        courses.Add(words[2], new SortedSet<Person>());
                    }
                    var person = new Person(words[0],words[1]);
                    courses[words[2]].Add(person);

                    line = reader.ReadLine();
                }

                PrintCollection(courses);
            }
        }
        
        private static void PrintCollection(SortedDictionary<string, SortedSet<Person>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("{0}: {1}", item.Key, string.Join(", ", item.Value));
            }
        }
    }
}