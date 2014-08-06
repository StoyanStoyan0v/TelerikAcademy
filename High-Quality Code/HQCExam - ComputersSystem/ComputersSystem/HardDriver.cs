namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class HardDriver : IHardDriver
    {
        private readonly bool isInRaid;

        private readonly IList<HardDriver> hardDrives;
        
        private readonly int capacity;

        private readonly Dictionary<int, string> data;

        internal HardDriver()
        {
        }
        
        internal HardDriver(int capacity)
        {
            this.isInRaid = false;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
        }

        internal HardDriver(int capacity, IList<HardDriver> hardDrives)
        {
            this.isInRaid = true;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);

            this.hardDrives = hardDrives;
        }
        
        private int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hardDrives.Any())
                    {
                        return 0;
                    }

                    return this.hardDrives.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void SaveData(int address, string data)
        {
            if (this.isInRaid)
            {
                if (!this.data.ContainsKey(address))
                {
                    this.data.Add(address, data);
                }
            }

            // Composite pattern
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, data);
            }
        }
        
        public string LoadData(int address)
        {
            var data = this.data.First(x => x.Value != null).Value;
            if (data == null)
            {
                throw new ArgumentNullException("There is no RAID drive in this HDD!");
            }

            return data;
        }
    }
}