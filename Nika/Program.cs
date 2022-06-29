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
            // Задание: UIElement:    

            char[] healthBar = new char[0];
            int userInput;

            Console.WriteLine("Введите сколько процентов жизни вы хотите отобразить. Вводить нужно число кратное 10 (20, 40, 80 и .тд.)");
            userInput = Convert.ToInt32(Console.ReadLine());
            healthBar = DrawBar(healthBar, userInput);
        }

        static char[] DrawBar(char[] healthBar, int userInput)
        {
            char procentOfHealth = '#';
            char emptyHealth = ' ';
            int multiplicity = 10;
            int fullHealth = 100;

            if (procentOfHealth < 10 || procentOfHealth > 100)
            {
                Console.WriteLine("Введите корректное значение");
            }
            else
            {
                Console.WriteLine("\nВот ваш healthBar:\n");
                Console.Write("[");

                for (int i = 0; i < userInput / multiplicity; i++)
                {
                    char[] tempHealthBar = new char[healthBar.Length + 1];

                    for (int j = 0; j < healthBar.Length; j++)
                    {
                        tempHealthBar[j] = healthBar[j];
                    }
                    tempHealthBar[tempHealthBar.Length - 1] = procentOfHealth;
                    healthBar = tempHealthBar;

                    Console.Write(healthBar[i]);
                }

                for (int i = userInput / multiplicity; i < fullHealth / multiplicity; i++)
                {
                    char[] tempHealthBar = new char[healthBar.Length + 1];

                    for (int j = 0; j < healthBar.Length; j++)
                    {
                        tempHealthBar[j] = healthBar[j];
                    }
                    tempHealthBar[tempHealthBar.Length - 1] = emptyHealth;
                    healthBar = tempHealthBar;

                    Console.Write(healthBar[i]);
                }
                Console.Write("]");
                Console.WriteLine();
            }
            return healthBar;
        }
    }
}











