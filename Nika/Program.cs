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
            //Задание: Война:                 
           
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
            _leftLand.PrepareForFight();
            _rightLand.PrepareForFight();
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Перед вами арена, где сражаются взводы войнов Леволандии и Праволандии");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Нажмите Enter, чтобы начать бой");
            Console.ReadKey();
            Fight();
        }

        private void Fight()
        {
            int stepOfFight = 0;
            int indexOfLeftWarrior;
            int indexOfRightWarrior;
            Random random = new Random();

            while (_leftLand.IsAnyWarriorAlive == true && _rightLand.IsAnyWarriorAlive == true)
            {
                stepOfFight++;
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine("СРАЖЕНИЕ:");
                Console.SetCursorPosition(25, 20);

                indexOfLeftWarrior = random.Next(_leftLand.PlatoonToFight.Count);
                indexOfRightWarrior = random.Next(_rightLand.PlatoonToFight.Count);
                
                _leftLand.PlatoonToFight[indexOfLeftWarrior].UniqueSkill(stepOfFight);
                _rightLand.PlatoonToFight[indexOfRightWarrior].TakeDamage(_leftLand.PlatoonToFight[indexOfLeftWarrior].Damage);
                _rightLand.PlatoonToFight[indexOfRightWarrior].UniqueSkill(stepOfFight);
                _leftLand.PlatoonToFight[indexOfLeftWarrior].TakeDamage(_rightLand.PlatoonToFight[indexOfRightWarrior].Damage);
                
                _leftLand.DiagnoseWarriors();
                _leftLand.ShowInfo();
                _rightLand.DiagnoseWarriors();
                _rightLand.ShowInfo();
                FinishFight();
                Console.ReadKey();
            }   
        }

        private void FinishFight()
        {
            Console.SetCursorPosition(35, 2);
            
            if (_leftLand.IsAnyWarriorAlive == false && _rightLand.IsAnyWarriorAlive == false)
            {
                Console.WriteLine("Ничья!Все погибли!");
            }
            else if (_rightLand.IsAnyWarriorAlive == false)
            {
                Console.WriteLine("Победила Леволандия!");
            }
            else if (_leftLand.IsAnyWarriorAlive == false)
            {
                Console.WriteLine("Победила Праволандия!");
            }
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
        public bool IsAnyWarriorAlive  { get; protected set; } = true;

        public void PrepareForFight()
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
            AddWarriors(countOfRecruits, countOfInfantryman, countOfOfficers);
            GetReadyFoFight();
        }

        public void GetReadyFoFight()
        {
            PlatoonToFight = Platoon;
        }

        protected void AddWarriors(int countOfRecruits,int countOfInfantryman,int countOfOfficers)
        {
            for (int i = 0; i < countOfRecruits; i++)
            {
                Platoon.Add(new Recruit());
            }

            for (int i = 0; i < countOfInfantryman; i++)
            {
                Platoon.Add(new Infantryman());
            }
           
            for (int i = 0; i < countOfInfantryman; i++)
            {
                Platoon.Add(new Officer());
            }
        }

        public void DiagnoseWarriors()
        {
            int indexOfDeadWarior;

            for (int i = 0; i < PlatoonToFight.Count; i++)
            {
                if (PlatoonToFight[i].Health > 0)
                {
                    IsAnyWarriorAlive = true;
                }
                else
                {
                    indexOfDeadWarior = i;
                    Platoon.RemoveAt(indexOfDeadWarior);
                    GetReadyFoFight();
                    i--;
                }
            }

            if (PlatoonToFight.Count == 0)
            {
                IsAnyWarriorAlive = false;
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
        protected int UniqueFeature;
       
        public int Damage { get; protected set; }   
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public string Rank { get; protected set; }

        public virtual void UniqueSkill(int stepOfFigth) { }

        public void ShowIndicators()
        {
            Console.WriteLine($"{Rank }, жизни - {Health}, броня - {Armor}");
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
            Health = 30;
            Armor = 6;
            Damage = 15;
            Rank = "Рекрут";
            UniqueFeature = 5;
        }

        public override void UniqueSkill(int stepOfFigth)
        {
            int coolDown = 3;

            if (stepOfFigth % coolDown == 0)
            {
                Health += UniqueFeature;
            }
        }
    }
   
    class Infantryman : Warrior
    {
        public Infantryman()
        {
            Health = 40;
            Armor = 8;
            Damage = 20;
            Rank = "Пехотинец";
            UniqueFeature = 1;
        }

        public override void UniqueSkill(int stepOfFigth)
        {
            int coolDown = 4;
            
            if (stepOfFigth % coolDown == 0)
            {
                Armor += UniqueFeature;
            }
        }
    }

    class Officer : Warrior
    {
        public Officer()
        {
            Health = 50;
            Armor = 10;
            Damage = 25;
            Rank = "Офицер";
            UniqueFeature = 3;
        }

        public override void UniqueSkill(int stepOfFigth)
        {
            int coolDown = 5;

            if (stepOfFigth % coolDown == 0)
            {
                Damage += UniqueFeature;
            }
        }
    }
}









