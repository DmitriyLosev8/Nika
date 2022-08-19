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
        {      // Задание: Поиск преступника:

            List<Сriminal> criminals = new List<Сriminal> {new Сriminal(170,65,false,"Русский", "Жора"), new Сriminal(178, 80, false, "Русский", "Гена"), new Сriminal(165, 58, true, "Армянин", "Ашот"), 
                new Сriminal(181, 95, false, "Грузин", "Гиви"),new Сriminal(176,60,false,"Армянин", "Артур"),new Сriminal(160,48,false,"Грек", "Даниил"),new Сriminal(192,102,false,"Русский", "Коля"),
                new Сriminal(173,86,true,"Русский", "Саша")};

            int weightOfCriminal;
            int growthOfCriminal;
            Console.WriteLine("Введите рост преступника ДО какого показателя вам необходимо:");
            string userInput = Console.ReadLine();
            bool isSuccessful = int.TryParse(userInput, out growthOfCriminal);
            
            if (isSuccessful)
            {
                Console.WriteLine("Введите вес преступника ДО какого показателя вам необходимо:");
                userInput = Console.ReadLine();
                isSuccessful = int.TryParse(userInput, out weightOfCriminal);

                if (isSuccessful)
                {
                    Console.WriteLine("Введите национальность преступника:");
                    string nationalityOfCriminal = Console.ReadLine();

                    var criminalsWithNecessaryGrowth = criminals.Where(criminal => criminal.Growth < growthOfCriminal);
                    var criminalsWithNecessaryGrowthAndWeight = criminalsWithNecessaryGrowth.Where(criminal => criminal.Weight < weightOfCriminal);
                    var criminalsWithNecessaryGrowthAndWeightAndNationality = criminalsWithNecessaryGrowthAndWeight.Where(criminal => criminal.Nationality == nationalityOfCriminal);
                    var necessaryCriminals = criminalsWithNecessaryGrowthAndWeightAndNationality.Where(criminal => criminal.IsArrested == false);

                    foreach (var necessaryCriminal in necessaryCriminals)
                    {
                        Console.WriteLine(necessaryCriminal.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число.");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число.");
            }
        }             
    }

    class Сriminal
    {
        public string Name { get; private set; }    
        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public bool IsArrested { get; private set; }
        public string Nationality { get; private set; }
       
        public Сriminal(int growth, int weight, bool isArrested, string nationality, string name)
        {
            Growth = growth;
            Weight = weight;
            IsArrested = isArrested;
            Nationality = nationality;
            Name = name;
        }
    }
}









