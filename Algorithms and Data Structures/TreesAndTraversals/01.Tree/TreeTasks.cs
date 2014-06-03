namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class TreeTasks
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            TreeNode<int>[] nodes = new TreeNode<int>[n];
         
            InitializeTree(n, nodes);
           
            //1.Find the root.
            var root = nodes.First((node) => !node.HasParent);
            Console.WriteLine("The root of the tree is: {0}", root.Value);            
            
            //2.Find the leaves.
            var leaves = nodes.Where((node) => node.Children.Count == 0);
            Console.WriteLine("The leaves of the tree are: {0}", string.Join(" ", leaves.Select((node) => node.Value)));

            //3. Find the middle nodes.
            var middleNodes = nodes.
            Where((node) => node.Children.Count > 0 && node.HasParent);
            Console.WriteLine("The root of the tree is {0}", string.Join(" ", middleNodes.Select((node) => node.Value)));

            var longestPath = GetLongestPath(root);
            Console.WriteLine("Longest path in the tree is {0} relations ({1} nodes).", longestPath, longestPath + 1);

            //4.Paths in the tree with given sum.
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine("Paths with sum {0}: ", s);
            GetPaths(root, s, 0, new Queue<int>());

            //4.Subtrees in the tree with given sum.
            s = int.Parse(Console.ReadLine());
            Console.WriteLine("Subtrees with nodes' sum {0}: ", s);
            GetSubTrees(root, s, 0, new Queue<int>());
        }

        private static void GetSubTrees(TreeNode<int> node, int s, int currentSum, Queue<int> nums)
        {
            currentSum += node.Value;
            nums.Enqueue(node.Value);

            if (currentSum >= s)
            {
                if (currentSum == s)
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
                if (node.Value == s)
                {
                    Console.WriteLine(node.Value);
                }
            }
            
            if (node.Children.Count == 0)
            {
                return;
            }

            foreach (var child in node.Children)
            {
                if (node.Value + child.Value >= s)
                {
                    var q = new Queue<int>();
                    q.Enqueue(node.Value);
                    GetSubTrees(child, s, node.Value, new Queue<int>(q));
                }
                else
                {
                    GetSubTrees(child, s, currentSum, new Queue<int>(nums));
                }
            }
        }

        private static void GetPaths(TreeNode<int> node, int s, int currentSum, Queue<int> nums)
        {
            currentSum += node.Value;
            nums.Enqueue(node.Value);
            
            if (node.Children.Count == 0)
            {
                if (currentSum == s)
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
                return;
            }

            foreach (var child in node.Children)
            {
                GetPaths(child, s, currentSum, new Queue<int>(nums));
            }
        }

        private static int GetLongestPath(TreeNode<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int size = 0;
            foreach (var child in node.Children)
            {
                size = Math.Max(size, GetLongestPath(child));
            }

            return size + 1;
        }

        private static void InitializeTree(int n, TreeNode<int>[] nodes)
        {
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }
            
            for (int i = 0; i < n - 1; i++)
            {
                string endNodesAsString = Console.ReadLine();
                string[] endNodes = endNodesAsString.Split(' ');

                int parent = int.Parse(endNodes[0]);
                int child = int.Parse(endNodes[1]);
                nodes[parent].Children.Add(nodes[child]);
                nodes[child].HasParent = true;
            }
        }
    }
}