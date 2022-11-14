using System.Drawing;

namespace GDI
{
    internal class Player
    {
        Point point;

        public Player(Point point)
        {
            this.point = point;
        }

        public void MoveX(int dx, int w)
        {
            point.X += dx;
        }

        public void MoveY(int dy)
        {
            point.Y += dy;
        }

        public void Paint(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(point, new Size(50, 50));
            graphics.FillRectangle(new SolidBrush(Color.Red), rectangle);
        }

        public Point GetPoint()
        {
            return point;
        }
    }
}
