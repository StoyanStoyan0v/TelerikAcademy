namespace Company.DataGenerator
{   
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    public class EmployeesGenerator : DataGenerator, IDataGenerator
    {
        public EmployeesGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int count) : base(randomGenerator,dbContext,count)
        {
        }

        public override void Generate()
        {
            var departamentIds = this.Database.Departments.Select(d => d.Id).ToList();
            List<int> firstEmployees = null;
            this.Logger.LogLine("Adding employees...");
            for (int i = 0; i < this.Count; i++)
            {
                var employee = new Employee()
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    YearSalary = this.Random.GetRandomNumber(50000, 200000),
                    DepartmentId = departamentIds[this.Random.GetRandomNumber(0, departamentIds.Count - 1)]
                };
                
                if (i > 200)
                {
                    if (firstEmployees == null)
                    {
                        firstEmployees = this.Database.Employees.Select(e => e.Id).ToList();
                    }
                    employee.ManagerId = firstEmployees[this.Random.GetRandomNumber(0, firstEmployees.Count - 1)];
                }

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Database.SaveChanges();
                }
                this.Database.Employees.Add(employee);
            }
            this.Logger.LogLine();
            this.Logger.LogLine("Employees added...");
        }
    }
}