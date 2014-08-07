namespace ComputersSystem.ComputerFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Simple factory..
    public static class ComputerFactory
    {
        public static Laptop CreateLaptop(ComputerInfo info)
        {
            return new Laptop(info.Cpu, info.Memory, info.HardDrives, info.VideoCard);
        }

        public static PersonalComputer CreatePC(ComputerInfo info)
        {
            return new PersonalComputer(info.Cpu, info.Memory, info.HardDrives, info.VideoCard);
        }

        public static Server CreateServer(ComputerInfo info)
        {
            return new Server(info.Cpu, info.Memory, info.HardDrives, info.VideoCard);
        }
    }
}