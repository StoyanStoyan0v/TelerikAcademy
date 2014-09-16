using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverTheMessage
{
    class Program
    {
        private static SortedDictionary<char, Node> graph;

        private static readonly List<char> result = new List<char>();

        private class Node : IComparable<Node>
        {
            public Node(char symbol)
            {
                this.Value = symbol;
                this.Successors = new HashSet<Node>();
                this.Parents = new HashSet<Node>();
            }

            public char Value { get; set; }

            public ICollection<Node> Successors { get; set; }

            public ICollection<Node> Parents { get; set; }

            public int CompareTo(Node other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }

        static void Main(string[] args)
        {
            FillTheGraph();
         
            TopologicalSort();
            
            Console.WriteLine(string.Join("", result));
        }

        private static void FillTheGraph()
        {
            graph = new SortedDictionary<char, Node>();

            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var currentMsg = Console.ReadLine();

                var previous = currentMsg[0];

                if (!graph.ContainsKey(previous))
                {
                    graph.Add(previous, new Node(previous));
                }

                for (int j = 1; j < currentMsg.Length; j++)
                {
                    var currentSymbol = currentMsg[j];
                    var previousSymbol = currentMsg[j - 1];
                   
                    if (!graph.ContainsKey(previousSymbol))
                    {
                        graph.Add(previousSymbol, new Node(previousSymbol));
                    }

                    if (!graph.ContainsKey(currentSymbol))
                    {
                        graph.Add(currentSymbol, new Node(currentSymbol));
                    }

                    graph[previousSymbol].Successors.Add(graph[currentSymbol]);
                    graph[currentSymbol].Parents.Add(graph[previousSymbol]);
                }
            }
        }

        private static void TopologicalSort()
        {
            var nodes = new SortedSet<Node>();

            foreach (var node in graph.Values)
            {
                if (node.Parents.Count == 0)
                {
                    nodes.Add(node);
                }
            }

            while (nodes.Count > 0)
            {
                var node = nodes.Min();
                nodes.Remove(node);

                result.Add(node.Value);
                foreach (var child in node.Successors)
                {
                    child.Parents.Remove(node);
                    if (child.Parents.Count == 0)
                    {
                        nodes.Add(child);
                    }
                }
            }
        }
    }
}