using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int x = 20;
        int y = 20;
        int step = 5;

        int direction = 0;

        int rectLeft = 20;
        int rectTop = 20;
        int rectRight;
        int rectBottom;

        int circleSize = 40;

        Color circleColor = Color.Blue;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            //this.KeyDown += Form1_KeyDown;

            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Application.Exit();
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            rectRight = this.ClientSize.Width - 20;
            rectBottom = this.ClientSize.Height - 20;

            switch (direction)
            {
                case 0:
                    x += step;
                    if (x + circleSize >= rectRight)
                        direction = 1;
                    break;

                case 1:
                    y += step;
                    if (y + circleSize >= rectBottom)
                        direction = 2;
                    break;

                case 2:
                    x -= step;
                    if (x <= rectLeft)
                        direction = 3;
                    break;

                case 3:
                    y -= step;
                    if (y <= rectTop)
                        direction = 0;
                    break;
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            rectRight = this.ClientSize.Width - 20;
            rectBottom = this.ClientSize.Height - 20;

            //прямоугольник
            g.DrawRectangle(Pens.Black, rectLeft, rectTop,
                rectRight - rectLeft, rectBottom - rectTop);

            //кружок
            SolidBrush brush = new SolidBrush(circleColor);
            g.FillEllipse(brush, x, y, circleSize, circleSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();

            if (f.ShowDialog() == DialogResult.OK)
            {
                circleColor = f.SelectedColor;
                timer1.Interval = f.Speed;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }
}
