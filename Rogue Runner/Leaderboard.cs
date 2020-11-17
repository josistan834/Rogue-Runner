using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Rogue_Runner
{
    public partial class Leaderboard : UserControl
    {
        public Leaderboard()
        {
            InitializeComponent();

            updateScores();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            #region change screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);

            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);

            ms.Focus();
            #endregion
        }
        private void updateScores()
        {
            nameOutput.Text = timeOutput.Text = enemiesOutput.Text = "";
            List<Score> sortedList = Score.scores.OrderBy(s => Convert.ToInt32(s.time.Replace(":","").Replace(".", ""))).ToList();

            for(int i = 0; i < 10; i++)
            {
                nameOutput.Text += sortedList[sortedList.Count() - (i + 1)].name + "\n";
                timeOutput.Text += sortedList[sortedList.Count() - (i + 1)].time + "\n";
                enemiesOutput.Text += sortedList[sortedList.Count() - (i + 1)].enemiesDefeated + "\n";
            }
            Refresh();



        }
    }
}
