using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            textBox2.TextChanged += textBox_TextChanged;
            textBox1.TextChanged += textBox_TextChanged;
            textBox2.KeyPress += textBox_KeyPress;
            textBox1.KeyPress += textBox_KeyPress;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox2.Text);
                double eps = Convert.ToDouble(textBox1.Text);

                // Исключение если X вне диапазона
                if (x <= -1 || x > 1)
                    throw new ArgumentOutOfRangeException("X должен быть в диапазоне -1 < X ≤ 1");

                // Исключение если точность неверная
                if (eps <= 0 || eps >= 1)
                    throw new ArgumentOutOfRangeException("Точность должна быть 0 < ε < 1");

                if (x == 0)
                {
                    throw new InvalidOperationException("Демонстрационное исключение: X не может быть равен 0 для данного теста.");
                }

                double term = x;
                double sum = term;
                int n = 1;

                // Основной цикл вычисления ряда
                while (Math.Abs(term) > eps)
                {
                    term = term * (-x) * n / (n + 1);
                    sum += term;
                    n++;
                }

                double realValue = Math.Log(1 + x);

                label4.Text = "Ln(1+x) = " + realValue.ToString();
                label5.Text = "Сумма ряда = " + sum.ToString();
                label6.Text = "Количество членов ряда = " + n.ToString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Ошибка диапазона: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Демонстрационная ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Общая ошибка: " + ex.Message);
            }
        }

        // Проверка ввода символов
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' &&
                e.KeyChar != '-' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Проверка пустых полей
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled =
                !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text);
        }
    }
}
