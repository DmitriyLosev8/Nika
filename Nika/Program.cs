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
            //домашнее задание: кратность: 

            int lowerNumber = 1;
            int upperNumber = 27;
            int lowerBorder = 100;
            int upperBorder = 1000;

            Random random = new Random();  
            int n = random.Next(lowerNumber, upperNumber);   

            Console.WriteLine("Число N - " + n);

            for (int i = 0; i < upperBorder; i+=n)
            { 
              
                if (i > lowerBorder)
                {
                    Console.WriteLine(i);
                } 
            }
        }
    }
}
