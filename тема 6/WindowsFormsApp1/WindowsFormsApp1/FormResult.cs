using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormResult : Form
    {
        public int Score;

        public FormResult()
        {
            InitializeComponent();
        }

        private void FormResult_Load(object sender, EventArgs e)
        {
            label1.Text = "Ваш результат: " + Score;

            if (Score >= 80)
                label1.Text += "\nУровень пройден";
            else
                label1.Text += "\nПопробуйте снова";
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            FormMenu f = new FormMenu();
            f.Show();
            this.Hide();
        }
    }
}
