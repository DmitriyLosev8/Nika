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
        {      // Задание: Объединение войск:

            List<Warrior> leftWarriors = new List<Warrior> { (new Warrior("Гена", "Борисов")), (new Warrior("Дима", "Аникеев")), (new Warrior("Саша", "Бондаренко")),
                (new Warrior("Саша", "Степанов")),(new Warrior("Боря", "Андропов")),(new Warrior("Семён", "Бонько")),(new Warrior("Никита", "Опа")),(new Warrior("Степан", "Борислав")), };

            List<Warrior> rigthWarriors = new List<Warrior> { (new Warrior("Саша", "Задорожный")), (new Warrior("Дима", "Лосев")), (new Warrior("Сергей", "Бодров")),
                (new Warrior("Сергей", "Шнуров")),(new Warrior("Незами", "Мамедов")),(new Warrior("Ксения", "Задорожная")),(new Warrior("Любовь", "Двойнина")),(new Warrior("Владимир", "Двойнин")), };

            var unitedSqaud = rigthWarriors.Union(leftWarriors.Where(warrior => warrior.LastName.StartsWith("Б"))).ToList();
            rigthWarriors = unitedSqaud;
            var warriorsWithAFirst = leftWarriors.OrderBy(warrior => warrior.LastName).TakeWhile(warrior => warrior.LastName.StartsWith("А")).ToList();
            var warriorsWithOutAAndBFirst = leftWarriors.OrderBy(warrior => warrior.LastName).SkipWhile(warrior => warrior.LastName.StartsWith("А")).SkipWhile(warrior => warrior.LastName.StartsWith("Б"));
            var newLeftWarriors = warriorsWithOutAAndBFirst.Union(warriorsWithAFirst.Where(warrior => warrior.LastName.StartsWith("А"))).ToList();
            Console.WriteLine("Левый отряд без бойцов с фамилией на букву Б:");

            foreach (var warrior in newLeftWarriors)
            {
                Console.WriteLine(warrior.Name + " " + warrior.LastName);
            }

            Console.WriteLine("\n\nПравый отряд с перенесёнными бойцами с фамилией на букву Б:");

            foreach (var warrior in rigthWarriors)
            {
                Console.WriteLine(warrior.Name + " " + warrior.LastName);
            }
        }
    }

    class Warrior
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }

        public Warrior(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}









