using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMTest
{
    public static class GSMTest
    {
        private static List<GSM> telephones = new List<GSM>();

        private static void AddPhone(params string[] info)
        {
            GSM firstGsm = new GSM(info[0], info[1]);
            firstGsm.Owner = info[2];
            firstGsm.Price = decimal.Parse(info[3]);
            firstGsm.BatteryInfo = new Battery((Battery.BatteryType)Enum.Parse(typeof(Battery.BatteryType), info[4]));
            firstGsm.BatteryInfo.IdleHours = int.Parse(info[5]);
            firstGsm.BatteryInfo.TalkHours = int.Parse(info[6]);
            firstGsm.DisplayInfo = new Display(int.Parse(info[8]), int.Parse(info[7]));
            telephones.Add(firstGsm);
        }

        public static void AddTestPhones()
        {
            AddPhone("Lumia", "Nokia", "Ilarion Garibaldi", "525.35", "1", "300", "16", "16000000", "5");
            AddPhone("Galaxy S4 mini", "Samsung", "Kebapcho Nadenichkov", "420.50", "2", "222", "10", "13329732", "6");
            AddPhone("Xperia tipo", "Sony", "Petar Cheh", "88.50", "1", "250", "12", "13000500", "4");
        }

        public static void PrintPhonesInfo()
        {
            foreach (GSM phone in telephones)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
            }
        }
    }
}
