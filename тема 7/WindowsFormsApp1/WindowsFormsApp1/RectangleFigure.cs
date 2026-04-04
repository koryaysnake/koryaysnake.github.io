using System;
using System.Drawing;

[Serializable]
public class RectangleFigure : Figure
{
    public RectangleFigure(Rectangle rect) : base(rect) { }

    public override void Draw(Graphics g)
    {
        using (Pen pen = Stroke.GetPen())
        {
            g.DrawRectangle(pen, Bounds);
        }
    }
}
