namespace _03_jedi_galaxy
{
    using System;
    using System.Linq;

    public class Galaxy
    {
        private int[,] map;

        public Galaxy(int rows, int cols)
        {
            this.map = new int[rows, cols];

            var power = 0;
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    this.map[row, col] = power++;
                }
            }
        }

        public int Rows => this.map.GetLength(0);

        public int Cols => this.map.GetLength(1);

        public bool CoordinatesAreValid(int row, int col)
        {
            return 0 <= row && row < this.Rows
                && 0 <= col && col < this.Cols;
        }

        public int this[int row, int col]
        {
            get
            {
                return this.map[row, col];
            }
            set
            {
                this.map[row, col] = value;
            }
        }
    }
}