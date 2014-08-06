namespace ComputersSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class ColorfullVideocard : IVideoCard
    {
        private const bool IS_MONOCHROME = false;

        public bool IsMonochrome
        {
            get
            {
                return IS_MONOCHROME;
            }
        }

        public void Draw(string output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }
}