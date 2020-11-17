using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Rogue_Runner
{
    public partial class Form1 : Form
    {
        public static bool rushMode = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            XmlTextReader reader = new XmlTextReader("Resources/LeaderboardXML.xml");

            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Text)
                {
                    string name = reader.ReadString();

                    reader.ReadToNextSibling("time");
                    string time = reader.ReadString();

                    reader.ReadToNextSibling("kills");
                    string kills = reader.ReadString();

                    Score newScore = new Score(name, time, kills);
                    Score.scores.Add(newScore);
                }
            }
            reader.Close();

            Form form1 = this.FindForm();
            form1.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            form1.Controls.Add(ms);

            ms.Focus();
            ms.Location = new Point(this.Width / 2 - ms.Width / 2, this.Height / 2 - ms.Height / 2);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("Resources/LeaderboardXML.xml", null);

            writer.WriteStartElement("HighScores");

            foreach (Score s in Score.scores)
            {
                writer.WriteStartElement("Player");

                writer.WriteElementString("name", s.name);
                writer.WriteElementString("time", s.time);
                writer.WriteElementString("kills", s.enemiesDefeated);

                writer.WriteEndElement();
            }

            if(Score.scores.Count() < 10)
            {
                for(int i = 0; i < 10 - Score.scores.Count(); i++)
                {
                    writer.WriteStartElement("Player");

                    writer.WriteElementString("name", "AAA");
                    writer.WriteElementString("time", "00:00.0" + i);
                    writer.WriteElementString("kills", "");

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();

            writer.Close();
        }
    }
}
