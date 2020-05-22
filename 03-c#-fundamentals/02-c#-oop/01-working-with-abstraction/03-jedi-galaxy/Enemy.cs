namespace _03_jedi_galaxy
{
    public class Enemy
    {
        public Enemy(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public void DestroyStars(Galaxy galaxy)
        {
            int row = this.Row;
            int col = this.Col;

            while (row >= 0 && col >= 0)
            {
                if (galaxy.CoordinatesAreValid(row, col))
                {
                    galaxy[row, col] = 0;
                }

                row--;
                col--;
            }
        }
    }
}