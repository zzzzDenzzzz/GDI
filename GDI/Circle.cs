using System;
using System.Drawing;

namespace GDI
{
    internal class Circle
    {
        Point point;

        public Circle(Random random, int w, int h)
        {
            point.X = random.Next(40, w - 40);
            point.Y = random.Next(40, h - 40);

        }

        public void Paint(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(point, new Size(20, 20));
            graphics.DrawEllipse(new Pen(Color.Orange, 5), rectangle);
        }
    }
}
