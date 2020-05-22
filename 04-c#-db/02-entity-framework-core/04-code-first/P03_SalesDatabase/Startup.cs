namespace P03_SalesDatabase
{
    using System;
    using P03_SalesDatabase.Data;

    class Startup
    {
        static void Main()
        {
            var context = new SalesContext();

            using (context)
            {
                context.Database.EnsureCreated();
            }
        }
    }
}