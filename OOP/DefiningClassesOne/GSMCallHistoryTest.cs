using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMTest
{
    public static class GSMCallHistoryTest
    {
        private static GSM phone = new GSM("OneX", "HTC");

        public static GSM TestPhone
        {
            get { return phone; }
        }

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
            if (phone.Calls.Count > 0)
            {
                for (int i = 0; i < phone.Calls.Count; i++)
                {
                    Console.WriteLine(i + 1 + "." + phone.Calls[i]);
                }
            }
            else
            {
                Console.WriteLine("The history is empty!");
            }
        }

        public static void PrintCostOfCalls()
        {
            Console.WriteLine("Cost of all calls: {0:C2}", phone.CalculatePriceOfCalls(0.37m));
        }

        public static void RemoveLongestCall()
        {
            int index = -1;
            for (int i = 0; i < phone.Calls.Count; i++)
            {
                int currentLongestDuration = -1;
                if (phone.Calls[i].Duration > currentLongestDuration)
                {
                    currentLongestDuration = phone.Calls[i].Duration;
                    index = i;
                }
            }
            phone.DeleteCallsFromHistory(index, 1);
        }


    }
}
