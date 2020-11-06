using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class BiteBall
    {
        public int x, y, w, h, speed, health, damage, preY, preX, iframes;
        public bool reflected;
        public string direc;
        public BiteBall(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            health = _health;
            damage = _damage;
            reflected = false;
        }
        public void move(string dir)
        {
            
            if (dir == "Left")
            {
                x -= speed;
            }
            else if (dir == "Right")
            {
                x += speed;
            }
            else if (dir == "Up")
            {
                y -= speed;
            }
            else if (dir == "Down")
            {
                y += speed;
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
