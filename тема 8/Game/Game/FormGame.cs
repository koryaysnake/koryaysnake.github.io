using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        string player;
        int poisonedBarrel;
        bool[,] tests = new bool[4, 16];  // [мышка, бочка]
        bool[] miceAlive = new bool[4];
        int selectedMouse = 0;
        bool gameActive = true;
        List<GameResult> results = new List<GameResult>();


        public FormGame(string login)
        {
            InitializeComponent();
            player = login;
            lblPlayer.Text = "Игрок: " + player;
            NewGame();
            LoadResults();
        }

        void NewGame()
        {
            Random rnd = new Random();
            poisonedBarrel = rnd.Next(0, 16);

            // Очищаем тесты
            for (int m = 0; m < 4; m++)
                for (int b = 0; b < 16; b++)
                    tests[m, b] = false;

            // Сбрасываем цвет всех бочек
            Button[] barrels = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8,
                                 btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16 };
            foreach (Button btn in barrels)
                btn.BackColor = Color.LightGray;

            // Сбрасываем мышек
            Button[] mice = { btnMouse1, btnMouse2, btnMouse3, btnMouse4 };
            foreach (Button btn in mice)
            {
                btn.BackColor = Color.White;
                btn.Text = "🐭";
            }

            gameActive = true;
            selectedMouse = 0;
            btnMouse1.BackColor = Color.LightGreen;
            lblStatus.Text = "Новая игра! Выбери мышку и отметь бочки (зелёные).";
        }

        private void MouseClick(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if (clicked == btnMouse1) selectedMouse = 0;
            if (clicked == btnMouse2) selectedMouse = 1;
            if (clicked == btnMouse3) selectedMouse = 2;
            if (clicked == btnMouse4) selectedMouse = 3;

            Button[] mice = { btnMouse1, btnMouse2, btnMouse3, btnMouse4 };
            for (int i = 0; i < 4; i++)
                mice[i].BackColor = (i == selectedMouse) ? Color.LightGreen : Color.White;

            lblStatus.Text = "Выбрана мышка " + (selectedMouse + 1);
        }

        private void BarrelClick(object sender, EventArgs e)
        {
            if (!gameActive)
            {
                lblStatus.Text = "Игра окончена. Нажми 'Новая игра'.";
                return;
            }

            Button barrel = sender as Button;
            int barrelNum = int.Parse(barrel.Text);

            tests[selectedMouse, barrelNum] = !tests[selectedMouse, barrelNum];

            if (tests[selectedMouse, barrelNum])
                barrel.BackColor = Color.LightGreen;
            else
                barrel.BackColor = Color.LightGray;
        }

        private void btnCheckGuess_Click(object sender, EventArgs e)
        {
            if (!gameActive)
            {
                MessageBox.Show("Начни новую игру!");
                return;
            }

            // Проверяем кто умер
            string testResult = "Результаты:\n";
            for (int m = 0; m < 4; m++)
            {
                bool died = false;
                for (int b = 0; b < 16; b++)
                {
                    if (tests[m, b] && b == poisonedBarrel)
                    {
                        died = true;
                        break;
                    }
                }
                miceAlive[m] = !died;
                testResult += $"Мышка {m + 1}: {(miceAlive[m] ? "Жива 🐭" : "Умерла 💀")}\n";

                // Меняем внешний вид мышки
                Button[] mice = { btnMouse1, btnMouse2, btnMouse3, btnMouse4 };
                if (!miceAlive[m])
                {
                    mice[m].BackColor = Color.Red;
                    mice[m].Text = "💀";
                }
            }

            MessageBox.Show(testResult, "Результаты тестов");

            // ПРОСТОЙ ВВОД ЧИСЛА
            string input = "";
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = "Твоя догадка",
                StartPosition = FormStartPosition.CenterParent
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Номер бочки (0-15):" };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 240 };
            Button confirmation = new Button() { Text = "OK", Left = 110, Width = 80, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender2, e2) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);

            prompt.ShowDialog();
            input = textBox.Text;

            int guess;
            if (!int.TryParse(input, out guess) || guess < 0 || guess > 15)
            {
                MessageBox.Show("Введи число от 0 до 15!");
                return;
            }

            bool win = (guess == poisonedBarrel);

            // Сохраняем результат
            GameResult res = new GameResult();
            res.PlayerName = player;
            res.Date = DateTime.Now;
            res.Win = win;
            res.PoisonedBarrel = poisonedBarrel;
            res.GuessedBarrel = guess;
            SaveResult(res);

            if (win)
            {
                lblStatus.Text = $"ПОБЕДА! Отравлена бочка {poisonedBarrel}";
                MessageBox.Show($"Поздравляю! Бочка {poisonedBarrel} была отравлена!");
            }
            else
            {
                lblStatus.Text = $"ПРОИГРЫШ! Отравлена бочка {poisonedBarrel}, а ты назвал {guess}";
                MessageBox.Show($"Не угадал! Отравлена бочка {poisonedBarrel}");
            }

            gameActive = false;
        }
        void SaveResult(GameResult res)
        {
            List<GameResult> all = new List<GameResult>();
            if (File.Exists("results.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("results.bin", FileMode.Open))
                    all = (List<GameResult>)bf.Deserialize(fs);
            }
            all.Add(res);
            BinaryFormatter bf2 = new BinaryFormatter();
            using (FileStream fs = new FileStream("results.bin", FileMode.Create))
                bf2.Serialize(fs, all);
        }

        void LoadResults()
        {
            if (File.Exists("results.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("results.bin", FileMode.Open))
                {
                    List<GameResult> all = (List<GameResult>)bf.Deserialize(fs);
                    foreach (var r in all)
                        if (r.PlayerName == player)
                            results.Add(r);
                }
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void показатьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Твои результаты:\n\n";
            foreach (var r in results)
                text += r.ToString() + "\n";

            if (results.Count == 0)
                text = "У тебя пока нет результатов!";

            MessageBox.Show(text, "Результаты");
        }

        private void цветБочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Button[] barrels = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8,
                                     btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16 };
                foreach (Button btn in barrels)
                    if (btn.BackColor != Color.LightGreen)
                        btn.BackColor = cd.Color;
            }
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("4 мышки пробуют вино из отмеченных бочек. Угадай отравленную!");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    public class GameResult
    {
        public string PlayerName { get; set; }
        public DateTime Date { get; set; }
        public bool Win { get; set; }
        public int PoisonedBarrel { get; set; }
        public int GuessedBarrel { get; set; }

        public override string ToString()
        {
            return $"{Date:dd.MM.yyyy HH:mm} - {(Win ? "ВЫИГРЫШ" : "ПРОИГРЫШ")} (было {PoisonedBarrel}, ответил {GuessedBarrel})";
        }
    }
}




    
