namespace KnapsackProblem
{
    internal class Product
    {
        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Cost { get; private set; }

        public Product(string name, int weigth, int cost)
        {
            this.Name = name;
            this.Weight = weigth;
            this.Cost = cost;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((this.Name != null) ? this.Name.GetHashCode() : 0);
                result = result * 23 + this.Weight.GetHashCode();
                result = result * 23 + this.Cost.GetHashCode();
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals((obj as Product).Name);
        }

        public override string ToString()
        {
            return string.Format("Name: {0,7} | Weight: {1,2} | Cost: {2,2}", this.Name, this.Weight, this.Cost);
        }
    }
}