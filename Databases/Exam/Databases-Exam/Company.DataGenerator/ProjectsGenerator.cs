namespace Company.DataGenerator
{
    using System;
    using System.Linq;
    using Company.Data;

    public class ProjectsGenerator : DataGenerator, IDataGenerator
    {
        public ProjectsGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int count) : base(randomGenerator,dbContext,count)
        {
        }

        public override void Generate()
        {
            var employees = this.Database.Employees.Select(e => e.Id).ToList();
            this.Logger.LogLine("Adding projects...");
            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project()
                {
                    ProjectName = this.Random.GetRandomStringWithRandomLength(5, 50),
                    StartingDate = DateTime.Now,
                    EndingDate = DateTime.Now.AddDays(this.Random.GetRandomNumber(10, 30)),
                };
                
                var employeesAssigned = this.Random.GetRandomNumber(2, 20);
                for (int j = 0; j < employeesAssigned; j++)
                {
                    var employeeId = employees[this.Random.GetRandomNumber(0, employees.Count - 1)];
                    var employee = this.Database.Employees.First(e => e.Id == employeeId);
                    
                    project.Employees.Add(employee);
                }

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Database.SaveChanges();
                }
                this.Database.Projects.Add(project);
            }
            this.Logger.LogLine();
            this.Logger.LogLine("Projects added...");
        }
    }
}