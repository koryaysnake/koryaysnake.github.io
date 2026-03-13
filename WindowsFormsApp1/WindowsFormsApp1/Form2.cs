using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Supabase;  // Для основного клиента
using Supabase.Gotrue;  // Для аутентификации
using Supabase.Interfaces;  // Для интерфейсов
using Supabase.Realtime;  // Для реального времени
using Supabase.Postgrest;  // Для работы с таблицами
using static Supabase.Postgrest.Constants;  // Для констант

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Supabase.Client supabase;
        public Form2()
        {
            InitializeComponent();
            InitializeSupabase();
        }
        private void InitializeSupabase()
        {
            var options = new SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            supabase = new Supabase.Client(
                "https://rvwwsgpmzhnlklhahiqx.supabase.courl",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJ2d3dzZ3BtemhubGtsaGFoaXF4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzNzc4NTksImV4cCI6MjA4ODk1Mzg1OX0.Dru6k5l4FepuoPTk37rDTYm_4dAVU5_Y5xCB64oxoH8",
                options
            );
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстовых полей
                string name = textBox1.Text.Trim();    //  поле "введите имя"
                string password = textBox2.Text;    //  поле "введите парль"

                // Простая валидация
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка");
                    return;
                }

                // Создаем словарь с данными для вставки
                var newUser = new UserModel
                {
                    Name = name,
                    Password = password
                };

                var response = await supabase
                   .From<UserModel>()  // Обрати внимание на <UserModel>!
                   .Insert(newUser);

                // Проверяем результат
                if (response != null)
                {
                    MessageBox.Show("Регистрация успешна!", "Успех");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }

        }
    }
}
