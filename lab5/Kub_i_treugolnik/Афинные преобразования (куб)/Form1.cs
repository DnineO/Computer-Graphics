using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Афинные_преобразования__куб_
{
    public partial class Form1 : Form
    {
        double Cos(double angle) { return Math.Cos(angle); }
        double Sin(double angle) { return Math.Sin(angle); }

        //элементы матрицы вращения
        double a00() { return Cos(fi) * Cos(tetta); }
        double a01() { return (Cos(fi) * Sin(psi) * Sin(tetta) - Sin(fi) * Cos(psi)); }
        double a02() { return (Cos(fi) * Sin(tetta) * Cos(psi) - Sin(fi) * Sin(psi)); }

        double a10() { return Sin(fi) * Cos(tetta); }
        double a11() { return (Sin(fi) * Sin(psi) * Sin(tetta) + Cos(fi) * Cos(psi)); }
        double a12() { return (Sin(fi) * Sin(tetta) * Cos(psi) - Cos(fi) * Sin(psi)); }

        double a20() { return -Sin(tetta); }
        double a21() { return (Cos(tetta) * Sin(psi)); }
        double a22() { return (Cos(tetta) * Cos(psi)); }

        delegate double MyDelegate();

        private MyDelegate[,] MatrixRotation;

        public Form1()
        {
            InitializeComponent();
            MatrixRotation = new MyDelegate[3, 3];
            MatrixRotation[0, 0] = a00; MatrixRotation[0, 1] = a01; MatrixRotation[0, 2] = a02;
            MatrixRotation[1, 0] = a10; MatrixRotation[1, 1] = a11; MatrixRotation[1, 2] = a12;
            MatrixRotation[2, 0] = a20; MatrixRotation[2, 1] = a21; MatrixRotation[2, 2] = a22;
            X0 = pictureBox1.Width / 2;
            Y0 = pictureBox1.Height / 2;
        }

        bool DawnIsML = false;

        int x = 0, y = 0, X0, Y0;

        double fi = 0, tetta = 0, psi = 0;

        //координаты вершины куба
        Vertex[] Cube = new Vertex[]
       {
            new Vertex(-1,-1,-1),
            new Vertex(-1,-1,1),
            new Vertex(-1,1,-1),
            new Vertex(-1,1,1),
            new Vertex(1,-1,-1),
            new Vertex(1,-1,1),
            new Vertex(1,1,-1),
            new Vertex(1,1,1)
       };

        Pen p = new Pen(Color.Black, 2);

        PointF CP(double[,] mas)
        {
            float z = (float)mas[2, 0];
            float x = (6 / (12 - z) * (float)mas[0, 0] * 100) + X0;
            float y = (6 / (12 - z) * (float)mas[1, 0] * 100) + Y0;
            return new PointF(x, y);
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DawnIsML = true;
                x = Cursor.Position.X;
                y = Cursor.Position.Y;
            }
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //преобразование координат куба
            for (int i = 0; i < Cube.Length; i++)
                Cube[i].Vertexes = Multiplication(MatrixRotation, Cube[i].Vertexes);

            //отрисовка куба
            for (int i = 0; i < 4; i++)
                e.Graphics.DrawLine(p, CP(Cube[i].Vertexes), CP(Cube[i + 4].Vertexes));

            for (int i = 0; i < 7; i += 2)
                e.Graphics.DrawLine(p, CP(Cube[i].Vertexes), CP(Cube[i + 1].Vertexes));

            for (int i = 0; i < 6; i++)
                e.Graphics.DrawLine(p, CP(Cube[i].Vertexes), CP(Cube[i + 2].Vertexes));
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (DawnIsML == true)
            {
                psi = GradToRad(-0.5 * (-y + Cursor.Position.Y));
                tetta = GradToRad(0.5 * (-x + Cursor.Position.X));
                x = Cursor.Position.X;
                y = Cursor.Position.Y;
                pictureBox1.Refresh();
                psi = 0;
                tetta = 0;
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DawnIsML = false;
                x = Cursor.Position.X;
                y = Cursor.Position.Y;
            }
        }

        private static double GradToRad(double value)
        {
            return value * Math.PI / 180.0;
        }

        //метод для умножения матриц
        private static double[,] Multiplication(MyDelegate[,] a, double[,] b)
        {
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        r[i, j] += a[i, k]() * b[k, j];
            return r;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            X0 = pictureBox1.Width / 2;
            Y0 = pictureBox1.Height / 2;
            pictureBox1.Refresh();
        }
    }

    //Трехмерные координаты
    struct Vertex
    {
        public double[,] Vertexes;

        public double X
        {
            get { return Vertexes[0, 0]; }
            set { Vertexes[0, 0] = value; }
        }

        public double Y
        {
            get { return Vertexes[0, 1]; }
            set { Vertexes[1, 0] = value; }
        }

        public double Z
        {
            get { return Vertexes[0, 2]; }
            set { Vertexes[2, 0] = value; }
        }

        public Vertex(double x, double y, double z)
        {
            Vertexes = new double[3, 1];
            X = x; Y = y; Z = z;
        }
    }
}
