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
        Random randgen = new Random();
        List<Room> rooms = new List<Room>();
        private void generateFloor()
        {

            int width, height, obstacleCount, enemyCount;
            int size = randgen.Next(1, 4);
            string type;
            List<Rectangle> obstacles = new List<Rectangle>();
           
            switch (size)
            {
                case 1:
                    type = "small";
                    width = 550;
                    height = 450;
                    obstacleCount = randgen.Next(0, 3);
                    enemyCount = randgen.Next(1, 5);
                    break;
                case 2:
                    type = "medium";
                    width = 700;
                    height = 525;
                    obstacleCount = randgen.Next(1, 4);
                    enemyCount = randgen.Next(2, 6);
                    break;
                case 3:
                    type = "large";
                    width = 850;
                    height = 650;
                    obstacleCount = randgen.Next(2, 6);
                    enemyCount = randgen.Next(4, 8);
                    break;
            }

            for (int i = 0; i < obstacleCount; i++)
            {
                int obsType = randgen.Next(1, 8);
                int rWidth, rHeight, rX, rY;


                switch (obsType)
                {
                    case 1:
                        //horizontal rectancle
                        rWidth = 100;
                        rHeight = 50;
                        rX = randgen.Next(75, width - 175);
                        rY = randgen.Next(75, height - 125);
                        Rectangle newRec = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec);
                        break;
                    case 2:
                        //vertical rectangle
                        rWidth = 50;
                        rHeight = 100;
                        rY = randgen.Next(75, height - 175);
                        rX = randgen.Next(75, width - 125);
                        Rectangle newRec2 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec2);
                        break;
                    case 3:
                        //L shape: |_
                        rWidth = 40;
                        rHeight = 80;
                        rY = randgen.Next(75, height - 155);
                        rX = randgen.Next(75, width - 115);
                        Rectangle newRec3 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec3);

                        rWidth = 80;
                        rHeight = 40;
                        rY += 40;
                        Rectangle newRec4 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec4);
                        break;
                    case 4:
                        //L shape: _|
                        rWidth = 40;
                        rHeight = 80;
                        rY = randgen.Next(75, height - 155);
                        rX = randgen.Next(75, width - 115);
                        Rectangle newRec5 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec5);

                        rWidth = 80;
                        rHeight = 40;
                        rY += 40;
                        rX += 40;
                        Rectangle newRec6 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec6);
                        break;
                    case 5:
                        //L shape: upside down
                        rWidth = 40;
                        rHeight = 80;
                        rY = randgen.Next(75, height - 155);
                        rX = randgen.Next(75, width - 115);
                        Rectangle newRec7 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec7);

                        rWidth = 80;
                        rHeight = 40;
                        Rectangle newRec8 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec8);

                        break;
                    case 6:
                        //L shape: upside down facing left
                        rWidth = 40;
                        rHeight = 80;
                        rY = randgen.Next(75, height - 155);
                        rX = randgen.Next(75, width - 115);
                        Rectangle newRec9 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec9);

                        rWidth = 80;
                        rHeight = 40;
                        rX -= 40;
                        Rectangle newRec10 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec10);

                        break;
                    case 7:
                        //+ shape
                        rWidth = 30;
                        rHeight = 60;
                        rY = randgen.Next(75, height - 155);
                        rX = randgen.Next(75, width - 115);
                        Rectangle newRec11 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec11);

                        rWidth = 60;
                        rHeight = 30;
                        rX -= 15;
                        rY += 15;
                        Rectangle newRec12 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec12);
                        break;
                }
            }

            Room newRoom = new Room(width, height, type, obstacles);
            rooms.Add(newRoom);
        }

        public GameScreen()
        {
            InitializeComponent();
        }
    }
}
