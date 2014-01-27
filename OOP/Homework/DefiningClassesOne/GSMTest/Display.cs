using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMTest
{
    public class Display
    {
        private int size;
        private int colours;

        public Display(int size, int colours)
        {
            if (size < 4 || size > 10)
            {
                throw new ArgumentException("Invalid size. It should be in the range [4...10] inches.");
            }

            if (colours < 1 || colours > 20000000)
            {
                throw new ArgumentException("Invalid size. It should be in the range [1...20 000 000] colours.");
            }
            this.size = size;
            this.colours = colours;
        }

        public int Size
        {
            get { return this.size; }
            set
            {
                if (value < 4 || value > 10)
                {
                    throw new ArgumentException("Invalid size. It should be in the range [4...10] inches.");
                }

                this.size = value;
            }
        }

        public int Colours
        {
            get { return this.colours; }
            set
            {
                if (value < 1 || value > 20000000)
                {
                    throw new ArgumentException("Invalid size. It should be in the range [1...20 000 000] colours.");
                }

                this.colours = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Display size: {0} inches\nDisplay colours: {1} colours",
                this.size, this.colours);
        }
    }
}
