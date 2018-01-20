using System;

namespace Number_Between_100_and_200
{
    class Program
    {
        static void Main()
        {
            var number = double.Parse(Console.ReadLine());

            if(number<100)
            {
                Console.WriteLine("Less than 100");
            }
            else if(number>=100 && number<=200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (number>200)
            {
                Console.WriteLine("Greater than 200");
            }
            else
            {
                throw new NotImplementedException("Holy bonkers! This ain't what I signed up for!");
            }
        }
    }
}
