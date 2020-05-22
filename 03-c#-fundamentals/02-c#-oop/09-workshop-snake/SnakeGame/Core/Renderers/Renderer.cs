using SnakeGame.Interfaces;

namespace Snake.Core.Renderers
{
    public abstract class Renderer
    {
        private IContext context;

        protected Renderer(IContext context)
        {
            this.context = context;
        }
    }
}