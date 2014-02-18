namespace BitArray
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    
    public class BitArray64 : IEnumerable<ulong>
    {
        public ulong Number { get; private set; }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong this[int num]
        {
            get
            {
                return (this.Number >> (63 - num)) & 1;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Number == (obj as BitArray64).Number;
        }

        public static bool operator ==(BitArray64 firstArray, BitArray64 secondArray)
        {
            return firstArray.Number == secondArray.Number;
        }

        public static bool operator !=(BitArray64 firstArray, BitArray64 secondArray)
        {
            return firstArray.Number != secondArray.Number;
        }

        public override int GetHashCode()
        {
            ulong code = this.Number;
            for (int i = 63; i >= 0; i--)
            {
                code ^= this.Number >> i;
            }

            return (int)code;
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            int i = 63;
            while (i >= 0)
            {
                yield return (this.Number >> i) & 1;
                i--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); 
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 64; i++)
            {
                result.Append((this.Number >> (63 - i)) & 1);
            }
            return result.ToString();
        }
    }
}