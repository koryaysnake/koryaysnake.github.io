using System;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("questions.xml");

            writer.WriteStartDocument();
            writer.WriteStartElement("tests");

            writer.WriteStartElement("theme");
            writer.WriteAttributeString("name", "Архитектура");

            writer.WriteStartElement("level");
            writer.WriteAttributeString("number", "1");

            writer.WriteStartElement("question");
            writer.WriteAttributeString("text", textBoxQuestion.Text);
            writer.WriteAttributeString("img", textBoxImage.Text);

            writer.WriteStartElement("answer");
            writer.WriteAttributeString("right", "yes");
            writer.WriteString(textBoxAnswer.Text);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.Close();

            MessageBox.Show("Вопрос добавлен");
        }
    }
}
