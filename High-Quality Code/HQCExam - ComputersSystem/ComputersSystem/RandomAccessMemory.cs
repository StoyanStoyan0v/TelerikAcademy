namespace ComputersSystem
{
    public class RandomAccessMemory : IMemory
    {
        private int memoryValue;

        internal RandomAccessMemory(int memoryValue)
        {
            this.memoryValue = memoryValue;
        }
        
        public void SaveValue(int newValue)
        {
            this.memoryValue = newValue;
        }

        public int LoadValue()
        {
            return this.memoryValue;
        }
    }
}