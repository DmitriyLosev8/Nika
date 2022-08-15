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
            //Задание: Супермаркет:    ОЧЕРЕДЬ

            Supermarket supermarket = new Supermarket();

            //supermarket.Test();

           // supermarket.Work();

            //for (int i = 0; i < supermarket._clients.Count; i++)
            //{
            //    Console.WriteLine(supermarket._clients[i].
            //}

            //foreach (var client in supermarket._clients)
            //{
            //    Console.WriteLine(client._money);
            //}

            Queue<string> products = new Queue<string>();
            products.Enqueue("Молоко");
            products.Enqueue("Сахар");
            products.Enqueue("Хлеб");
            products.Enqueue("Пиво");
            products.Enqueue("Пельмени");
            products.Enqueue("Мясо");

            foreach(var product in products)
            {
                Console.WriteLine(product);
                products.Dequeue();
            }





        }
    }


    class Supermarket
    {
        private int _countOfCliensPerDay = 15;
        private int _countOfProductsPerDay = 500;
        private int _money = 5000;
        private int _purchaseAmount = 0;
        private List<Product> _shelves = new List<Product>();
        private Queue<Client> _clients = new Queue<Client>();

        //CalculatePurchase

        public void Work()  //Product[] productsToCashier   
        {
            AddProducts();
            AddClients();
            TakeOfProducts();

            foreach (var client in _clients)
            {
                
                int numberOfClient = 1;
                client.ShowInfo();
                ShowInfo();
                Console.WriteLine("На кассе клиент номер - " + numberOfClient);

                for (int i = 0; i < client.Busket.Count; i++)
                {
                    _purchaseAmount += client.Busket[i].Price;
                }
                Console.WriteLine("Сумма покупки - " + _purchaseAmount);
                client.ChekCountOfMoney(_purchaseAmount);

                if (client.IsEnoughMoney == true)
                {
                    client.BuyProdutc(_purchaseAmount);
                }
                else
                {
                    while (client.IsEnoughMoney == false)
                    {
                        client.DeleteProduct();
                        client.ChekCountOfMoney(_purchaseAmount);
                    }
                    client.BuyProdutc(_purchaseAmount);
                }
                numberOfClient++;
                _clients.Dequeue();
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ShowInfo()
        {
            Console.SetCursorPosition(45, 3);
            Console.WriteLine("Денег в супермаркете - " + _money);
        }

        public void Test()
        {
            AddProducts();
            AddClients();
            TakeOfProducts();
            foreach (var client in _clients)
            {
                for (int i = 0; i < client.Busket.Count; i++)
                {
                    Console.WriteLine($"Продукт - {client.Busket[i].Title}, его цена - {client.Busket[i].Price}");
                }
                Console.WriteLine("\n\n");    

            }

        }

        private void TakeOfProducts()
        {
            foreach (var client in _clients)
            {
                for (int i = 0; i < client.NecessaryProducts; i++)
                {
                    Random random = new Random();
                    Product productToTakeOf = _shelves[random.Next(_shelves.Count)];
                    client.PutProducToGroceryBusket(productToTakeOf);
                    System.Threading.Thread.Sleep(50);
                }
            }
        }

        private void AddClients()
        {
            for (int i = 0; i < _countOfCliensPerDay; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        private void AddProducts()
        {
            string[] titlesOfProducts = { "Морковь", "Картофель", "Лук", "Сахар", "Яйца", "Хлеб", "Свинина", "Курица", "Пельмени", "Колбаса" };
            int indexOfProduct;
            string titleOfProduct;
            int priceOfProduct;
            int[] pricesOfProduts = { 50, 70, 40, 75, 65, 30, 320, 280, 380, 450 };
            Random random = new Random();

            for (int i = 0; i < _countOfProductsPerDay; i++)
            {
                indexOfProduct = random.Next(titlesOfProducts.Length);
                titleOfProduct = titlesOfProducts[indexOfProduct];
                priceOfProduct = pricesOfProduts[indexOfProduct];
                _shelves.Add(new Product(titleOfProduct, priceOfProduct));
            }
        }
    }

    class Client
    {
        private int _money = 1500;
        private List<Product> _groceryBusket = new List<Product>();

        public IReadOnlyList<Product> Busket;


        public Product ProductToPut { get; private set; }
        public int NecessaryProducts { get; private set; } = 5;



        public bool IsEnoughMoney { get; private set; }

        public void PutProducToGroceryBusket(Product productToPut)
        {

            ProductToPut = productToPut;
            _groceryBusket.Add(productToPut);
            Busket = _groceryBusket;
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("Денег у клиента - " + _money);
        }

        public void BuyProdutc(int purchaseAmount)
        {
            _money -= purchaseAmount;
        }

        //public void PutProductsToCashier()
        //{
        //    Busket = _groceryBusket;
        //}

        public void ChekCountOfMoney(int purchaseAmount)
        {
            if (_money >= purchaseAmount)
            {
                IsEnoughMoney = true;
            }
            else
            {
                IsEnoughMoney = false;
                Console.WriteLine("Денег не достаточно. Из корзины будет удалён случайный товар(ы) пока денег не станет достаточно.");
            }

        }

        public void DeleteProduct()
        {
            Random random = new Random();
            _groceryBusket.RemoveAt(random.Next(_groceryBusket.Count));
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









