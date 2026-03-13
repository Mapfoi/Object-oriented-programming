using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Circle figure implemented as a special case of ellipse.
    /// </summary>
    public class Circle : EllipseFigure
    {
        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        public int Radius { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="x">X coordinate of the left side of bounding square.</param>
        /// <param name="y">Y coordinate of the top side of bounding square.</param>
        /// <param name="r">Radius of the circle.</param>
        /// <param name="color">Color of the circle.</param>
        public Circle(int x, int y, int r, Color color)
            : base(x, y, r * 2, r * 2, color)
        {
            Radius = r;
        }

        /// <inheritdoc />
        public override void Accept(IFigureVisitor visitor)
        {
            visitor.VisitCircle(this);
        }
    }
}
