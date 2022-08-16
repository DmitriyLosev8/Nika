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
        {
            //Задание: Война:                 ДОДЕЛАТЬ

            //RightLand rightLand = new RightLand();
            //rightLand.PrepareFoFight();
            //rightLand.ShowInfo();
            //LeftLand leftLand = new LeftLand();
            //leftLand.PrepareFoFight();
            //leftLand.ShowInfo();
            Arena arena = new Arena();
            arena.BeginFight();
        }
    }

    class Arena
    {
       private LeftLand _leftLand = new LeftLand();  
       private RightLand _rightLand = new RightLand();
        
       public void BeginFight()
        {
            _leftLand.PrepareFoFight();
            _rightLand.PrepareFoFight();

            while (_leftLand.IsAnyWarriorAlive == true && _rightLand.IsAnyWarriorAlive == true)
            {
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("Перед вами арена, где сражаются взводы войнов Леволандии и Праволандии");
                _leftLand.ShowInfo();
                _rightLand.ShowInfo();
                Console.SetCursorPosition(25, 20);
                //Console.WriteLine("Нажмите Enter, чтобы начать бой");
                //Console.ReadKey();
                
            }
        }

        private void Fight()
        {
            _leftLand.DiagnoseWarriors();
            _rightLand.DiagnoseWarriors();
            int indexOfLeftWarrior;
            int indexOfRightWarrior;
            Random random = new Random();
            indexOfLeftWarrior = random.Next(_leftLand.PlatoonToFight.Count);
            indexOfRightWarrior = random.Next(_rightLand.PlatoonToFight.Count);
   
        }
    }

   

    class Country
    {
        protected List<Warrior> Platoon = new List<Warrior>();
        protected int CountOfWarriors;
        protected int ChanceToHirefRecruit;
        protected int ChanceToHireInfantryman;
        protected int ChanceToHireOfficer;
        

        public IReadOnlyList<Warrior> PlatoonToFight { get; protected set; }
        public bool IsAnyWarriorAlive { get; protected set; }

       
        public Country()
        {       
            IsAnyWarriorAlive = true;
        }

        public void PrepareFoFight()
        {
            int minimalNumberOfWarriors = 10;
            int maximalNumberOfWarriors = 16;
            int countOfRecruits;
            int countOfInfantryman;
            int countOfOfficers;
            Random random = new Random();
            CountOfWarriors = random.Next(minimalNumberOfWarriors, maximalNumberOfWarriors);
            countOfRecruits = CountOfWarriors / ChanceToHirefRecruit;
            countOfInfantryman = CountOfWarriors / ChanceToHireInfantryman;
            countOfOfficers = CountOfWarriors / ChanceToHireOfficer;
            AddWarriors(new Recruit(), countOfRecruits);
            AddWarriors(new Infantryman(), countOfInfantryman);
            AddWarriors(new Officer(), countOfOfficers);
            PlatoonToFight = Platoon;
        }


        protected void AddWarriors(Warrior warrior, int countOfNewWarriors)
        {
            for (int i = 0; i < countOfNewWarriors; i++)
            {
                Platoon.Add(warrior);
            }

        }

        //protected void AddWarriors(int countOfRecruits, int countOfInfantryman, int countOfOfficers)
        //{
        //    for (int i = 0; i < countOfRecruits; i++)
        //    {
        //        Platoon.Add(new Recruit());
        //    }

        //    for (int i = 0; i < countOfInfantryman; i++)
        //    {
        //        Platoon.Add(new Infantryman());
        //    }

        //    for (int i = 0; i < countOfOfficers; i++)
        //    {
        //        Platoon.Add(new Officer());
        //    }
        //}

        public void DiagnoseWarriors()
        {
            for (int i = 0; i < PlatoonToFight.Count; i++)
            {
                if (PlatoonToFight[i].Health > 0)
                {
                    IsAnyWarriorAlive = true;
                }
                else
                {
                    Console.WriteLine("Все войны этого взвода погибли");
                    IsAnyWarriorAlive = false;
                }
            }
        }

        public virtual void ShowInfo()
        {
            for (int i = 0; i < PlatoonToFight.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                PlatoonToFight[i].ShowIndicators();
            }
        }

       
    }

    
    class LeftLand : Country
    {
        public LeftLand() : base()
        {
            ChanceToHirefRecruit = 5;
            ChanceToHireInfantryman = 2;
            ChanceToHireOfficer = 3;
           // AddWarriors();
        }

        public override void ShowInfo()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Леволандия:");
            base.ShowInfo();
        }
    }

    class RightLand : Country
    {
        public RightLand() : base()
        {
            ChanceToHirefRecruit = 4;
            ChanceToHireInfantryman = 2;
            ChanceToHireOfficer = 4;
            
            //AddWarriors();
        }

        public override void ShowInfo()
        {
            int leftIndent = 50;
            int topIndent = 5;
            Console.SetCursorPosition(leftIndent, topIndent);
            Console.WriteLine("Праволандия:");
            
            for (int i = 0; i < PlatoonToFight.Count; i++)
            {
                topIndent++;
                Console.SetCursorPosition(leftIndent, topIndent);
                Console.Write(i + 1 + " - ");
                PlatoonToFight[i].ShowIndicators();
            }    
        }
    }

    class Warrior
    {
        protected int Damage;
       
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        
        public virtual void UniqueSkill(int stepOfFigth) { }

        public void ShowIndicators()
        {
            Console.WriteLine($"Жизни - {Health}, броня - {Armor}");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }

    
    class Recruit : Warrior
    {
        public Recruit()
        {
            Health = 100;
            Armor = 25;
            Damage = 10;
        }

        public override void UniqueSkill(int stepOfFigth)
        {
            int coolDown = 3;

            if (stepOfFigth % coolDown == 0)
            {
                Health += 15;
            }
        }
    }
    class Infantryman : Warrior
    {
        public Infantryman()
        {
            Health = 150;
            Armor = 50;
            Damage = 15;
        }

        public override void UniqueSkill(int stepOfFigth)
        {
            int coolDown = 4;
            
            if (stepOfFigth % coolDown == 0)
            {
                Armor += 8;
            }
        }
    }

    class Officer : Warrior
    {
        public Officer()
        {
            Health = 200;
            Armor = 75;
            Damage = 20;
        }

        public override void UniqueSkill(int stepOfFigth)
        {
            int coolDown = 5;

            if (stepOfFigth % coolDown == 0)
            {
                Damage += 5;
            }
        }
    }
}









