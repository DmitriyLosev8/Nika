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
            //Задание: Магазин:       
            Seller seller = new Seller();
            seller.AddProduct();
            Client client = new Client();
            bool isWorking = true;

            while (isWorking)
            {
                bool isSuccessfull;
                string userInput;
                int inputedNumber;
                Console.SetCursorPosition(45, 0);
                Console.WriteLine("Добро пожаловать в магазин");
                seller.ShowAllProducts();
                Console.SetCursorPosition(45, 8);
                Console.WriteLine("Чтобы купить товар, нажмите 1");
                Console.SetCursorPosition(45, 9);
                Console.WriteLine("Чтобы посмотреть купленные товары, нажмите 2");
                userInput = Console.ReadLine();
                isSuccessfull = int.TryParse(userInput, out inputedNumber);

                if (isSuccessfull == true)
                {
                    if (inputedNumber == 1)
                    {
                        Console.WriteLine("Введите название товара, который вы хотите купить");
                        userInput = Console.ReadLine();
                        
                        for (int i = 0; i < seller.Products.Count; i++)
                        {
                            if (seller.Products[i].Title == userInput)
                            {
                                client.Purchase(i, seller.Products);
                                seller.Sale(i);
                            }
                        }
                    }

                    if (inputedNumber == 2)
                    {
                        client.ShowCliensProducts();
                    }
                    else
                    {
                        isWorking = false;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Client
    {
        private List<Product> _bag = new List<Product>();
        private int _money;

        public void Purchase(int productIndex, List<Product> Products)
        {
            _money -= Products[productIndex].Price;
            _bag.Add(Products[productIndex]);
        }

        public void ShowCliensProducts()
        {
            Console.WriteLine("Вот список всех купленных товаров:\n");

            for (int i = 0; i < _bag.Count; i++)
            {
                Console.Write(i + 1 + " ");
                Console.WriteLine(_bag[i].Title + " стоит - " + _bag[i].Price);
                Console.WriteLine("Денег у покупателя - " + _money);
            }
        }
        
        public Client()
        {
        _money = 1000;
        }  
    }

    class Seller
    {
        private int _money;

        public List<Product> Products { get; private set; } = new List<Product>();

        public Seller()
        {
            _money = 0;
        }

        public void AddProduct()
        {
            Products.Add(new Product("Сахар", 50));
            Products.Add(new Product("Масло", 70));
            Products.Add(new Product("Мука", 40));
            Products.Add(new Product("Соль", 20));
            Products.Add(new Product("Греча", 75));
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("Вот список всех товаров:\n");

            for (int i = 0; i < Products.Count; i++)
            {
                Console.Write(i + 1 + " ");
                Console.WriteLine(Products[i].Title + " стоит - " + Products[i].Price);       
            }
            Console.WriteLine("Денег в магазине - " + _money);
        }

        public void Sale(int productIndex)
        {
            _money += Products[productIndex].Price;
            Products.RemoveAt(productIndex);
        } 
    }
   
    class Product
    {
        public string Title { get; private set; }
        public int Price { get; private set; }

        public Product(string title, int price)
        {
            Title = title;
            Price = price;
        }
    }
}









