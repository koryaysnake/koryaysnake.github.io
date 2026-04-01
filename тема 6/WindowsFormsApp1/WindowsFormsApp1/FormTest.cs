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
            questions = XmlLoader.Load("questions.xml", level)
                .OrderBy(x => Guid.NewGuid())
                .Take(5)
                .ToList();
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
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            var q = questions[current];

            label1.Text = q.Text;

            if (System.IO.File.Exists(q.Image))
                pictureBox1.Image = Image.FromFile(q.Image);

            radioButton1.Text = q.Answers[0];
            radioButton2.Text = q.Answers[1];
            radioButton3.Text = q.Answers[2];
            radioButton4.Text = q.Answers[3];
        }

        private void buttonNext_Click(object sender, EventArgs e)
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
    }
}
