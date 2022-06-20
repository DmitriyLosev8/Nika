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

            // домашнее задание: split:

            string str = "Каждый охотник желает знать где сидит фазан";
            string[] words = str.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

        }
    }
}






