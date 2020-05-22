using space_station.Core;
using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller = new Controller();

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    var message = string.Empty;
                    if (input[0] == "AddAstronaut")
                    {
                        var type = input[1];
                        var name = input[2];

                        message = this.controller.AddAstronaut(type, name);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var planet = input[1];
                        var items = input.Skip(2).ToArray();

                        message = this.controller.AddPlanet(planet, items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        var astronaut = input[1];

                        message = this.controller.RetireAstronaut(astronaut);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var planet = input[1];

                        message = this.controller.ExplorePlanet(planet);
                    }
                    else if (input[0] == "Report")
                    {
                        message = this.controller.Report();
                    }

                    this.writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
