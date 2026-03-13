using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Ellipse figure that stores bounding rectangle.
    /// </summary>
    public class EllipseFigure : Figure
    {
        /// <summary>
        /// Gets the rectangle that bounds the ellipse.
        /// </summary>
        public Rectangle Rect { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseFigure"/> class.
        /// </summary>
        /// <param name="x">X coordinate of the left side.</param>
        /// <param name="y">Y coordinate of the top side.</param>
        /// <param name="w">Width of the rectangle.</param>
        /// <param name="h">Height of the rectangle.</param>
        /// <param name="color">Color of the ellipse.</param>
        public EllipseFigure(int x, int y, int w, int h, Color color)
            : base(color)
        {
            Rect = new Rectangle(x, y, w, h);
        }

        /// <inheritdoc />
        public override void Accept(IFigureVisitor visitor)
        {
            visitor.VisitEllipse(this);
        }
    }
}
