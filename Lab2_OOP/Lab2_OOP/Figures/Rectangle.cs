using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Rectangle figure that stores rectangle bounds.
    /// </summary>
    public class RectangleFigure : Figure
    {
        /// <summary>
        /// Gets the rectangle that defines the figure bounds.
        /// </summary>
        public Rectangle Rect { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleFigure"/> class.
        /// </summary>
        /// <param name="x">X coordinate of the left side.</param>
        /// <param name="y">Y coordinate of the top side.</param>
        /// <param name="w">Width of the rectangle.</param>
        /// <param name="h">Height of the rectangle.</param>
        /// <param name="color">Color of the rectangle.</param>
        public RectangleFigure(int x, int y, int w, int h, Color color)
            : base(color)
        {
            Rect = new Rectangle(x, y, w, h);
        }

        /// <inheritdoc />
        public override void Accept(IFigureVisitor visitor)
        {
            visitor.VisitRectangle(this);
        }
    }
}
