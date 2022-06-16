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

            // домашнее задание: подмассив повторейний чисел:

            int[] array = { 2, 6, 4, 8, 8, 8, 5, 6, 4, 8, 6, 4, 4, 4, 4, 4, 4, 3, 2, 8, };
            int firstnumber;
            int secondmumber;
            int count = 0;

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1]) 
                {    
                    count ++;    

                }                   //доделать
                if (array[i] != array[i + 1])
                {
                    break;
                }



            }
            Console.WriteLine(count);     // доделать. их нужно ещё сравнить
        }
    }
}






