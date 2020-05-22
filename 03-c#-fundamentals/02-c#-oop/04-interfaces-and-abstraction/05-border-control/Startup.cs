namespace _05_border_control
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var inhabitants = new List<IIdentifiable>();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var data = input.Split(' ');
                var id = data[data.Length - 1];

                if (data.Length == 2)
                {
                    var model = data[0];

                    var robot = new Robot(model, id);
                    inhabitants.Add(robot);
                }
                else if (data.Length == 3)
                {
                    var name = data[0];
                    var age = int.Parse(data[1]);

                    var citizen = new Citizen(name, age, id);
                    inhabitants.Add(citizen);
                }

                input = Console.ReadLine();
            }

            var invalidIdEnd = Console.ReadLine();
            var detainedInhabitants = inhabitants.Where(i => i.Id.EndsWith(invalidIdEnd));

            foreach (var detainedInhabitant in detainedInhabitants)
            {
                Console.WriteLine(detainedInhabitant.Id);
            }
        }
    }
}
