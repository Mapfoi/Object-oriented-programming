using System.Drawing;

namespace Figures
{
    public class LineFigure : Figure
    {
        private Point p1, p2;

        public LineFigure(Point p1, Point p2, Color color)
            : base(color)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(pen, p1, p2);
        }
    }
}
