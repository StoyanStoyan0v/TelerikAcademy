using SubstringSearcherConsumer.SubstringSearcherServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearcherConsumer
{
    class Consumer
    {
        static void Main(string[] args)
        {
            SubstringSearcherClient client = new SubstringSearcherClient();
            var count = client.GetSubstringCount("watch","Three witches watch three Swatch watches. Which Swatch watch which witch watches?");
            Console.WriteLine(count);
        }
    }
}
