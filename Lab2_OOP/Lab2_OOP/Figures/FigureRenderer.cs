using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Visitor implementation that draws figures on a Graphics surface.
    /// Figure classes themselves do not contain drawing code.
    /// </summary>
    public sealed class FigureRenderer : IFigureVisitor
    {
        private const float DefaultPenWidth = 5f;
        private readonly Graphics _graphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="FigureRenderer"/> class.
        /// </summary>
        /// <param name="graphics">Graphics surface used for drawing.</param>
        public FigureRenderer(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <inheritdoc />
        public void VisitRectangle(RectangleFigure rectangle)
        {
            using Pen pen = CreatePen(rectangle.Color);
            _graphics.DrawRectangle(pen, rectangle.Rect);
        }

        /// <inheritdoc />
        public void VisitLine(LineFigure line)
        {
            using Pen pen = CreatePen(line.Color);
            _graphics.DrawLine(pen, line.Start, line.End);
        }

        /// <inheritdoc />
        public void VisitSquare(Square square)
        {
            using Pen pen = CreatePen(square.Color);
            _graphics.DrawRectangle(pen, square.Rect);
        }

        /// <inheritdoc />
        public void VisitEllipse(EllipseFigure ellipse)
        {
            using Pen pen = CreatePen(ellipse.Color);
            _graphics.DrawEllipse(pen, ellipse.Rect);
        }

        /// <inheritdoc />
        public void VisitCircle(Circle circle)
        {
            using Pen pen = CreatePen(circle.Color);
            _graphics.DrawEllipse(pen, circle.Rect);
        }

        /// <inheritdoc />
        public void VisitTriangle(Triangle triangle)
        {
            using Pen pen = CreatePen(triangle.Color);
            _graphics.DrawPolygon(pen, triangle.Points);
        }

        /// <summary>
        /// Creates a pen with standard width for drawing figures.
        /// </summary>
        /// <param name="color">Color of the pen.</param>
        /// <returns>Pen instance to use for drawing.</returns>
        private static Pen CreatePen(Color color)
        {
            return new Pen(color, DefaultPenWidth);
        }
    }
}

