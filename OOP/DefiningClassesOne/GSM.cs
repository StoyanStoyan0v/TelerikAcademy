using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMTest
{
    public class GSM
    {
        //Fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string ownerName;
        private Battery batteryCharacteristics;
        private Display displayCharacteristics;
        private static GSM iPhone=new GSM("Iphone4S","Apple");
        private List<Call> callHistory = new List<Call>();
        
        //Constructor
        public GSM (string model, string manufacturer)
        {           
            this.model = model;
            this.manufacturer = manufacturer;
        }

        //Properties
        public static GSM IPhoneInfo
        {
            get { InitializeIphoneInfo(); return iPhone; }            
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The device price cannot be a negative number!");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get { return this.ownerName; }
            set { this.ownerName = value; }
        }

        public Battery BatteryInfo
        {
            get { return this.batteryCharacteristics; }
            set
            {
                this.batteryCharacteristics = value;
            }
        }

        public Display DisplayInfo
        {
            get { return this.displayCharacteristics; }
            set
            {
                this.displayCharacteristics = value;
            }
        }

        public List<Call> Calls
        {
            get { return this.callHistory; }
        }

        //Methods
        public void AddCallsToHistory(DateTime date, string number, int duration )
        {
            Call newCall = new Call(date, number, duration);
            callHistory.Add(newCall);
        }

        public void DeleteCallsFromHistory(int startIndex, int length)
        {
            callHistory.RemoveRange(startIndex, length);
        }

        public void ClearAllHistory()
        {
            callHistory.Clear();
        }

        public decimal CalculatePriceOfCalls(decimal pricePerMin)
        {
            decimal price = 0.0m;

            foreach (Call call in callHistory)
            {
                price += (call.Duration / 60) * pricePerMin;
                if(call.Duration%50>0)
                {
                    price += pricePerMin;
                }
            }

            return price;
        }       

        public override string ToString()
        {
            return string.Format("Phone info:\nManufacturer: {0}\nModel: {1}\nPrice: {2:C2}\nOwner: {3}\nBattery info:\n{4}\nDisplay info:\n{5}",
                this.manufacturer, this.model, this.price, this.ownerName,this.batteryCharacteristics, this.displayCharacteristics);
        }

        private static void InitializeIphoneInfo()
        {
            iPhone.BatteryInfo = new Battery(Battery.BatteryType.NiMH);
            iPhone.batteryCharacteristics.IdleHours = 300;
            iPhone.batteryCharacteristics.TalkHours = 10;
            iPhone.displayCharacteristics = new Display(5, 15390232);
            iPhone.ownerName = "Stamat Georgiev";
            iPhone.price = 600m;
        }
    }
}
