using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Powerups
    {
        //all powerup assembly and properties
        public int x, y, w, h, type;
        public Powerups (int _type, int _x, int _y, int _w, int _h)
        {
            type = _type;
            x = _x;
            y = _y;
            w = _w;
            h = _h;
        }
        //assigns types to each power up, thanks for name Josiah
        public void powerGoBrrr()
        {
            if (type == 1)
            {
                GameScreen.player.damage += 10;
            }
            else if (type == 2)
            {
                GameScreen.player.swordSize += 10;
                GameScreen.player.swordSize += 10;
            }
            else if (type == 3)
            {
                if (GameScreen.player.speed < 8)
                {
                    GameScreen.player.speed += 1;
                } 
            }
            else if (type == 4)
            {
                GameScreen.player.health += 150;
            }
        }
    }
}
