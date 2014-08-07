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
        public Server() : this(new CPU(3, 4, new RandomAccessMemory(8)), new RandomAccessMemory(8), new[] { new HardDriver() },new MonochromeVideocard())
        {
        }

        public Server(ICpu cpu, IMemory memory, IEnumerable<IHardDriver> hardDriver, IVideoCard videoCard) : base(cpu, memory, hardDriver, new MonochromeVideocard())
        {
        }
        
        internal void Process(int data)
        {
            this.Memory.SaveValue(data);

            this.Cpu.RenderSquareNumber(this.VideoCard);
        }
        
    }
}