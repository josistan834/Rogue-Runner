using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace Rogue_Runner
{
    
    public partial class GameScreen : UserControl
    {
        //Global Variables
        bool aDown, dDown, wDown, sDown, escDown, spaDown;
        SolidBrush roomBrush = new SolidBrush(Color.LightBlue);
        SolidBrush obsBrush = new SolidBrush(Color.Black);
        SolidBrush swordBrush = new SolidBrush(Color.Green);
        SolidBrush enemyBrush = new SolidBrush(Color.Red);
        int levelIndex = 0;
        
        public int swordCounter = 30sssa;
        bool attacked;
        public static int knock = 30;
        int knockCounter = 0;
        int cooldown = 0;
        int iframes = 30;

        int prevX, prevY;


        //Object

        public static Player player = new Player(0, 0, 20, 20, 4, 500, 100, "Up");

        Random randgen = new Random();
        List<Room> rooms = new List<Room>();
        List<Runner> run = new List<Runner>();
        Image heroUp = Properties.Resources.heroUp;
        Image heroDown = Properties.Resources.heroDown;
        Image heroLeft = Properties.Resources.heroLeft;
        Image heroRight = Properties.Resources.heroRight;
        Image heroHitUp = Properties.Resources.heroHitUp;
        Image heroHitDown = Properties.Resources.heroHitDown;
        Image heroHitLeft = Properties.Resources.heroLeftHit;
        Image heroHitRight = Properties.Resources.heroRightHit;
        Image hitUp = Properties.Resources.hitEffectUp;
        Image hitDown = Properties.Resources.hitEffectDown;
        Image hitLeft = Properties.Resources.hitEffectLeft;
        Image hitRight = Properties.Resources.hitEffect;


        private void generateFloor()
        {

            int width, height, obstacleCount, enemyCount;
            width = height = obstacleCount = 0;
            string type = "";
            List<Rectangle> obstacles = new List<Rectangle>();
            int size = randgen.Next(1, 4);

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
                        rX = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 175);
                        rY = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
                        Rectangle newRec = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec);
                        break;
                    case 2:
                        //vertical rectangle
                        rWidth = 50;
                        rHeight = 100;
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 175);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
                        Rectangle newRec2 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec2);
                        break;
                    case 3:
                        //L shape: |_
                        rWidth = 40;
                        rHeight = 80;
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 155);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
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
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 155);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
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
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 155);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
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
                        rY = randgen.Next(this.Height/2 - height/2 + 75, this.Height / 2 + height / 2 - 155);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
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
                        rWidth = 40;
                        rHeight = 100;
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 155);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 115);
                        Rectangle newRec11 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec11);

                        rWidth = 100;
                        rHeight = 40;
                        rX -= 30;
                        rY += 30;
                        Rectangle newRec12 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec12);
                        break;

                }
            }

            Runner fast = new Runner(500, 500, 30, 30, 6, 500, 50);
            run.Add(fast);
            Room newRoom = new Room(width, height, type, obstacles);
            rooms.Add(newRoom);

            Refresh();
        }

        public GameScreen()
        {
            //Initialize
            InitializeComponent();
            generateFloor();
            player.x = this.Width / 2;
            player.y = this.Height / 2 + rooms[levelIndex].height / 2 - 30;
            //Set starting values
            aDown = dDown = wDown = sDown = escDown = spaDown = attacked = false;
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
                    spaDown = false;
                    break;
                case Keys.Escape:
                    escDown = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (player.x <= this.Width / 2 - rooms[levelIndex].width / 2)
            {
                aDown = false;
            }
            if (player.x >= this.Width / 2 + rooms[levelIndex].width / 2 - player.w)
            {
                dDown = false;
            }
            if (player.y <= this.Height / 2 - rooms[levelIndex].height / 2)
            {
                wDown = false;
            }
            if (player.y >= this.Height / 2 + rooms[levelIndex].height / 2 - player.w)
            {
                sDown = false;
            }
            if (aDown)
            {
                player.move("Left");
            }
            if (dDown)
            {
                player.move("Right");
            }
            if (wDown)
            {
                player.move("Up");
            }
            if (sDown)
            {
                player.move("Down");
            }
            if (escDown)
            {

            }
            if (spaDown)
            {
                if (cooldown <= 0)
                {
                    cooldown = 70;
                    swordCounter = 0;
                    player.attack();
                    attacked = true;
                }
                
                
            }
            if (swordCounter > 30)
            {
                player.deleteSword();
                attacked = false;
                swordCounter--;
            }
            if (attacked == true)
            {
                player.attack();
                swordCounter++;
            }
            if (cooldown > 0)
            {
                cooldown--;
            }
            
            foreach(Runner r in run)
            {
                bool move = true;
                Rectangle runRec = new Rectangle(r.x, r.y, r.w, r.h);
                Rectangle playerRec = new Rectangle(player.x, player.y, player.w, player.h);
                foreach (Rectangle c in rooms[levelIndex].obstacles)
                {
                    if (c.IntersectsWith(runRec))
                    {
                        move = false;
                    }
                }
                if (knockCounter == 0 && !runRec.IntersectsWith(playerRec))
                {
                    if (move)
                    {
                        if (r.x - player.x < 200 && r.x - player.x > 20)
                        {
                            r.move("Left");
                        }
                        if (player.x - r.x < 200 && player.x - r.x > 20)
                        {
                            r.move("Right");
                        }
                        if (r.y - player.y < 200 && r.y - player.y > 20)
                        {
                            r.move("Up");
                        }
                        if (player.y - r.y < 200 && player.y - r.y > 20)
                        {
                            r.move("Down");
                        }
                    }
                    else
                    {
                        if (r.x - player.x < 200 && r.x - player.x > 20)
                        {
                            r.move("Down");
                        }
                        if (player.x - r.x < 200 && player.x - r.x > 20)
                        {
                            r.move("Up");
                        }
                        if (r.y - player.y < 200 && r.y - player.y > 20)
                        {
                            r.move("Right");
                        }
                        if (player.y - r.y < 200 && player.y - r.y > 20)
                        {
                            r.move("Left");
                        }
                    }
                    
                }
               
               
                if (runRec.IntersectsWith(player.sword))
                { 
                    r.damaged(player.damage, knock);
                    knockCounter = 70;
                    
                }
                
                if (runRec.IntersectsWith(playerRec))
                {
                    if(iframes <= 0)
                    {
                        player.damaged(r.damage);
                        r.damaged(0, knock);
                        knockCounter = 30;
                    }  
                    iframes = 30;
                }
                if (r.health <= 0)
                {
                    run.Remove(r);
                    break;
                }
            }
            if (knockCounter > 0)
            {
                knockCounter--;
            }
            if (iframes > 0)
            {
                iframes--;
            }
            if (player.health <= 0)
            {
                Application.Exit();
            }

            #region player collision
           

            foreach (Rectangle r in rooms[levelIndex].obstacles)
            {
                Rectangle playerRec = new Rectangle(player.x, player.y, player.w, player.h);
                if (playerRec.IntersectsWith(r))
                {
                    player.x = prevX;
                    player.y = prevY;
                    if (aDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                        //player.x += player.speed;
                    }
                    if (dDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                        //player.x -= player.speed;
                    }
                    if (wDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                        //player.y += player.speed;
                    }
                    if (sDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                       //player.y -= player.speed;
                    }
                }
            }
            #endregion


            prevX = player.x;
            prevY = player.y;

            Refresh();
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(roomBrush, this.Width / 2 - rooms[levelIndex].width / 2, this.Height / 2 - rooms[levelIndex].height / 2, rooms[levelIndex].width, rooms[levelIndex].height);
            
            foreach(Rectangle r in rooms[0].obstacles)
            {
                e.Graphics.FillRectangle(obsBrush, r.X, r.Y, r.Width, r.Height);
            }

            foreach(Runner r in run)
            {
                e.Graphics.FillRectangle(enemyBrush, r.x, r.y, r.w, r.h);
            }
            if(swordCounter >= 30)
            {
                if (player.direc == "Up")
                {
                    e.Graphics.DrawImage(heroUp, player.x, player.y, player.w, player.h);
                }
                else if (player.direc == "Down")
                {
                    e.Graphics.DrawImage(heroDown, player.x, player.y, player.w, player.h);
                }
                else if (player.direc == "Left")
                {
                    e.Graphics.DrawImage(heroLeft, player.x, player.y, player.w, player.h);
                }
                else if (player.direc == "Right")
                {
                    e.Graphics.DrawImage(heroRight, player.x, player.y, player.w, player.h);
                }
            }
            else
            {
                if (player.direc == "Up")
                {
                    e.Graphics.DrawImage(heroHitUp, player.x, player.y, player.w, player.h);
                }
                else if (player.direc == "Down")
                {
                    e.Graphics.DrawImage(heroHitDown, player.x, player.y, player.w, player.h);
                }
                else if (player.direc == "Left")
                {
                    e.Graphics.DrawImage(heroHitLeft, player.x, player.y, player.w, player.h);
                }
                else if (player.direc == "Right")
                {
                    e.Graphics.DrawImage(heroHitRight, player.x, player.y, player.w, player.h);
                }
            }

            if (player.direc == "Up")
            {
                e.Graphics.DrawImage(hitUp, player.sword);
            }
            else if (player.direc == "Down")
            {
                e.Graphics.DrawImage(hitDown, player.sword);
            }
            else if (player.direc == "Left")
            {
                e.Graphics.DrawImage(hitLeft, player.sword);
            }
            else if (player.direc == "Right")
            {
                e.Graphics.DrawImage(hitRight, player.sword);
            }


            e.Graphics.FillRectangle(enemyBrush, 100, 0, player.health , 20);
        }
    }
}
