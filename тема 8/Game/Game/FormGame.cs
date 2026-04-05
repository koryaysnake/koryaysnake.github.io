using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        string player;
        int poisonedBarrel;
        bool[,] tests = new bool[4, 16];
        bool[] miceAlive = new bool[4];
        int selectedMouse = 0;
        bool gameActive = true;
        bool testsCompleted = false;
        List<GameResult> results = new List<GameResult>();

        // Для анимации
        Timer animationTimer;
        int currentMouse = -1;
        int currentBarrelPos = 0;
        List<int>[] barrelsToTest;
        int animStep = 0;
        Point startP;
        Point endP;
        bool goToBarrel = true;

        Button[] barrels;
        Button[] miceButtons;

        public FormGame(string login)
        {
            InitializeComponent();
            player = login;
            lblPlayer.Text = "Игрок: " + player;

            barrels = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8,
                                     btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16 };
            miceButtons = new Button[] { btnMouse1, btnMouse2, btnMouse3, btnMouse4 };

            barrelsToTest = new List<int>[4];
            for (int i = 0; i < 4; i++)
                barrelsToTest[i] = new List<int>();

            animationTimer = new Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTick;

            NewGame();
            LoadResults();
        }

        private void AnimationTick(object sender, EventArgs e)
        {
            if (currentMouse == -1)
            {
                animationTimer.Stop();
                return;
            }

            Button mouse = miceButtons[currentMouse];

            if (goToBarrel)
            {
                int newX = mouse.Location.X + (endP.X - startP.X) * animStep / 20;
                int newY = mouse.Location.Y + (endP.Y - startP.Y) * animStep / 20;
                mouse.Location = new Point(newX, newY);
                animStep++;

                if (animStep >= 20)
                {
                    mouse.Location = endP;
                    int barrelNum = barrelsToTest[currentMouse][currentBarrelPos];
                    barrels[barrelNum].BackColor = Color.Orange;
                    Refresh();
                    System.Threading.Thread.Sleep(250);

                    if (tests[currentMouse, barrelNum])
                        barrels[barrelNum].BackColor = Color.LightGreen;
                    else
                        barrels[barrelNum].BackColor = SystemColors.Control;
                    Refresh();

                    System.Threading.Thread.Sleep(150);
                    goToBarrel = false;
                    animStep = 0;
                    startP = mouse.Location;
                    endP = new Point(10, 10 + currentMouse * 60);
                }
            }
            else
            {
                int newX = mouse.Location.X + (endP.X - startP.X) * animStep / 20;
                int newY = mouse.Location.Y + (endP.Y - startP.Y) * animStep / 20;
                mouse.Location = new Point(newX, newY);
                animStep++;

                if (animStep >= 20)
                {
                    mouse.Location = endP;
                    goToBarrel = true;
                    animStep = 0;
                    currentBarrelPos++;

                    if (currentBarrelPos >= barrelsToTest[currentMouse].Count)
                    {
                        int finished = currentMouse;
                        currentMouse = -1;

                        // Ищем следующую мышку
                        for (int m = finished + 1; m < 4; m++)
                        {
                            if (barrelsToTest[m].Count > 0)
                            {
                                StartAnimationForMouse(m);
                                return;
                            }
                        }

                        animationTimer.Stop();
                        ShowTestResults();
                    }
                    else
                    {
                        int nextBarrel = barrelsToTest[currentMouse][currentBarrelPos];
                        startP = mouse.Location;
                        endP = barrels[nextBarrel].Location;
                        endP.Offset(barrels[nextBarrel].Width / 2 - mouse.Width / 2,
                                   barrels[nextBarrel].Height / 2 - mouse.Height / 2);
                        goToBarrel = true;
                        animStep = 0;
                    }
                }
            }
        }

        private void StartAnimationForMouse(int mouseIndex)
        {
            if (barrelsToTest[mouseIndex].Count == 0)
            {
                for (int m = mouseIndex + 1; m < 4; m++)
                {
                    if (barrelsToTest[m].Count > 0)
                    {
                        StartAnimationForMouse(m);
                        return;
                    }
                }
                ShowTestResults();
                return;
            }

            currentMouse = mouseIndex;
            currentBarrelPos = 0;
            Button mouse = miceButtons[mouseIndex];
            startP = mouse.Location;
            int firstBarrel = barrelsToTest[mouseIndex][0];
            endP = barrels[firstBarrel].Location;
            endP.Offset(barrels[firstBarrel].Width / 2 - mouse.Width / 2,
                       barrels[firstBarrel].Height / 2 - mouse.Height / 2);
            goToBarrel = true;
            animStep = 0;
            animationTimer.Start();
        }

        private void NewGame()
        {
            Random rnd = new Random();
            poisonedBarrel = rnd.Next(0, 16);

            for (int m = 0; m < 4; m++)
                for (int b = 0; b < 16; b++)
                    tests[m, b] = false;

            foreach (Button btn in barrels)
                btn.BackColor = SystemColors.Control;

            for (int i = 0; i < 4; i++)
            {
                miceButtons[i].Text = "🐭";
                barrelsToTest[i].Clear();
            }

            gameActive = true;
            testsCompleted = false;
            selectedMouse = 0;
            lblStatus.Text = "Выбери мышку и отметь бочки. Затем нажми 'Угадать бочку'.";
        }

        private void MouseClick(object sender, EventArgs e)
        {
            if (!gameActive || testsCompleted)
            {
                lblStatus.Text = "Нажми 'Новая игра'.";
                return;
            }

            if (sender == btnMouse1) selectedMouse = 0;
            if (sender == btnMouse2) selectedMouse = 1;
            if (sender == btnMouse3) selectedMouse = 2;
            if (sender == btnMouse4) selectedMouse = 3;

            lblStatus.Text = $"Выбрана мышка {selectedMouse + 1}. Отметь бочки для неё.";
        }

        private void BarrelClick(object sender, EventArgs e)
        {
            if (!gameActive || testsCompleted)
            {
                lblStatus.Text = "Нажми 'Новая игра'.";
                return;
            }

            Button barrel = sender as Button;
            int barrelNum = int.Parse(barrel.Text);

            bool canTest = false;
            if (selectedMouse == 0 && barrelNum < 4) canTest = true;
            if (selectedMouse == 1 && barrelNum >= 4 && barrelNum < 8) canTest = true;
            if (selectedMouse == 2 && barrelNum >= 8 && barrelNum < 12) canTest = true;
            if (selectedMouse == 3 && barrelNum >= 12) canTest = true;

            if (!canTest)
            {
                lblStatus.Text = $"Мышка {selectedMouse + 1} пробует только бочки {GetRange(selectedMouse)}!";
                return;
            }

            tests[selectedMouse, barrelNum] = !tests[selectedMouse, barrelNum];

            if (tests[selectedMouse, barrelNum])
                barrel.BackColor = Color.LightGreen;
            else
                barrel.BackColor = SystemColors.Control;

            int count = 0;
            for (int b = 0; b < 16; b++)
                if (tests[selectedMouse, b]) count++;
            lblStatus.Text = $"Мышка {selectedMouse + 1} пробует {count} бочeк.";
        }

        private string GetRange(int mouse)
        {
            if (mouse == 0) return "0-3";
            if (mouse == 1) return "4-7";
            if (mouse == 2) return "8-11";
            return "12-15";
        }

        private void btnCheckGuess_Click(object sender, EventArgs e)
        {
            if (!gameActive)
            {
                MessageBox.Show("Начни новую игру!");
                return;
            }

            if (!testsCompleted)
            {
                for (int m = 0; m < 4; m++)
                {
                    barrelsToTest[m].Clear();
                    for (int b = 0; b < 16; b++)
                    {
                        if (tests[m, b])
                            barrelsToTest[m].Add(b);
                    }
                }

                bool anyTest = false;
                for (int m = 0; m < 4; m++)
                    if (barrelsToTest[m].Count > 0) anyTest = true;

                if (!anyTest)
                {
                    MessageBox.Show("Отметь бочки для мышек!");
                    return;
                }

                testsCompleted = true;
                btnCheckGuess.Enabled = false;
                btnNewGame.Enabled = false;
                lblStatus.Text = "Мышки бегут к бочкам! 🐭";

                for (int m = 0; m < 4; m++)
                {
                    if (barrelsToTest[m].Count > 0)
                    {
                        StartAnimationForMouse(m);
                        return;
                    }
                }
            }
            else
            {
                AskForGuess();
            }
        }

        private void ShowTestResults()
        {
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

                if (!miceAlive[m])
                    miceButtons[m].Text = "💀";
                else
                    miceButtons[m].Text = "🐭";
            }

            string result = "РЕЗУЛЬТАТЫ ТЕСТОВ:\n\n";
            for (int m = 0; m < 4; m++)
            {
                result += $"Мышка {m + 1} ({GetRange(m)}): {(miceAlive[m] ? "ЖИВА" : "УМЕРЛА")}\n";
            }
            result += "\nЕсли мышка умерла - отравленная бочка в её группе!";

            MessageBox.Show(result, "Результаты");

            btnCheckGuess.Text = "Ввести ответ";
            btnCheckGuess.Enabled = true;
            btnNewGame.Enabled = true;
            lblStatus.Text = "Введи номер отравленной бочки.";
        }

        private void AskForGuess()
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 180,
                Text = "Твоя догадка",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            string hint = "Отравленная бочка в группе УМЕРШЕЙ мышки!\n\nВведи номер (0-15):";

            Label label = new Label() { Left = 20, Top = 20, Text = hint, Width = 300, Height = 60 };
            TextBox textBox = new TextBox() { Left = 20, Top = 90, Width = 200 };
            Button ok = new Button() { Text = "Угадать!", Left = 230, Top = 88, Width = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(label);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(ok);

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                int guess;
                if (!int.TryParse(textBox.Text, out guess) || guess < 0 || guess > 15)
                {
                    MessageBox.Show("Введи число от 0 до 15!");
                    return;
                }

                CheckGuess(guess);
            }
        }

        private void CheckGuess(int guess)
        {
            bool win = (guess == poisonedBarrel);

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
                MessageBox.Show($"ПОБЕДА! Бочка {poisonedBarrel} была отравлена!", "Победа!");
            }
            else
            {
                lblStatus.Text = $"ПРОИГРЫШ! Отравлена бочка {poisonedBarrel}";
                MessageBox.Show($"Проигрыш! Отравлена бочка {poisonedBarrel}, ты назвал {guess}", "Проигрыш");
            }

            gameActive = false;
            btnCheckGuess.Text = "Угадать бочку";
        }

        private void SaveResult(GameResult res)
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

        private void LoadResults()
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
            animationTimer.Stop();
            currentMouse = -1;
            NewGame();
            btnCheckGuess.Text = "Угадать бочку";
            btnCheckGuess.Enabled = true;
            btnNewGame.Enabled = true;
            testsCompleted = false;
        }

        private void показатьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "ТВОИ РЕЗУЛЬТАТЫ:\n\n";
            if (results.Count == 0)
                text = "Нет результатов!";
            else
            {
                int wins = 0;
                foreach (var r in results)
                {
                    if (r.Win) wins++;
                    text += r.ToString() + "\n";
                }
                text += $"\nПобед: {wins} из {results.Count}";
            }
            MessageBox.Show(text, "Результаты");
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ПРАВИЛА:\n\n" +
                "Мышка 1 → бочки 0-3\n" +
                "Мышка 2 → бочки 4-7\n" +
                "Мышка 3 → бочки 8-11\n" +
                "Мышка 4 → бочки 12-15\n\n" +
                "1. Выбери мышку\n" +
                "2. Отметь бочки (зелёные)\n" +
                "3. Нажми 'Угадать бочку'\n" +
                "4. Смотри анимацию\n" +
                "5. Угадай отравленную бочку",
                "Правила");
        }

        private void цветБочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Button[] barrels = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8,
                                     btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16 };
                foreach (Button btn in barrels)
                {
                    if (btn.BackColor != Color.LightGreen && btn.BackColor != Color.Orange)
                        btn.BackColor = cd.Color;
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            Form1 main = new Form1();
            main.Show();
            this.Close();
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
            return $"{Date:dd.MM.yyyy HH:mm} - {(Win ? "ВЫИГРЫШ" : "ПРОИГРЫШ")} (отравлена {PoisonedBarrel})";
        }
    }
}