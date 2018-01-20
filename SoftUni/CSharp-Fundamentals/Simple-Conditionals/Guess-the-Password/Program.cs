using System;

namespace Guess_the_Password
{
    class Program
    {
        static void Main()
        {
            var password = "s3cr3t!P@ssw0rd";
            var input = Console.ReadLine();

            if (input == password)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
