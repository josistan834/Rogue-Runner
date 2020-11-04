using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Soul
    {
        public int x, y, w, h, speed, health, damage, preY, preX;
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
        public void move()
        {
            if (!right)
            {
                x -= speed;
            }
            else if (right)
            {
                x += speed;
            }
            if (up)
            {
                y -= speed;
            }
            else if (!up)
            {
                y += speed;
            }
        }
    }

}
