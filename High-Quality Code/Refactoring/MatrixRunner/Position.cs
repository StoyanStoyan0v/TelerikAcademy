namespace MatrixUtils
{
    public class Position
    {
        private const int INITIAL_X = 0;
        private const int INITIAL_Y = 0;

        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x = INITIAL_X, int y = INITIAL_Y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            var pos = obj as Position;
            if (pos != null)
            {
                return pos.X == this.X && pos.Y == this.Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}