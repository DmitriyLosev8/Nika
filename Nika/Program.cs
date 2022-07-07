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
        {      //Задание: объединение в одну коллекцию:  Доделать  

            string[] chairs = { "1", "2", "3", "7", "10", "45" };
            string[] armchairs = { "4", "3", "5", "10", "18" };
            List<string> seats = new List<string>();
            seats.AddRange(chairs);
            seats.AddRange(armchairs);

            SearchAndDeleteRepeatingStrings(seats, chairs, armchairs);
            ShowingAllUniqueSeats(seats);
        }

        static void SearchAndDeleteRepeatingStrings(List<string> seats, string[] chairs, string[] armchairs)
        {
            string repeatingString;
            int repeatingElement;

            List<string> tempSeats =new List<string>();
            tempSeats.AddRange(armchairs);
            tempSeats.AddRange(chairs);

            int count = 0;


            for (int i = 0; i < seats.Count; i++)
            {
                for (int j = 0; j < tempSeats.Count; j++)
                {
                    if (seats[i] == tempSeats[j])
                    {
                        count++;
                        repeatingString = seats[i];
                        Console.WriteLine(count);
                    }
                    
                    //repeatingElement = i;
                    //Console.WriteLine(repeatingElement);
                }
                //count++;
                //Console.WriteLine(count);

            }



            //for (int i = 0; i < seats.Count; i++)
            //{
            //    for (int j = 0; j < seats.Count; j++)
            //    {

            //        if (seats[i] == seats[j])
            //        {
            //            repeatingString = seats[i];
            //            count++;
            //            if (count > 1)
            //            {
            //                //repeatingString = seats[i];
            //                Console.WriteLine("хай");

            //                // seats.Remove(repeatingString);
            //            }
            //        }

            //    }
            //}

            //for (int i = 0; i < chairs.Length; i++)
            //{
            //    for (int j = 0; j < armchairs.Length; j++)
            //    {
            //        if (chairs[i] == armchairs[j])
            //        {
            //            repeatingString = armchairs[j]
            //            seats.Remove(repeatingString);
            //        }
            //    }
            //}
        }

        static void ShowingAllUniqueSeats(List<string> seats)
        {
            for (int i = 0; i < seats.Count; i++)
            {
                Console.WriteLine(seats[i]);

            }
        }
    }
} 









