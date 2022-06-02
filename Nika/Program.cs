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

            int upperBorder = 1000;
            int lowerBorder = 100;
            Random random = new Random();  
            int n = random.Next(1, 27);   

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
