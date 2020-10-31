namespace SnakeGame.Core.Renderers
{
    using Snake.Core.Renderers;
    using SnakeGame.Interfaces;

    public class SnakeRenderer : Renderer, IRenderer<ISnake>
    {
        public SnakeRenderer(IContext context)
            : base(context) { }

        public void Render(ISnake item)
        {
            throw new System.NotImplementedException();
        }
    }
}