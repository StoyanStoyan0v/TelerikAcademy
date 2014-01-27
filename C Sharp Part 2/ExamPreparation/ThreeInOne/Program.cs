using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    
    class Program
    {
        static List<int> output = new List<int>();

        

        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            ThirdTaks();
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

       

        static void FirstTask()
        {
            string[] nums = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[nums.Length];
            int max = 0;
            int maxI = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].ToString());
                if (numbers[i] > max && numbers[i]<=21)
                {
                    max = numbers[i];
                    maxI = i;
                }
                
            }
            
            if (Array.IndexOf(numbers,max,maxI+1)==-1)
            {
                output.Add(maxI);
            }
            else
            {
                output.Add(-1);
            }
        }

        static void SecondTask()
        {
            string[] bitesAsArray = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            List<int> bites = new List<int>();
            foreach (string bite in bitesAsArray)
            {
                bites.Add(int.Parse(bite));
            }

            bites.Sort();
            int myBites = 0;
            for (int i = bites.Count-1; i >= 0; )
            {
                for (int j = 0; j <= n; j++)
                {
                    if(j==0)
                    {
                        myBites += bites[i];
                    }
                    i--;
                    if(i<0)
                    {
                        break;
                    }
                }
                
                if(i<0)
                {
                    break;
                }
            }
            output.Add(myBites);
        }

        static void ThirdTaks()
        {
            string[] money = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> yourMoney = new List<int>();
            List<int> price = new List<int>();
            yourMoney.Add(int.Parse(money[0]));
            yourMoney.Add(int.Parse(money[1]));
            yourMoney.Add(int.Parse(money[2]));
            price.Add(int.Parse(money[3]));
            price.Add(int.Parse(money[4]));
            price.Add(int.Parse(money[5]));

            int counter = 0;
            while (price[2] > yourMoney[2])
            {
                if (yourMoney[1] != 0)
                {
                    yourMoney[2] += 9;
                    yourMoney[1]--;
                    counter++;
                }
                else
                {
                    yourMoney[1] +=9;
                    yourMoney[0]--;
                    counter++;
                }
                
            }

            while(price[1]>yourMoney[1])
            {
                if (yourMoney[0] > 0)
                {
                    yourMoney[1] += 9;
                    yourMoney[0]--;
                    counter++;
                }
                else
                {
                    output.Add(-1);
                    return;
                }
            }

            if(price[0]<yourMoney[0])
            {
                output.Add(counter);
                return;
            }
            else
            {
                while (price[0] > yourMoney[0])
                {
                    if (yourMoney[1] >= price[1]+11)
                    {
                        yourMoney[0] ++;
                        yourMoney[1]-=11;
                        counter++;
                    }
                    else
                    {
                        yourMoney[1] ++;
                        yourMoney[2]-=11;
                        counter++;
                    }
                }                
            }

            if(price[2]>yourMoney[2])
            {
                output.Add(-1);
            }
            else
            {
                output.Add(counter);
            }

        }
    }
}
