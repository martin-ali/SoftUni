namespace P01_HospitalDatabase
{
    using System;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    class Startup
    {
        static void Main()
        {
            var context = new HospitalContext();

            using (context)
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
