using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Runner
    {
        //all runner properties
        public int x, y, w, h, speed, health, damage, iframes;
        public bool movement;
        public string direc;

        public Runner(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage, int _iframes)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            health = _health;
            damage = _damage;
            iframes = _iframes;
            direc = "Up";
        }
        //moves the runner based on direction
        public void move(string dir)
        {
            direc = dir;
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
        //damages the runner when hit
        public void damaged(int damage)
        {
            
            if (iframes <= 0)
            {
                health -= damage;

            }

        }
    }
}
