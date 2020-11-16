using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rogue_Runner
{
    public class Boss
    {
        public int x, y, w, h, speed, health, damage, iframes, attack, bounces, tX, tY, tW, tH, tX2, tY2, tW2, tH2, toNum, timer;
        public bool right = true;
        public List<Rectangle> fires = new List<Rectangle>();
        Random randGen = new Random();
        public Rectangle tornadoRec = new Rectangle();
        public Rectangle tornadoRec2 = new Rectangle();

        public Boss(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage, int _iframes)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            health = _health;
            damage = _damage;
            iframes = _iframes;
            attack = 0;
            bounces = 0;
            tX = 0;
            tW = 30;
            tH = 90;
            tX2 = 900;
            tW2 = 30;
            tH2 = 90;
            toNum = 0;
            timer = 0;
        }

        public void attack1(string skill)
        {
            if (skill == "goRight")
            {
                if (bounces == 3)
                {
                    attack = 0;
                    bounces = 0;
                }
                x += speed;
            }
            if (skill == "goLeft")
            {
                if (bounces == 3)
                {
                    attack = 0;
                    bounces = 0;
                }
                x -= speed;
            }
            if (skill == "tentacle")
            {
                x = 0;
                Tentacle tent = new Tentacle(0,0,0,0, false);
                if (GameScreen.player.y >= y + h)
                {
                     tent = new Tentacle(x, y + h, 1000, y + h, false);
                }
                else if (GameScreen.player.y <= y)
                {
                     tent = new Tentacle(x, y, 1000, y, false);
                }
                else
                {
                     tent = new Tentacle(x, GameScreen.player.y + 30, 1000, GameScreen.player.y +30, false);
                }
                
                GameScreen.tentacles.Add(tent);

            }
            if (skill == "bite")
            {
                x = 0;
            }
        }
        public void attack2(string skill)
        {
            Rectangle fire = new Rectangle(0, 0, 0, 0);
            if (skill == "Fire")
            {
                x += 2*speed;
                if (x > 1000)
                {
                    x = -50;
                    y = randGen.Next(0, 300);
                    toNum++;
                    fires.Clear();
                }
                if (x > 500)
                {
                    y -= speed;
                }
                else
                {
                    y += speed;
                }
                fire = new Rectangle(x+w, y+h+40, 60, 60);
                fires.Add(fire);
            }
            if (skill == "Flap")
            {
                if(tX == 0)
                {
                    tX = x  + w / 2;
                }
                else
                {
                    tX += 5;
                } 
                tH = 900 - tX + 200;
                tY = y-tH/2;
                tornadoRec = new Rectangle(tX, tY, tW, tH);
                if (tX2 == 900)
                {
                    tX2 = x + w/2;
                }
                else
                {
                    tX2 -= 5;
                }
                tH2 = tX2 + 200;
                tY2 = y - tH2 / 2;
                tornadoRec2 = new Rectangle(tX2, tY2, tW2, tH2);
            }
            if (skill == "Grab")
            {
                x = randGen.Next((900 / 2 - GameScreen.rooms[GameScreen.levelIndex].width / 2), (900 / 2 + GameScreen.rooms[GameScreen.levelIndex].width / 2 - w));
                y = randGen.Next((700 / 2 - GameScreen.rooms[GameScreen.levelIndex].height / 2), (700 / 2 + GameScreen.rooms[GameScreen.levelIndex].height / 2 - w));
                if (GameScreen.swordCounter == 30)
                {
                    GameScreen.player.x = x;
                    GameScreen.player.y = y;
                }
                toNum++;
            }
        }
        public void attack3(string skill)
        {
            if (skill == "regenerate")
            {
                Projectile arrow = new Projectile(30, 0, 30, 50, 3, 30, "Down");
                Ranger.bullets.Add(arrow);
                Projectile arrow1 = new Projectile(300, 0, 30, 50, 3, 30, "Down");
                Ranger.bullets.Add(arrow1);
                Projectile arrow2 = new Projectile(600, 0, 30, 50, 3, 30, "Down");
                Ranger.bullets.Add(arrow2);
                Projectile arrow3 = new Projectile(850, 0, 30, 50, 3, 30, "Down");
                Ranger.bullets.Add(arrow3);
                Projectile arrow4 = new Projectile(30, 30, 50, 30, 3, 30, "Right");
                Ranger.bullets.Add(arrow4);
                Projectile arrow5 = new Projectile(30, 200, 50, 30, 3, 30, "Right");
                Ranger.bullets.Add(arrow5);
                Projectile arrow6 = new Projectile(850, 400, 50, 30, 3, 30, "Left");
                Ranger.bullets.Add(arrow6);
                Projectile arrow7 = new Projectile(850, 650, 50, 30, 3, 30, "Left");
                Ranger.bullets.Add(arrow7);
                if (health < 500)
                {
                    health++;
                }   
            }
            if (skill == "teleport")
            {
                if (timer == 0)
                {
                    fires.Clear();
                    if (GameScreen.player.direc == "Up")
                    {
                        x = GameScreen.player.x;
                        y = GameScreen.player.y + h;
                    }
                    else if (GameScreen.player.direc == "Down")
                    {
                        x = GameScreen.player.x;
                        y = GameScreen.player.y - h;
                    }
                    else if (GameScreen.player.direc == "Left")
                    {
                        x = GameScreen.player.x + w;
                        y = GameScreen.player.y;
                    }
                    else if (GameScreen.player.direc == "Right")
                    {
                        x = GameScreen.player.x - w;
                        y = GameScreen.player.y;
                    }
                }
                else if (timer == 20)
                {
                    Rectangle knife = new Rectangle(x-120/2, y+h/2, 120, 10);
                    fires.Add(knife);
                    
                }
                timer++;

            }
            if (skill == "shoot")
            {
                y = GameScreen.player.y;
                string tempDir;
                if (GameScreen.player.x < x)
                {
                    tempDir = "Left";
                }
                else
                {
                    tempDir = "Right";
                }
                Projectile arrow = new Projectile(x, y, 10, 10, 10, 30, tempDir);
                Ranger.bullets.Add(arrow);
                Projectile arrow1 = new Projectile(x, y + 20, 10, 10, 10, 30, tempDir);
                Ranger.bullets.Add(arrow1);
                Projectile arrow2 = new Projectile(x, y + 40, 10, 10, 10, 30, tempDir);
                Ranger.bullets.Add(arrow2);
            }
        }
        public void damaged(int damage)
        {

            if (iframes <= 0)
            {
                health -= damage;

            }

        }
    }
}
