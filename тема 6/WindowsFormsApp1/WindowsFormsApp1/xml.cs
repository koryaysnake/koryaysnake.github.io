using System.Collections.Generic;
using System.Xml;

namespace WindowsFormsApp1
{
    class XmlLoader
    {
        public static List<questoin> Load(string path, int levelNumber)
        {
            List<questoin> questions = new List<questoin>();

            XmlReader reader = XmlReader.Create(path);

            bool correctLevel = false;

            while (reader.Read())
            {
                if (reader.Name == "level")
                {
                    if (reader.GetAttribute("number") == levelNumber.ToString())
                        correctLevel = true;
                    else
                        correctLevel = false;
                }

                if (reader.Name == "question" && correctLevel)
                {
                    questoin q = new questoin();
                    q.Text = reader.GetAttribute("text");
                    q.Image = reader.GetAttribute("img");

                    int i = 0;

                    while (reader.Read())
                    {
                        if (reader.Name == "answer")
                        {
                            if (reader.GetAttribute("right") == "yes")
                                q.RightAnswer = i;

                            reader.Read();

                            if (i < 4)
                                q.Answers[i] = reader.Value;

                            i++;
                        }

                        if (reader.Name == "question" && reader.NodeType == XmlNodeType.EndElement)
                            break;
                    }

                    questions.Add(q);
                }
            }

            return questions;
        }
    }
}
