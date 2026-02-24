using System.Collections.Generic;
using System.Drawing;
using Figures;
public class FigureList
{
    private List<Figure> figures = new List<Figure>();

    //Добавить фигуру в список
    public void Add(Figure f)
    {
        figures.Add(f);
    }

    //Нарисовать все
    public void DrawAll(Graphics g)
    {
        //Рисуем каждую фигуру с помощью Draw из Figure
        foreach (Figure f in figures)
            f.Draw(g);
    }
}