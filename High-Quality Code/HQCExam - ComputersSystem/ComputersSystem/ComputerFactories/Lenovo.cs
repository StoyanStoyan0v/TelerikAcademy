namespace ComputersSystem.ComputerFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Lenovo : Manufacturer
    {
        public override Computer IntroducePC()
        {
            var hddInfo = new[] { new HardDriver(2000) };
            var computerInfo = new ComputerInfo(4, hddInfo, 2, 64);
            computerInfo.VideoCard = new ColorfullVideocard();
            return ComputerFactory.CreatePC(computerInfo);
        }

        public override Computer IntroduceLaptop()
        {
            var hddInfo = new[] { new HardDriver(1000) };
            var computerIfno = new ComputerInfo(16, hddInfo, 2, 64);
            computerIfno.VideoCard = new ColorfullVideocard();
            return ComputerFactory.CreateLaptop(computerIfno);
        }

        public override Computer IntroduceServer()
        {
            var hddInfo = new[] { new HardDriver(0, new List<HardDriver> { new HardDriver(500), new HardDriver(500) }) };
            var computerIfno = new ComputerInfo(8, hddInfo, 2, 128);
            computerIfno.VideoCard = new MonochromeVideocard();
            return ComputerFactory.CreateServer(computerIfno);
        }
    }
}