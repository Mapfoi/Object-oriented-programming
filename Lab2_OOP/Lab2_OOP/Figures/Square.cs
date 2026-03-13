using System.Drawing;
using Lab2_OOP.Figures;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Square figure implemented as a special case of rectangle.
    /// </summary>
    public class Square : RectangleFigure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="x">X coordinate of the left side.</param>
        /// <param name="y">Y coordinate of the top side.</param>
        /// <param name="size">Size of both width and height.</param>
        /// <param name="color">Color of the square.</param>
        public Square(int x, int y, int size, Color color)
            : base(x, y, size, size, color)
        {
        }

        /// <inheritdoc />
        public override void Accept(IFigureVisitor visitor)
        {
            visitor.VisitSquare(this);
        }
    }
}

