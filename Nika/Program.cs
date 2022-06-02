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
            //домашнее задание: степень двойки: 

            int lowerNumber = 1;
            int upperNumber = 100;
            int stepen;
            int numberStepen = 2;
            int tempN = 0;

            Random random = new Random();
            int number = random.Next(lowerNumber, upperNumber);      //условно тут число 50

            Console.WriteLine("Стартовое число - " + number);

          // while (tempN <= number)
           // {
           //     tempN++;
          //      if (tempN = number)

          //  }
           
            





            for (int i = number; i < upperNumber; i++)
            {
                if (i % numberStepen == 0)
               {
                       Console.WriteLine(i);
                }
               
            }
           
            
        }
    }
}
