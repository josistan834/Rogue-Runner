using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Tentacle
        //creates a tentacle object for the wall boss to use
    {
        public int x, y, x2, y2;
        public bool active;
        public Tentacle(int _x, int _y, int _x2, int _y2, bool _active)
        {
            x = _x;
            y = _y;
            x2 = _x2;
            y2 = _y2;
            active = _active;
        }
    }
}
