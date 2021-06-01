using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool mouseClick = true;
        int x1, y1, x2, y2 = 0;
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(110, 114, 105));
        SolidBrush backSolidBrush;
        List<Point> points;
        Pen pen;
        double sumAngle = 0;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            pen = new Pen(solidBrush, 3);
            backSolidBrush = new SolidBrush(BackColor);
            points = new List<Point>();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = e.X.ToString() + ";" + e.Y.ToString();
            if (rb_CurvedLine.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point point = new Point(x1, y1);
                    points.Add(point);
                    g.FillRectangle(solidBrush, x1, y1, 2, 2);
                }
                x1 = e.X;
                y1 = e.Y;
            }
        }

        // Функция поворота фигуры, представленной в виде точек
        private void RotateAt(bool isStraightLine)
        {
            int size = points.Count;
            sumAngle += Convert.ToDouble(textBox_Angle.Text);
            int half_size = size / 2;
            double r, gr;
            int x0 = Width / 2;
            int y0 = Height / 2;
            int[] x_paint = new int[size];
            int[] y_paint = new int[size];

            for (int i = 0; i < size; i++)
            {
                double angleRadian = sumAngle * Math.PI / 180;
                int x = points[i].X;
                int y = points[i].Y;
                x_paint[i] = (int)((x - x0) * Math.Cos(angleRadian) - (y - y0) * Math.Sin(angleRadian) + x0);
                y_paint[i] = (int)((x - x0) * Math.Sin(angleRadian) + (y - y0) * Math.Cos(angleRadian) + y0);


                //r = Math.Sqrt(Math.Pow((points[half_size].X - points[i].X), 2) + Math.Pow((points[half_size].Y - points[i].Y), 2));
                //if (i == half_size)
                //{
                //    x_paint[i] = points[i].X;
                //    y_paint[i] = points[i].Y;
                //    continue;
                //}
                //if (points[half_size].X <= points[i].X && points[half_size].Y >= points[i].Y)
                //{
                //    gr = Math.Asin((points[half_size].Y - points[i].Y) / r);
                //    x_paint[i] = (int)(points[half_size].X + r * Math.Cos(sumAngle * Math.PI / 180 - gr));
                //    y_paint[i] = (int)(points[half_size].Y + r * Math.Sin(sumAngle * Math.PI / 180 - gr));
                //    continue;
                //}

                //if (points[half_size].X > points[i].X && points[half_size].Y > points[i].Y)
                //{
                //    gr = Math.Asin((points[half_size].Y - points[i].Y) / r);
                //    x_paint[i] = (int)(points[half_size].X + r * Math.Cos(sumAngle * Math.PI / 180 - (Math.PI - gr)));
                //    y_paint[i] = (int)(points[half_size].Y + r * Math.Sin(sumAngle * Math.PI / 180 - (Math.PI - gr)));
                //    continue;
                //}
                //if (points[half_size].X >= points[i].X && points[half_size].Y <= points[i].Y)
                //{
                //    gr = Math.Asin((points[i].Y - points[half_size].Y) / r);
                //    x_paint[i] = (int)(points[half_size].X + r * Math.Cos(sumAngle * Math.PI / 180 - (gr + Math.PI)));
                //    y_paint[i] = (int)(points[half_size].Y + r * Math.Sin(sumAngle * Math.PI / 180 - (gr + Math.PI)));
                //    continue;
                //}
                //if (points[half_size].X < points[i].X && points[half_size].Y < points[i].Y)
                //{
                //    gr = Math.Asin((points[i].Y - points[half_size].Y) / r);
                //    x_paint[i] = (int)(points[half_size].X + r * Math.Cos(sumAngle * Math.PI / 180 - (2 * Math.PI - gr)));
                //    y_paint[i] = (int)(points[half_size].Y + r * Math.Sin(sumAngle * Math.PI / 180 - (2 * Math.PI - gr)));
                //    continue;
                //}
            }

            g.FillRectangle(backSolidBrush, 0, 0, this.Width, this.Height);

            if (isStraightLine) 
            {
                g.FillEllipse(Brushes.Black, (int)x_paint[0] - 2, (int)y_paint[0] - 2, 5, 5);
                g.DrawLine(pen, x_paint[0], y_paint[0], x_paint[1], y_paint[1]);
                g.FillEllipse(Brushes.Black, (int)x_paint[1] - 2, (int)y_paint[1] - 2, 5, 5);
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    g.FillRectangle(solidBrush, x_paint[i], y_paint[i], 2, 2);
                }
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            button_Stop.Enabled = true;
            button_Start.Enabled = false;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AffineTransformationsMethod();
        }

        private void AffineTransformationsMethod()
        {
            if (timer1.Enabled)
                RotateAt(rb_StraightLine.Checked);
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            button_Stop.Enabled = false;
            button_Start.Enabled = true;
            timer1.Enabled = false;
            timer1.Stop();
        }

        private void rb_CurvedLine_MouseClick(object sender, MouseEventArgs e)
        {
            sumAngle = 0;
            g.FillRectangle(backSolidBrush, 0, 0, this.Width, this.Height);
            if (points.Count != 0)
                points.Clear();
        }

        private void rb_StraightLine_MouseClick(object sender, MouseEventArgs e)
        {
            sumAngle = 0;
            g.FillRectangle(backSolidBrush, 0, 0, this.Width, this.Height);
            if (points.Count != 0)
                points.Clear();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (rb_StraightLine.Checked)
            {
                if (mouseClick)
                {
                    sumAngle = 0;
                    g.FillRectangle(backSolidBrush, 0, 0, this.Width, this.Height);
                    x1 = e.X;
                    y1 = e.Y;
                    mouseClick = false;
                    g.FillEllipse(Brushes.Black, (int)x1 - 2, (int)y1 - 2, 5, 5);
                    points.Clear();
                    Point point1 = new Point(x1, y1);
                    points.Add(point1);
                }
                else
                {
                    x2 = e.X;
                    y2 = e.Y;
                    mouseClick = true;
                    g.FillEllipse(Brushes.Black, (int)x2 - 2, (int)y2 - 2, 5, 5);
                    g.DrawLine(pen, x1, y1, x2, y2);
                    Point point2 = new Point(x2, y2);
                    points.Add(point2);
                }
            }
        }
    }
}
