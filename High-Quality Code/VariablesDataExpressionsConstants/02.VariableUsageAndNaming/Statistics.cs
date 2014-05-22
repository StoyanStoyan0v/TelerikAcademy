namespace VariableUsageAndNaming
{
    using System;

    public class Statistics
    {
        public void PrintStatistics(double[] stats, int statsCount)
        {
            if (statsCount > stats.Length)
            {
                statsCount = stats.Length;
            }

            double maxStat = 0;

            for (int i = 0; i < statsCount; i++)
            {
                if (stats[i] > maxStat)
                {
                    maxStat = stats[i];
                }
            }
            PrintMaxStat(maxStat);
            
            double minStat = 0;
            for (int i = 0; i < statsCount; i++)
            {
                if (stats[i] < minStat)
                {
                    minStat = stats[i];
                }
            }
            PrintMinStat(minStat);

            double statsSum = 0;
            for (int i = 0; i < statsCount; i++)
            {
                statsSum += stats[i];
            }
            PrintAvgStat(statsSum / statsCount);
        }
  
        private void PrintAvgStat(double statsCount)
        { 
            throw new NotImplementedException();
        }

        private void PrintMinStat(double minStat)
        {
            throw new NotImplementedException();
        }

        private void PrintMaxStat(double maxStat)
        {
            throw new NotImplementedException();
        }
    }
}