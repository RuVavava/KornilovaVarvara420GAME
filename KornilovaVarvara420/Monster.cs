using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornilovaVarvara420
{
    public class Monster //Монстр
    {
        public int Health { get; set; }
        public Monster(bool isBoss = false)
        {
            Random rand = new Random();
            if (isBoss)
                Health = rand.Next(100, 201); // Босс с 100-200 HP
            else
                Health = rand.Next(20, 51); // Обычный монстр с 20-50 HP
        }
    }
}
