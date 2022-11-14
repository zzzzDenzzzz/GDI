using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace GDI
{
    public partial class Form1 : Form
    {
        Player player;
        Circle circle;
        Random random;
        int speed = 2;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(press);
            player = new Player(new Point(this.Width / 2, this.Height / 2));
            circle = new Circle(random, Width, Height);
            FormClosing += new FormClosingEventHandler(close);
            timer = new Timer(1);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            updateGame();
        }

        public void close(object sender, FormClosingEventArgs args)
        {
            player.stop();
            timer.Stop();
            timer.Dispose();
        }
        protected override void OnPaint(PaintEventArgs args)
        {
            player.paint(args.Graphics);
        }

        public void press(object sender, KeyEventArgs key)
        {
            if (player.currentDirection() == Direction.Stop)
            {
                player.setDirection(key.KeyCode);
                player.start();
            }
            else
            {
                player.setDirection(key.KeyCode);
            }
        }

        private void updateGame()
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(BackColor);
            player.paint(graphics);
        }
    }
}
