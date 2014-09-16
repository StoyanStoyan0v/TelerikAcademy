using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        static readonly SortedSet<string> set = new SortedSet<string>();
        static Frame[] frames;
        static bool[] used;
        static int counter = 0;
    
        static void Main(string[] args)
        {
            int framesCount = int.Parse(Console.ReadLine());
            frames = new Frame[framesCount];
            used = new bool[framesCount];
            for (int i = 0; i < framesCount; i++)
            {
                var frameDimensions = Console.ReadLine().Split(' ');
                frames[i] = new Frame(int.Parse(frameDimensions[0]), int.Parse(frameDimensions[1]));
            }
            Permutations(new Frame[framesCount], 0);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(counter.ToString());
            foreach (var item in set)
            {
                sb.AppendLine(item);
            }
            Console.WriteLine(sb.ToString());
        }

        static void Permutations(Frame[]result, int index)
        {
            if (index == result.Length)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < result.Length - 1; i++)
                {
                    sb.Append(result[i] + " | ");
                }
                sb.Append(result[result.Length - 1]);

                if (!set.Contains(sb.ToString()))
                {
                    counter++;
                    set.Add(sb.ToString());
                }
            }
            else
            {
                for (int i = 0; i < frames.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        result[index] = frames[i];
                        Permutations(result, index + 1);

                        result[index] = new Frame(frames[i].Heigth, frames[i].Width);
                        Permutations(result, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }

    public class Frame : IComparable<Frame>
    {
        public int Width { get; set; }

        public int Heigth { get; set; }

        public Frame(int width, int heigth)
        {
            this.Heigth = heigth;
            this.Width = width;
        }

        public int CompareTo(Frame other)
        {
            if (this.Width == this.Heigth)
            {
                return this.Heigth.CompareTo(other.Heigth);
            }
            else
            {
                return this.Width.CompareTo(other.Width);
            }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Width, this.Heigth);
        }
    }
}