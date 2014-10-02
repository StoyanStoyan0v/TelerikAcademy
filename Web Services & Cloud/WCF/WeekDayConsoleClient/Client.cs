using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekDayConsoleClient.WeekDayServiceReference;

namespace WeekDayConsoleClient
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date time in this format (mm/dd/yyyy):");
            DateTime date = DateTime.Now ;
            try
            {
                string dateAsStr = Console.ReadLine();
                date = DateTime.Parse(dateAsStr);               
                WeekDayClient client = new WeekDayClient();
                var result = client.GetDay(date);
                Console.WriteLine(result);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid datetime format");
            }
        }
    }
}