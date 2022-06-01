using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // домашнее задание: Вывод имени:

            string name;
            string symbol;
            int amountOfSymbolsInName;
            string topAndLower;
            Console.WriteLine("Напишите Ваше имя:");
            name = Console.ReadLine();
            amountOfSymbolsInName = name.Length;

            Console.WriteLine("Введите любой один символ и ваше имя окажется внутри прямоугольника, состоящего из этого символа:");
            symbol = Console.ReadLine();
            topAndLower = symbol;
            for (int i = 0; i <= amountOfSymbolsInName; i++)

            {
                topAndLower += symbol;
            }

            Console.WriteLine(topAndLower);
            Console.WriteLine(symbol + name + symbol);
            Console.WriteLine(topAndLower);

        }
    }
}
