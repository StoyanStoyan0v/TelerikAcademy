using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GSMTest
{      
    class Tests 
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;

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
            Console.WriteLine("Longest call removed! The price of the ramining calls recalculated!");
            GSMCallHistoryTest.PrintCostOfCalls();
            Console.WriteLine();
            GSMCallHistoryTest.TestPhone.ClearAllHistory();
            GSMCallHistoryTest.PrintCallsHistory();

        }
    }
}
