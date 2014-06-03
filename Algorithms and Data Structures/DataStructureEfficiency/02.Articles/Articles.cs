using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Articles
{
    class Articles
    {
        private class Article
        {
            public string Title { get; private set; }

            public int Barcode { get; private set; }

            public string Vendor { get; set; }

            public decimal Price { get; private set; }

            public Article(string title, int barcode, decimal price)
            {
                this.Title = title;
                this.Barcode = barcode;
                this.Price = price;
            }

            public override string ToString()
            {
                return this.Barcode + "  " + this.Title + "  " + (this.Vendor != null ? this.Vendor : string.Empty);
            }
        }

        private static readonly OrderedMultiDictionary<decimal, string> articles = new OrderedMultiDictionary<decimal, string>(true);

        static void Main(string[] args)
        {
            int articlesCount = 100000;
            FillDictionary(articlesCount);

            decimal searchPriceStart = 100m;
            decimal searchPriceEnd = 100m;
            GetArticlesInPriceRange(searchPriceStart, searchPriceEnd);
        }
  
        private static void GetArticlesInPriceRange(decimal startPrice, decimal endPrice)
        {
            foreach (var item in articles)
            {
                if (startPrice <= item.Key && item.Key <= endPrice)
                {
                    Console.WriteLine("Price: {0:C2} -> {1} product(s)\n{2}", item.Key, item.Value.Count, string.Join("\n", item.Value));
                    Console.WriteLine();
                }
            }
        }

        private static void FillDictionary(int elementsCount)
        {
            for (int i = 1; i <= elementsCount; i++)
            {
                Article article = new Article("Article" + i, i, (decimal)new Random(i).Next(10000));
                if (i % 2 == 0)
                {
                    article.Vendor = "Vendor" + i;
                }
                articles.Add(article.Price, article.ToString());
            }
        }
    }
}