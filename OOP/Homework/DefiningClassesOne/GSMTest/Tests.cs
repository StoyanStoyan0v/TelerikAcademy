using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GSMTest
{
    public class GSMTest
    {
        public static List<GSM> telephones = new List<GSM>();

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
            AddPhone("Lumia", "Nokia", "Ilarion Garibaldi", "525.35", "LiIon", "300", "16", "16000000", "5");
            AddPhone("Galaxy S4 mini", "Samsung", "Kebapcho Nadenichkov", "420.50", "NiCd", "222", "10", "13329732", "6");
            AddPhone("Xperia tipo", "Sony", "Petar Cheh", "88.50", "NiMH", "250", "12", "13000500", "4");
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

    public class GSMCallHistoryTest
    {
        public static GSM phone = new GSM("OneX", "HTC");

        public static void AddTestCalls()
        {
            phone.AddCallsToHistory(DateTime.Now, "+359888123456", 312);
            phone.AddCallsToHistory(DateTime.Now.AddDays(5), "+359888654321", 32);
            phone.AddCallsToHistory(DateTime.Now.AddHours(6), "+359888888888", 154);
            phone.AddCallsToHistory(DateTime.Now.AddMinutes(45), "+359889889889", 15);
            phone.AddCallsToHistory(DateTime.Now.AddMonths(1), "+359876876678", 1200);
        }

        public static void PrintCallsHistory()
        {
            Console.WriteLine("Phone calls history: ");
            if(phone.CallHistory.Count>0)
            {
                for (int i = 0; i < phone.CallHistory.Count; i++)
                {
                    Console.WriteLine(i+1+"."+phone.CallHistory[i]);
                }
            }
            else
            {
                Console.WriteLine("The history is empty!");
            }
        }

        public static void PrintCostOfCalls()
        {
            Console.WriteLine("Cost of all calls: {0:C2}",phone.CalculatePriceOfCalls(0.37m));
        }

        public static void RemoveLongestCall()
        {
            int index = -1;
            for (int i = 0; i < phone.CallHistory.Count; i++)
            {
                int currentLongestDuration = -1;
                if (phone.CallHistory[i].Duration > currentLongestDuration)
                {
                    currentLongestDuration = phone.CallHistory[i].Duration;
                    index = i;
                }               
            }
            phone.DeleteCallsFromHistory(index, 1);
        }

    }

    class Tests 
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //First test
            GSMTest.AddTestPhones();
            GSMTest.PrintPhonesInfo();
            Console.WriteLine(GSM.IPhoneInfo);
            Console.WriteLine();

            //Second test
            GSMCallHistoryTest.AddTestCalls();           
            GSMCallHistoryTest.PrintCallsHistory();
            Console.WriteLine();
            GSMCallHistoryTest.PrintCostOfCalls();
            GSMCallHistoryTest.RemoveLongestCall();
            GSMCallHistoryTest.PrintCostOfCalls();
            Console.WriteLine();
            GSMCallHistoryTest.phone.ClearAllHistory();
            GSMCallHistoryTest.PrintCallsHistory();

        }
    }
}
