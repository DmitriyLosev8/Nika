using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                       //мы вбили это, чтобы мы могли работать с файлами внутри компа

namespace CSLight    //Создание игры Pac-Man - Передвижение
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание игры "Pac-Man" - Передвижение

            Console.CursorVisible = false;   // отключаем видимость курсора
            bool isPlaing = true;   // булевая переменная, чтобы моно было выходить из игры
            int pacmanX, pacmanY;
            char[,] map = ReadMap("map1", out pacmanX, out pacmanY);  //координаты персонажа пакман  Чтобы правильно изначально задать координаты пакмана(карты ведь будут меняться) и он не оказался в стене
                                                                      // надо указать эти координаты в файле, который считывает функция изначально 

            int pacmanDX = 0, pacmanDY = 1;  // это будут направления движения
            DrawMap(map);

            while (isPlaing)   // пока играется, рисуем игрока
            {
                if (Console.KeyAvailable)  // мы будем заходит в этой if тогда, когда кто-то нажал какую-то клавишу
                {
                    ConsoleKeyInfo key = Console.ReadKey(true); //ConsoleKeyInfo - запоминает нажатую клавишу
                                                                //у ReadKey есть перегрузка (true), чтобы при нажатии эти символы не появлялись рядом с курсором (которые не видимый в нашем случае)

                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);

                    //  из этого сделали функцию
                    //switch (key.Key)   // и тут назначаем что делать в случае нажатия тех или иных клавиш
                    //{
                    //    case ConsoleKey.UpArrow:           // а тут в зависимости от нажатой клавиши (вверх, влево и тд) изменяем переменные направлений движения
                    //        pacmanDX = -1; pacmanDY = 0;
                    //        break;
                    //    case ConsoleKey.DownArrow:
                    //        pacmanDX = 1; pacmanDY = 0;
                    //        break;
                    //    case ConsoleKey.LeftArrow:
                    //        pacmanDX = 0; pacmanDY = -1;
                    //        break;
                    //    case ConsoleKey.RightArrow:
                    //        pacmanDX = 0; pacmanDY = 1;
                    //        break;
                    //}  
                }
                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')   // если на пути следования персонажа не символ '#' (стена) то идём, вот как:
                {
                    Move(ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);

                    //  из этого сделали функцию
                    //    Console.SetCursorPosition(pacmanY, pacmanX);   //ставим курсор в позицию координат
                    //    Console.Write(" "); // стриаем (меняем символ персонажа на пустоту), чтобы персонаж не дублировался на карте

                    //    pacmanX += pacmanDX;   // собственно передвигаем наш курсор
                    //    pacmanY += pacmanDY;

                    //    Console.SetCursorPosition(pacmanY, pacmanX); // ставим курсор в позицию новых координат
                    //    Console.Write('@'); // и рисуем на месте курсора с новыми координатами @ - нашего персонажа
                    //}    // сейчас он двигается сам максимально до стены, но очень быстро, его нельзя остановить или поменять направление, для этого нужна задержка итераций цикла:

                    System.Threading.Thread.Sleep(200);  // команда для остановки всего в милисекундах

                    //теперь надо сделать из этого функцию
                }
            }
        }

        static void Move(ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(" ");

            X += DX;
            Y += DY;

            Console.SetCursorPosition(Y, X);
            Console.Write('@');
        }
        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;
            }
        }
        
        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY)    // добывили в параметры out переменные, потому что надо проинициализировать и перезаписывать в память  
        {

            pacmanX = 0;    //начальная инициализация, чтобы out мог выполниться. Потому что без этого прогрммма считает, что эти координаты не всегда могут быть полученны
                            // (да, в теории там может быть ещё и  else
            pacmanY = 0;

            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");

            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '@')    // мы говорим, что если в массиве по двум координатам будет символ собаки, то  pacmanX = i;, а pacmanY = j;
                    {                         // то есть надо поставить туда игрока (в фауле с картой, надо нарисовать этот символ, где будет игрок
                        pacmanX = i;
                        pacmanY = j;
                    }
                }   
            }
            return map;
        }
    }
}






