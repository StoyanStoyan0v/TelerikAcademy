using System;

class AstrologicalDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        
        int temmSum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '.' || number[i] =='-')
            {
                continue;
            }
            else
            {
                string x = number[i].ToString();
                temmSum += int.Parse(x);               
            }
        }

        while (temmSum > 9)
        {
            string x = temmSum.ToString();
            temmSum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                string a = x[i].ToString();
                temmSum += int.Parse(a);
            }
        }
        Console.WriteLine(temmSum);
    }
}

