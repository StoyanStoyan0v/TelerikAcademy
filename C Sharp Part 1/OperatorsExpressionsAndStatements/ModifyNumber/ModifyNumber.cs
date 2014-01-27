using System;

class ModifyNumber
{
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());       
        Console.Write("p= ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("v(0 or 1)= ");
        byte v = byte.Parse(Console.ReadLine());
        int newN = 0;
        if (v == 1)
        {
            if (n >> p == 1)
            {
                Console.WriteLine("The {0} bit is already 1.", p);
            }
            else
            {
                int mask = v << p;
                newN = n | mask;
                Console.WriteLine("New number= {0}. ", newN);
            }
        }
        else
        {
            if (n >> p == 0)
            {
                Console.WriteLine("The {0} bit is already 0.", p);
            }
            else
            {
                newN &=~(1<<p) ;
                Console.WriteLine("new number= {0}. ",newN);                
            }
        }
        Console.WriteLine("Binary(old): {0}", Convert.ToString(n, 2).PadLeft(32, '0'));
        Console.WriteLine("Binary(new): {0}", Convert.ToString(newN, 2).PadLeft(32, '0'));
    }
}

