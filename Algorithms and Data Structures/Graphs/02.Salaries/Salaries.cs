using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Salaries
{
    internal class Salaries
    {
        private class Employer
        {
            public int Id { get; set; }

            public long Salary { get; set; }

            public List<Employer> Employers { get; set; }

            public Employer(int id)
            {
                this.Id = id;
                this.Employers = new List<Employer>();
            }
        }

        private static IDictionary<int, Employer> graph;

        private static readonly HashSet<Employer> visited = new HashSet<Employer>();

        private static long salaries = 0;

        private static void Main(string[] args)
        {
            BuildGraph();

            foreach (var e in graph)
            {
                GetSalarySum(e.Value);
            }

            foreach (var emp in graph.Values)
            {
                salaries += emp.Salary;
            }
            Console.WriteLine(salaries);
        }

        private static void BuildGraph()
        {
            int dimensions = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, Employer>();

            for (int i = 0; i < dimensions; i++)
            {
                var row = Console.ReadLine();
                if (!graph.ContainsKey(i))
                {
                    graph.Add(i, new Employer(i));
                }
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == 'Y')
                    {
                        if (!graph.ContainsKey(j))
                        {
                            graph.Add(j, new Employer(j));
                        }
                        graph[i].Employers.Add(graph[j]);
                    }
                }
            }
        }

        private static void GetSalarySum(Employer emp)
        {
            if (visited.Contains(emp))
            {
                return;
            }
            
            visited.Add(emp);
            if (emp.Employers.Count == 0)
            {
                emp.Salary = 1;
                return;
            }

            foreach (var e in emp.Employers)
            {
                GetSalarySum(e);
                emp.Salary += e.Salary;
            }
        }
    }
}