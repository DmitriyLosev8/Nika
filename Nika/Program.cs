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

            // домашнее задание: сортировка чисел:

            int[] array = {3,8,7,9,5,6,1,2,4};

            int[] tempArray = array;

            for (int i = 0; i < array.Length; i++)
            {
              for (int j = 0; j < tempArray.Length; j++)   // дальше надо думать
                {
                    if (array[i] < tempArray[j])
                    {
                        tempArray[j] = tempArray[j - 1];
                    }
                }
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                Console.WriteLine(tempArray[i]);
            }





        }
    }
}






