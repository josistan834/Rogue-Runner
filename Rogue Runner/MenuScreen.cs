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
            backButton.Show();
            controlsBox.Show();

            bossButton.Hide();
            playButton.Hide();
            leaderboardButton.Hide();
            controlsButton.Hide();
            exitButton.Hide();
            backButton.Focus();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            Form form1 = this.FindForm();
            form1.Controls.Remove(this);

            Leaderboard lb = new Leaderboard();
            form1.Controls.Add(lb);

            lb.Focus();
            lb.Location = new Point(form1.Width / 2 - lb.Width / 2, form1.Height / 2 - lb.Height / 2);
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.ForeColor = Color.Black;
            playButton.BackColor = Color.White;
            
            bossButton.ForeColor = Color.White;
            bossButton.BackColor = Color.Black;
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

            bossButton.ForeColor = Color.White;
            bossButton.BackColor = Color.Black;
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

            bossButton.ForeColor = Color.White;
            bossButton.BackColor = Color.Black;
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

            bossButton.ForeColor = Color.White;
            bossButton.BackColor = Color.Black;
            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;
            leaderboardButton.BackColor = Color.Black;
            leaderboardButton.ForeColor = Color.White;
            controlsButton.BackColor = Color.Black;
            controlsButton.ForeColor = Color.White;
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            Form1.rushMode = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            controlsBox.Hide();
            backButton.Hide();
            playButton.Show();
            leaderboardButton.Show();
            controlsButton.Show();
            bossButton.Show();
            exitButton.Show();
            playButton.Focus();


        }

        private void bossButton_Click(object sender, EventArgs e)
        {
            Form1.rushMode = true;
            Form form1 = this.FindForm();
            form1.Controls.Remove(this);

            GameScreen gs = new GameScreen();
            form1.Controls.Add(gs);

            gs.Focus();
            gs.Location = new Point(form1.Width / 2 - gs.Width / 2, form1.Height / 2 - gs.Height / 2);
        }

        private void bossButton_Enter(object sender, EventArgs e)
        {
            bossButton.ForeColor = Color.Black;
            bossButton.BackColor = Color.White;

            leaderboardButton.ForeColor = Color.White;
            leaderboardButton.BackColor = Color.Black;
            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;
            exitButton.BackColor = Color.Black;
            exitButton.ForeColor = Color.White;
            controlsButton.BackColor = Color.Black;
            controlsButton.ForeColor = Color.White;
        }
    }
}
