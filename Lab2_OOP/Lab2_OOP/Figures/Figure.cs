using System.Drawing;

namespace Lab2_OOP.Figures
{
    /// <summary>
    /// Base class for all figures. Stores only shared data and
    /// delegates drawing to a separate visitor.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Gets the color of the figure.
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class.
        /// </summary>
        /// <param name="color">Color used to draw the figure.</param>
        protected Figure(Color color)
        {
            Color = color;
        }

        /// <summary>
        /// Accepts a visitor that knows how to work with a specific figure type.
        /// This method does not contain any drawing logic.
        /// </summary>
        /// <param name="visitor">Visitor that performs an operation for this figure.</param>
        public abstract void Accept(IFigureVisitor visitor);
    }

    /// <summary>
    /// Visitor interface for operations with concrete figure types.
    /// Drawing is implemented by classes that implement this interface.
    /// </summary>
    public interface IFigureVisitor
    {
        void VisitRectangle(RectangleFigure rectangle);
        void VisitLine(LineFigure line);
        void VisitSquare(Square square);
        void VisitEllipse(EllipseFigure ellipse);
        void VisitCircle(Circle circle);
        void VisitTriangle(Triangle triangle);
    }
}
