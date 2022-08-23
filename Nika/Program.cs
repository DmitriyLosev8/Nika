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
        {      // Задание: Анархия в больнице:

            List<Patient> patients = new List<Patient> {new Patient("Анжуров Никита Семёнович", 24, "Ангина"), new Patient("Жмышенко Валерий Альбертович", 54, "Стафилокок"), new Patient("Борисенко Дмитрий Степанович", 29, "Грипп"),
          new Patient("Степанян Кристина Артуровна", 35, "ОРВИ"),new Patient("Данилова Анастасия Анатольевна", 19, "Астма"),new Patient("Жуков Степан Андреевич", 69, "Остеохондроз"),new Patient("Носов Николай Артёмович", 14, "Грипп"),
          new Patient("Губарев Андрей Вячеславович", 42, "Перелом ноги"),new Patient("Мурзук Юлия Александровна", 62, "Сердечная недостаточность"),new Patient("Андропов Артём Витальевич", 35, "Шизофрения"),};

            bool isWorking = true;
            string sortFullNames = "1";
            string sortAges = "2";
            string showSomeDiseases = "3";

            while (isWorking)
            {
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("Перед вами меню управления списком пациентов:");
                Console.WriteLine($"Нажмите {sortFullNames}, чтобы отсортировать пациентов по ФИО\nНажмите {sortAges}, чтобы отсортировать пациентов по возрасту\nНажмите {showSomeDiseases}, чтобы найти пациентов по болезни\n" +
                    $"Нажмите любую другую клавишу, чтобы выйти");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    var sortByFullNamesPatients = patients.OrderBy(patient => patient.FullName).ToList();
                    ShowPatiens(sortByFullNamesPatients);
                }
                else if (userInput == "2")
                {
                    var sortByAgePatient = patients.OrderBy(patient => patient.Age).ToList();
                    ShowPatiens(sortByAgePatient);
                }
                else if (userInput == "3")
                {
                    var necessaryDiseases = FindNesecessaryDisease(patients);
                    ShowPatiens(necessaryDiseases);
                }
                else
                {
                    isWorking = false;
                }

                Console.ReadKey();
                Console.Clear();
            }

            static void ShowPatiens(List<Patient> patients)
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine($"{patient.FullName} - {patient.Age} - {patient.Disease}");
                }
            }

            static List<Patient> FindNesecessaryDisease(List<Patient> patients)
            {
                Console.WriteLine("Введите болезнь, которую ищите:");
                string userInput = Console.ReadLine();
                var necessaryDiseases = patients.Where(patient => patient.Disease == userInput).ToList();

                if (necessaryDiseases.Count == 0)
                {
                    Console.WriteLine("Пациента с такой болезнью нет в базе данных");
                }

                return necessaryDiseases;
            }
        }
    }

    class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }
    }
}









