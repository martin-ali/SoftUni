namespace _07_food_shortage.Models
{
    using _07_food_shortage.Interfaces;

    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; }

        public string Id { get; }
    }
}