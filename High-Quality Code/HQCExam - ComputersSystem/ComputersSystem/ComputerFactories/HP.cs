namespace ComputersSystem.ComputerFactories
{
    using System.Collections.Generic;
    using System.Linq;

    // Simple Factory
    public class HP : Manufacturer
    {
        public override PersonalComputer IntroducePC()
        {
            var hddInfo = new[] { new HardDriver(500) };
            var computerIfno = new ComputerInfo(2, hddInfo, 2, 32);
            computerIfno.VideoCard = new ColorfullVideocard();
            return ComputerFactory.CreatePC(computerIfno);
        }

        public override Laptop IntroduceLaptop()
        {
            var hddInfo = new[] { new HardDriver(500) };
            var computerIfno = new ComputerInfo(4, hddInfo, 2, 64);
            computerIfno.Battery = new LaptopBattery();
            computerIfno.VideoCard = new ColorfullVideocard();
            return ComputerFactory.CreateLaptop(computerIfno);
        }

        public override Server IntroduceServer()
        {
            var hddInfo = new[] { new HardDriver(0, new List<HardDriver> { new HardDriver(1000), new HardDriver(1000) }) };
            var computerIfno = new ComputerInfo(32, hddInfo, 4, 32);
            computerIfno.VideoCard = new MonochromeVideocard();
            return ComputerFactory.CreateServer(computerIfno);
        }
    }
}