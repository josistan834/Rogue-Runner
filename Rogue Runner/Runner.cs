using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Runner
    {
        int x, y, w, h, speed, health, damage;

        public Runner(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage)
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
            
        }
        public void attack()
        {

        }
        public void block()
        {

        }
        public void damaged()
        {

        }
    }
}
