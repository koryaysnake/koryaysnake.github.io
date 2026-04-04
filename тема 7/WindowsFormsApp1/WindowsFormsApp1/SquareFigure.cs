using System;
using System.Drawing;

[Serializable]
public class SquareFigure : Figure
{
    public SquareFigure(Rectangle rect) : base(rect)
    {
        int size = Math.Min(rect.Width, rect.Height);
        Bounds = new Rectangle(rect.X, rect.Y, size, size);
    }

    public override void Draw(Graphics g)
    {
        using (Pen pen = Stroke.GetPen())
        {
            g.DrawRectangle(pen, Bounds);
        }
    }
}
