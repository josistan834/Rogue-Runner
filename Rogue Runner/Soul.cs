using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Soul
    {
        //creates a soul object and its properties
        public int x, y, w, h, speed, health, damage, preY, preX, iframes;
        public bool up, right;
        
        public Soul(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            health = _health;
            damage = _damage;
        }
        //moves the soul based on direction
        public void move()
        {
            if (right == false)
            {
                x -= speed;
            }
            else if (right == true)
            {
                x += speed;
            }
            if (up == true)
            {
                y -= speed;
            }
            else if (up == false)
            {
                y += speed;
            }
        }
        //lowers soul health when damaged
        public void damaged(int damage)
        {
            if (iframes <= 0)
            {
                health -= damage;

            }

        }
    }

}
