using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornilovaVarvara420
{
    public class Player //Игрок
    {
        public int Health { get; set; }
        public int Potion { get; set; } 
        public int Gold { get; set; }
        public int Arrows { get; set; }
        public List<string> Inventory { get; set; }

        public Player()
        {
            Health = 100;
            Potion = 3;
            Gold = 0;
            Arrows = 5;
            Inventory = new List<string>();
        }

    }
}
