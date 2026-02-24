using Figures;
using Lab1_OOP.Figures;


public class Form1 : Form
{
    private static FigureList figures;

    static Form1()
    {
        figures = new FigureList();

        figures.Add(new RectangleFigure(50, 50, 100, 60, Color.Blue));

        figures.Add(new LineFigure(
            new Point(20, 20),
            new Point(200, 20),
         Color.Red));

        figures.Add(new Square(150, 150, 60, Color.Brown));

        figures.Add(new EllipseFigure(200, 50, 120, 80, Color.Green));

        figures.Add(new Circle(50, 150, 40, Color.Purple));

         figures.Add(new Triangle(
            new Point(300, 150),
            new Point(350, 220),
            new Point(250, 220),
            Color.Black));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        figures.DrawAll(e.Graphics);
    }
}