using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game
{
    public partial class FormReg : Form
    {
        Dictionary<string, string> users = new Dictionary<string, string>();

        public FormReg()
        {
            InitializeComponent();
            LoadUsers();
        }

        void LoadUsers()
        {
            if (File.Exists("users.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("users.bin", FileMode.Open))
                    users = (Dictionary<string, string>)bf.Deserialize(fs);
            }
            else
            {
                users.Add("admin", "123");
                users.Add("player", "123");
            }
        }

        void SaveUsers()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.bin", FileMode.Create))
                bf.Serialize(fs, users);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pass = txtPassword.Text;

            if (users.ContainsKey(login) && users[login] == pass)
            {
                FormGame game = new FormGame(login);
                game.Show();
                this.Close();
            }
            else
                MessageBox.Show("Неверный логин или пароль!");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pass = txtPassword.Text;

            if (users.ContainsKey(login))
                MessageBox.Show("Такой логин уже есть!");
            else
            {
                users.Add(login, pass);
                SaveUsers();
                MessageBox.Show("Регистрация успешна!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Close();
        }
    }

}
