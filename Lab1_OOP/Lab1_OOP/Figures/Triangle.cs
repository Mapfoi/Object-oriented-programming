using System.Drawing;

namespace Figures
{
    public class Triangle : Figure
    {
        private Point[] points;

        public Triangle(Point p1, Point p2, Point p3, Color color)
            : base(color)
        {
            points = new[] { p1, p2, p3 };
        }

        public override void Draw(Graphics g)
        {
            g.DrawPolygon(pen, points);
        }
    }
}