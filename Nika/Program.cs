using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание: Гладиаторские бои:       

            Arena arena = new Arena();
            arena.Fight();
        }
    }

    class Arena
    {
        static bool readyToFight = true;

        private Warrior[] warriors = { new Giant("Гигант", 10, 300, 50, readyToFight), new Knight("Рыцарь", 5, 200, 30, readyToFight), new Wizard("Волшебник", 5, 150, 30, readyToFight),
            new Recruit("Рекрут",3,150,25,readyToFight), new Officer("Офицер", 7,300,50,readyToFight) };

        public void ShowAllWarriors()
        {
            Console.WriteLine("Вот список всех бойцов:\n");

            for (int i = 0; i < warriors.Length; i++)
            {
                Console.Write(i + 1 + " ");
                warriors[i].ShowIndicators();
            }
        }

        public void Fight()
        {
            int stepOfFight = 0;
            int leftWarriorIndex;
            int rightWarriorIndex;
            string userInput;
            bool isSuccessfull;
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ НА АРЕНУ:");
            Console.SetCursorPosition(0, 2);
            ShowAllWarriors();
            Console.WriteLine("\nВыберете левого бойца:");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out leftWarriorIndex);

            if (isSuccessfull == true && leftWarriorIndex <= warriors.Length)
            {
                Console.WriteLine("\nВыберете правого бойца:");
                userInput = Console.ReadLine();
                isSuccessfull = int.TryParse(userInput, out rightWarriorIndex);

                if (isSuccessfull == true && rightWarriorIndex <= warriors.Length && leftWarriorIndex != rightWarriorIndex)
                {
                    Console.Clear();
                    while (warriors[leftWarriorIndex - 1].Health > 0 && warriors[rightWarriorIndex - 1].Health > 0 && warriors[leftWarriorIndex - 1].ReadyToFight == true && warriors[rightWarriorIndex - 1].ReadyToFight == true)
                    {
                        stepOfFight++;
                        Console.SetCursorPosition(35, 0);
                        Console.WriteLine("Идёт ожесточённая битва. Внимательно следите за жизнями бойцов");
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine("Боец слева:");
                        Console.SetCursorPosition(55, 2);
                        Console.WriteLine("Боец справа:");
                        Console.SetCursorPosition(0, 5);
                        warriors[leftWarriorIndex - 1].ShowIndicators();
                        Console.SetCursorPosition(55, 5);
                        warriors[rightWarriorIndex - 1].ShowIndicators();
                        Console.SetCursorPosition(25, 7);
                        Console.WriteLine("Применить способность у левого бойца и нанести урон или просто нанести урон?");
                        Console.SetCursorPosition(35, 8);
                        Console.WriteLine("д - Да, н - нет");

                        userInput = Console.ReadLine();

                        if (userInput == "д")
                        {
                            warriors[leftWarriorIndex - 1].UniqueSkill(stepOfFight);
                            warriors[rightWarriorIndex - 1].TakeDamage(warriors[leftWarriorIndex - 1].Damage);
                        }
                        else
                        {
                            warriors[rightWarriorIndex - 1].TakeDamage(warriors[leftWarriorIndex - 1].Damage);
                        }

                        Console.SetCursorPosition(25, 7);
                        Console.WriteLine("Применить способность у правого бойца и нанести урон или просто нанести урон?");
                        Console.SetCursorPosition(35, 8);
                        Console.WriteLine("д - Да, н - нет");

                        userInput = Console.ReadLine();

                        if (userInput == "д")
                        {
                            Console.SetCursorPosition(55, 10);
                            warriors[rightWarriorIndex - 1].UniqueSkill(stepOfFight);
                            warriors[leftWarriorIndex - 1].TakeDamage(warriors[rightWarriorIndex - 1].Damage);
                        }
                        else
                        {
                            warriors[leftWarriorIndex - 1].TakeDamage(warriors[rightWarriorIndex - 1].Damage);
                        }

                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число или бойца под таким номером нет/его уже выбрали");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число или бойца под таким номером нет");
            }
        }
    }

    class Warrior
    {
        protected string Name;
        protected int Armor;

        public bool ReadyToFight { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int UniqueFeature { get; protected set; }

        public void ShowIndicators()
        {
            Console.WriteLine($"{Name}, {Damage} - урона. Жизней - {Health}, брони - {Armor}");
        }

        public virtual void UniqueSkill(int uniqueInfo)
        {

        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    class Giant : Warrior
    {
        public Giant(string name, int armor, int health, int damage, bool readyToFight)
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            int coolDown = 6;
            Console.WriteLine("SuperHit + 30 к урону");

            if (stepOfFight % coolDown == 0)
            {
                Damage += 30;
            }
        }
    }

    class Knight : Warrior
    {
        public Knight(string name, int armor, int health, int damage, bool readyToFight) 
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            Console.WriteLine("ExtraDamage - 20% вероятность увеличить урон на 15");
            int lowerBorder = 0;
            int upperBorder = 5;
            int possibility = 1;
            Random random = new Random();
            int chance = random.Next(lowerBorder, upperBorder);

            if (chance == possibility)
            {
                Damage += 15;
            }
        }
    }

    class Wizard : Warrior
    {
        public Wizard(string name, int armor, int health, int damage, bool readyToFight) 
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
            UniqueFeature = 100;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            int priceOfAplly = 25;

            if (UniqueFeature >= priceOfAplly)
            {
                Console.WriteLine("GetExtraHealth - жизни + 20");
                UniqueFeature -= priceOfAplly;
                Health += 20;
            }
            else
            {
                Console.WriteLine("Недостаточно маны");
            }
        }
    }

    class Recruit : Warrior
    {
        public Recruit(string name, int armor, int health, int damage, bool readyToFight) 
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            Console.WriteLine("GiveUp - боец сдался");
            ReadyToFight = false;
        }
    }

    class Officer : Warrior
    {
        public Officer(string name, int armor, int health, int damage, bool readyToFight) 
        {
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            ReadyToFight = true;
        }

        public override void UniqueSkill(int stepOfFight)
        {
            int coolDown = 8;

            if (stepOfFight % coolDown == 0)
            {
                Console.WriteLine("DoubleDamage - двойной урон");
                Damage *= 2;
            }
        }
    }
}









