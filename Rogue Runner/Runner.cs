using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Runner
    {
        public int x, y, w, h, speed, health, damage;

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
        public void attack()
        {

        }
        public void block()
        {

        }
        public void damaged(int damage, int knock)
        {
            if (knock == 30)
            {
                health -= damage;
                GameScreen.knock--;
            }
            else if (knock > 0)
            {
                move(GameScreen.player.direc);
                GameScreen.knock--;

            }
            else
            {
                GameScreen.knock = 30;
            }
            
        }
    }
}
