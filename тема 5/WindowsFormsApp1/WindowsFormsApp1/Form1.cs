using System;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DictionaryLib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DictionaryService dict = new DictionaryService();
        string currentFile = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                dict.Load(currentFile);
                listBox1.DataSource = dict.Words.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!dict.AddWord(textBox1.Text))
                MessageBox.Show("Слово уже существует");
            else
                RefreshList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            dict.RemoveWord(listBox1.SelectedItem.ToString());
            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = dict.FindBySubstring(textBox1.Text);

            if (result.Count() == 0)
                MessageBox.Show("Ничего не найдено");

            listBox1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = dict.FuzzySearch(textBox1.Text);

            if (result.Count() == 0)
                MessageBox.Show("Ничего не найдено");

            listBox1.DataSource = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var data = listBox1.Items.Cast<string>().ToArray();
                File.WriteAllLines(dialog.FileName, data);
            }
        }

        private void расстояниеЛевенштейнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Расстояние Левенштейна — количество операций вставки, удаления и замены.");
        }

        private void RefreshList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = dict.Words.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Сохранить словарь
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dict.Save(dialog.FileName);
            }
        }

        // Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Добавить слово
        private void добавитьСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dict.AddWord(textBox1.Text))
                MessageBox.Show("Слово уже существует");
            else
                RefreshList();
        }

        // Удалить слово
        private void удалитьСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            dict.RemoveWord(listBox1.SelectedItem.ToString());
            RefreshList();
        }

        // Поиск по слогу
        private void поискПоСлогуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = dict.FindBySubstring(textBox1.Text);

            if (result.Count() == 0)
                MessageBox.Show("Ничего не найдено");

            listBox1.DataSource = result;
        }

        // Нечеткий поиск
        private void нечеткийПоискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = dict.FuzzySearch(textBox1.Text);

            if (result.Count() == 0)
                MessageBox.Show("Ничего не найдено");

            listBox1.DataSource = result;
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        @"Программа: Словарь с поиском слов
            Версия: 1.0

                Функции программы:
            - Загрузка словаря из файла
            - Добавление слов
            - Удаление слов
            - Поиск по слогу
            - Нечеткий поиск (Левенштейн ≤ 3)
            - Сохранение результатов поиска

            Разработала: Житарь Дарья Олеговна
            Группа: 23-1094
            2026 год",
        "О программе");
        }

    }
}
