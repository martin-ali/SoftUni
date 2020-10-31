namespace P03_FootballBetting
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data;

    class Startup
    {
        static void Main()
        {
            var context = new FootballBettingContext();

            context.Database.Migrate();
        }
    }
}
