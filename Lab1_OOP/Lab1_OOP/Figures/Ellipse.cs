using System.Drawing;

namespace Figures
{
    public class EllipseFigure : Figure
    {
        private Rectangle rect;

        public EllipseFigure(int x, int y, int w, int h, Color color)
            : base(color)
        {
            rect = new Rectangle(x, y, w, h);
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, rect);
        }
    }
}