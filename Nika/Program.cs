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
            //Задание: Супермаркет:    

            Supermarket supermarket = new Supermarket();
            supermarket.Work();
        }
    }

    class Supermarket
    {
        private int _countOfCliensPerDay = 15;
        private int _countOfProductsPerDay = 500;
        private int _money = 5000;
        private List<Product> _shelves = new List<Product>();
        private List<Client> _clients = new List<Client>();

        public void Work()
        {
            AddProducts();
            AddClients();
            PrepareProductsForSale();
            int numberOfClient = 1;
            int purchaseAmount = 0;

            while (_clients.Count > 0)
            {
                Client clientToServe = _clients[0]; 
                ShowInfo(numberOfClient);
                clientToServe.TakePurchaseAmount();
                clientToServe.ShowInfo();
                purchaseAmount = CalculatePurchase(clientToServe, purchaseAmount);
                clientToServe.CompareMoneyWithPurchaseAmount(purchaseAmount);

                if (clientToServe.IsEnoughMoney)
                {
                    clientToServe.BuyProdutcs(purchaseAmount);
                    SellProducts(purchaseAmount);
                    Console.WriteLine("Покупка пройдёт успешно");
                    purchaseAmount = 0;
                }
                else
                {
                    int countOfProduct = 0;
                    Console.WriteLine("Денег не достаточно. Нажмите Enter, чтобы удалить случайный товар(ы) из корзины пока денег не будет достаточно.");
                    Console.ReadKey();

                    while (clientToServe.IsEnoughMoney == false)
                    {
                        countOfProduct++;
                        purchaseAmount = 0;
                        clientToServe.DeleteProduct();
                        ReturnProduct(clientToServe);  
                        purchaseAmount = CalculatePurchase(clientToServe, purchaseAmount);
                        clientToServe.CompareMoneyWithPurchaseAmount(purchaseAmount);
                    }

                    clientToServe.BuyProdutcs(purchaseAmount);
                    SellProducts(purchaseAmount);
                    Console.WriteLine("Покупка пройдёт успешно, но пришлось вытащить из корзины " + countOfProduct + " продуктов.");
                    purchaseAmount = 0;
                }

                _clients.RemoveAt(0);
                numberOfClient++;
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SellProducts(int purchaseAmount)
        {
            _money += purchaseAmount;
        }

        private void ReturnProduct(Client client)
        {
            _shelves.Add(client.ProductToReturn);
        }

        private int CalculatePurchase(Client client, int purchaseAmount)
        {
            for (int i = 0; i < client.Busket.Count; i++)
            {
                purchaseAmount += client.Busket[i].Price;
            }

            Console.WriteLine("Сумма покупки - " + purchaseAmount);
            return purchaseAmount;
        }

        private void ShowInfo(int numberOfClient)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("На кассе клиент номер - " + numberOfClient);
            Console.SetCursorPosition(45, 1);
            Console.WriteLine("Денег в супермаркете - " + _money);
        }

        private void PrepareProductsForSale()
        {
            foreach (var client in _clients)
            {
                for (int i = 0; i < client.NecessaryProducts; i++)
                {
                    if (client.NecessaryProducts <= _shelves.Count)
                    {
                        Random random = new Random();
                        int indexOfProduct = random.Next(_shelves.Count);
                        Product productToTakeOf = _shelves[indexOfProduct];
                        client.PutProducToGroceryBusket(productToTakeOf);
                        _shelves.RemoveAt(indexOfProduct);
                        System.Threading.Thread.Sleep(50);
                    }
                    else
                    {
                        Console.WriteLine("Продукты закончились, приходите завтра");
                    }   
                }
            }
        }

        private void AddClients()
        {
            for (int i = 0; i < _countOfCliensPerDay; i++)
            {
                _clients.Add(new Client());
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
        private int _money;
        private List<Product> _groceryBusket = new List<Product>();

        public IReadOnlyList<Product> Busket { get; private set; }
        public Product ProductToPut { get; private set; }
        public Product ProductToReturn { get; private set; }
        public int NecessaryProducts { get; private set; } = 8;
        public bool IsEnoughMoney { get; private set; }

        public Client()
        {
            int minimalNumberOfMoney = 1000;
            int maximumNumberOfMoney = 2000;
            Random random = new Random();
            _money = random.Next(minimalNumberOfMoney, maximumNumberOfMoney);
        }

        public void PutProducToGroceryBusket(Product productToPut)
        {
            ProductToPut = productToPut;
            _groceryBusket.Add(productToPut);
        }

        public void TakePurchaseAmount()
        {
            Busket = _groceryBusket;
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("Денег у клиента - " + _money);
        }

        public void BuyProdutcs(int purchaseAmount)
        {
            _money -= purchaseAmount;
        }

        public void CompareMoneyWithPurchaseAmount(int purchaseAmount)
        {
            IsEnoughMoney = _money >= purchaseAmount;
        }

        public void DeleteProduct()
        {
            Random random = new Random();
            int indexOfProduct = random.Next(_groceryBusket.Count);
            ProductToReturn = _groceryBusket[indexOfProduct];
            _groceryBusket.RemoveAt(indexOfProduct);
            TakePurchaseAmount();
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









