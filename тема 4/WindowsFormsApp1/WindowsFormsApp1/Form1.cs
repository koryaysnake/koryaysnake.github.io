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
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ArraySale A = new ArraySale();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Таблица
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Месяц";
            dataGridView1.Columns[1].Name = "Продажи";

            // Месяцы
            comboBox1.Items.AddRange(new string[]
            {
                "Январь","Февраль","Март","Апрель","Май","Июнь",
                "Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"
            });
        }

        // Добавить
        private void button1_Click(object sender, EventArgs e)
        {
            string month = comboBox1.Text;
            double value = Convert.ToDouble(textBox1.Text);

            Sale s = new Sale(month, value);
            A.Add(s);

            dataGridView1.Rows.Add(month, value);

            textBox1.Clear();
        }

        // Сохранить
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                A.SaveFile(sfd.FileName);
            }
        }

        // Загрузить
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                A.OpenFile(ofd.FileName);

                dataGridView1.Rows.Clear();

                for (int i = 0; i < A.Count; i++)
                {
                    dataGridView1.Rows.Add(A[i].Month, A[i].Value);
                }
            }
        }

        // Построить график
        private void button4_Click(object sender, EventArgs e)
        {
            A.Diagram(chart1);
        }
    }
}