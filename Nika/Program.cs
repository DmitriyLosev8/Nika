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

            // домашнее задание: сдвиг значений массива:

            int[] array = { 1, 2, 3, 4,};
            int userInput;
            int tempNumber;

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine("\n\nЧтобы сдвинуть значения элементов массива влево, введите число на сколько позиций будет сдвиг:");
            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < array.Length; i++) 
            {
               
                if (i == userInput - 1)
                {
                    tempNumber = array[userInput - 1];

                    for (int j = 1; j < array.Length; j++)
                    {
                        array[j - 1] = array[j];
                    }
                    array[array.Length - 1] = tempNumber;
                }   
            }
            Console.WriteLine("Изменённый массив:");
            for (int i = 0; i < array.Length; i++)
              {
                  Console.Write(array[i] + " | ");
             }
            Console.WriteLine();
        }
    }
}






