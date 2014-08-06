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
        public static Computer CreateLaptop(ComputerInfo info)
        {
            return new Laptop(info.Cpu, info.Memory, info.HardDrives, info.VideoCard);
        }

        public static Computer CreatePC(ComputerInfo info)
        {
            return new Laptop(info.Cpu, info.Memory, info.HardDrives, info.VideoCard);
        }

        public static Computer CreateServer(ComputerInfo info)
        {
            return new Laptop(info.Cpu, info.Memory, info.HardDrives, info.VideoCard);
        }
    }
}