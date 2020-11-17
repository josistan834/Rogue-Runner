using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Summoner
    {
        //all summoner properties
        public int x, y, w, h, health, iframes, speed;
        public bool sumRun, attacking;
        public string sumdir;
        public Image image = GameScreen.sumImage;

        public Summoner(int _x, int _y, int _w, int _h, int _health, int _iframes, int _speed)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            health = _health;
            iframes = _iframes;
            speed = _speed;
            sumRun = false;
            sumdir = null;
        }
        
        //damages summoner when hit
        public void damaged(int damage)
        {
            if (iframes <= 0)
            {
                health -= damage;

            }

        }
        //moves the summoner when hit based on direction
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
    }
}
