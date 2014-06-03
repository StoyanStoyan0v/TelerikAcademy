namespace BiDictionary
{
    public class Triple<K1, K2, V> 
    {
        public K1 Key1 { get; private set; }

        public K2 Key2 { get; private set; }

        public V Value { get; private set; }

        public Triple(K1 key1, V value) 
        {
            this.Key1 = key1;
            this.Value = value;
        }
        
        public Triple(K1 key1, K2 key2, V value) : this(key1,value)
        {
            this.Key2 = key2;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Triple<K1, K2, V>;
            if (other == null)
            {
                return false;
            }
            return this.Key1.Equals(other.Key1) && this.Key2.Equals(other.Key2) && this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            if (this.Key2 == null)
            {
                return this.Key1.GetHashCode() + this.Value.GetHashCode();
            }
            return this.Key1.GetHashCode() + this.Key2.GetHashCode() + this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[K1: {0}, K2: {1} -> V: {2}]",this.Key1,this.Key2,this.Value);
        }
    }
}