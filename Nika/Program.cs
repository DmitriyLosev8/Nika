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
        {      //Задание: очередь в магазине:    

            Queue<int> queueToStore = new Queue<int>();
            queueToStore.Enqueue(50);
            queueToStore.Enqueue(80);
            queueToStore.Enqueue(45);
            queueToStore.Enqueue(36);
            queueToStore.Enqueue(67);
            queueToStore.Enqueue(90);
            queueToStore.Enqueue(250);

            int amountOfPurchases = 0;
            serviceOfClients(queueToStore, amountOfPurchases);
        }
        static void serviceOfClients(Queue<int> queueToStore,int amountOfPurchases)
        {
            foreach (var client in queueToStore)
            {
                amountOfPurchases += client;
                Console.WriteLine("Текущая сумма покупок всех клиентов - " + amountOfPurchases + ", нажмите любою клавишу, чтобы обслужить следующего клиента:");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}






