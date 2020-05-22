namespace SnakeGame
{
    using System;
    using SnakeGame.Core;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            var engine = new Engine();
            engine.Run();
        }
    }
}
