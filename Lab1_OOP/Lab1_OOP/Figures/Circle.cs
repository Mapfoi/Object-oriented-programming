using System.Drawing;

namespace Figures
{
    public class Circle : EllipseFigure
    {
        public Circle(int x, int y, int r, Color color)
            : base(x, y, r * 2, r * 2, color)
        { }
    }
}