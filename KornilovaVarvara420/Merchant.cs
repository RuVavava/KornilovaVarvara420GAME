using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornilovaVarvara420
{
    public class Merchant //Торговец
    {
        public bool SellPotion(Player player)
        {
            if (player.Gold >= 30)
            {
                Console.WriteLine("Вы встретили торговца! \nХотите преобрести зелье за 30 золото? (Да или Нет)");
                string answer = Console.ReadLine();

                if (answer == "Да")
                {
                    if (player.Inventory.Count < 5)
                    {
                        Console.WriteLine("Вы преобрели зелье за 30 золота.");
                        player.Gold -= 30;
                        player.Inventory.Add("Зелье");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Ваш инвентарь полон. Вы не можете взять новое зелье.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ничего не купили.");
                    return true;
                }

            }
            else
            {
                Console.WriteLine("У Вас недостаточно монет!");
                return false;
            }
        }
    }
}
