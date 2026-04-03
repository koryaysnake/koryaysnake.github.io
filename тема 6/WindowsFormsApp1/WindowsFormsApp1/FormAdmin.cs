using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();

            comboLevel.Items.Add("1");
            comboLevel.Items.Add("2");
            comboLevel.Items.Add("3");

            comboRight.Items.Add("1");
            comboRight.Items.Add("2");
            comboRight.Items.Add("3");
            comboRight.Items.Add("4");
        }


        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "\\questions.xml";

                XDocument doc = XDocument.Load(path);

                var level = doc.Root
                               .Element("theme")
                               .Elements("level")
                               .FirstOrDefault(x => x.Attribute("number").Value == comboLevel.Text);

                if (level == null)
                {
                    MessageBox.Show("Уровень не найден!");
                    return;
                }

                XElement newQuestion =
                    new XElement("question",
                        new XAttribute("text", textBoxQuestion.Text),
                        new XAttribute("img", textBoxImage.Text),

                        new XElement("answer", new XAttribute("right", comboRight.Text == "1" ? "yes" : "no"), textBox1.Text),
                        new XElement("answer", new XAttribute("right", comboRight.Text == "2" ? "yes" : "no"), textBox2.Text),
                        new XElement("answer", new XAttribute("right", comboRight.Text == "3" ? "yes" : "no"), textBox3.Text),
                        new XElement("answer", new XAttribute("right", comboRight.Text == "4" ? "yes" : "no"), textBox4.Text)
                    );

                level.Add(newQuestion);

                doc.Save(path);

                MessageBox.Show("Вопрос добавлен в XML!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void ClearFields()
        {
            textBoxQuestion.Text = "";
            textBoxImage.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboRight.Text = "";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMenu f = new FormMenu();
            f.Show();
            this.Hide();
        }
    }
}
