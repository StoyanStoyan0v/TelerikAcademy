using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMTest
{
    public class Battery
    {
        private BatteryType batteryModel;
        private int idleHours;
        private int hoursTalk;

        public Battery(BatteryType model)
        {
            this.batteryModel = model;
        }

        public int IdleHours
        {
            get { return this.idleHours; }
            set
            {
                if (value > 400 || value < 200)
                {
                    throw new ArgumentException("Idle time is outside of the normal boundaries [200...400].");
                }
                this.idleHours = value;
            }
        }

        public int TalkHours
        {
            get { return this.hoursTalk; }
            set
            {
                if (value > 30 || value < 6)
                {
                    throw new ArgumentException("Talkin time is outside of the normal boundaries [6...30].");
                }
                this.hoursTalk = value;

            }
        }

        public enum BatteryType
        {
            LiIon, NiMH, NiCd
        }

        public override string ToString()
        {
            return string.Format("Battery model: {0}\nIdle hours staying power: {1}h\nHours available for talking: {2}h",
                this.batteryModel, this.idleHours, this.hoursTalk);
        }
    }
}
