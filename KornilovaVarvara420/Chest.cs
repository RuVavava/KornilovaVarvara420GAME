using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornilovaVarvara420
{
    public class Chest //Сундук
    {
        public string Reward { get; set; }

        public Chest()
        {
            Random rand = new Random();
            int reward = rand.Next(0, 3);

            if (reward == 0)
                Reward = "Зелье";
            else if (reward == 1)
                Reward = "Золото";
            else
                Reward = "Стрелы";
        }

        public bool Open()
        {
            Console.WriteLine("Чтобы открыть сундук, необходимо решить задачу:");
            Random rand = new Random();
            int a = rand.Next(0, 10);
            int b = rand.Next(0, 10);
            Console.WriteLine($"Сколько будет {a} + {b} ?");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == (a + b))
            {
                Console.WriteLine($"Ты открыл сундук и забираешь награду {Reward}!");
                return true;
            }
            else
            {
                Console.WriteLine("Ответ неверный. Попробуй снова.");
                return false;
            }
        }
    }
}
