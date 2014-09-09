namespace Company.DataGenerator
{
    using Company.Data;

    public abstract class DataGenerator : IDataGenerator
    {
        public DataGenerator(IRandomDataGenerator randomGenerator, CompanyEntities dbContex, int count)
        {
            this.Random = randomGenerator;
            this.Database = dbContex;
            this.Count = count;
            this.Logger = new ConsoleLogger();
        }

        protected ILogger Logger { get; private set; }

        protected IRandomDataGenerator Random { get; private set; }

        protected CompanyEntities Database { get; private set; }

        protected int Count { get; private set; }

        public abstract void Generate();
    }
}