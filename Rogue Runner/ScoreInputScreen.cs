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
    public partial class ScoreInputScreen : UserControl
    {
        //indexes for each letter box
        int index1, index2, index3 = 0;
        //variables for scores
        int enemies = GameScreen.enemiesKilled;
        string time = GameScreen.playerTime.ToString(@"mm\:ss\.ff");
        //list of letters
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public ScoreInputScreen()
        {
            InitializeComponent();
        }
        //goes back to gamescreen
        private void playAgainButton_Click(object sender, EventArgs e)
        {
            storeScore();

            #region change screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);

            gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);

            gs.Focus();
            #endregion
        }
        //returns to menu
        private void exitButton_Click(object sender, EventArgs e)
        {
            storeScore();
            #region change screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);

            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);

            ms.Focus();
            #endregion
        }
        //stores the score in the list
        public void storeScore()
        {
            
            string playerName = letter1Output.Text + letter2Output.Text + letter3Output.Text;
            

            Score newScores = new Score(playerName, time, enemies + "");

            Score.scores.Add(newScores);
        }
        
        private void playAgainButton_Enter(object sender, EventArgs e)
        {
            //plays again and adds high score
            playAgainButton.BackColor = Color.Firebrick;
            exitButton.BackColor = Color.White;
        }
        
        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Firebrick;
            playAgainButton.BackColor = Color.White;
        }


        //detects controls for the first letter and changes letter or focus based on input
        private void letter1Output_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    // UpArrowDown = true;

                    if (index1 < 25)
                    {
                        index1++;
                    }
                    else
                    {
                        index1 = 0;
                    }
                    letter1Output.Text = alphabet[index1];
                    Refresh();



                    break;
                case Keys.Down:
                    //DownArrowDown = true;


                    if (index1 > 0)
                    {
                        index1--;
                    }
                    else
                    {
                        index1 = 25;
                    }
                    letter1Output.Text = alphabet[index1];
                    Refresh();


                    break;
                case Keys.Right:
                    //RightArrowDown = true;
                    letter2Output.Enabled = true;
                    letter2Output.Focus();
                    letter1Output.Enabled = false;

                    letter1Output.ForeColor = Color.Black;
                    letter2Output.ForeColor = Color.Firebrick;
                    break;
                case Keys.Left:
                    //LeftArrowDown = true;
                    exitButton.Focus();

                    exitButton.Enabled = true;
                    exitButton.Focus();
                    letter1Output.Enabled = false;

                    letter1Output.ForeColor = Color.Black;

                    break;

                default:
                    break;
            }
        }
        //detects controls for the second letter and changes letter or focus based on input
        private void letter2Output_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    // UpArrowDown = true;

                    if (index2 < 25)
                    {
                        index2++;
                    }
                    else
                    {
                        index2 = 0;
                    }
                    letter2Output.Text = alphabet[index2];
                    Refresh();

                    break;
                case Keys.Down:
                    //DownArrowDown = true;


                    if (index2 > 0)
                    {
                        index2--;
                    }
                    else
                    {
                        index2 = 25;
                    }
                    letter2Output.Text = alphabet[index2];
                    Refresh();


                    break;
                case Keys.Right:
                    //RightArrowDown = true;

                    letter3Output.Enabled = true;
                    letter3Output.Focus();
                    letter2Output.Enabled = false;

                    letter2Output.ForeColor = Color.Black;
                    letter3Output.ForeColor = Color.Firebrick;
                    break;
                case Keys.Left:
                    //LeftArrowDown = true;

                    letter1Output.Enabled = true;
                    letter1Output.Focus();
                    letter2Output.Enabled = false;

                    letter1Output.ForeColor = Color.Firebrick;
                    letter2Output.ForeColor = Color.Black;

                    break;

                default:
                    break;
            }
        }
        //detects controls for the third letter and changes letter or focus based on input
        private void letter3Output_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    // UpArrowDown = true;

                    if (index3 < 25)
                    {
                        index3++;
                    }
                    else
                    {
                        index3 = 0;
                    }
                    letter3Output.Text = alphabet[index3];
                    Refresh();



                    break;
                case Keys.Down:
                    //DownArrowDown = true;


                    if (index3 > 0)
                    {
                        index3--;
                    }
                    else
                    {
                        index3 = 25;
                    }
                    letter3Output.Text = alphabet[index3];
                    Refresh();


                    break;
                case Keys.Right:
                    //RightArrowDown = true;

                    playAgainButton.Enabled = true;
                    playAgainButton.Focus();
                    letter3Output.Enabled = false;

                    letter3Output.ForeColor = Color.Black;

                    break;
                case Keys.Left:
                    //LeftArrowDown = true;

                    letter2Output.Enabled = true;
                    letter2Output.Focus();
                    letter3Output.Enabled = false;

                    letter2Output.ForeColor = Color.Firebrick;
                    letter3Output.ForeColor = Color.Black;

                    break;

                default:
                    break;
            }
        }

        //detects controls for the exit button and changes focus based on input
        private void exitButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    //RightArrowDown = true;

                    playAgainButton.Enabled = true;
                    playAgainButton.Focus();
                    exitButton.Enabled = false;



                    break;
                case Keys.Left:
                    //LeftArrowDown = true;

                    letter1Output.Enabled = true;
                    letter1Output.Focus();
                    exitButton.Enabled = false;

                    letter1Output.ForeColor = Color.Firebrick;
                    exitButton.BackColor = Color.Silver;
                    break;

                default:
                    break;
            }
        }
        //detects controls for the play again button and changes focus based on input
        private void playAgainButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    //RightArrowDown = true;

                    letter3Output.Enabled = true;
                    letter3Output.Focus();
                    playAgainButton.Enabled = false;
                    playAgainButton.BackColor = Color.White;
                    letter3Output.ForeColor = Color.Firebrick;
                    break;
                case Keys.Left:
                    //LeftArrowDown = true;

                    exitButton.Enabled = true;
                    exitButton.Focus();
                    playAgainButton.Enabled = false;
                    playAgainButton.BackColor = Color.White;
                    exitButton.BackColor = Color.Firebrick;

                    break;

                default:
                    break;
            }
        }
   
        private void ScoreInputScreen_Load(object sender, EventArgs e)
        {
            
            gameOverLabel.Text = $"Game Over \n You lived for {time} and defeated {enemies} enemies";

            letter1Output.Text = alphabet[0];
            letter2Output.Text = alphabet[0];
            letter3Output.Text = alphabet[0];

            letter1Output.Focus();
            letter1Output.ForeColor = Color.Firebrick;
            Refresh();
        }
    }
}

