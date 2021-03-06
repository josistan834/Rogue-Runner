﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rogue_Runner
{
    //The behaviours and properties of boss
    public class Boss
    {
        //public values per boss
        public int x, y, w, h, speed, health, damage, iframes, attack, bounces, tX, tY, tH, tX2, tY2, tH2, toNum, timer, direc, dir;
        public bool right = true;
        public List<Rectangle> fires = new List<Rectangle>();
        Random randGen = new Random();
        public Rectangle tornadoRec = new Rectangle();
        public Rectangle tornadoRec2 = new Rectangle();
        public Image image = Properties.Resources.blade_saw;

        //boss object and properties used on creation
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
            tH = 90;
            tX2 = 900;
            tH2 = 90;
            toNum = 0;
            timer = 0;
            dir = 1;
        }

        //called when boss 1 attacks
        public void attack1(string skill)
        {
            //moves right
            if (skill == "goRight")
            {
                if (bounces == 3)
                {
                    attack = 0;
                    bounces = 0;
                }
                x += speed;
            }
            //moves left
            if (skill == "goLeft")
            {
                if (bounces == 3)
                {
                    attack = 0;
                    bounces = 0;
                    image = Properties.Resources.wallFacingLeft_dithering_;
                }
                x -= speed;
            }
            //spawns tentacles near the player
            if (skill == "tentacle")
            {
                image = Properties.Resources.wallFacingRIGHT_dithering_;
                x = 30;
                Tentacle tent = new Tentacle(0,0,0,0, false);
                if (GameScreen.player.y >= y + h)
                {
                     tent = new Tentacle(x+10, y + h, 1000, y + h, false);
                }
                else if (GameScreen.player.y <= y)
                {
                     tent = new Tentacle(x+10, y, 1000, y, false);
                }
                else
                {
                     tent = new Tentacle(x+10, GameScreen.player.y + 30, 1000, GameScreen.player.y +30, false);
                }
                
                GameScreen.tentacles.Add(tent);

            }
            //moves to the spawn position
            if (skill == "bite")
            {
                x = 30;
                image = Properties.Resources.wallFacingRIGHT_dithering_;
            }
        }

        //called when boss 2 does an attack
        public void attack2(string skill)
        {
            //initiallization of fire rectangle
            Rectangle fire = new Rectangle(0, 0, 0, 0);
            //goes from right of left breathing fire
            if (skill == "Fire")
            {
                if (dir == 1)
                {
                    image = Properties.Resources.dragonRight_Open_;
                    x += 2 * speed;
                    if (x > 1000)
                    {
                        dir = randGen.Next(1, 3);
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
                    fire = new Rectangle(x + w, y + h + 40, 60, 60);
                    fires.Add(fire);
                }
                else
                {
                    image = Properties.Resources.dragonLeft_Open_;
                    x -= 2 * speed;
                    if (x < 0)
                    {
                        dir = randGen.Next(1, 3);
                        x = 1000;
                        y = randGen.Next(0, 300);
                        toNum++;
                        fires.Clear();
                    }
                    if (x < 500)
                    {
                        y -= speed;
                    }
                    else
                    {
                        y += speed;
                    }
                    fire = new Rectangle(x - w, y + h + 40, 60, 60);
                    fires.Add(fire);
                }
            }
            //flaps wings to create tornado
            if (skill == "Flap")
            {
                if(tX == 0)
                {
                    tX = x + w/2;
                }
                else
                {
                    tX += 5;
                } 
                tH = 900 - tX;
                tY = y-tH/2;
                tornadoRec = new Rectangle(tX, tY, Convert.ToInt32(Math.Round(tH * 0.8)), tH);
                if (tX2 == 900)
                {
                    tX2 = x + w/2 - 200;
                }
                else
                {
                    tX2 -= 5;
                }
                tH2 = tX2 + 200;
                tY2 = y - tH2 / 2;
                tornadoRec2 = new Rectangle(tX2, tY2, Convert.ToInt32(Math.Round(tH2 * 0.8)), tH2);
            }
            //moves to the player location and brings them with the dragon
            if (skill == "Grab")
            {
                image = Properties.Resources.dragonDown;
                x = randGen.Next((900 / 2 - GameScreen.rooms[GameScreen.levelIndex].width / 2), (900 / 2 + GameScreen.rooms[GameScreen.levelIndex].width / 2 - w));
                y = randGen.Next((700 / 2 - GameScreen.rooms[GameScreen.levelIndex].height / 2), (700 / 2 + GameScreen.rooms[GameScreen.levelIndex].height / 2 - w));
                if (GameScreen.swordCounter == 30)
                {
                    GameScreen.player.x = x+w/2;
                    GameScreen.player.y = y+h/2;
                }
                toNum++;
            }
        }
        //if the third boss uses and attack
        public void attack3(string skill)
        {
            //creates walls around itself and regenerates slowly
            if (skill == "regenerate")
            {
                fires.Clear();
                image = Properties.Resources.WarriorDown;
                Projectile arrow = new Projectile(30, 0, 30, 50, 3, 30, "Down", Properties.Resources.arrowDown);
                Ranger.bullets.Add(arrow);
                Projectile arrow1 = new Projectile(300, 0, 30, 50, 3, 30, "Down", Properties.Resources.arrowDown);
                Ranger.bullets.Add(arrow1);
                Projectile arrow2 = new Projectile(600, 0, 30, 50, 3, 30, "Down", Properties.Resources.arrowDown);
                Ranger.bullets.Add(arrow2);
                Projectile arrow3 = new Projectile(850, 0, 30, 50, 3, 30, "Down", Properties.Resources.arrowDown);
                Ranger.bullets.Add(arrow3);
                Projectile arrow4 = new Projectile(30, 30, 50, 30, 3, 30, "Right", Properties.Resources.arrowRight);
                Ranger.bullets.Add(arrow4);
                Projectile arrow5 = new Projectile(30, 200, 50, 30, 3, 30, "Right", Properties.Resources.arrowRight);
                Ranger.bullets.Add(arrow5);
                Projectile arrow6 = new Projectile(850, 400, 50, 30, 3, 30, "Left", Properties.Resources.arrowLeft);
                Ranger.bullets.Add(arrow6);
                Projectile arrow7 = new Projectile(850, 650, 50, 30, 3, 30, "Left", Properties.Resources.arrowLeft);
                Ranger.bullets.Add(arrow7);
                if (health < 500)
                {
                    health++;
                }   
            }
            //teleports to the player and attempts to stab them
            if (skill == "teleport")
            {
                if (timer == 0)
                {
                    fires.Clear();
                    if (GameScreen.player.direc == "Up")
                    {
                        direc = 1;
                        x = GameScreen.player.x;
                        y = GameScreen.player.y + h;
                    }
                    else if (GameScreen.player.direc == "Down")
                    {
                        direc = 2;
                        x = GameScreen.player.x;
                        y = GameScreen.player.y - h;
                    }
                    else if (GameScreen.player.direc == "Left")
                    {
                        direc = 1;
                        x = GameScreen.player.x + w;
                        y = GameScreen.player.y;
                    }
                    else if (GameScreen.player.direc == "Right")
                    {
                        direc = 2;
                        x = GameScreen.player.x - w;
                        y = GameScreen.player.y;
                    }
                }
                else if (timer == 20)
                {
                    if (direc == 1)
                    {
                        image = Properties.Resources.warriorLeft;
                        Rectangle knife = new Rectangle(x - 140 / 2, y + h / 2, 120, 10);
                        fires.Add(knife);
                    }
                    if (direc == 2)
                    {
                        image = Properties.Resources.warriorRight;
                        Rectangle knife = new Rectangle(x + 20 / 2, y + h / 2, 120, 10);
                        fires.Add(knife);
                    }

                }
                timer++;

            }
            //shoots three arrows towards the player
            if (skill == "shoot")
            {
                fires.Clear();
                y = GameScreen.player.y;
                string tempDir;
                if (GameScreen.player.x < x)
                {
                    tempDir = "Left";
                    image = Properties.Resources.warriorLeft;
                    Projectile arrow = new Projectile(x, y, 10, 10, 10, 30, tempDir, Properties.Resources.arrowLeft);
                    Ranger.bullets.Add(arrow);
                    Projectile arrow1 = new Projectile(x, y + 20, 10, 10, 10, 30, tempDir, Properties.Resources.arrowLeft);
                    Ranger.bullets.Add(arrow1);
                    Projectile arrow2 = new Projectile(x, y + 40, 10, 10, 10, 30, tempDir, Properties.Resources.arrowLeft);
                    Ranger.bullets.Add(arrow2);
                }
                else
                {
                    tempDir = "Right";
                    image = Properties.Resources.warriorRight;
                    Projectile arrow = new Projectile(x, y, 10, 10, 10, 30, tempDir, Properties.Resources.arrowRight);
                    Ranger.bullets.Add(arrow);
                    Projectile arrow1 = new Projectile(x, y + 20, 10, 10, 10, 30, tempDir, Properties.Resources.arrowRight);
                    Ranger.bullets.Add(arrow1);
                    Projectile arrow2 = new Projectile(x, y + 40, 10, 10, 10, 30, tempDir, Properties.Resources.arrowRight);
                    Ranger.bullets.Add(arrow2);
                }
               
            }
        }
        //when damaged take damage if not invicible
        public void damaged(int damage)
        {

            if (iframes <= 0)
            {
                health -= damage;

            }

        }
    }
}
