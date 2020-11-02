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
    public partial class GameScreen : UserControl
    {
        //Global Variables
        bool aDown, dDown, wDown, sDown, escDown, spaDown;
        //Object
        Player player = new Player(0, 0, 0, 0, 0, 0, 0);

        public GameScreen()
        {
            //Initialize
            InitializeComponent();
           
            //Set starting values
            aDown = dDown = wDown = sDown = escDown = spaDown = false;


        } 

        private void keyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    spaDown = true;
                    break;
                case Keys.Escape:
                    escDown = true;
                    break;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Space:
                    spaDown = true;
                    break;
                case Keys.Escape:
                    escDown = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (aDown)
            {
                player.move("Left");
            }
            else if (dDown)
            {
                player.move("Right");
            }
            else if (wDown)
            {
                player.move("Up");
            }
            else if (sDown)
            {
                player.move("Down");
            }
            else if (escDown)
            {

            }
            if (spaDown)
            {
                player.attack();
            }



        }
    }
}
