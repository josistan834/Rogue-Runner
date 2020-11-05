using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rogue_Runner
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form form1 = this.FindForm();
            form1.Controls.Remove(this);

            GameScreen gs = new GameScreen();
            form1.Controls.Add(gs);

            gs.Focus();
            gs.Location = new Point(form1.Width / 2 - gs.Width / 2, form1.Height / 2 - gs.Height / 2);
        }

        private void controlsButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void leaderboardButton_Click(object sender, EventArgs e)
        {
           
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.ForeColor = Color.Black;
            playButton.BackColor = Color.White;

            leaderboardButton.BackColor = Color.Black;
            leaderboardButton.ForeColor = Color.White;
            exitButton.BackColor = Color.Black;
            exitButton.ForeColor = Color.White;
            controlsButton.BackColor = Color.Black;
            controlsButton.ForeColor = Color.White;

        }

        private void controlsButton_Enter(object sender, EventArgs e)
        {
            controlsButton.ForeColor = Color.Black;
            controlsButton.BackColor = Color.White;

            leaderboardButton.BackColor = Color.Black;
            leaderboardButton.ForeColor = Color.White;
            exitButton.BackColor = Color.Black;
            exitButton.ForeColor = Color.White;
            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;
        }

        private void leaderboardButton_Enter(object sender, EventArgs e)
        {
            leaderboardButton.ForeColor = Color.Black;
            leaderboardButton.BackColor = Color.White;

            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;
            exitButton.BackColor = Color.Black;
            exitButton.ForeColor = Color.White;
            controlsButton.BackColor = Color.Black;
            controlsButton.ForeColor = Color.White;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.Black;
            exitButton.BackColor = Color.White;

            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;
            leaderboardButton.BackColor = Color.Black;
            leaderboardButton.ForeColor = Color.White;
            controlsButton.BackColor = Color.Black;
            controlsButton.ForeColor = Color.White;
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
