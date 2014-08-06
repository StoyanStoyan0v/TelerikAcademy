namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface IBattery
    {
        int Percentage { get; set; }

        void Charge(int p);
    }
}