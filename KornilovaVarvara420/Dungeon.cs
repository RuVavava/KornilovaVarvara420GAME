using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornilovaVarvara420
{
    public class Dungeon //Комнаты
    {
        public string[] DungeonMap { get; set; }

        public Dungeon()
        {
            DungeonMap = new string[10];
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int eventType = rand.Next(0, 5);
                if (eventType == 0)
                    DungeonMap[i] = "Монстр";
                else if (eventType == 1)
                    DungeonMap[i] = "Ловушка";
                else if (eventType == 2)
                    DungeonMap[i] = "Сундук";
                else if (eventType == 3)
                    DungeonMap[i] = "Торговец";
                else
                    DungeonMap[i] = "Пустая комната\n";
            }

            DungeonMap[9] = "БОСС";
        }
    }
}
