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
            // Задание: Кадровый учёт:   доделать поиск по фамилии

            string[] fio = new string[0];
            string[] post = new string[0];
            string userInformation;
            string userInput;
            bool isWorking = true;
            int DossierToDelete;
            int numberToCorrectInputOrUotput = 1;
            int numberOfDossier = 0;



            while (isWorking)
            {
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("ПЕРЕД ВАМИ ПРОГРАММА КАДРОВОГО УЧЁТА");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Нажмите 1, чтобы добавить досье\nНажмите 2, чтобы показать все досье\nНажмите 3, чтобы удалить какое-то досье\n" +
                    "Нажмите 4, для поиска досье по фамилии\nНажмите 5, чтобы выйти\n\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Введите Ваши ФИО:");
                        userInformation = Console.ReadLine();
                        fio = AddDossier(fio, userInformation);
                        Console.WriteLine("Введите Вашe должность:");
                        userInformation = Console.ReadLine();
                        post = AddDossier(post, userInformation);
                        break;
                    case "2":
                        Console.WriteLine("Вот список досье:\n");

                        for (int i = 0; i < fio.Length; i++)
                        {
                            for (int j = 0; j < post.Length; j++)
                            {
                                if (i == j)
                                {
                                    Console.Write((i + numberToCorrectInputOrUotput) + ") " + fio[i] + "-" + post[j] + ", ");
                                }
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Какое по счёту досье вы хотите удалить?");
                        DossierToDelete = Convert.ToInt32(Console.ReadLine());
                        DeleteDossier(ref fio, DossierToDelete);
                        DeleteDossier(ref post, DossierToDelete);
                        break;
                    case "4":
                        Console.WriteLine("Введите фамилию и мы покажем вам это досье:");
                        userInformation = Console.ReadLine();
                        SearchOfFio(out fio, userInformation,numberOfDossier);

                        Console.WriteLine("Вот это досье:\n");

                        for (int i = 0; i < fio.Length; i++)
                        {
                            for (int j = 0; j < post.Length; j++)
                            {
                                if (i == numberOfDossier)
                                {
                                    Console.Write((i + numberToCorrectInputOrUotput) + ") " + fio[i] + "-" + post[j] + ", ");
                                }
                            }
                        }
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static string[] AddDossier(string[] partOfDossier, string userInformation)
        {
            string[] tempPartOfDossier = new string[partOfDossier.Length + 1];

            for (int i = 0; i < partOfDossier.Length; i++)
            {
                tempPartOfDossier[i] = partOfDossier[i];
            }
            tempPartOfDossier[tempPartOfDossier.Length - 1] = userInformation;
            partOfDossier = tempPartOfDossier;
            return partOfDossier;
        }

        static void DeleteDossier(ref string[] partOfDossier, int DossierToDelete)
        {
            int numberToCorrectInput = 1;
            
            if (DossierToDelete - numberToCorrectInput > partOfDossier.Length)
            {
                Console.WriteLine("Такого досье нет, введите корректный номер досье");
            }
            
            string[] tempPartOfDossier = new string[partOfDossier.Length - 1];

            for (int i = 0; i < DossierToDelete - numberToCorrectInput; i++)
            {
                tempPartOfDossier[i] = partOfDossier[i];
            }

            for (int i = DossierToDelete; i < partOfDossier.Length; i++)
            {
                tempPartOfDossier[i - 1] = partOfDossier[i];
            }
            partOfDossier = tempPartOfDossier;
        }

        static void SearchOfFio(out string[] partOfDossier, string userInformation, int numberOfDossier)
        {  
            string familia;

            for (int i = 0; i < partOfDossier.Length; i++)
            {
                familia = partOfDossier[i];
                string[] separateFio = familia.Split();

                for (int j = 0; j < separateFio.Length; j++)
                {
                    if (separateFio[j] == userInformation)
                    {
                        numberOfDossier = i;
                    }
                }   
            }
           //return partOfDossier;
        }
    }
}






