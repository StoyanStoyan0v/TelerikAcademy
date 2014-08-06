namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class MonochromeVideocard : IVideoCard
    {
        private const bool IS_MONOCHROME = true;

        public bool IsMonochrome
        {
            get
            {
                return IS_MONOCHROME;
            }
        }

        public void Draw(string output)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }
}