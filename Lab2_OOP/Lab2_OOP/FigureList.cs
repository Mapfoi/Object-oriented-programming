using System.Collections.Generic;
using System.Drawing;
using Lab2_OOP.Figures;

namespace Lab2_OOP
{
    /// <summary>
    /// Collection of figures with helper methods for drawing.
    /// </summary>
    public class FigureList
    {
        private readonly List<Figure> _figures = new List<Figure>();

        /// <summary>
        /// Adds a figure to the internal collection.
        /// </summary>
        /// <param name="f">Figure to be stored and later drawn.</param>
        public void Add(Figure f)
        {
            _figures.Add(f);
        }

        /// <summary>
        /// Draws all figures using a visitor-based renderer.
        /// </summary>
        /// <param name="g">Graphics surface used for drawing.</param>
        public void DrawAll(Graphics g)
        {
            FigureRenderer renderer = new FigureRenderer(g);

            foreach (Figure f in _figures)
            {
                f.Accept(renderer);
            }
        }
    }
}
