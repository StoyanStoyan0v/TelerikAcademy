namespace ComputersSystem
{
    using System;
    
    internal class CPU : ICpu
    {
        private const byte CPU_BITS_32 = 32;

        private const byte CPU_BITS_64 = 64;

        private const byte CPU_BITS_128 = 128;

        private static readonly Random Random = new Random();

        private readonly byte numberOfBits;

        private readonly IMemory ram;

        internal CPU(byte numberOfCores, byte numberOfBits, IMemory ram)
        {
            this.numberOfBits = numberOfBits;
            this.ram = ram;
        }

        // Strategy pattern...
        public void RenderSquareNumber(IVideoCard videoCard)
        {
            if (this.numberOfBits == CPU_BITS_32)
            {
                this.RenderSquareNumber(videoCard, 500);
            }

            if (this.numberOfBits == CPU_BITS_64)
            {
                this.RenderSquareNumber(videoCard, 1000);
            }

            if (this.numberOfBits == CPU_BITS_128)
            {
                this.RenderSquareNumber(videoCard, 2000);
            }
        }

        public void SaveRandomNumberToRam(int minNumber, int maxNumber)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= minNumber && randomNumber <= maxNumber));
            this.ram.SaveValue(randomNumber);
        }

        // Strategy pattern..
        private void RenderSquareNumber(IVideoCard videoCard, int max)
        {
            var numberData = this.ram.LoadValue();
            if (numberData < 0)
            {
                videoCard.Draw("Number too low.");
            }
            else if (numberData > max)
            {
                videoCard.Draw("Number too high.");
            }
            else
            {
                int squareNumber = numberData * numberData;

                // Bottleneck: loop fo multiplication is too slow...
                // for (int i = 0; i < data; i++)
                // {
                //    squareNumber += numberData;
                // }
                videoCard.Draw(string.Format("Square of {0} is {1}.", numberData, squareNumber));
            }
        }

        private void RenderSquareNumber128(IVideoCard videoCard)
        {
            throw new NotImplementedException();
        }
    }
}