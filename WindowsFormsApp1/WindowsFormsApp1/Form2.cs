using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using Supabase.Gotrue;
using static Supabase.Postgrest.Constants;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Supabase.Client supabase;
        private byte[] selectedAvatarBytes;
        private string selectedAvatarFileName;

        public Form2()
        {
            InitializeComponent();
            InitializeSupabase();
        }

        private async void InitializeSupabase()
        {
            try
            {
                var options = new SupabaseOptions
                {
                    AutoConnectRealtime = true,
                    AutoRefreshToken = true
                };

                supabase = new Supabase.Client(
                    "https://rvwwsgpmzhnlklhahiqx.supabase.co",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJ2d3dzZ3BtemhubGtsaGFoaXF4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzNzc4NTksImV4cCI6MjA4ODk1Mzg1OX0.Dru6k5l4FepuoPTk37rDTYm_4dAVU5_Y5xCB64oxoH8",
                    options
                );

                await supabase.InitializeAsync();
                Console.WriteLine("Supabase инициализирован успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации Supabase: {ex.Message}", "Ошибка");
            }
        }

        // Кнопка "зарегистрироваться"
        // Кнопка "зарегистрироваться"
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка");
                    return;
                }

                // Проверяем, существует ли уже пользователь
                var existingUsers = await supabase
                    .From<UserModel>()
                    .Where(x => x.Name == username)
                    .Get();

                if (existingUsers.Models.Count > 0)
                {
                    MessageBox.Show("Пользователь с таким именем уже существует!", "Ошибка");
                    return;
                }

                // Загружаем аватарку
                string avatarUrl = await UploadAvatar(username);

                // Создаем пользователя
                var newUser = new UserModel
                {
                    Name = username,
                    Password = password,
                    AvatarUrl = avatarUrl
                };

                var response = await supabase.From<UserModel>().Insert(newUser);

                if (response.Models.Count > 0)
                {
                    string avatarMsg = avatarUrl == null ? "без аватарки" : "с аватаркой";
                    MessageBox.Show($"Регистрация успешна! {avatarMsg}", "Успех");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    selectedAvatarBytes = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}", "Ошибка");
            }
        }


        // Кнопка "войти"
        // Кнопка "войти"
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите имя и пароль!", "Ошибка");
                    return;
                }

                // Ищем пользователя
                var response = await supabase
                    .From<UserModel>()
                    .Where(x => x.Name == username && x.Password == password)
                    .Get();

                if (response.Models.Count > 0)
                {
                    var user = response.Models[0];
                    string avatarInfo = string.IsNullOrEmpty(user.AvatarUrl) ? "без аватарки" : "с аватаркой";
                    MessageBox.Show($"Добро пожаловать, {user.Name}!\nСтатус: {avatarInfo}", "Успешный вход");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    selectedAvatarBytes = null;
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка входа");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка входа: {ex.Message}", "Ошибка");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await supabase
                    .From<UserModel>()
                    .Get();

                MessageBox.Show($"Подключение работает! Найдено записей: {response.Models.Count}", "Тест");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Картинки|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedAvatarBytes = File.ReadAllBytes(openFileDialog.FileName);
                    selectedAvatarFileName = Path.GetFileName(openFileDialog.FileName);
                    MessageBox.Show($"Аватарка выбрана: {selectedAvatarFileName}");
                }
            }
        }
        private async Task<string> UploadAvatar(string username)
        {
            if (selectedAvatarBytes == null) return null;

            try
            {
                string fileName = $"{username}_{DateTime.Now.Ticks}.jpg";
                await supabase.Storage.From("avatars").Upload(selectedAvatarBytes, fileName);
                return supabase.Storage.From("avatars").GetPublicUrl(fileName);
            }
            catch
            {
                return null; // Если ошибка - просто продолжаем без аватарки
            }
        }
    }
}