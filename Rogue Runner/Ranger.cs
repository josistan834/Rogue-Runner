using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Ranger
    {
        //all properties of a ranger
        public int x, y, w, h, health, iframes;
        public string direc;
        public static List<Projectile> bullets = new List<Projectile>();


        public Ranger(int _x, int _y, int _w, int _h, int _health, int _iframes, string _direc)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            health = _health;
            iframes = _iframes;
            direc = _direc;
        }
        //adds a bullet to the bullet list 
        public void attack()
        {
            Projectile bullet = new Projectile(x, y, 10, 10, 10, 15, direc, null);
            bullets.Add(bullet);
            
        }
        //damages the ranger when hit
        public void damaged(int damage)
        {
            if (iframes <= 0)
            {
                health -= damage;

            }

        }
    }
}
