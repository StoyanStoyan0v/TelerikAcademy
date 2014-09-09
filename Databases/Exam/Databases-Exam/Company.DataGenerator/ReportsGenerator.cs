namespace Company.DataGenerator
{
    using System;
    using System.Linq;
    using Company.Data;

    public class ReportsGenerator : DataGenerator, IDataGenerator
    {
        public ReportsGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int count) : base(randomGenerator,dbContext,count)
        {
        }

        public override void Generate()
        {
            var employeesIds = this.Database.Employees.Select(e => e.Id).ToList();

            this.Logger.LogLine("Adding reports...");
            for (int i = 0; i < employeesIds.Count; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var report = new Report()
                    {
                        TimeOfRporting = DateTime.Now,
                        EmployeeId = employeesIds[i]
                    };
                    this.Database.Reports.Add(report);
                }

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Database.SaveChanges();
                }
            }
            this.Logger.LogLine();
            this.Logger.LogLine("Reports added...");
                
        }
    }
}