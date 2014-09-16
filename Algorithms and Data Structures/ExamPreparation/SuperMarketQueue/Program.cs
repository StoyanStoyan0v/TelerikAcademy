using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace SuperMarketQueue
{
    internal class Program
    {
        static BigList<string> queue = new BigList<string>();
        static Dictionary<string, int> count = new Dictionary<string, int>();
        static StringBuilder sb = new StringBuilder();
        static StringBuilder output = new StringBuilder();

        private static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                sb.Append(command);
                if (Eat("Append "))
                {
                    queue.Add(sb.ToString());
                    IncreaseCount(sb.ToString());
                    output.AppendLine("OK");
                }

                if (Eat("Insert "))
                {
                    var position = int.Parse(sb.ToString().Split(' ')[0]);
                    if (position >= queue.Count)
                    {
                        if (position == queue.Count)
                        {
                            queue.Add(sb.ToString().Split(' ')[1]);
                            output.AppendLine("OK");
                            IncreaseCount(sb.ToString().Split(' ')[1]);
                        }
                        else
                        {
                            output.AppendLine("Error");
                        }
                    }
                    else
                    {
                        queue.Insert(position, sb.ToString().Split(' ')[1]);
                        output.AppendLine("OK");
                        IncreaseCount(sb.ToString().Split(' ')[1]);
                    }
                }

                if (Eat("Find "))
                {
                    if (!count.ContainsKey(sb.ToString()))
                    {
                        output.AppendLine("0");
                    }
                    else
                    {
                        output.AppendLine(count[sb.ToString()].ToString());
                    }
                }

                if (Eat("Serve "))
                {
                    int count = int.Parse(sb.ToString());

                    if (count > queue.Count)
                    {
                        output.AppendLine("Error");
                    }
                    else
                    {
                        var names = new string[count];
                        for (int i = 0; i < count; i++)
                        { 
                            Program.count[queue[i]]--;  
                            names[i] = queue[i];
                        }

                        queue.RemoveRange(0, count);
                        output.AppendLine(string.Join(" ", names));
                    }
                }

                sb.Clear();
                command = Console.ReadLine();
            }

            Console.WriteLine(output);
        }

        static void IncreaseCount(string name)
        {
            if (!count.ContainsKey(name))
            {
                count[name] = 0;
            }
            count[name]++;
        }

        static bool Eat(string what)
        {
            for (int ii = 0; ii < what.Length; ++ii)
            {
                if (sb[ii] != what[ii])
                {
                    return false;
                }
            }
            sb.Remove(0, what.Length);
            return true;
        }
    }
}