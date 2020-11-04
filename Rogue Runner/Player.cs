﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Player
    {
        public int x, y, w, h, speed, health, damage;
        public string direc;
        public Rectangle sword = new Rectangle();
        public Player(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage, string direc)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            health = _health;
            damage = _damage;
            
        }
        public void move(string dir)
        {
            if (dir == "Left")
            {
                x -= speed;
                direc = "Left";
            }
            else if (dir == "Right")
            {
                x += speed;
                direc = "Right";
            }
            else if (dir == "Up")
            {
                y -= speed;
                direc = "Up";
            }
            else if (dir == "Down")
            {
                y += speed;
                direc = "Down";
            }
        }
        public void attack()
        {

            if (direc == "Left")
            {
                sword = new Rectangle(x-w, y, 30, 30);
            }
            else if (direc == "Right")
            {
                sword = new Rectangle(x+w, y, 30, 30);
            }
            else if (direc == "Up")
            {
                sword = new Rectangle(x, y-h, 30, 30);
            }
            else if (direc == "Down")
            {
                sword = new Rectangle(x, y+h, 30, 30);
            }
            
        }
        public void deleteSword()
        {
            sword = new Rectangle(0, 0, 0, 0);
        }
        public void block()
        {

        }
        public void damaged(int damage)
        {
            health -= damage;
        }
    }
}