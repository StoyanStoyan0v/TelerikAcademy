namespace ComputersSystem.ComputerFactories
{
    using System;
    
    // Abstract factory...
    public abstract class Manufacturer
    {
        protected const int SIZE_BASE = 8;

        public abstract Laptop IntroduceLaptop();
       
        public abstract Server IntroduceServer();
        
        public abstract PersonalComputer IntroducePC();
    }
}