namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ComputerInfo
    {
        public ComputerInfo(int memoryValue, IEnumerable<IHardDriver> hardDrives, byte numberOfCpuCores, byte numberOfCpuBits)
        {
            this.Memory = new RandomAccessMemory(memoryValue);
            this.Cpu = new CPU(numberOfCpuCores, numberOfCpuBits, this.Memory);
            this.HardDrives = hardDrives;
        }

        public ICpu Cpu { get; private set; }

        public IMemory Memory { get; private set; }

        public IEnumerable<IHardDriver> HardDrives { get; private set; }

        public IVideoCard VideoCard { get; set; }

        public IBattery Battery { get; set; }
    }
}