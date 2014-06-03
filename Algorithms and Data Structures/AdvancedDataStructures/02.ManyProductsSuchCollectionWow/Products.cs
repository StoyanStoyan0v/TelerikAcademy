namespace ManyProductsSuchCollectionWow
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;
    
    class Products
    {
        private class PriceProductPair<K, V> : IComparable<PriceProductPair<K, V>> where K : IComparable<K>
        {
            public K Price { get; private set; }

            public V ProductName { get; private set; }

            public PriceProductPair(K price, V produceName)
            {
                this.Price = price;
                this.ProductName = produceName;
            }

            public int CompareTo(PriceProductPair<K, V> other)
            {
                return this.Price.CompareTo(other.Price);
            }

            public override string ToString()
            {
                return string.Format("[{0} {1}]", this.Price, this.ProductName);
            }
        }

        static void Main()
        {
            Stopwatch a = new Stopwatch();
            a.Start();

            OrderedBag<PriceProductPair<decimal, string>> products = new OrderedBag<PriceProductPair<decimal, string>>();

            for (int i = 1; i <= 500000; i++)
            {
                products.Add(new PriceProductPair<decimal, string>(i * i,"Product" + i));
            }

            var start = new PriceProductPair<decimal, string>(150000 * 4000m, "Product150000");
            var end = new PriceProductPair<decimal, string>(200000 * 4000m, "Product200000");
            var prods = products.Range(start, true, end, true);

            foreach (var item in prods)
            {
                Console.WriteLine(item);
            }

            a.Stop();           

            Console.WriteLine(a.Elapsed);
        }
    }
}