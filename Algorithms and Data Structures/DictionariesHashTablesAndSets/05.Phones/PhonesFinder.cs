using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phones
{
    class PhonesFinder
    {
        static void Main(string[] args)
        {
            var entries = GetEntries();
            string[] commands = GetCommands();

            foreach (var command in commands)
            {
                ExecuteCommand(command, entries);
            }
        }
  
        private static void ExecuteCommand(string command, Dictionary<string, string[]> entries)
        {
            int openingBracket = command.IndexOf('(');
            int closingBracket = command.IndexOf(')');
            var args = command.Substring(openingBracket+1, closingBracket - openingBracket-1);

            if (command.Contains(','))
            {
                var argsAsArray=args.Split(',');
                argsAsArray[0] = argsAsArray[0].Trim();
                argsAsArray[1] = argsAsArray[1].Trim();
                Console.WriteLine("{0} from {1}: ", argsAsArray[0], argsAsArray[1]);

                foreach (var item in entries)
                {
                    if (item.Key.Contains(argsAsArray[0]) && item.Value[0] == argsAsArray[1])
                    {
                        Console.WriteLine(item.Value[1]);
                    }
                }
            }
            else
            {
                Console.WriteLine(args+": ");
                foreach (var item in entries)
                {
                    if (item.Key.Contains(args))
                    {
                        Console.WriteLine("Town: {0} | Phone number: {1}",item.Value[0],item.Value[1]);
                    }
                }
            }
            Console.WriteLine();
        }

        private static string[] GetCommands()
        {
            List<string> commands = new List<string>();
            StreamReader reader = new StreamReader("commands.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    commands.Add(line);
                    line = reader.ReadLine();
                }
            }

            return commands.ToArray();
        }

        private static Dictionary<string, string[]> GetEntries()
        {
            Dictionary<string, string[]> entries = new Dictionary<string, string[]>();
            StreamReader reader = new StreamReader("phones.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var infoParts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    infoParts[0] = infoParts[0].Trim();
                    infoParts[1] = infoParts[1].Trim();
                    infoParts[2] = infoParts[2].Trim();
                    if (entries.ContainsKey(infoParts[0]))
                    {
                        infoParts[0] += "." + new Random().Next(0, 500);
                    }
                    entries.Add(infoParts[0], new string[] { infoParts[1], infoParts[2] });
                    line = reader.ReadLine();
                }
            }

            return entries;
        }
    }
}