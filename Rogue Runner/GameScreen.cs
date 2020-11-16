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
using System.Security.Cryptography.X509Certificates;

namespace Rogue_Runner
{

    public partial class GameScreen : UserControl
    {
        //Global Variables
        #region Variables
        public static TimeSpan playerTime = new TimeSpan();
        public static int enemiesKilled = 0;

        bool aDown, dDown, wDown, sDown, escDown, spaDown;
        SolidBrush roomBrush = new SolidBrush(Color.Black);
        SolidBrush obsBrush = new SolidBrush(Color.White);
        SolidBrush swordBrush = new SolidBrush(Color.Green);
        SolidBrush enemyBrush = new SolidBrush(Color.White);

        Pen activeTent = new Pen(Color.Orange);
        Pen inactiveTent = new Pen(Color.LightBlue);

        Font drawFont = new Font("Century Gothic", 13); 

        Rectangle exitDoorRec = new Rectangle(0, 0, 1, 1);
        public static int levelIndex = 0;

        public static int swordCounter = 30;
        bool attacked;
        int knockCounter = 0;
        int cooldown = 0;
        int iframes = 30;
        int runStun = 0;
        int prevX, prevY;
        int counter = 0;
        int bossType = 0;

        bool bossDead = false;
        #endregion

        //Object
        #region Objects
        public static Player player = new Player(0, 0, 40, 40, 4, 500, 50, "Up");
        public List<Boss> bosses = new List<Boss>();
        public static List<Tentacle> tentacles = new List<Tentacle>();
        public static List<BiteBall> bballs = new List<BiteBall>();
        Random randgen = new Random();
        public static List<Room> rooms = new List<Room>();
        #endregion

        //Images
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
        Image rangerUp = Properties.Resources.rangerUp;
        Image rangerDown = Properties.Resources.rangerDown;
        Image rangerLeft = Properties.Resources.rangerLeft;
        Image rangerRight = Properties.Resources.rangerRight;
        Image atkPower = Properties.Resources.ATKPower;
        Image hpPower = Properties.Resources.HpPower;
        Image speedPower = Properties.Resources.SpeedPower;
        Image rangePower = Properties.Resources.rangePower;
        #endregion

        //generate the levels and enemies
        #region level creation
        private void generateFloor()
        {
            //preset variables for rooms
            int width, height, obstacleCount, enemyCount;
            width = height = obstacleCount = enemyCount = 0;
            string type = "";
            List<Rectangle> obstacles = new List<Rectangle>();
            Image image = Properties.Resources.big_room;
            int size = randgen.Next(1, 4);

            //create roomes based on size
            switch (size)
            {
                case 1:
                    type = "small";
                    image = Properties.Resources.small_room;
                    width = 550;
                    height = 450;
                    obstacleCount = randgen.Next(0, 3);
                    enemyCount = randgen.Next(1, 3);
                    break;
                case 2:
                    type = "medium";
                    image = Properties.Resources.med_room;
                    width = 700;
                    height = 525;
                    obstacleCount = randgen.Next(1, 4);
                    enemyCount = randgen.Next(1, 4);
                    break;
                case 3:
                    type = "large";
                    image = Properties.Resources.big_room;
                    width = 850;
                    height = 650;
                    obstacleCount = randgen.Next(2, 6);
                    enemyCount = randgen.Next(2, 5);
                    break;
            }

            //add obstacles to rooms
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
                        rY = randgen.Next(this.Height / 2 - height / 2 + 75, this.Height / 2 + height / 2 - 155);
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

            //add created room to the list
            Room newRoom = new Room(width, height, type, obstacles, image);
            rooms.Add(newRoom);

            //create enemies 
            for (int i = 0; i < enemyCount; i++)
            {
                int enemyType = randgen.Next(1, 5);
                int enmX = randgen.Next((this.Width / 2 - newRoom.width / 2), (this.Width / 2 + newRoom.width / 2 - 30));
                int enmY = randgen.Next((this.Height / 2 -newRoom.height / 2), (this.Height / 2 + newRoom.height / 2 - 30));
                Rectangle tempEnemy = new Rectangle(enmX, enmY, 30, 30);

                //do not allow enemies to spawn in an obstacle
                foreach (Rectangle c in newRoom.obstacles)
                {  
                    if (c.IntersectsWith(tempEnemy))
                    {
                        enmX = randgen.Next((this.Width / 2 - newRoom.width / 2), (this.Width / 2 + newRoom.width / 2 - 30));
                        enmY = randgen.Next((this.Height / 2 - newRoom.height / 2), (this.Height / 2 + newRoom.height / 2 - 30));
                    }
                }
                
                //adding enemies to their respective lists
                if (enemyType == 1)
                {
                    Runner fast = new Runner(enmX, enmY, 30, 30, 5, 150, 25, 30);
                    newRoom.run.Add(fast);

                }
                else if (enemyType == 2)
                {
                    Summoner summoner = new Summoner(enmX, enmY, 30, 30, 100    , 30, 2);
                    newRoom.summoners.Add(summoner);

                }
                else if (enemyType == 3)
                {
                    Soul spooky = new Soul(enmX, enmY, 30, 30, 4, 150, 10);
                    newRoom.souls.Add(spooky);
                }
                else if (enemyType == 4)
                {
                    Ranger gun = new Ranger(enmX, enmY, 30, 30, 250, 30, "Left");
                    newRoom.rangers.Add(gun);
                }
            }

            //refresh the gamescreen
            Refresh();
        }

        private void assembleFloor()
        {
            for (int i = 0; i < 12; i++)
            {
                generateFloor();
            }
            for (int i = 0; i < 3; i++)
            {
                List<Rectangle> obstacles = new List<Rectangle>();

                Room newPowerRoom = new Room(700, 525, "powerUp", obstacles, Resources.med_room);
                Powerups newPowerUp = new Powerups(randgen.Next(1, 5), this.Width / 2, this.Height / 2, 50, 50);
                newPowerRoom.powers.Add(newPowerUp);
                rooms.Add(newPowerRoom);
                

            }
            rooms = rooms.OrderBy(a => Guid.NewGuid()).ToList();

            List<Rectangle> bossObstacles = new List<Rectangle>();
            Room bossRoom = new Room(850, 650, "boss", bossObstacles, Resources.big_room);
            rooms.Add(bossRoom);

        }
        #endregion

        //initialize the gamescreen objects and player variables
        public GameScreen()
        {
            //Initialize
            InitializeComponent();
            assembleFloor();
            player.x = this.Width / 2;
            player.y = this.Height / 2 + rooms[levelIndex].height / 2 - 30;
            //Set starting values
            aDown = dDown = wDown = sDown = escDown = spaDown = attacked = false;
            counter = 0;
            enemiesKilled = 0;
        }

        //recieve player input
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
            //Runs custom hero method for all hero actions and input
            HERO();

            //check for collisions with powers and the player
            POWER();

            //run each of the individual enemy methods
            #region enemies
            RU();
            SO();
            RA();
            SU();
            BB();
            BOSS();
            #endregion

            //check if player is touching exit then move to next room
            nextRoom();

            //increasse counter
            counter++;

            //redraw gamescreen
            Refresh();
        }

        #region Custom Methods
        public void POWER()
        {
            //check collisions with player 
            Rectangle heroRec = new Rectangle(player.x, player.y, player.w, player.h);
            foreach (Powerups p in rooms[levelIndex].powers)
            {
                Rectangle powerRec = new Rectangle(p.x, p.y, p.w, p.h);

                //when colliding, give a power and delete the powerup
                if (powerRec.IntersectsWith(heroRec))
                {
                    p.powerGoBrrr();
                    rooms[levelIndex].powers.Remove(p);
                    break;
                }
            }
        }
        public void RU()
        {

            foreach (Runner r in rooms[levelIndex].run)
            {
                //create rectangles required for collisions
                Rectangle runRec = new Rectangle(r.x, r.y, r.w, r.h);
                Rectangle playerRec = new Rectangle(player.x, player.y, player.w, player.h);

                //check if colliding with obstacles
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

                //check if stunned and decreasse stun
                if (runStun > 0)
                {
                    runStun--;
                }

                //if not stunned allow movement
                else if (runStun <= 0)
                {
                    r.movement = true;
                }

                //if movement is allowed move runner
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

                //if the runner hits sword take damage
                if (runRec.IntersectsWith(player.sword))
                {

                    r.damaged(player.damage);
                    knockCounter = 30;
                    if (r.iframes <= 0)
                    {
                        r.iframes = 30;
                    }

                }
                
                //if the runner hits player deal damage
                if (runRec.IntersectsWith(playerRec))
                {
                    if (iframes <= 0)
                    {
                        player.damaged(r.damage);
                        knockCounter = 10;
                        iframes = 30;
                    }

                }

                //when health is 0 remove the runner
                if (r.health <= 0)
                {
                    enemiesKilled++;
                    rooms[levelIndex].run.Remove(r);
                    break;
                }

                //while there are iframes make them go down
                if (r.iframes > 0)
                {
                    r.iframes--;
                }

            }

            //while the runner has knockback decrease knockback timer
            if (knockCounter > 0)
            {
                knockCounter--;
            }
        }
        public void SO()
        {
            //run movement method for souls
            foreach (Soul s in rooms[levelIndex].souls)
            {
                s.move();
            }

            //if the soul hits an obstacle change direction
            foreach (Soul s in rooms[levelIndex].souls)
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

                //if the soul hits a wall change direction
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

                //create a rectangle for the player
                Rectangle plr = new Rectangle(player.x, player.y, player.w, player.h);

                //if the soul hits a player deal damage
                if (spook.IntersectsWith(plr))
                {
                    if (iframes <= 0)
                    {
                        player.damaged(s.damage);
                        iframes = 30;
                    }
                }

                //if the soul hits a sword take damage and change direction
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

                //if the soul health is 0 remove the soul
                if (s.health <= 0)
                {
                    enemiesKilled++;
                    rooms[levelIndex].souls.Remove(s);
                    break;
                }

                //while the soul has iframes decreasse them
                if (s.iframes > 0)
                {
                    s.iframes--;
                }
            }

            //prevent clipping into the obstacles
            foreach (Soul s in rooms[levelIndex].souls)
            {
                s.preX = s.x;
                s.preY = s.y;
            }
        }

        public void RA()
        {
            foreach (Ranger r in rooms[levelIndex].rangers)
            {
                Random location = new Random();
                //look towards player
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

                //if iframes decreasse
                if (r.iframes > 0)
                {
                    r.iframes--;
                }

                //create rectangle for ranger and player
                Rectangle rng = new Rectangle(r.x, r.y, r.w, r.h);
                Rectangle plr = new Rectangle(player.x, player.y, player.w, player.h);

                //if ranger touching sword teleport and take damage
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

                //if no health remove
                if (r.health <= 0)
                {
                    enemiesKilled++;
                    rooms[levelIndex].rangers.Remove(r);
                    if (rooms[levelIndex].rangers.Count == 0)
                    {
                        foreach (Projectile b in Ranger.bullets)
                        {
                            Ranger.bullets.Clear();
                            break;
                        }
                    }
                    break;
                }

                
            }
            foreach (Projectile b in Ranger.bullets)
            {
                //move bullet
                b.move();

                //create rectangles for collisions
                Rectangle pew = new Rectangle(b.x, b.y, b.w, b.h);
                Rectangle plr = new Rectangle(player.x, player.y, player.w, player.h);

                //when the bullet hits anything remove it
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

                //if bullet hits player deal damage
                if (pew.IntersectsWith(plr))
                {
                    if (iframes <= 0)
                    {
                        player.damaged(b.damage);
                        iframes = 30;
                    }
                }

                //if bullet hits obstacle remove it
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

        private void playButton_Click(object sender, EventArgs e)
        {
            //continue the game and hide pause menu
            escDown = false;
            gameTimer.Start();
            pauseLabel.Hide();
            pauseMenu.Hide();
            playButton.Hide();
            exitButton.Hide();
            this.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //end program on exit clck
            Application.Exit();
        }

        public void SU()
        {
            foreach (Summoner r in rooms[levelIndex].summoners)
            {

                //summon a soul once every 6 seconds
                if (counter % 360 == 0)
                {
                    Soul soul = new Soul(r.x, r.y + 10, 20, 20, 3, 100, 10);
                    rooms[levelIndex].souls.Add(soul);
                    r.attacking = true;
                }

                //if there are ifrmaes decreasse them
                if (r.iframes > 0)
                {
                    r.iframes--;
                }

                //create rectangle for summoner
                Rectangle sum = new Rectangle(r.x, r.y, r.w, r.h);

                //if touch sword get damaged
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

                //if no health remove
                if (r.health <= 0)
                {
                    enemiesKilled++;
                    rooms[levelIndex].summoners.Remove(r);
                    break;
                }

                //run away when hit until hitting a wall
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
        public void BOSS()
        {
            //if no boss in boss room make boss

            if (rooms[levelIndex].type == "boss" && bossType == 0 && bossDead == false)
            {
                bossType = randgen.Next(1, 4);
                
            }
            //if boss type is 1 make boss and do random attacks
            if (bossType == 1)
            {
                if (bosses.Count < 1)
                {
                    Boss boss = new Boss(0, rooms[levelIndex].height / 9, 60, rooms[levelIndex].height - rooms[levelIndex].height / 6, 5, 500, 20, 30);
                    bosses.Add(boss);
                }
                else
                {
                    Rectangle bossRec = new Rectangle(bosses[0].x, bosses[0].y, bosses[0].w, bosses[0].h);
                    Rectangle plrRec = new Rectangle(player.x, player.y, player.w, player.h);
                    if (bossRec.IntersectsWith(plrRec))
                    {
                        if (iframes <= 0)
                        {
                            player.damaged(bosses[0].damage);
                            iframes = 30;
                        }
                    }
                    if (bossRec.IntersectsWith(player.sword))
                    {
                        bosses[0].damaged(player.damage);
                        bosses[0].iframes = 30;
                    }

                    if (bosses[0].attack == 0)
                    {
                        bosses[0].attack = randgen.Next(1, 4);
                    }
                    if (bosses[0].iframes > 0)
                    {
                        bosses[0].iframes--;
                    }

                    if (bosses[0].attack == 1)
                    {
                        if (bosses[0].x <= this.Width / 2 + rooms[levelIndex].width / 2 - bosses[0].w && bosses[0].right)
                        {
                            bosses[0].attack1("goRight");

                        }
                        else if (bosses[0].x >= this.Width / 2 - rooms[levelIndex].width / 2 && !bosses[0].right)
                        {
                            bosses[0].attack1("goLeft");
                        }
                        else
                        {
                            bosses[0].right = !bosses[0].right;
                            bosses[0].bounces++;
                        }
                    }
                    if (bosses[0].attack == 2)
                    {
                        bool allChanged = false;
                        if (counter % 30 == 0 && tentacles.Count <= 8)
                        {
                            bosses[0].attack1("tentacle");
                        }
                        if (counter % 60 == 0)
                        {
                            int CHANGED = 0;
                            foreach (Tentacle t in tentacles)
                            {
                                if (CHANGED == 0 && !t.active)
                                {
                                    t.active = true;
                                    CHANGED++;

                                }

                            }
                            int index = tentacles.FindIndex(t => t.active == false);
                            if (index < 0)
                            {
                                allChanged = true;
                            }
                            else
                            {
                                allChanged = false;
                            }
                        }
                        if (tentacles.Count > 7 && allChanged)
                        {

                            bosses[0].attack = 0;
                            tentacles.Clear();
                        }

                        foreach (Tentacle t in tentacles)
                        {
                            RectangleF tenti = new RectangleF(Math.Min(t.x, t.x2), Math.Min(t.y, t.y2), Math.Abs(t.x - t.x2), Math.Abs(t.y - t.y2));
                            if (tenti.IntersectsWith(plrRec))
                            {
                                if (t.active)
                                {
                                    if (iframes <= 0)
                                    {
                                        player.damaged(bosses[0].damage);
                                        iframes = 30;
                                    }

                                }

                            }
                        }


                    }
                    if (bosses[0].attack == 3)
                    {
                        bosses[0].attack1("bite");
                        if (counter % 60 == 0)
                        {
                            BiteBall bb = new BiteBall(bosses[0].x + 100, bosses[0].y + 100 + 10, 20, 20, 3, 100, 10);
                            bballs.Add(bb);
                            bosses[0].bounces++;
                        }
                        if (bosses[0].bounces == 20)
                        {
                            bballs.Clear();
                            bosses[0].bounces = 0;
                            bosses[0].attack = 0;
                        }
                    }
                }
            }
            //if boss type is 2 make boss and do random attacks
            else if (bossType == 2)
            {
                if (bosses.Count < 1)
                {
                    Boss boss = new Boss(this.Width / 2 - 45, this.Height / 2, 90, 90, 5, 500, 5, 30);
                    bosses.Add(boss);
                }
                else
                {
                    Rectangle bossRec = new Rectangle(bosses[0].x, bosses[0].y, bosses[0].w, bosses[0].h);
                    Rectangle plrRec = new Rectangle(player.x, player.y, player.w, player.h);
                    if (bossRec.IntersectsWith(plrRec) || bosses[0].tornadoRec.IntersectsWith(plrRec) || bosses[0].tornadoRec2.IntersectsWith(plrRec))
                    {
                        if (iframes <= 0)
                        {
                            player.damaged(bosses[0].damage);
                            iframes = 30;
                        }
                    }
                    if (bossRec.IntersectsWith(player.sword))
                    {
                        bosses[0].damaged(player.damage);
                        bosses[0].iframes = 30;
                    }
                    if (bosses[0].attack == 0)
                    {
                        bosses[0].attack = randgen.Next(1, 4);
                    }
                    if (bosses[0].iframes > 0)
                    {
                        bosses[0].iframes--;
                    }
                    if (bosses[0].attack == 1)
                    {
                        bosses[0].attack2("Fire");

                        if (bosses[0].toNum > 4)
                        {
                            bosses[0].toNum = 0;
                            bosses[0].attack = 0;
                            bosses[0].fires.Clear();
                        }
                        foreach (Rectangle f in bosses[0].fires)
                        {
                            if (f.IntersectsWith(plrRec))
                            {
                                if (iframes <= 0)
                                {
                                    player.damaged(bosses[0].damage * 2);
                                    iframes = 30;
                                }
                            }
                        }
                    }
                    if (bosses[0].attack == 2)
                    {
                        bosses[0].x = this.Width / 2 - 45;
                        bosses[0].y = this.Height / 2;
                        bosses[0].attack2("Flap");
                        if (counter % 120 == 0 && bosses[0].toNum < 4)
                        {
                            bosses[0].toNum++;
                            bosses[0].tX = 0;
                            bosses[0].tX2 = 900;
                        }
                        else if (bosses[0].toNum >= 4)
                        {
                            bosses[0].toNum = 0;
                            bosses[0].attack = 0;
                            bosses[0].tornadoRec = new Rectangle(0, 0, 0, 0);
                            bosses[0].tornadoRec2 = new Rectangle(0, 0, 0, 0);
                        }


                    }
                    if (bosses[0].attack == 3)
                    {
                        if (bosses[0].toNum == 0)
                        {
                            bosses[0].x = player.x;
                            bosses[0].y = player.y;
                            bosses[0].toNum = 1;
                        }
                        if (counter % 30 == 0 && bosses[0].toNum != 0)
                        {
                            bosses[0].attack2("Grab");
                            bosses[0].iframes = 100;
                        }
                        if (bosses[0].toNum > 9)
                        {
                            bosses[0].toNum = 0;
                            bosses[0].attack = 0;
                        }

                    }
                }
            }
            //if boss type is 3 make boss and do random attacks
            else if (bossType == 3)
            {
                if (bosses.Count < 1)
                {
                    Boss boss = new Boss(this.Width / 2 - 45, this.Height / 2, 30, 50, 5, 500, 20, 30);
                    bosses.Add(boss);
                }
                else
                {
                    Rectangle bossRec = new Rectangle(bosses[0].x, bosses[0].y, bosses[0].w, bosses[0].h);
                    Rectangle plrRec = new Rectangle(player.x, player.y, player.w, player.h);
                    if (bossRec.IntersectsWith(plrRec) || bosses[0].tornadoRec.IntersectsWith(plrRec) || bosses[0].tornadoRec2.IntersectsWith(plrRec))
                    {
                        if (iframes <= 0)
                        {
                            player.damaged(bosses[0].damage);
                            iframes = 30;
                        }
                    }
                    if (bossRec.IntersectsWith(player.sword))
                    {
                        bosses[0].damaged(player.damage);
                        bosses[0].iframes = 30;
                    }
                    if (bosses[0].attack == 0)
                    {
                        bosses[0].attack = randgen.Next(1, 4);
                    }
                    if (bosses[0].iframes > 0)
                    {
                        bosses[0].iframes--;
                    }
                    if (bosses[0].attack == 1)
                    {
                        if (counter % 30 == 0)
                        {
                            bosses[0].attack3("regenerate");
                        }
                        if (bossRec.IntersectsWith(player.sword))
                        {
                            bosses[0].damaged(player.damage);
                            bosses[0].iframes = 30;
                            bosses[0].attack = 0;
                            bosses[0].toNum = 0;
                        }
                    }
                    if (bosses[0].attack == 2)
                    {
                        bosses[0].attack3("teleport");
                        if (counter % 300 == 0)
                        {
                            bosses[0].timer = 0;
                            bosses[0].toNum++;
                        }
                        
                        if (bossRec.IntersectsWith(player.sword))
                        {
                            bosses[0].fires.Clear();
                            bosses[0].damaged(player.damage);
                            bosses[0].iframes = 30;
                            bosses[0].x = randgen.Next((this.Width / 2 - rooms[levelIndex].width / 2), (this.Width / 2 + rooms[levelIndex].width / 2 - bosses[0].w));
                            bosses[0].y = randgen.Next((this.Height / 2 - rooms[levelIndex].height / 2), (this.Height / 2 + rooms[levelIndex].height / 2 - bosses[0].h));
                            
                        }
                        if (bosses[0].toNum == 5)
                        {
                            bosses[0].attack = 0;
                            bosses[0].toNum = 0;
                        }
                        foreach (Rectangle f in bosses[0].fires)
                        {
                            if (f.IntersectsWith(plrRec))
                            {
                                if (iframes <= 0)
                                {
                                    player.damaged(bosses[0].damage * 3);
                                    iframes = 30;
                                }
                            }
                        }
                    }
                    if (bosses[0].attack == 3)
                    {
                        if (counter % 30 == 0 && bosses[0].toNum <= 20)
                        {
                            bosses[0].attack3("shoot");
                            bosses[0].toNum++;
                        }
                        if (bosses[0].toNum > 20)
                        {
                            bosses[0].attack = 0;
                            bosses[0].toNum = 0;
                        }
                            
                    }
                }
            }

            //if boss dies remove it and reset boss variables
            if (bosses.Count > 0)
            {
                if (bosses[0].health <= 0)
                {
                    bosses.RemoveAt(0);
                    bossDead = true;
                    bossType = 0;
                    tentacles.Clear();
                    Powerups newPowerUp = new Powerups(randgen.Next(1, 5), this.Width / 2, this.Height / 2, 50, 50);
                    rooms[levelIndex].powers.Add(newPowerUp);
                }
            }
            
        }
        public void BB()
        {
            //move ball
            foreach (BiteBall r in bballs)
            {
                if (!r.reflected)
                {
                    if (r.x - player.x < 800 && r.x - player.x > 5)
                    {
                        r.move("Left");
                    }
                    if (player.x - r.x < 800 && player.x - r.x > 5)
                    {
                        r.move("Right");
                    }
                    if (r.y - player.y < 800 && r.y - player.y > 5)
                    {
                        r.move("Up");
                    }
                    if (player.y - r.y < 800 && player.y - r.y > 5)
                    {
                        r.move("Down");
                    }
                }
                else
                {
                    r.move(r.direc);
                }

            }

            //make rectangles and check collisions
            foreach (BiteBall s in bballs)
            {
                Rectangle spook = new Rectangle(s.x, s.y, s.w, s.h);
                Rectangle plr = new Rectangle(player.x, player.y, player.w, player.h);
                Rectangle bosRec = new Rectangle();
                if (bosses.Count > 0)
                {
                    bosRec = new Rectangle(bosses[0].x, bosses[0].y, bosses[0].w, bosses[0].h);
                }
                
                //if touching player or boss deal damage
                if (spook.IntersectsWith(plr))
                {
                    if (iframes <= 0)
                    {
                        player.damaged(s.damage);
                        bballs.Remove(s);
                        iframes = 30;
                        break;
                    }
                }
                if (spook.IntersectsWith(bosRec))
                {
                    bosses[0].damaged(s.damage);
                    bballs.Remove(s);
                    break;
                }

                //if touching sword take damage
                if (spook.IntersectsWith(player.sword))
                {
                    s.direc = player.direc;
                    s.damaged(player.damage);
                    s.reflected = true;

                    if (s.iframes <= 0)
                    {
                        s.iframes = 30;
                    }
                }

                //if no health remove
                if (s.health <= 0)
                {
                    bballs.Remove(s);
                    break;
                }
                if (s.iframes > 0)
                {
                    s.iframes--;
                }


            }

            //prevent clipping
            foreach (BiteBall s in bballs)
            {
                s.preX = s.x;
                s.preY = s.y;
            }
        }
        public void HERO()
        {
            //movement and input for player
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

            //pause game
            if (escDown)
            {
                pauseLabel.Show();
                pauseMenu.Show();
                playButton.Show();
                exitButton.Show();
                playButton.Focus();
                gameTimer.Stop();
            }
            #endregion

            #region attack
            //attack with sword
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
            //if sword counter is over remove the sword
            if (swordCounter > 30)
            {
                player.deleteSword();
                attacked = false;
                swordCounter--;
            }
            //while attacking increase the sword counter
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
            //playercollisions
            if (iframes > 0)
            {
                iframes--;
            }
            //if player dies end 
            if (player.health <= 0)
            {
                Application.Exit();
            }

            //if touching obstacles dont
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
            //draw everything on the gamescreen (enemies, players, obstacles, rooms )
            
            e.Graphics.DrawImage(rooms[levelIndex].image, this.Width / 2 - rooms[levelIndex].width / 2, this.Height / 2 - rooms[levelIndex].height / 2, rooms[levelIndex].width, rooms[levelIndex].height);

            TimeSpan addTime = new TimeSpan((counter * 15) * 10000);
            playerTime = addTime;
            
            e.Graphics.DrawString(playerTime.ToString(@"mm\:ss\.ff"), drawFont, obsBrush, (this.Width / 4) * 3, 0);

            if (exitDoorRec.X != 0)
            {
                e.Graphics.FillRectangle(roomBrush, exitDoorRec);
            }

            foreach (Rectangle r in rooms[levelIndex].obstacles)
            {
                e.Graphics.DrawImage(Resources.obstacleSprite, r.X, r.Y, r.Width, r.Height);
            }

            if (tentacles != null)
            {
                foreach (Tentacle t in tentacles)
                {
                    if (t.active)
                    {
                        e.Graphics.DrawLine(activeTent, t.x, t.y, t.x2, t.y2);
                    }
                    else
                    {
                        e.Graphics.DrawLine(inactiveTent, t.x, t.y, t.x2, t.y2);
                    }

                }
            }


            foreach (Runner r in rooms[levelIndex].run)
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
            foreach (Ranger r in rooms[levelIndex].rangers)
            {
                if (r.direc == "Left")
                {
                    e.Graphics.DrawImage(rangerLeft, r.x, r.y, r.w, r.h);
                }
                else if (r.direc == "Right")
                {
                    e.Graphics.DrawImage(rangerRight, r.x, r.y, r.w, r.h);
                }
                else if (r.direc == "Up")
                {
                    e.Graphics.DrawImage(rangerUp, r.x, r.y, r.w, r.h);
                }
                else if (r.direc == "Down")
                {
                    e.Graphics.DrawImage(rangerDown, r.x, r.y, r.w, r.h);
                }
            }
            foreach (Boss b in bosses)
            {
                e.Graphics.FillRectangle(enemyBrush, b.x, b.y, b.w, b.h);
                e.Graphics.FillRectangle(enemyBrush, 150, 22, b.health, 20);
                foreach (Rectangle f in b.fires)
                {
                    e.Graphics.FillRectangle(swordBrush, f.X, f.Y, f.Width, f.Height);
                }
                e.Graphics.FillRectangle(swordBrush, b.tornadoRec);
                e.Graphics.FillRectangle(swordBrush, b.tornadoRec2);
            }
            foreach (BiteBall b in bballs)
            {
                e.Graphics.FillRectangle(enemyBrush, b.x, b.y, b.w, b.h);
            }
            foreach (Summoner r in rooms[levelIndex].summoners)
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
            foreach (Soul r in rooms[levelIndex].souls)
            {
                e.Graphics.DrawImage(soulImage, r.x, r.y, r.w, r.h);
            }
            foreach (Powerups p in rooms[levelIndex].powers)
            {
                if (p.type == 1)
                {
                    e.Graphics.DrawImage(atkPower, p.x, p.y, p.w, p.h);
                }
                if (p.type == 2)
                {
                    e.Graphics.DrawImage(rangePower, p.x, p.y, p.w, p.h);
                }
                if (p.type == 3)
                {
                    e.Graphics.DrawImage(speedPower, p.x, p.y, p.w, p.h);
                }
                if (p.type == 4)
                {
                    e.Graphics.DrawImage(hpPower, p.x, p.y, p.w, p.h);
                }

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
                else
                {
                    player.direc = "Up";
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


            e.Graphics.FillRectangle(enemyBrush, 150, this.Height - 22, player.health, 20);

            e.Graphics.DrawImage(Resources.heart_overlay, 150, this.Height - 22, 750, 20);

        }

        private void nextRoom()
        {
            if (bosses.Count == 0 && rooms[levelIndex].souls.Count() == 0 && rooms[levelIndex].run.Count() == 0 && rooms[levelIndex].summoners.Count() == 0 && rooms[levelIndex].rangers.Count() == 0)
            {
                exitDoorRec.X = this.Width / 2 - (rooms[levelIndex].width / 2 - 50);
                exitDoorRec.Y = this.Height / 2 - (rooms[levelIndex].height / 2 + 10);

                exitDoorRec.Width = 125;
                exitDoorRec.Height = 25;
            }
            else
            {
                exitDoorRec.X = 0;
                exitDoorRec.Y = 0;

                exitDoorRec.Width = 1;
                exitDoorRec.Height = 1;
            }
            Rectangle playerRec = new Rectangle(player.x, player.y, player.w, player.h);
            if (playerRec.IntersectsWith(exitDoorRec))
            {
                if (rooms[levelIndex].type == "boss")
                {
                    rooms.Clear();
                    assembleFloor();
                    levelIndex = -1;
                    bossDead = false;
                    
                }
                levelIndex++;
                player.x = this.Width / 2;
                player.y = this.Height / 2 + (rooms[levelIndex].height / 2 - 50);
            }
        }
    }
}
