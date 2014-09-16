using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OnlineMarket
{
    public static class DecimalExtensions
    {
        public static Decimal Normalize(this Decimal value)
        {
            return value / 1.000000000000000000000000000000000m;
        }
    }

    class Program
    {
        private class Product:IComparable<Product>
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Type { get; set; }

            public Product(string name, decimal price, string type)
            {
                this.Name = name;
                this.Price = price;
                this.Type = type;
            }

            public override string ToString()
            {
                return string.Format("{0}({1})", this.Name, this.Price.Normalize());
            }

            public int CompareTo(Product other)
            {
                if (this.Price == other.Price)
                {
                    if (this.Name == other.Name)
                    {
                        return this.Type.CompareTo(other.Type);
                    }
                    else
                    {
                        return this.Name.CompareTo(other.Name);
                    }
                }
                else
                {
                    return this.Price.CompareTo(other.Price);
                }
            }
        }

        static void Main()
        {
            var productsByType = new OrderedMultiDictionary<string, Product>(true);
            var productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
            var productsByName = new HashSet<string>();

            var output = new StringBuilder();

            var command = Console.ReadLine();
            while (command != "end")
            {
                var commandEnd = command.IndexOf(' ');
                var commandName = command.Substring(0, commandEnd);
                var argumentsAsString = command.Substring(commandEnd + 1);
                if (commandName == "add")
                {
                    var arguments = argumentsAsString.Split(' ');
                    var name = arguments[0];
                    var price = decimal.Parse(arguments[1]);
                    var type = arguments[2];
                    var product = new Product(name,price,type);
                    if (productsByName.Contains(name))
                    {
                        output.AppendLine("Error: Product " + name + " already exists");
                    }
                    else
                    {
                        productsByName.Add(name);
                        output.AppendLine("Ok: Product " + name + " added successfully");
                        productsByType.Add(type, product);
                        productsByPrice.Add(price, product);
                    }
                }
                else
                {
                    if (argumentsAsString.Contains("from") && argumentsAsString.Contains("to"))
                    {
                        output.Append("Ok: ");
                        var whitespace = command.LastIndexOf(' ');
                        var toPrice = decimal.Parse(command.Substring(whitespace + 1));
                        whitespace = command.IndexOf("from") + 5;
                        var fromPrice = decimal.Parse(command.Substring(whitespace, command.IndexOf("to") - whitespace));
                        var products = productsByPrice.Where(x => x.Key >= fromPrice && x.Key <= toPrice);
                        if (products.Count() != 0)
                        {
                            int i = 1;
                            foreach (var item in products)
                            {
                                foreach (var v in item.Value)
                                {
                                    output.Append(v + ", ");
                                    i++;
                                    if (i == 11)
                                    {
                                        break;
                                    }
                                }
                                if (i == 11)
                                {
                                    break;
                                }
                            }
                            output.Remove(output.Length - 2, 2);
                        }
                        output.AppendLine();
                    }
                    else if (argumentsAsString.Contains("from"))
                    {
                        output.Append("Ok: ");
                        var whitespace = command.LastIndexOf(' ');
                        var price = decimal.Parse(command.Substring(whitespace + 1));
                        var products = productsByPrice.Where(x => x.Key >= price);
                        if (products.Count() != 0)
                        {
                            int i = 1;
                            foreach (var item in products)
                            {
                                foreach (var v in item.Value)
                                {
                                    output.Append(v + ", ");
                                    i++;
                                    if (i == 11)
                                    {
                                        break;
                                    }
                                }
                                if (i == 11)
                                {
                                    break;
                                }
                            }
                            output.Remove(output.Length - 2, 2);
                        }
                        output.AppendLine();
                    }
                    else if (argumentsAsString.Contains("to"))
                    {
                        output.Append("Ok: ");
                        var whitespace = command.LastIndexOf(' ');
                        var price = decimal.Parse(command.Substring(whitespace + 1));
                        var products = productsByPrice.Where(x => x.Key <= price);
                        if (products.Count() != 0)
                        {
                            int i = 1;
                            foreach (var item in products)
                            {
                                foreach (var v in item.Value)
                                {
                                    output.Append(v + ", ");
                                    i++;
                                    if (i == 11)
                                    {
                                        break;
                                    }
                                }
                                if (i == 11)
                                {
                                    break;
                                }
                            }
                            output.Remove(output.Length - 2, 2);
                        }
                        output.AppendLine();
                    }
                    else if (argumentsAsString.Contains("type"))
                    {
                        var whitespace = command.LastIndexOf(' ');
                        var type = command.Substring(whitespace + 1);
                        if (!productsByType.ContainsKey(type))
                        {
                            output.AppendLine("Error: Type " + type + " does not exists");
                        }
                        else
                        {
                            output.Append("Ok: ");

                            var products = productsByType[type];
                            if (products.Count != 0)
                            {
                                int i = 1;
                                foreach (var item in products)
                                {
                                    output.Append(item + ", ");
                                    i++;
                                    if (i == 11)
                                    {
                                        break;
                                    }
                                }
                                output.Remove(output.Length - 2, 2);
                            }
                            output.AppendLine();
                        }
                    }
                    else
                    {
                        output.AppendLine();
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(output.ToString());
        }
    }
}