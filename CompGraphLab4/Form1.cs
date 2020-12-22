using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraphLab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] t = { -6, 1, 2, 5, -1, -8, -9, 2, 8, 12, 21, 12, 7,
4, 4, -3, 6, 4, 4, 0, -1, -9, 0, 7, 7, 16, 6,
0, -6, 15, 18 };
            Graphics g = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            Font fn = new Font("Arial", 10);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Рисуем ось X
            // начальная точка первой линии
            int x1 = 0; int y1 = pictureBox1.Size.Height / 2;
            // конечная точка первой линии
            int x2 = pictureBox1.Size.Width;
            int y2 = pictureBox1.Size.Height / 2;
            g.DrawLine(p, x1, y1, x2, y2);
            // Рисуем ось Y
            // начальная точка первой линии
            x1 = 0; y1 = 0;
            // конечная точка первой линии
            x2 = 0; y2 = pictureBox1.Size.Height;
            g.DrawLine(p, x1, y1, x2, y2);
            // Находим максимум в массиве темепратур
            int max = -1;
            for (int i = 0; i < t.Length; i++) { if (t[i] > max) max = t[i]; }
            // Находим количество экранных точек в единице длины по оси Y
            int dy = pictureBox1.Size.Height / (2 * max);
            // Находим количество экранных точек в единице длины по оси X
            int dx = pictureBox1.Size.Width / 31;
            // ************** Ставим метки по оси Y вверх **************
            int y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, 10, y, sf);
                g.DrawLine(p, 0, y, pictureBox1.Size.Width, y);
                y = y - dy;
            }
            // ************** Ставим метки по оси Y вниз ****************
            y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, 10, y, sf);
                g.DrawLine(p, 0, y, pictureBox1.Size.Width, y);
                y = y + dy;
            }
            // *************** Ставим метки по оси X ********************
            int x = dx;
            for (int i = 1; i <= 31; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, x,
                pictureBox1.Size.Height / 2 - 22, sf);
                g.DrawLine(p, x, pictureBox1.Size.Height / 2 - 5, x,
                pictureBox1.Size.Height / 2 + 5);
                x = x + dx;
            }
            p.Dispose();
            // *************** Выводим график температур ***************
            // Задаем цвет и толщину пера для вывода графика температур
            p = new Pen(Color.Green, 3);
            // Задаем стиль линии "точечная"
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            // Задаем начальную координату x
            x = dx;
            // Отмечаем кружком значение температуры в первый день
            g.DrawEllipse(Pens.Red, x - 3, pictureBox1.Size.Height / 2 - t[0] * dy - 3, 6, 6);
            // Организуем цикл по элементам массива температур
            for (int i = 1; i <= t.Length - 1; i++)
            {
                // Проводим линию из одного значения температуры в другое
                g.DrawLine(p, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                // Отмечаем кружком значение температуры
                g.DrawEllipse(Pens.Red, x + dx - 3, pictureBox1.Size.Height / 2 - t[i] * dy - 3, 6, 6);
                // Переходим к следующему дню месяца
                x = x + dx;
            }
            p.Dispose();
        }
    }
}
