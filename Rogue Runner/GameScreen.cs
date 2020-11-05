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
using Rogue_Runner.Properties;

namespace Rogue_Runner
{
    
    public partial class GameScreen : UserControl
    {
        //Global Variables
        #region Variables
        bool aDown, dDown, wDown, sDown, escDown, spaDown;
        SolidBrush roomBrush = new SolidBrush(Color.LightBlue);
        SolidBrush obsBrush = new SolidBrush(Color.White);
        SolidBrush swordBrush = new SolidBrush(Color.Green);
        SolidBrush enemyBrush = new SolidBrush(Color.Red);
        int levelIndex = 0;
        
        public int swordCounter = 30;
        bool attacked;
        int knockCounter = 0;
        int cooldown = 0;
        int iframes = 30;
        int runStun = 0;
        int prevX, prevY;
        int counter = 0;
        #endregion

        //Object
        #region Objects
        public static Player player = new Player(0, 0, 40, 40, 4, 500, 50, "Up");

        Random randgen = new Random();
        List<Room> rooms = new List<Room>();
        List<Runner> run = new List<Runner>();
        public static List<Soul> souls = new List<Soul>();
        List<Ranger> rangers = new List<Ranger>();
        List<Summoner> summoners = new List<Summoner>();
        #endregion

        #region images
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
        Image runUp = Properties.Resources.runnerUp;
        Image runDown = Properties.Resources.runnerFront;
        Image runLeft = Properties.Resources.runnerLeft;
        Image runRight = Properties.Resources.runnerRight;
        Image soulImage = Properties.Resources.soulEnemy;
        public static Image sumImage = Properties.Resources.summoner;
        Image sumAttack = Properties.Resources.summonerAttack;
        #endregion

        private void generateFloor()
        {

            int width, height, obstacleCount, enemyCount;
            width = height = obstacleCount = 0;
            string type = "";
            List<Rectangle> obstacles = new List<Rectangle>();
            Image image = Properties.Resources.big_room;
            int size = randgen.Next(1, 4);

            switch (size)
            {
                case 1:
                    type = "small";
                    image = Properties.Resources.small_room;
                    width = 550;
                    height = 450;
                    obstacleCount = randgen.Next(0, 3);
                    enemyCount = randgen.Next(1, 5);
                    break;
                case 2:
                    type = "medium";
                    image = Properties.Resources.med_room;
                    width = 700;
                    height = 525;
                    obstacleCount = randgen.Next(1, 4);
                    enemyCount = randgen.Next(2, 6);
                    break;
                case 3:
                    type = "large";
                    image = Properties.Resources.big_room;
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
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 115);
                        rX = randgen.Next(this.Width / 2 - width / 2 + 75, this.Width / 2 + width / 2 - 175);
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

                        rWidth = 40;
                        rHeight = 40;
                        rY += 40;
                        rX -= 40;
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

                        rWidth = 40;
                        rHeight = 40;
                        rY += 40;
                        rX -= 40;
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

                        rWidth = 40;
                        rHeight = 40;
                        rX += 40;
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

                        rWidth = 40;
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

                        rWidth = 30;
                        rHeight = 40;
                        rX -= 30;
                        rY += 30;
                        Rectangle newRec12 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec12);
                        
                        rWidth = 30;
                        rHeight = 40;
                        rX += 70;
                        Rectangle newRec13 = new Rectangle(rX, rY, rWidth, rHeight);
                        obstacles.Add(newRec13);
                        break;

                }
            }

            Runner fast = new Runner(500, 500, 30, 30, 5, 200, 50, 30);
            //run.Add(fast);

            Ranger gun = new Ranger(500, 500, 30, 30, 250, 30, "Left");
           // rangers.Add(gun);


            Soul spooky = new Soul(500, 400, 30, 30, 4, 150, 10);
            souls.Add(spooky);

            Summoner summoner = new Summoner(400, 400, 30, 30, 150, 30, 2);
            summoners.Add(summoner);


            Room newRoom = new Room(width, height, type, obstacles, image);
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

        #region Input
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
        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            HERO();

            #region enemies
            RU();
            SO();
            RA();
            SU();
            #endregion

            counter++;
            Refresh();
        }

        #region Custom Methods
        public void RU()
        {

            foreach (Runner r in run)
            {
                //r.movement = true;
                Rectangle runRec = new Rectangle(r.x, r.y, r.w, r.h);
                Rectangle playerRec = new Rectangle(player.x, player.y, player.w, player.h);
                foreach (Rectangle c in rooms[levelIndex].obstacles)
                {
                    if (c.IntersectsWith(runRec))
                    {
                        r.movement = false;
                        rooms[levelIndex].obstacles.Remove(c);
                        runStun = 60;
                        break;

                    }
                }
                if (runStun > 0)
                {
                    runStun--;
                }
                else if (runStun <= 0)
                {
                    r.movement = true;
                }
                if (r.movement == true)
                {
                    if (knockCounter == 0 && !runRec.IntersectsWith(playerRec))
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
                    else if (knockCounter != 0 || runRec.IntersectsWith(playerRec))
                    {
                        if (r.x <= this.Width / 2 - rooms[levelIndex].width / 2)
                        {

                        }
                        else if (r.x >= this.Width / 2 + rooms[levelIndex].width / 2 - r.w)
                        {

                        }
                        else if (r.y <= this.Height / 2 - rooms[levelIndex].height / 2)
                        {

                        }
                        else if (r.y >= this.Height / 2 + rooms[levelIndex].height / 2 - r.w)
                        {

                        }
                        else
                        {
                            r.move(player.direc);
                        }

                    }
                    else if (knockCounter != 0 && !runRec.IntersectsWith(playerRec))
                    {
                        if (r.x <= this.Width / 2 - rooms[levelIndex].width / 2)
                        {

                        }
                        else if (r.x >= this.Width / 2 + rooms[levelIndex].width / 2 - r.w)
                        {

                        }
                        else if (r.y <= this.Height / 2 - rooms[levelIndex].height / 2)
                        {

                        }
                        else if (r.y >= this.Height / 2 + rooms[levelIndex].height / 2 - r.w)
                        {

                        }
                        else
                        {
                            r.move(player.direc);
                        }

                    }
                }

                if (runRec.IntersectsWith(player.sword))
                {

                    r.damaged(player.damage);
                    knockCounter = 30;
                    if (r.iframes <= 0)
                    {
                        r.iframes = 30;
                    }

                }

                if (runRec.IntersectsWith(playerRec))
                {
                    if (iframes <= 0)
                    {
                        player.damaged(r.damage);
                        knockCounter = 10;
                        iframes = 30;
                    }

                }
                if (r.health <= 0)
                {
                    run.Remove(r);
                    break;
                }
                if (r.iframes > 0)
                {
                    r.iframes--;
                }

            }
            if (knockCounter > 0)
            {
                knockCounter--;
            }
        }
        public void SO()
        {
            foreach (Soul s in souls)
            {
                s.move();
            }

            foreach (Soul s in souls)
            {

                Rectangle spook = new Rectangle(s.x, s.y, s.w, s.h);
                foreach (Rectangle c in rooms[levelIndex].obstacles)
                { 
                    if (spook.IntersectsWith(c))
                    {
                        if (s.x <= c.X + (c.Width - 5) && s.x >= c.X - (s.w - 5))
                        {
                            s.up = !s.up;

                            s.x = s.preX;
                            s.y = s.preY;
                            break;
                        }
                        else if (s.y >= c.Y - s.h && s.y <= c.Y + c.Height)
                        {
                            s.right = !s.right;

                            s.x = s.preX;
                            s.y = s.preY;
                            break;
                        }
                    }
                }

                if (s.x <= this.Width / 2 - rooms[levelIndex].width / 2)
                {
                    s.right = !s.right;
                    s.x = s.preX;
                    s.y = s.preY;
                }
                else if (s.x >= this.Width / 2 + rooms[levelIndex].width / 2 - s.w)
                {
                    s.right = !s.right;
                    s.x = s.preX;
                    s.y = s.preY;
                }
                else if (s.y <= this.Height / 2 - rooms[levelIndex].height / 2)
                {
                    s.up = !s.up;
                    s.x = s.preX;
                    s.y = s.preY;
                }
                else if (s.y >= this.Height / 2 + rooms[levelIndex].height / 2 - s.h)
                {
                    s.up = !s.up;
                    s.x = s.preX;
                    s.y = s.preY;
                }

                Rectangle plr = new Rectangle(player.x, player.y, player.w, player.h);
                if (spook.IntersectsWith(plr))
                {
                    if (iframes <= 0)
                    {
                        player.damaged(s.damage);
                        iframes = 30;
                    }
                }
                if (spook.IntersectsWith(player.sword))
                {

                    s.damaged(player.damage);
                    if (player.direc == "Right")
                    {
                        s.right = true;
                    }
                    else if (player.direc == "Left")
                    {
                        s.right = false;
                    }
                    if (player.direc == "Up")
                    {
                        s.up = true;
                    }
                    else if (player.direc == "Down")
                    {
                        s.up = false;
                    }
                    if (s.iframes <= 0)
                    {
                        s.iframes = 30;
                    }
                }
                if (s.health <= 0)
                {
                    souls.Remove(s);
                    break;
                }
                if (s.iframes > 0)
                {
                    s.iframes--;
                }


            }

            foreach (Soul s in souls)
            {
                s.preX = s.x;
                s.preY = s.y;
            }
        }
        public void RA()
        {
            foreach (Ranger r in rangers)
            {
                Random location = new Random();
                if (counter % 45 == 0)
                {
                    if (Math.Abs(player.x - r.x) > Math.Abs(player.y - r.y))
                    {
                        if (r.x < player.x)
                        {
                            r.direc = "Right";
                        }
                        if (r.x > player.x)
                        {
                            r.direc = "Left";
                        }
                    }
                    else
                    {
                        if (r.y < player.y)
                        {
                            r.direc = "Down";
                        }
                        if (r.y > player.y)
                        {
                            r.direc = "Up";
                        }
                    }

                    r.attack();
                }
                if (r.iframes > 0)
                {
                    r.iframes--;
                }

                Rectangle rng = new Rectangle(r.x, r.y, r.w, r.h);
                Rectangle plr = new Rectangle(player.x, player.y, player.w, player.h);
                if (rng.IntersectsWith(player.sword))
                {
                    r.x = location.Next((this.Width / 2 - rooms[levelIndex].width / 2), (this.Width / 2 + rooms[levelIndex].width / 2 - r.w));
                    r.y = location.Next((this.Height / 2 - rooms[levelIndex].height / 2), (this.Height / 2 + rooms[levelIndex].height / 2 - r.w));
                    foreach (Rectangle c in rooms[levelIndex].obstacles)
                    {
                        if (c.IntersectsWith(rng))
                        {
                            r.x = location.Next((this.Width / 2 - rooms[levelIndex].width / 2), (this.Width / 2 + rooms[levelIndex].width / 2 - r.w));
                            r.y = location.Next((this.Height / 2 - rooms[levelIndex].height / 2), (this.Height / 2 + rooms[levelIndex].height / 2 - r.w));
                        }
                    }
                    if (r.iframes <= 0)
                    {
                        r.damaged(player.damage);
                        r.iframes = 30;
                    }
                    break;
                }
                if (r.health <= 0)
                {
                    rangers.Remove(r);
                    if (rangers.Count == 0)
                    {
                        foreach (Projectile b in Ranger.bullets)
                        {
                            Ranger.bullets.Clear();
                            break;
                        }
                    }
                    break;
                }

                foreach (Projectile b in Ranger.bullets)
                {
                    b.move();
                    Rectangle pew = new Rectangle(b.x, b.y, b.w, b.h);


                    if (b.x < 0 || b.x > this.Width || b.y < 0 || b.y > this.Height)
                    {
                        Ranger.bullets.Remove(b);
                        break;
                    }
                    if (pew.IntersectsWith(player.sword))
                    {
                        Ranger.bullets.Remove(b);
                        break;
                    }
                        if (pew.IntersectsWith(plr))
                    {
                        if (iframes <= 0)
                        {
                            player.damaged(b.damage);
                            iframes = 30;
                        }
                    }
                    bool intersect = false;
                    foreach (Rectangle c in rooms[levelIndex].obstacles)
                    {
                        if (pew.IntersectsWith(c))
                        {
                            intersect = true;
                        }

                    }
                    if (intersect)
                    {
                        Ranger.bullets.Remove(b);
                        intersect = false;
                        break;

                    }
                }
            }
        }
        public void SU()
        {
            foreach (Summoner r in summoners)
            {


                if (counter % 360 == 0)
                {
                    r.attack();
                    r.attacking = true;
                }
                if (r.iframes > 0)
                {
                    r.iframes--;
                }

                Rectangle sum = new Rectangle(r.x, r.y, r.w, r.h);
                if (sum.IntersectsWith(player.sword))
                {

                    if (r.iframes <= 0)
                    {
                        r.damaged(player.damage);


                        r.iframes = 30;
                    }
                    r.sumRun = true;
                    break;
                }
                if (r.health <= 0)
                {
                    summoners.Remove(r);
                    break;
                }
                if (r.sumRun)
                {
                    foreach (Rectangle c in rooms[levelIndex].obstacles)
                    {
                        if (sum.IntersectsWith(c))
                        {
                            r.sumRun = false;
                        }
                    }
                    if (r.x <= this.Width / 2 - rooms[levelIndex].width / 2)
                    {
                        r.sumRun = false;
                    }
                    else if (r.x >= this.Width / 2 + rooms[levelIndex].width / 2 - r.w)
                    {
                        r.sumRun = false;
                    }
                    else if (r.y <= this.Height / 2 - rooms[levelIndex].height / 2 + 20)
                    {
                        r.sumRun = false;
                    }
                    else if (r.y >= this.Height / 2 + rooms[levelIndex].height / 2 - r.w)
                    {
                        r.sumRun = false;
                    }
                    else
                    {
                        if (r.sumdir == null)
                        {
                            r.sumdir = player.direc;
                        }
                        r.attacking = false;
                        r.move(r.sumdir);


                    }

                }
            }
        }
        public void HERO()
        {
            #region movement
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
            #endregion

            #region attack
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
            #endregion

            #region collisions
            if (iframes > 0)
            {
                iframes--;
            }
            if (player.health <= 0)
            {
                Application.Exit();
            }

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
                    }
                    if (dDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                    }
                    if (wDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                    }
                    if (sDown == true)
                    {
                        aDown = false;
                        dDown = false;
                        wDown = false;
                        sDown = false;
                    }
                }
            }
            prevX = player.x;
            prevY = player.y;
            #endregion
        }
        #endregion
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(rooms[levelIndex].image, this.Width / 2 - rooms[levelIndex].width / 2, this.Height / 2 - rooms[levelIndex].height / 2, rooms[levelIndex].width, rooms[levelIndex].height);
            
            foreach(Rectangle r in rooms[0].obstacles)
            {
                e.Graphics.DrawImage(Resources.obstacleSprite, r.X, r.Y, r.Width, r.Height);
            }

            foreach(Runner r in run)
            {
                if (r.direc == "Left")
                {
                    e.Graphics.DrawImage(runLeft, r.x, r.y, r.w, r.h);
                }
                else if (r.direc == "Right")
                {
                    e.Graphics.DrawImage(runRight, r.x, r.y, r.w, r.h);
                }
                else if (r.direc == "Up")
                {
                    e.Graphics.DrawImage(runUp, r.x, r.y, r.w, r.h);
                }
                else if (r.direc == "Down")
                {
                    e.Graphics.DrawImage(runDown, r.x, r.y, r.w, r.h);
                }
            }
            foreach (Ranger r in rangers)
            {
                e.Graphics.FillRectangle(enemyBrush, r.x, r.y, r.w, r.h);
            }
            foreach (Summoner r in summoners)
            {
                if (r.attacking && counter % 50 == 0)
                {
                    if (r.image == sumImage)
                    {
                        r.image = sumAttack;
                    }
                    else if (r.image == sumAttack)
                    { 
                        r.image = sumImage;
                    }
                }
                e.Graphics.DrawImage(r.image, r.x, r.y, r.w, r.h);
               
            }
            foreach (Projectile b in Ranger.bullets)
            {
                e.Graphics.FillRectangle(enemyBrush, b.x, b.y, b.w, b.h);
            }
            foreach (Soul r in souls)
            {
                e.Graphics.DrawImage(soulImage, r.x, r.y, r.w, r.h);
            }
            if (swordCounter >= 30)
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


            e.Graphics.FillRectangle(enemyBrush, 150, this.Height - 22, player.health , 20);
            e.Graphics.DrawImage(Resources.heart_overlay, 150, this.Height - 22, 750, 20);
        }
    }
}
