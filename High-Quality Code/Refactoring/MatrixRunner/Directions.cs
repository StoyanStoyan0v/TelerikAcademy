using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixUtils
{
    public static class Directions
    {
        private const int INITIAL_DIR_X = 1;
        private const int INITIAL_DIR_Y = 1;

        private static readonly Position[] directions;

        static Directions()
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            directions = new Position[dirX.Length];

            for (int i = 0; i < directions.Length; i++)
            {
                directions[i] = new Position();
                directions[i].X = dirX[i];
                directions[i].Y = dirY[i];
            }
        }

        public static Position GetNextDirection(Position direction)
        {
            var index = Array.IndexOf(directions, direction);

            if (index == directions.Length - 1)
            {
                return directions[0];
            }
            else
            {
                return directions[index + 1];
            }
        }

        public static Position GetInitialDirection()
        {
            return new Position(INITIAL_DIR_X, INITIAL_DIR_Y);
        }
    }
}