namespace _01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class FriendsOfPesho
    {
        private class Node : IComparable<Node>
        {
            public Node(int id)
            {
                this.Id = id;
            }

            public bool IsHospital { get; set; }

            public int Id { get; private set; }

            public long DijkstraDistance { get; set; }

            public int CompareTo(Node obj)
            {
                if (!(obj is Node))
                {
                    return -1;
                }

                return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
            }
        }
        
        private class Connection
        {
            public Connection(Node node, long distance)
            {
                this.Node = node;
                this.Distance = distance;
            }

            public Node Node { get; set; }

            public long Distance { get; set; }
        }

        private class PriorityQueue<T> where T : IComparable<T>
        {
            private T[] heap;

            private int index;
 
            public int Count
            {
                get
                {
                    return this.index - 1;
                }
            }
 
            public PriorityQueue()
            {
                this.heap = new T[16];
                this.index = 1;
            }
 
            public void Enqueue(T element)
            {
                if (this.index >= this.heap.Length - 1)
                {
                    IncreaseArray();
                }
 
                this.heap[this.index] = element;
 
                int childIndex = this.index;
                int parentIndex = childIndex / 2;
                this.index++;
 
                while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
                {
                    T swapValue = this.heap[parentIndex];
                    this.heap[parentIndex] = this.heap[childIndex];
                    this.heap[childIndex] = swapValue;
 
                    childIndex = parentIndex;
                    parentIndex = childIndex / 2;
                }
            }
 
            public T Dequeue()
            {
                T result = this.heap[1];
 
                this.heap[1] = this.heap[this.Count];
                this.index--;
 
                int rootIndex = 1;
 
                int minChild;
 
                while (true)
                {
                    int leftChildIndex = rootIndex * 2;
                    int rightChildIndex = rootIndex * 2 + 1;
 
                    if (leftChildIndex > this.index)
                    {
                        break;
                    }
                    else if (rightChildIndex > this.index)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                        {
                            minChild = leftChildIndex;
                        }
                        else
                        {
                            minChild = rightChildIndex;
                        }
                    }
 
                    if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                    {
                        T swapValue = this.heap[rootIndex];
                        this.heap[rootIndex] = this.heap[minChild];
                        this.heap[minChild] = swapValue;
 
                        rootIndex = minChild;
                    }
                    else
                    {
                        break;
                    }
                }
 
                return result;
            }
 
            public T Peek()
            {
                return this.heap[1];
            }
 
            private void IncreaseArray()
            {
                T[] copiedHeap = new T[this.heap.Length * 2];
 
                for (int i = 0; i < this.heap.Length; i++)
                {
                    copiedHeap[i] = this.heap[i];
                }
 
                this.heap = copiedHeap;
            }
        }

        private static IEnumerable<int> hospitals;

        private static Dictionary<Node, List<Connection>> graph;

        private static Dictionary<int, Node> uniqueNodes;

        static void Main(string[] args)
        {            
            BuildGraph();
            long minDistance = long.MaxValue;

            foreach (var item in hospitals)
            {
                uniqueNodes[item].IsHospital = true;
            }

            foreach (var hospitalId in hospitals)
            {
                DijkstraWithPriorityQueue(graph, uniqueNodes[hospitalId]);
                var currentMinDistance = GetCurrentSum();
                if (currentMinDistance < minDistance)
                {
                    minDistance = currentMinDistance;
                }
            }

            Console.WriteLine(minDistance);
        }

        private static long GetCurrentSum()
        {
            long sum = 0;
            foreach (var item in uniqueNodes)
            {
                if (!item.Value.IsHospital)
                {
                    sum += item.Value.DijkstraDistance;
                }
            }
            return sum;
        }

        private static void BuildGraph()
        {
            graph = new Dictionary<Node, List<Connection>>();
            uniqueNodes = new Dictionary<int, Node>();

            var mapInfo = Console.ReadLine().Split(' ');
            hospitals = Console.ReadLine().Split(' ').Select(x => int.Parse(x));

            var edges = int.Parse(mapInfo[1]);

            for (int i = 0; i < edges; i++)
            {
                var edgeInfo = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                var firstNode = edgeInfo[0];
                var secondNode = edgeInfo[1];
                var distance = edgeInfo[2];
                if (!uniqueNodes.ContainsKey(firstNode))
                {
                    Node firstUniqueNode = new Node(firstNode);
                    uniqueNodes.Add(firstNode, firstUniqueNode);
                }
 
                if (!uniqueNodes.ContainsKey(secondNode))
                {
                    Node secondUniqueNode = new Node(secondNode);
                    uniqueNodes.Add(secondNode, secondUniqueNode);
                }
 
                if (!graph.ContainsKey(uniqueNodes[firstNode]))
                {
                    graph.Add(uniqueNodes[firstNode], new List<Connection>());
                }
 
                if (!graph.ContainsKey(uniqueNodes[secondNode]))
                {
                    graph.Add(uniqueNodes[secondNode], new List<Connection>());
                }
 
                graph[uniqueNodes[firstNode]].Add(new Connection(uniqueNodes[secondNode], distance));
                graph[uniqueNodes[secondNode]].Add(new Connection(uniqueNodes[firstNode], distance));
            }
        }

        private static void DijkstraWithPriorityQueue(Dictionary<Node, List<Connection>> graph, Node source)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            source.DijkstraDistance = 0;           
            queue.Enqueue(source);
            
            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var neighbor in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                    if (potDistance < neighbor.Node.DijkstraDistance)
                    {
                        neighbor.Node.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbor.Node);
                    }
                }
            }
        }
    }
}