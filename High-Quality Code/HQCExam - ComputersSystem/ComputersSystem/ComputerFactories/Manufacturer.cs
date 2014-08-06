namespace ComputersSystem.ComputerFactories
{
    using System;
    
    // Abstract factory...
    public abstract class Manufacturer
    {
        protected const int SIZE_BASE = 8;

        public abstract Computer IntroduceLaptop();
       
        public abstract Computer IntroduceServer();
        
        public abstract Computer IntroducePC();
    }
}