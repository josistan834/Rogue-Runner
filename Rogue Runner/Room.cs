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
        public List<Runner> run = new List<Runner>();
        public List<Soul> souls = new List<Soul>();
        public List<Ranger> rangers = new List<Ranger>();
        public List<Summoner> summoners = new List<Summoner>();
        public List<Powerups> powers = new List<Powerups>();
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
