using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    class Program
    {
        private class Product :  IComparable<Product>
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Manufacturer { get; set; }

            public Product(string name, string price, string manufacturer)
            {
                this.Name = name;
                this.Price = decimal.Parse(price);
                this.Manufacturer = manufacturer;
            }

            public int CompareTo(Product other)
            {
                return this.ToString().CompareTo(other.ToString());
            }

        
            public override string ToString()
            {
                return "{" + string.Format("{0};{1};{2:F}", this.Name, this.Manufacturer, this.Price) + "}";
            }
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

        private static readonly StringBuilder output = new StringBuilder();

        static void Main()
        {
            var setOfProducts = new OrderedBag<Product>();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandLine = Console.ReadLine();
                var firstSpace = commandLine.IndexOf(' ');
                var command = commandLine.Substring(0, firstSpace);
                var args = commandLine.Substring(firstSpace).Split(';');
                if (command == "AddProduct")
                {
                    var name = args[0].Trim();
                    var price = args[1].Trim();
                    var manufacturer = args[2].Trim();
                    setOfProducts.Add(new Product(name, price, manufacturer));
                    output.AppendLine("Product added");
                }
                else if (command == "DeleteProducts")
                {
                    if (args.Length == 1)
                    {
                        var manufacturer = args[0].Trim();
                        var deleted = setOfProducts.RemoveAll(p => p.Manufacturer == manufacturer);
                        GetDeletedMessage(deleted.Count);
                    }
                    else
                    {
                        var name = args[0].Trim();
                        var manufacturer = args[1].Trim();
                        var deleted = setOfProducts.RemoveAll(p => p.Manufacturer == manufacturer && p.Name == name);
                        GetDeletedMessage(deleted.Count);
                    }
                }
                else if (command == "FindProductsByName")
                {
                    var name = args[0].Trim();
                    var productsByName = setOfProducts.Where(x => x.Name == name);
                    GetItemsMessage(productsByName);
                }
                else if (command == "FindProductsByPriceRange")
                {
                    var fromPrice = decimal.Parse(args[0].Trim());
                    var toPrice = decimal.Parse(args[1].Trim());
                    var productsInPriceRange = setOfProducts.Where(p => fromPrice <= p.Price && p.Price <= toPrice);
                    GetItemsMessage(productsInPriceRange);
                }
                else if (command == "FindProductsByProducer")
                {
                    var manufacturer = args[0].Trim();
                    var productsByManufacturer = setOfProducts.Where(x => x.Manufacturer == manufacturer);
                    GetItemsMessage(productsByManufacturer);
                }
            }
            Console.WriteLine(output.ToString());
        }

        private static void GetItemsMessage(IEnumerable<Product> products)
        {
            if (products.Count() == 0)
            {
                output.AppendLine("No products found");
            }
            else
            {
                output.AppendLine(string.Join(Environment.NewLine, products));
            }
        }

        private static void GetDeletedMessage(int deleted)
        {
            if (deleted == 0)
            {
                output.AppendLine("No products found");
            }
            else
            {
                output.AppendLine(deleted + " products deleted");
            }
        }
    }
}