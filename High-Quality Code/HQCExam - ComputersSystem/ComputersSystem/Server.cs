namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Server : Computer
    {
        // Dependency invertion...
        public Server()
            : this(new CPU(3, 4, new RandomAccessMemory(8)), new RandomAccessMemory(8), new[] { new HardDriver() })
        {
        }

        public Server(ICpu cpu, IMemory memory, IEnumerable<IHardDriver> hardDriver)
            : base(cpu, memory, hardDriver, new MonochromeVideocard())
        {
        }
    }
}