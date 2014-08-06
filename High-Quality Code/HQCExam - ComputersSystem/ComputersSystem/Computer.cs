namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Computer : IMotherboard
    {
        internal Computer(ICpu cpu, IMemory ram, IEnumerable<IHardDriver> hardDrives, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Memory = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;            
        }

        public IVideoCard VideoCard { get; set; }

        public IBattery Battery { get; set; }

        public ICpu Cpu { get; set; }

        public IMemory Memory { get; set; }

        protected IEnumerable<IHardDriver> HardDrives { get; set; }

        public void Play(int guessNumber)
        {
            this.Cpu.SaveRandomNumberToRam(1, 10);
            var number = this.Memory.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }

        internal void Process(int data)
        {
            this.Memory.SaveValue(data);

            this.Cpu.RenderSquareNumber(this.VideoCard);
        }

        internal void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}%", this.Battery.Percentage));
        }
    }
}