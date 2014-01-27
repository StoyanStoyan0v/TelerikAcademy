using System;

class DaysDistance
{
    static int GetDistance(string first,string second)
    {
        string[] firstDate = first.Split(new char[] { '.', '/' }, StringSplitOptions.RemoveEmptyEntries);
        string[] secondDate=second.Split(new char[]{'.','/'},StringSplitOptions.RemoveEmptyEntries);
        DateTime validateFirst = new DateTime(int.Parse(firstDate[2]),int.Parse(firstDate[1]), int.Parse(firstDate[0]));
        DateTime validateSecond = new DateTime(int.Parse(secondDate[2]), int.Parse(secondDate[1]), int.Parse(secondDate[0]));
        int days = (int)(validateSecond - validateFirst).TotalDays;
        return days;
        
    }

    static void Main()
    {
        Console.Write("Enter the first date: ");
        string firstDate = Console.ReadLine();
        Console.Write("Enter the second date: ");
        string secondDate = Console.ReadLine();
        Console.WriteLine("Distance: {0} days. ",GetDistance(firstDate,secondDate));
    }
}

