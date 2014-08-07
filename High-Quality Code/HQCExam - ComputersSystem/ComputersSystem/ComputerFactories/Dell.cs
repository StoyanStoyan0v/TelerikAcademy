namespace ComputersSystem.ComputerFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComputersSystem;

    public class Dell : Manufacturer
    {
        public override PersonalComputer IntroducePC()
        {
            var hddInfo = new[] { new HardDriver(1000) };
            var computerInfo = new ComputerInfo(8, hddInfo, 4, 64);
            computerInfo.VideoCard = new ColorfullVideocard();
            return ComputerFactory.CreatePC(computerInfo);
        }

        public override Laptop IntroduceLaptop()
        {
            var hddInfo = new[] { new HardDriver(1000) };
            var computerIfno = new ComputerInfo(8, hddInfo, 4, 32);
            computerIfno.VideoCard = new ColorfullVideocard();
            return ComputerFactory.CreateLaptop(computerIfno);
        }

        public override Server IntroduceServer()
        {
            var hddInfo = new[] { new HardDriver(0, new List<HardDriver> { new HardDriver(2000), new HardDriver(2000) }) };
            var computerIfno = new ComputerInfo(64, hddInfo, 8, 64);
            computerIfno.VideoCard = new MonochromeVideocard();
            return ComputerFactory.CreateServer(computerIfno);
        }
    }
}