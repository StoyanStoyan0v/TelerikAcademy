namespace Company.DataGenerator
{
    using Company.Data;

    public class DepartmentsGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentsGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContext, int count) : base(randomGenerator,dbContext,count)
        {
        }
        
        public override void Generate()
        {
            this.Logger.LogLine("Adding departments...");

            for (int i = 0; i < this.Count; i++)
            {
                var department = new Department()
                {
                    DepartmentName = this.Random.GetRandomStringWithRandomLength(10, 50)
                };

                if (i % 25 == 0)
                {
                    this.Logger.Log(".");
                    this.Database.SaveChanges();
                }

                this.Database.Departments.Add(department);
            }
            this.Logger.LogLine();
            this.Logger.LogLine("Departaments added...");
        }
    }
}