namespace SandwichMaker.App
{
    using SandwichMaker.Models;

    class Startup
    {
        static void Main()
        {
            var menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Bacon", "No cheese", "Wheat", "Lettuce, Tomato");
            menu["Turkey"] = new Sandwich("Turkey", "Swiss", "Rye", "Lettuce, Onion, Tomato");

            var firstSandwich = menu["BLT"].Clone();
            var secondSandwich = menu["Turkey"].Clone();
        }
    }
}
