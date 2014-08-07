namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Laptop : Computer
    {
        // Dependency invertion...
        public Laptop() : this(new CPU(3, 4, new RandomAccessMemory(8)), new RandomAccessMemory(8), new[] { new HardDriver() }, new ColorfullVideocard())
        {
        }

        public Laptop(ICpu cpu, IMemory memory, IEnumerable<IHardDriver> hardDrives, IVideoCard videoCard) : base(cpu, memory, hardDrives, videoCard)
        {
            this.Battery = new LaptopBattery();
        }
        
        internal void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}%", this.Battery.Percentage));
        }
    }
}