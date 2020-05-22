namespace _03_jedi_galaxy
{
    public class Player
    {
        public Player(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.StarPower = 0;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public long StarPower { get; private set; }

        public void TravelToCoordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public void GatherStarPower(Galaxy galaxy)
        {
            int row = this.Row;
            int col = this.Col;

            while (row >= 0 && col < galaxy.Cols)
            {
                if (galaxy.CoordinatesAreValid(row, col))
                {
                    this.StarPower += galaxy[row, col];
                }

                row--;
                col++;
            }
        }
    }
}