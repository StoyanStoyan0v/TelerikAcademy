namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonalComputer : Computer
    {
        // Dependency invertion...
        public PersonalComputer()
            : this(new CPU(3, 4, new RandomAccessMemory(8)), new RandomAccessMemory(8), new[] { new HardDriver() }, new ColorfullVideocard())
        {
        }

        public PersonalComputer(ICpu cpu, IMemory memory, IEnumerable<IHardDriver> hardDrives, IVideoCard videoCard)
            : base(cpu, memory, hardDrives, videoCard)
        {
        }
    }
}