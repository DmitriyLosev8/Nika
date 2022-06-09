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
            // дамашнее задание: локальные максимумы:   В ПРОЦЕССЕ!!!!!!!!!!!!!!!!!!!!!!!!
            
            int[] array = new int[30];
            Console.WriteLine(array.Length);
            Random random = new Random();
            int minimalNumber = 0;
            int maximulNumber = 100;
            int maximalElement = int.MinValue;


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimalNumber, maximulNumber);
                Console.WriteLine(array[i]);


                if (maximalElement < (array[i] -1) && maximalElement < (array[i] + 1))                  
                {
                    maximalElement = array[i];
                }
            }
            Console.WriteLine("Дальше идут локальные максимумы:");
            Console.WriteLine(maximalElement);










            //Console.WriteLine(array[i]);
        }

    }
    
}
