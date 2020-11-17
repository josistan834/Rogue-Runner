using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Runner
{
    class Score
    {
        //all score proprties
        public string name, time, enemiesDefeated;
        public static List<Score> scores = new List<Score>();

        public Score(string _name, string _time, string _enemiesDefeated)
        {
            name = _name;
            time = _time;
            enemiesDefeated = _enemiesDefeated;
        }

    }
}
