using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Line figure that stores two end points.
    /// </summary>
    public class LineFigure : Figure
    {
        /// <summary>
        /// Gets the first end point of the line.
        /// </summary>
        public Point Start { get; }

        /// <summary>
        /// Gets the second end point of the line.
        /// </summary>
        public Point End { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineFigure"/> class.
        /// </summary>
        /// <param name="p1">First end point of the line.</param>
        /// <param name="p2">Second end point of the line.</param>
        /// <param name="color">Color of the line.</param>
        public LineFigure(Point p1, Point p2, Color color)
            : base(color)
        {
            Start = p1;
            End = p2;
        }

        /// <inheritdoc />
        public override void Accept(IFigureVisitor visitor)
        {
            visitor.VisitLine(this);
        }
    }
}
