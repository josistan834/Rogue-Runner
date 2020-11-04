using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Projectile
    {
        public int speed, x, y, w, h, damage;
        public string dir;
        public Projectile(int _x, int _y, int _w, int _h, int _speed, int _damage, string _dir)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            damage = _damage;
            dir = _dir;
        }
        public void move()
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
    }
}
