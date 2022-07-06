using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight    
{
    internal class Program
    {
        static void Main(string[] args)
        {      //Задание: толковый словарь:    

            Dictionary<string, string> fullNames = new Dictionary<string, string>();

            fullNames.Add("Георгий", "Золотарёв");
            fullNames.Add("Степан", "Калин");
            fullNames.Add("Сергей", "Бондаренко");
            fullNames.Add("Николай", "Киреев");
            fullNames.Add("Александр", "Гордеев");

            ShowingLastName(fullNames);
        }

        static void ShowingLastName(Dictionary<string, string> fullNames)
        {
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Напишите имя и мы покажем вам фамилию этого человека");
                userInput = Console.ReadLine();

                if (fullNames.ContainsKey(userInput))
                {
                    Console.WriteLine("Вот фамилия этого человека - " + fullNames[userInput]);
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Такого человека нет, нажмите Enter, чтобы попробовать снова:");
                    Console.ReadKey();
                }
            }
        }
    }
}






