using System.Drawing;

namespace Figures
{
    public abstract class Figure
    {
        protected Pen pen;

        protected Figure(Color color)
        {
            pen = new Pen(color, 5);
        }

        public abstract void Draw(Graphics g);
    }
}
