namespace Company.DataGeneratorClient
{
    using System.Collections.Generic;
    using Company.Data;
    using Company.DataGenerator;

    internal class Generator
    {
        private static void Main(string[] args)
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var generators = new List<IDataGenerator>()
            {
                new DepartmentsGenerator(random,db,100),
                new EmployeesGenerator(random,db,5000),
                new ProjectsGenerator(random,db,5000),
                new ReportsGenerator(random,db,0)
            };

            foreach (var generator in generators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}