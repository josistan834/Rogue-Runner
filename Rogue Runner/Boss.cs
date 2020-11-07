﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Boss
    {
        public int x, y, w, h, speed, health, damage, iframes, attack, bounces, tX, tY, tW, tH, tX2, tY2, tW2, tH2, toNum;
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
                x = randGen.Next(0, 900);
                y = randGen.Next(0, 700);
                GameScreen.player.x = x;
                GameScreen.player.y = y;
                toNum++;
            }
        }
        public void attack3()
        {
            if (attack == 1)
            {

            }
            if (attack == 2)
            {

            }
            if (attack == 3)
            {

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