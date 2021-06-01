using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Закраска_треугольника
{
    public partial class Form1 : Form
    {
        Graphics g;
        byte count = 0;
        Point[] points = new Point[3];
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            this.BackColor = Color.FromArgb(200, 207, 207);
            pen = new Pen(Color.Green, 3);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (count == 0)
            {
                points[0].X = e.X;
                points[0].Y = e.Y;
                g.FillEllipse(Brushes.Red, points[0].X - 2, points[0].Y - 2, 3, 3);
                count++;
            } else
            if (count == 1)
            {
                points[1].X = e.X;
                points[1].Y = e.Y;
                g.FillEllipse(Brushes.Red, points[1].X - 2, points[1].Y - 2, 3, 3);
                count++;
            } else
            if (count == 2)
            {
                points[2].X = e.X;
                points[2].Y = e.Y;
                g.FillEllipse(Brushes.Red, points[2].X - 2, points[2].Y - 2, 3, 3);
                g.DrawLine(pen, points[0], points[1]);
                g.DrawLine(pen, points[1], points[2]);
                g.DrawLine(pen, points[2], points[0]);
				FillTriangle(points[0].X, points[0].Y,
					points[1].X, points[1].Y,
					points[2].X, points[2].Y);
				count = 0;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString() + ";" + e.Y.ToString();
        }

		void swap(ref int a, ref int b)
		{
			int t;
			t = a;
			a = b;
			b = t;
		}

		void swap(ref float a, ref float b)
		{
			float t;
			t = a;
			a = b;
			b = t;
		}


		private void FillTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			// Упорядочиваем точки p1(x1, y1),
			// p2(x2, y2), p3(x3, y3)
			if (y2 < y1)
			{
				swap(ref y1, ref y2);
				swap(ref x1, ref x2);
			} // точки p1, p2 упорядочены
			if (y3 < y1)
			{
				swap(ref y1, ref y3);
				swap(ref x1, ref x3);
			} // точки p1, p3 упорядочены
			  // теперь p1 самая верхняя
			  // осталось упорядочить p2 и p3
			if (y2 > y3)
			{
				swap(ref y2, ref y3);
				swap(ref x2, ref x3);
			}

			// приращения по оси x для трёх сторон
			// треугольника
			float dx13 = 0, dx12 = 0, dx23 = 0;

			// вычисляем приращения
			// в случае, если ординаты двух точек
			// совпадают, приращения
			// полагаются равными нулю
			if (y3 != y1)
			{
				dx13 = x3 - x1;
				dx13 /= y3 - y1;
			}
			else
			{
				dx13 = 0;
			}

			if (y2 != y1)
			{
				dx12 = x2 - x1;
				dx12 /= (y2 - y1);
			}
			else
			{
				dx12 = 0;
			}

			if (y3 != y2)
			{
				dx23 = x3 - x2;
				dx23 /= (y3 - y2);
			}
			else
			{
				dx23 = 0;
			}

			// "рабочие точки"
			// изначально они находятся в верхней точке
			float wx1 = x1;
			float wx2 = wx1;

			// сохраняем приращение dx13 в другой переменной
			float _dx13 = dx13;

			// упорядочиваем приращения таким образом, чтобы
			// в процессе работы алгоритмы
			// точка wx1 была всегда левее wx2
			if (dx13 > dx12)
			{
				swap(ref dx13, ref dx12);
			}

			// растеризуем верхний полутреугольник
			for (int i = y1; i < y2; i++)
			{
				// рисуем горизонтальную линию между рабочими точками
				for (int j = (int)wx1; j <= wx2; j++)
				{
					g.FillRectangle(Brushes.Green, j, i, 1, 1);
				}
				wx1 += dx13;
				wx2 += dx12;
			}

			// вырожденный случай, когда верхнего полутреугольника нет
			// надо разнести рабочие точки по оси x,
			// т.к. изначально они совпадают
			if (y1 == y2)
			{
				wx1 = x1;
				wx2 = x2;
			}

			// упорядочиваем приращения
			// (используем сохраненное приращение)
			if (_dx13 < dx23)
			{
				swap(ref _dx13, ref dx23);
			}

			// растеризуем нижний полутреугольник
			for (int i = y2; i <= y3; i++)
			{
				// рисуем горизонтальную линию между рабочими точками
				for (int j = (int)wx1; j <= (int)wx2; j++)
				{
					g.FillRectangle(Brushes.Green, j, i, 1, 1);
				}
				wx1 += _dx13;
				wx2 += dx23;
			}
		}
	}
}
