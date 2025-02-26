using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KornilovaVarvara420
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру! Давайте начнем.\n");

            Player player = new Player();
            Dungeon dungeon = new Dungeon();
            Merchant merchant = new Merchant();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Комната {i + 1}: {dungeon.DungeonMap[i]}");

                if (dungeon.DungeonMap[i] == "Монстр")
                {
                    Monster monster = new Monster();
                    Battle(player, monster);
                    Console.WriteLine("\n");
                }
                else if (dungeon.DungeonMap[i] == "Ловушка")
                {
                    Trap(player);
                    Console.WriteLine("\n");
                }
                else if (dungeon.DungeonMap[i] == "Сундук")
                {
                    Chest chest = new Chest();
                    bool opened = false;
                    while (!opened)
                    {
                        opened = chest.Open();
                    }
                    if (chest.Reward == "Зелье")
                    {
                        if (player.Inventory.Count < 5)
                            player.Inventory.Add("Зелье");
                        else
                            Console.WriteLine("Ваш инвентарь полон, вы не можете взять зелье.");
                    }
                    else if (chest.Reward == "Золото")
                    {
                        if (player.Inventory.Count < 5)
                            player.Gold += 20;
                        else
                            Console.WriteLine("Ваш инвентарь полон, вы не можете взять золото.");
                    }
                    else
                    {
                        if (player.Inventory.Count < 5)
                            player.Arrows += 5;
                        else
                            Console.WriteLine("Ваш инвентарь полон, вы не можете взять стрелы.");
                    }
                    Console.WriteLine("\n");
                }
                else if (dungeon.DungeonMap[i] == "Торговец")
                {
                    merchant.SellPotion(player);
                    Console.WriteLine("\n");
                }

                if (player.Health <= 0)
                {
                    Console.WriteLine("Вы были побеждены. Конец игры!");
                    break;
                }

                if (i == 9 && dungeon.DungeonMap[i] == "БОСС")
                {
                    Console.WriteLine("Вы достигли последнего босса!");
                    Monster boss = new Monster(isBoss: true); // Создаем босса с улучшенными параметрами
                    BattleWithBoss(player, boss);  // Бой с боссом
                    if (player.Health > 0)
                    {
                        Console.WriteLine("Вы победили босса и выиграли игру!");//
                    }
                }
            }
        }

        // Метод для боя с обычным монстром
        static void Battle(Player player, Monster monster)
        {
            Console.WriteLine($"Монстр появляется с {monster.Health} HP!");
            Random rand = new Random();
            while (player.Health > 0 && monster.Health > 0)
            {
                Console.WriteLine($"Ваши HP: {player.Health}, HP монстра: {monster.Health}");
                Console.WriteLine("Выберите оружие: (1) Меч (2) Лук");
                int choice = Convert.ToInt32(Console.ReadLine());

                int damage = 0;
                if (choice == 1) // Меч
                {
                    damage = rand.Next(10, 21);
                    Console.WriteLine($"Вы ударили монстра своим мечом на {damage} урона.");
                }
                else if (choice == 2 && player.Arrows > 0) // Лук
                {
                    damage = rand.Next(5, 16);
                    player.Arrows--;
                    Console.WriteLine($"Вы выстрелили в монстра из лука на {damage} урона. У вас осталось {player.Arrows} стрел.");
                }
                else
                {
                    Console.WriteLine("У вас нет стрел! Пожалуйста, выберите другое оружие.");
                    continue;
                }

                monster.Health -= damage;
                if (monster.Health <= 0)
                {
                    Console.WriteLine("Вы победили монстра!");
                    break;
                }

                int monsterDamage = rand.Next(5, 16);
                player.Health -= monsterDamage;
                Console.WriteLine($"Монстр атакует вас и наносит {monsterDamage} урона.");
            }

            Console.ReadKey();
        }

        // Метод для борьбы с боссом
        static void BattleWithBoss(Player player, Monster boss)
        {
            Console.WriteLine($"Вы столкнулись с Боссом! У него {boss.Health} HP!");
            Random rand = new Random();
            while (player.Health > 0 && boss.Health > 0)
            {
                Console.WriteLine($"Ваши HP: {player.Health}, HP босса: {boss.Health}");
                Console.WriteLine("Выберите оружие: (1) Меч (2) Лук");
                int choice = Convert.ToInt32(Console.ReadLine());

                int damage = 0;
                if (choice == 1) // Меч
                {
                    damage = rand.Next(15, 31); // Меч наносит больше урона на боссах
                    Console.WriteLine($"Вы ударили босса своим мечом на {damage} урона.");
                }
                else if (choice == 2 && player.Arrows > 0) // Лук
                {
                    damage = rand.Next(10, 21); // Лук также наносит больше урона на боссах
                    player.Arrows--;
                    Console.WriteLine($"Вы выстрелили в босса из лука на {damage} урона. У вас осталось {player.Arrows} стрел.");
                }
                else
                {
                    Console.WriteLine("У вас нет стрел! Пожалуйста, выберите другое оружие.");
                    continue;
                }

                boss.Health -= damage;
                if (boss.Health <= 0)
                {
                    Console.WriteLine("Вы победили босса!");
                    break;
                }

                int bossDamage = rand.Next(15, 31); // Босс наносит больший урон
                player.Health -= bossDamage;
                Console.WriteLine($"Босс атакует вас и наносит {bossDamage} урона.");
            }

            Console.ReadKey();
        }

        // Метод для ловушки
        static void Trap(Player player)
        {
            Random rand = new Random();
            int damage = rand.Next(10, 21);
            player.Health -= damage;
            Console.WriteLine($"Вы попали в ловушку и потеряли {damage} HP.");
        }
    }
}
