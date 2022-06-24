﻿using System;
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
            //домашнее задание: некий бар:
            
            int health = 5, maxHealth = 10;   
            int mana = 3, maxMana = 10;

           while (true)
            {
                DrawBar(health, maxHealth, ConsoleColor.Red, 0, '#');   // и вызываем функцию DrawBar, куда и помещаем наши переменные, а также вводим нужный нам цвет
                DrawBar(mana, maxMana, ConsoleColor.Blue, 1);    // так отрисует голубым, но здоровье (health), чтобы рисовал 2, надо изменить функцию

                Console.SetCursorPosition(0, 5);   // убираем вопросы пониже, чтобы было удобно

                Console.Write("Введите число, на которое изменятся жизни:");   // делаем так, чтобы количество жизней вводил пользователь и мог их менять
                health += Convert.ToInt32(Console.ReadLine());         // берём значение введёное пользователем
                Console.Write("Введите число, на которое изменится магия:");   // делаем так, чтобы количество магии вводил пользователь и мог его менять
                mana += Convert.ToInt32(Console.ReadLine());         // берём значение введёное пользователем

                Console.ReadKey();   //чтобы цикл постоянно не воспроизводился, а нужно было нажатие пользователя
                Console.Clear(); //стираем консоль, чтобы она обновлялась
            } 
        }

        //ЭТО ТОЛЬКО ФУНКЦИЯ РИСОВАНИЯ, А ВЫШЕ МОЖНО ПОДСТАВЛЯТЬ ЛЮБОЙ БАР (ЗДОРОВЬЯ, МАНА, БРОНЯ И ТД)
        
        static void DrawBar( int value, int maxValue, ConsoleColor color, int position, char symbol = ' ')   // это будет функция, которая рисует некий бар (здоровья, маны и тд. но ничего не возвращает (void)
        {                                                                     // ДОБАВИЛИ ПЕРЕМЕННУЮ ПОЗИЦИЯ, ЧТОБЫ РАЗДЕЛЯТЬ РАЗНЫЕ БАРЫ и необязательный char для заполненности
            ConsoleColor defaulColor = Console.BackgroundColor;   //запоминаем обычный цвет консоли, чтобы потом можно было его вернуть

            string bar = "";  // сюда мы будем записывать колличество каки-то наших элементов, сделаем это черз цикл for

            for (int i = 0; i < value; i++)   // value - это показатель нашего чего-то (здоровья, маны и тд)
            {
                bar += symbol;   // внутри цикла прибавляем к bar  по одному символу  (добавлю от себя - тут можно сделать условие, что if если value кратно 10 или 5, то тогда добавляем символ

            }
            Console.SetCursorPosition(0, position);   // устанавливаем курсор в полностью нулевую позицию // ДОБАВИЛИ ПЕРЕМЕННУЮ ПОЗИЦИЯ, ЧТОБЫ РАЗДЕЛЯТЬ РАЗНЫЕ БАРЫ
            Console.Write('[');  // и начинаем рисовать. Для начала у нас будет квадратная открывающая скобка
            Console.BackgroundColor = color;  // далее назначаем цвет текста
            Console.Write(bar);    // и выводим нашу строку bar
            Console.BackgroundColor = defaulColor; // так как заполненую часть бара мы отрисовали, то возвращем цвет текста на стандартный

            bar = "";  // говорим, что bar  - это пустая строка, чтобы заполнить пустую часть нашего бара
            // далее отрисовываем нашу НЕзаполненную часть:

            for (int i = value; i < maxValue; i++)  // так как это отрисовка пустой части, то i = value и пока i < maxValue (максимальное значение здоровья, маны и тд) тогда прибавляем i (рисуем)
            {
                bar += symbol;  // нарисовали пустые строки
            }
            Console.Write(bar + ']');  // и в конце рисуем наш бар (его пустую часть) и закрывающую скобку
        }

    }
}






