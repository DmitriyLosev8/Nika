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
        {      //Практика: Создание компьютерного клуба
            ComputerClub computerClub = new ComputerClub(8);  // создали компьтерный клуб с 8 компами
            computerClub.Work(); // запускаем цикл работы.


        }

    }

    class ComputerClub   // а тут самое интересное, так как тут всё управление
    {
       
        private int _money = 0;   // тут тоже сть деньги, изначально их нет
        private List<Computer>  _computers = new List<Computer>();  //создаём список компютеров, чтобы оттуда их брать и управлять ими
        private Queue<SchoolBoy> _scoolBoys = new Queue<SchoolBoy>();   // также у нас есть очередь из школьников
        //ДАЛЕЕ НАДО ПОДУМАТЬ, что может быть у школьника и у компьютера

        public ComputerClub(int computerCount)  // нам как-то надо заполнить клуб. ((Он ничего в себя не принимает)), но в нём будет рандом? ,будет кол-во компов, по которым будет их генерировать
        {
            Random random = new Random();   // рандом нужен для рандомной генерации компов

            for (int i = 0; i < computerCount; i++)  //будет кол-во компов, по которым будет их генерировать
            {
                _computers.Add(new Computer(random.Next(5,15)));  // и создаём тут новый комп, а рандом нужен для определения цены (можно и НЕ рандомно делать)
            }

            // теперь нам нужно создать школьников, НО ЕСЛИ СДЕЛАТЬ ИХ ТАКЖЕ ЧЕРЕЗ ЦИКЛ, то мы НЕ СМОЖЕМ ДОБАВИТЬ ИХ ПОТОМ. Поэтому лучше через метод:
            // вот собственно метод:
            CreateNewSchoolBoy(25); // создали 25 школьников
        }

        private void CreateNewSchoolBoy(int count)  // создавать новых школьников будем через метод и передаём сколько мы хотим их создать ПРИВАТНОЕ
        {
            Random random = new Random();  //  тут рандом для того, чтобы генерировать кол-во денег у школьников

            for (int i = 0; i < count; i++)
            {
                _scoolBoys.Enqueue(new SchoolBoy(random.Next(100,250), random)); // и создаём тут нового школьника в его ОЧЕРЕДИ (поэтому Enqueue),
                                                                         // а рандом нужен для определения денг у школьника (можно и НЕ рандомно делать)
                                                                         // + рандом для школьника, чтобы их минуты не были одикаковыми
            }
        }

        public void Work()  // тут будет цикл работы клуба
        {
            while(_scoolBoys.Count > 0)   // пока кол-во школьников больше нуля, то работаем
            {
                Console.WriteLine($"У компьютерного клуба сейчас {_money} рублей, ждём нового клиента.");

                SchoolBoy schoolBoy = _scoolBoys.Dequeue(); // мы удаляем из очереди и получаем его себе в клуб
                Console.WriteLine($"В очереди молодой человек, он хочет купить {schoolBoy.DesiredMinutes} минут");  // мы берём школьнкика, которого получили и берём его желаемые минуты
                Console.WriteLine("\nСписок компьютеров:");
                ShowAllComputers();

                Console.Write("\nВы предлагаете ему ПК по номером - ");
                int computerNumber = Convert.ToInt32(Console.ReadLine());  // тут надо делать проверку на ввод числа используя IntTryParse

                if (computerNumber >= 0 && computerNumber < _computers.Count) // делаем проверку чтобы пользователь ввёл число больше чем 0 и меньше чем все компов (их номера идут по порядку же)
                {
                    if (_computers[computerNumber].IsBusy)  // проверям занят ли наш комп ( по индексу, который ввёл пользователь)
                    {
                        Console.WriteLine("Вы предложили клиенту компьютер, который уже занят. Клиент ушёл.");
                    }
                    else
                    {
                        if (schoolBoy.CheckSolvency(_computers[computerNumber]))  // проверяем если денег хватает (нам сюда возвращается true или false из метода CheckSolvency
                        {
                            Console.WriteLine("Пересчитав деньги, клиент оплатил нужно время и сел за компьютер");
                            _money += schoolBoy.ToPay();   // оплатили используя метод (избежав ошибки, когда у школьника могли изменить ко-во денег на любое)

                            _computers[computerNumber].TakeThePlace(schoolBoy);   // заняли наше место используя метод TakeThePlace и школьником внутри него
                        }
                        else
                        {
                            Console.WriteLine("У клиента не хватило денег, он ушёл");
                        }


                    }
                }
                else
                {
                    Console.WriteLine("Вы сами не понимаете за какой ПК его посадить. Клиент ушёл.");
                }
                
                Console.WriteLine("Для того, чтобы перейти к номому клиенту, нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                SkipMitute();  // метод для уменьшения времени
            }
        }

        private void ShowAllComputers()  // приватный(потому что вызываться будет только из класса) метод показать все компы
        {
            for (int i = 0; i < _computers.Count; i++)  // используем for, чтобы можно было обращаться к каждому конкретному компу по индексу
            {
                Console.Write($"{i} - ");  // так мы посмотрим порядковый номер каждого компа
                _computers[i].ShowInfo();  // и вызываем метод показа инфы у каждого компа
            }
        }

        public void SkipMitute()  // этот метод будет перебирать все компы и отнимает у нужного минуты
        {
            foreach (var computer in _computers)
            {
                computer.SkipMinute();  // отнимаем минуту у нужного нам в будущем компа
            }
        }


    }

    class Computer  // компьтер тут не с точки зрения техники, а с точки зрения какого-то места, то есть это как бы слот для школьника
    {
        private SchoolBoy _schoolBoy;  // у компьтера есть поле школьник (буквально класс школьник), он за ним сидит
        private int _minutesLeft;  //то сколько минут осталось

        public int PriceForMinute { get; private set; }  // есть цена за минуту

        // ДАЛЕЕ НАМ НАДО СДЕЛАТЬ ПОКАЗАТЕЛЬ ЗАНЯТ ЛИ ОБЪЕКТ (КОМПЬТЕР):

        public bool IsBusy
        {
            get
            {
                return _minutesLeft > 0; // МЫ ПРОСТО ВОЗВРАЩАЕМ РЕЗУЛЬТАТ СРАВНЕНИЯ То есть, если Минут осталось больше чем 0, то true(комп занят), а если не больше 0, то false(Комп свободен) - гениально
            }
        }

        public Computer(int priceForMinute)  // в конструкторе передаём толшько цену за минуту
        {
            PriceForMinute = priceForMinute;
        }

        public void TakeThePlace(SchoolBoy schoolBoy)  // метод занятия места школьником
        {
            _schoolBoy = schoolBoy;  //мы присваеваем нашего школьника из класса школьник к переменной школьник (как в конструкторе)
            _minutesLeft = _schoolBoy.DesiredMinutes; // тут мы передаём в оставшиеся минуты желаемые минуты школька, то есть он их занимает
        }

        public void FreeThePlace()  // метод освобождения места
        {
            _schoolBoy = null;  // там больше ничего не хранится, мы очистили это поле
        }  

        public void SkipMinute() // сделать отсчёт времени
        {
            _minutesLeft--; // отнимаем по одной минуте
        }  

        public void ShowInfo()  // показ информации о компьютере
        {
            if (IsBusy)                                                          // занят ли комп
            {
                Console.WriteLine($"Комьтер занят, осталось минут - {_minutesLeft}");    // если да, то сколько минут осталось
            }
            else
            {
                Console.WriteLine($"Компьютер свободен, цена за минту - {PriceForMinute}");   //  если нет, то какая цена
            }
        }

    }

    class SchoolBoy
    {
        private int _money;   // у школьника могут быть деньги
        // сразу надо понимать какие поля могу понадобиться снаружи класса

        private int _moneyToPay;  // то, сколько денег НАДО заплатить
        public int DesiredMinutes { get; private set; }  // в таком случае делам свойство ( тут это желаемые минуты щкольника за компом)

        public SchoolBoy (int money, Random random)  // в конструкторе будут только деньги, потому что минуты передавать не будем, так как очередь будет рандомно сгенерирована
                                                      // также передаём рандом, чтобы минуты всех школьников не были одинаковыми (из-за ошибки рандома)
                                                      // ОКАЗЫВАЕТСЯ В КОНСТРУКТОР МОЖНО ПЕРЕДАВАТЬ ТО, ЧЕГО НЕТ В КЛАССЕ (ПРЯМ КАК В МЕТОД)
        { 
            _money = money;
            DesiredMinutes = random.Next(10, 30);   // рандомно школьник будут хотеть посидеть за компом от 10 до 30 минут
        }

        //public int TakeMoney(int minutePrice)
        //{
        //    _money -= minutePrice;
        //    return minutePrice;
        //}                               //ТАК ДЕЛАТЬ НЕ НАДО, ПОТОМУ ЧТО ТУДА МОГУТ ПЕРЕДАТЬ ЛЮБОЕ КОЛ-ВО ДЕНЕГ, МЕТОД ТО ПУБЛИЧНЫЙ, А НАДО ДЕЛАТЬ ТАК:

        public  bool CheckSolvency(Computer computer) // метод будет проверять платёжеспособность школьника, НО ПРИНИМАЕМ МЫ данные о компьютере, буквально весь класс(используя как тип параметра)
        {
            _moneyToPay = computer.PriceForMinute * DesiredMinutes;  // так как мы знаем сколько школьник хочет минут мы умножаем цену на эти минуты и получаем _moneyToPay (то, сколько денег НАДО заплатить)

            if (_money >= _moneyToPay)  // если денг у школьника больше или равно деньгам к оплате
            {
                return true;     // елси да, то возвращаем true (сделку можно совершить)
            }
            else   //если нет
            {
                _moneyToPay = 0;   // то обнуляем деньги к оплате, сделки то не будет
                return false;    // и возвращаем false, так как сделка не может пройти
            }
        }

        public int ToPay()  // метод для оплаты
        {
            _money -= _moneyToPay; // от денег школьника отнимаем деньги к оплате
            return _moneyToPay;  // и возвращаем кол-во денег к оплате
        }
    }


}









