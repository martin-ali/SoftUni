using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IController controller = new Controller();
        private IReader reader;
        private IWriter writer;


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

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
                    if (input[0] == "AddPlayer")
                    {
                        var name = input[1];

                        this.writer.WriteLine(this.controller.AddPlayer(name));
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var name = input[2];

                        this.writer.WriteLine(this.controller.AddGun(type, name));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var player = input[1];

                        this.writer.WriteLine(this.controller.AddGunToPlayer(player));
                    }
                    else if (input[0] == "Fight")
                    {
                        this.writer.WriteLine(this.controller.Fight());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
