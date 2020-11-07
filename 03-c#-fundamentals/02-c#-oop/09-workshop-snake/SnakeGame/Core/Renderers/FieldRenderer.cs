namespace SnakeGame.Core.Renderers
{
    using Snake.Core.Renderers;
    using SnakeGame.Interfaces;

    public class FieldRenderer : Renderer, IRenderer<IField>
    {
        public FieldRenderer(IContext context)
            : base(context) { }

        public void Render(IField item)
        {
            throw new System.NotImplementedException();
        }
    }
}