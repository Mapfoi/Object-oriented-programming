using System.Drawing;

namespace Figures
{
    public class RectangleFigure : Figure
    {
        protected Rectangle rect;

        //Сам объект
        public RectangleFigure(int x, int y, int w, int h, Color color)
            : base(color)
        {
            rect = new Rectangle(x, y, w, h);
        }

        //Действие над объектом
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(pen, rect);
        }
    }
}