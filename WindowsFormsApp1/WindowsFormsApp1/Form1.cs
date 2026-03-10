using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            double eps = double.Parse(textBox2.Text);

            double term = x;      // первый член ряда
            double prevTerm = 0;
            double sum = term;

            int n = 0;
            int count = 1;

            while (Math.Abs(term - prevTerm) >= eps)
            {
                prevTerm = term;

                term = term * (-x) * (n + 1) / (n + 2);

                sum += term;

                n++;
                count++;
            }

            label5.Text = "Math ln(1+x) = " + Math.Log(1 + x);
            label6.Text = "Сумма ряда = " + sum;
            label7.Text = "Количество членов = " + count;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' &&
                e.KeyChar != '-' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }

}
