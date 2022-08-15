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
        private int _purchaseAmount = 0;
        private List<Product> _shelves = new List<Product>();
        private List<Client> _clients = new List<Client>();

        public void Work()  
        {
            AddProducts();
            AddClients();
            TakeOfProducts();
            int numberOfClient = 1;

            for (int i = 0;i < _clients.Count; i++)
            {           
                ShowInfo(numberOfClient);
                _clients[i].TakePurchaseAmount();
                _clients[i].ShowInfo();
                CalculatePurchase(_clients[i]);
                _clients[i].ChekCountOfMoney(_purchaseAmount);

                if (_clients[i].IsEnoughMoney == true)
                {
                    _clients[i].BuyProdutcs(_purchaseAmount);
                    SellProducts();
                    Console.WriteLine("Покупка пройдёт успешно");
                    _purchaseAmount = 0;
                }
                else
                {
                    int countOfProduct = 0;
                    Console.WriteLine("Денег не достаточно. Нажмите Enter, чтобы удалить случайный товар(ы) из корзины пока денег не будет достаточно.");
                    Console.ReadKey();
                   
                    while (_clients[i].IsEnoughMoney == false)
                    {
                        countOfProduct++;
                        _purchaseAmount = 0;
                        _clients[i].DeleteProduct();
                        ReturnProduct(_clients[i]);
                        CalculatePurchase(_clients[i]);
                        _clients[i].ChekCountOfMoney(_purchaseAmount);
                    }
                    _clients[i].BuyProdutcs(_purchaseAmount);
                    SellProducts();
                    Console.WriteLine("Покупка пройдёт успешно, но пришлось вытащить из корзины " + countOfProduct + " продуктов.");
                    _purchaseAmount = 0;
                }
                _clients.RemoveAt(i);
                i--;
                numberOfClient++;
                Console.ReadKey();
                Console.Clear();
            }
        }
       
        public void SellProducts()
        {
            _money += _purchaseAmount;
        }

        public void ReturnProduct(Client client)
        {
            _shelves.Add(client.ProductToReturn);
        }

        public void CalculatePurchase(Client client)
        {
            for (int i = 0; i < client.Busket.Count; i++)
            {
                _purchaseAmount += client.Busket[i].Price;
            }
            Console.WriteLine("Сумма покупки - " + _purchaseAmount);
        }
       
        public void ShowInfo(int numberOfClient)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("На кассе клиент номер - " + numberOfClient);
            Console.SetCursorPosition(45, 1);
            Console.WriteLine("Денег в супермаркете - " + _money);
        }

        private void TakeOfProducts()
        {
            foreach (var client in _clients)
            {
                for (int i = 0; i < client.NecessaryProducts; i++)
                { 
                    Random random = new Random();
                    int indexOfProduct = random.Next(_shelves.Count);
                    Product productToTakeOf = _shelves[indexOfProduct];
                    client.PutProducToGroceryBusket(productToTakeOf);
                    _shelves.RemoveAt(indexOfProduct);
                    System.Threading.Thread.Sleep(50);
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

        public IReadOnlyList<Product> Busket;

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

        public void ChekCountOfMoney(int purchaseAmount)
        {
            if (_money >= purchaseAmount)
            {
                IsEnoughMoney = true;
            }
            else
            {
                IsEnoughMoney = false; 
            }
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









