using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    class Room
    {
        int width, height;
        string type;
        List<Rectangle> obstacles = new List<Rectangle>();
        //List <> enemy = new List <>();

        public Room(int _width, int _height, string _type, List<Rectangle> _obstacles)
        {
            width = _width;
            height = _height;
            type = _type;
            obstacles = _obstacles;
        }


    }
}
