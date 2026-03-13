using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Triangle figure that stores three corner points.
    /// </summary>
    public class Triangle : Figure
    {
        /// <summary>
        /// Gets the triangle points.
        /// </summary>
        public Point[] Points { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="p1">First vertex of the triangle.</param>
        /// <param name="p2">Second vertex of the triangle.</param>
        /// <param name="p3">Third vertex of the triangle.</param>
        /// <param name="color">Color of the triangle.</param>
        public Triangle(Point p1, Point p2, Point p3, Color color)
            : base(color)
        {
            Points = new[] { p1, p2, p3 };
        }

        /// <inheritdoc />
        public override void Accept(IFigureVisitor visitor)
        {
            visitor.VisitTriangle(this);
        }
    }
}
