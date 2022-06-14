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
            // домашнее задание: динамический массив:

            int sum = 0;
            int userInput;
            char userComand;
            bool isWorking = true;
            int[] number = new int[0];
            
            while (isWorking)
            {
                int[] tempNumber = new int[number.Length + 1];
                Console.WriteLine("Нажмитие английскую букву w, чтобы ввести число\n\n" +
                    "Нажмите английскую букву s, чтобы суммировать все введённые вами числа\n\nНажмите английскую букву e, чтобы выйти.\n");
                userComand = Convert.ToChar(Console.ReadLine());

                switch (userComand)
                {
                    case 'w':
                        Console.WriteLine("Введите любое число и программа его запомнит:");

                        for (int i = 0; i < number.Length; i++)
                        {
                           tempNumber[i] = number[i]; 
                        }
                        userInput = Convert.ToInt32(Console.ReadLine());
                        tempNumber[tempNumber.Length - 1] = userInput;
                        number = tempNumber;
                       break;
                    case 's':

                        for (int i = 0; i < number.Length; i++)
                        {
                            sum  +=  number[i];  
                        }
                        Console.Write("Сумма введённых вами чисел - " + sum);
                        break;
                    case 'e':
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}


