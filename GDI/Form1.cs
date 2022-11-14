using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDI
{
    public partial class Form1 : Form
    {
        Player player;
        Circle circle;
        Random random;
        int speed = 1;
        int kill = 0;

        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Press);
            random = new Random();
            player = new Player(new Point(Width / 2, Height / 2));
            circle = new Circle(random, Width, Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            player.Paint(e.Graphics);
            circle.Paint(e.Graphics);
        }

        void Press(object o, KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                case Keys.Left:
                    player.MoveX(-speed, Width);
                    break;
                case Keys.Right:
                    player.MoveX(speed, Width);
                    break;
                case Keys.Up:
                    player.MoveY(-speed);
                    break;
                case Keys.Down:
                    player.MoveY(speed);
                    break;
            }
            UpdateGame();
            G();
        }

        void G()
        {
            if (player.GetPoint() == circle.GetPoint())
            {
                circle = new Circle(random, Width, Height);
                UpdateGame2();
                kill++;
            }
        }

        void UpdateGame()
        {
            Text = $"player:{player.GetPoint().X} {player.GetPoint().Y}" +
                $" circle:{circle.GetPoint().X} {circle.GetPoint().Y} kill:{kill}";
            UpdateGame2();
        }

        void UpdateGame2()
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(BackColor);
            player.Paint(graphics);
            circle.Paint(graphics);
        }
    }
}
