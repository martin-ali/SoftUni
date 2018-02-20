using System;

namespace Personal_Titles
{
    class Program
    {
        static void Main()
        {
            var age = double.Parse(Console.ReadLine());
            var gender = Console.ReadLine();

            if (age < 16)
            {
                if (gender == "m")
                {
                    Console.WriteLine("Master");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
            else
            {
                if (gender == "f")
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Mr.");
                }
            }
        }
    }
}
