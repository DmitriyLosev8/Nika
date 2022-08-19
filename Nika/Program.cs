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
        {      // Задание: Амнистия:

            List<Prisoner> prisoners = new List<Prisoner> {new Prisoner("Коля", "Грабёж"),new Prisoner("Боря", "Антиправительственное"),new Prisoner("Егор", "Антиправительственное"),new Prisoner("Саша", "Убийство"),
                new Prisoner("Толя", "Грабёж"),  new Prisoner("Гена", "ДТП"), new Prisoner("Степан", "Кража"), new Prisoner("Женя", "Антиправительственное")};

            Console.WriteLine("Список преступников до амнистии:\n");

            foreach (var prisoner in prisoners)
            {
                Console.WriteLine(prisoner.Name + " - " + prisoner.Offense);
            }

            var notAmnestiedPrisoners = prisoners.Where(prisoner => prisoner.Offense != "Антиправительственное");

            Console.WriteLine("\n\nСписок преступников после амнистии:\n");

            foreach (var prisoner in notAmnestiedPrisoners)
            {
                Console.WriteLine(prisoner.Name + " - " + prisoner.Offense);
            }
        }          
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public string Offense { get; private set; }

        public Prisoner(string name, string offense)
        {
            Name = name;
            Offense = offense;
        }
    }
}









