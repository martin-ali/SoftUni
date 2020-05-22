namespace _03_jedi_galaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];
            var galaxy = new Galaxy(rows, cols);

            var ivo = new Player(galaxy.Rows - 1, 0);

            var input = Console.ReadLine();
            while (input != "Let the Force be with you")
            {
                var ivoStartCoordinates = input
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
                var ivoRow = ivoStartCoordinates[0];
                var ivoCol = ivoStartCoordinates[1];
                ivo.TravelToCoordinates(ivoRow, ivoCol);

                var evilStartCoordinates = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
                var evilRow = evilStartCoordinates[0];
                var evilCol = evilStartCoordinates[1];
                var evil = new Enemy(evilRow, evilCol);

                evil.DestroyStars(galaxy);
                ivo.GatherStarPower(galaxy);

                input = Console.ReadLine();
            }

            Console.WriteLine(ivo.StarPower);
        }
    }
}
/*

5 5
5 -1
5 5
Let the Force be with you

5 5
4 -1
4 5
Let the Force be with you

*/
