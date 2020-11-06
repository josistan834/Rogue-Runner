using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Boss
    {
        public int x, y, w, h, speed, health, damage, iframes, attack, bounces;
        public bool right = true;
        

        public Boss(int _x, int _y, int _w, int _h, int _speed, int _health, int _damage, int _iframes)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            speed = _speed;
            health = _health;
            damage = _damage;
            iframes = _iframes;
            attack = 0;
            bounces = 0;
        }

        public void attack1(string skill)
        {
            if (skill == "goRight")
            {
                if (bounces == 3)
                {
                    attack = 0;
                    bounces = 0;
                }
                x += speed;
            }
            if (skill == "goLeft")
            {
                if (bounces == 3)
                {
                    attack = 0;
                    bounces = 0;
                }
                x -= speed;
            }
            if (skill == "tentacle")
            {
                x = 0;
                Tentacle tent = new Tentacle(x, GameScreen.player.y, GameScreen.player.x, GameScreen.player.y, false);
                GameScreen.tentacles.Add(tent);

            }
            if (skill == "bite")
            {
                x = 0;
            }
        }
        public void attack2()
        {
            if (attack == 1)
            {

            }
            if (attack == 2)
            {

            }
            if (attack == 3)
            {

            }
        }
        public void attack3()
        {
            if (attack == 1)
            {

            }
            if (attack == 2)
            {

            }
            if (attack == 3)
            {

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
