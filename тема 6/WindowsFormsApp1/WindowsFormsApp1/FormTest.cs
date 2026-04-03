using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormTest : Form
    {
        List<questoin> questions;
        int current = 0;
        int correct = 0;
        int level = 1;
        int time = 60;
        Timer timer = new Timer();

        public FormTest()
        {
            InitializeComponent();

            label1.BringToFront();
            radioButton1.BringToFront();
            radioButton2.BringToFront();
            radioButton3.BringToFront();
            radioButton4.BringToFront();
            button1.BringToFront();

            LoadLevel();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            ShowQuestion();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }
        private void button1_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        void LoadLevel()
        {
            questions = XmlLoader.Load("questions.xml", level);
            current = 0;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            label2.Text = "Время: " + time;

            if (time <= 0)
                Finish();
        }

        void ShowQuestion()
        {
            var q = questions[current];

            label1.Text = q.Text;

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + q.Image);
            }
            catch
            {
                pictureBox1.Image = null;
            }

            radioButton1.Text = q.Answers[0];
            radioButton2.Text = q.Answers[1];
            radioButton3.Text = q.Answers[2];
            radioButton4.Text = q.Answers[3];
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int selected = -1;

            if (radioButton1.Checked) selected = 0;
            if (radioButton2.Checked) selected = 1;
            if (radioButton3.Checked) selected = 2;
            if (radioButton4.Checked) selected = 3;

            if (selected == -1)
            {
                MessageBox.Show("Выберите ответ!");
                return;
            }

            if (selected == questions[current].RightAnswer)
                correct++;

            current++;

            if (current >= questions.Count)
                Finish();
            else
                ShowQuestion();
        }

        void Finish()
        {
            timer.Stop();

            int score = correct * 100 / questions.Count;

            if (score >= 80)
            {
                level++;

                if (level <= 3)
                {
                    MessageBox.Show("Переход на уровень " + level);

                    correct = 0;
                    current = 0;
                    time = 60;

                    LoadLevel();
                    timer.Start();
                    ShowQuestion();
                    return;
                }
            }

            FormResult r = new FormResult();
            r.Score = score;
            r.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
