namespace SnakeGame.Core.Renderers
{
    using Snake.Core.Renderers;
    using SnakeGame.Interfaces;

    public class FoodRenderer : Renderer, IRenderer<IFood>
    {
        public FoodRenderer(IContext context)
            : base(context) { }

        public void Render(IFood item)
        {
            throw new System.NotImplementedException();
        }
    }
}