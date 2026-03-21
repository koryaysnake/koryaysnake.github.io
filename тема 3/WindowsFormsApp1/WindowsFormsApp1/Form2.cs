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
    public partial class Form2 : Form
    {
        public Color SelectedColor { get; set; }
        public int Speed { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                SelectedColor = cd.Color;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Speed = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
