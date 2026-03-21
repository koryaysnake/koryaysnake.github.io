using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
        public partial class Form3 : Form
        {
            Point[] points;

            public Form3()
            {
                InitializeComponent();
             button2.Enabled = false;
            label1.Text = "Периметр:";

            }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

            // Загрузка файла
            private void button1_Click(object sender, EventArgs e)
            {
            string path = "points.txt";

            try
            {
                // если файл не существует — создаём с примером
                if (!File.Exists(path))
                {
                    File.WriteAllText(path,
                        "0 0\n" +
                        "3 0\n" +
                        "3 4\n" +
                        "0 4");
                }

                // запускаем блокнот и ждём пока пользователь закроет его
                Process notepad = new Process();
                notepad.StartInfo.FileName = "notepad.exe";
                notepad.StartInfo.Arguments = path;
                notepad.Start();
                notepad.WaitForExit(); // Ждём закрытия блокнота

                // Загружаем точки из файла
                string[] lines = File.ReadAllLines(path);
                List<Point> pts = new List<Point>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 2) continue;
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    pts.Add(new Point(x, y));
                }

                points = pts.ToArray();

                if (points.Length >= 3)
                {
                    button2.Enabled = true; // разблокируем кнопку "Вычислить"
                    MessageBox.Show("Координаты успешно загружены. Теперь можно вычислять периметр.");
                }
                else
                {
                    MessageBox.Show("Недостаточно точек для многоугольника.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

            // Вычисление периметра
            private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    Polygon polygon = new Polygon(points);

                    if (!polygon.IsConvexPolygon())
                    {
                        MessageBox.Show("Многоугольник не является выпуклым!");
                        return;
                    }

                    double perimeter = polygon.Perimeter();

                    label1.Text = "Периметр: " + perimeter.ToString("F2");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Пример ввода
            private void button3_Click(object sender, EventArgs e)
            {
                MessageBox.Show(
                    "Пример файла:\n\n" +
                    "0 0\n" +
                    "3 0\n" +
                    "3 4\n" +
                    "0 4",
                    "Пример ввода"
                );
            }
        }
}