using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    public class Room
    {
        public int width, height;
        public string type;
        public List<Rectangle> obstacles = new List<Rectangle>();
        public Image image;
        //List <> enemy = new List <>();

        public Room(int _width, int _height, string _type, List<Rectangle> _obstacles, Image _image)
        {
            width = _width;
            height = _height;
            type = _type;
            obstacles = _obstacles;
            image = _image;
        }


    }
}
