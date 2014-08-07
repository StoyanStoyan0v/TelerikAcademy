namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Computer : IMotherboard
    {
        internal Computer(ICpu cpu, IMemory ram, IEnumerable<IHardDriver> hardDrives, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Memory = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;            
        }

        public IBattery Battery { get; set; }

        public ICpu Cpu { get; set; }

        public IMemory Memory { get; set; }

        protected IVideoCard VideoCard { get; set; }

        protected IEnumerable<IHardDriver> HardDrives { get; set; }
    }
}