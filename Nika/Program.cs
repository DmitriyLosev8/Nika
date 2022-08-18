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
        {      // Задание: Хранилище книг:

            Storage storage = new Storage();
            bool isWorking = true;

            while (isWorking)
            {
                Console.SetCursorPosition(35, 0);
                Console.WriteLine("Перед вами хранилище книг");
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Чтобы добавить книгу, нажмите 1\nЧтобы удалить книгу, нажмите 2\nЧтобы посмотреть список всех книг, нажмите 3\n" +
                    "Чтобы посмотмотреть список книг по определённому параметру, нажмите 4\nЧтобы выйти, нажмите 5");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        storage.PrepareForAddBook();
                        break;
                    case "2":
                        storage.PrepareForDeleteBook();
                        break;
                    case "3":
                        storage.ShowAllBooks();
                        break;
                    case "4":
                        storage.ShowPartOfBooks();
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public void PrepareForAddBook()
        {
            int userYearOfIssue;
            int userPrice;
            Console.WriteLine("Введите название книги:");
            string userTitle = Console.ReadLine();
            Console.WriteLine("Введите автора книги:");
            string userAuthor = Console.ReadLine();
            Console.WriteLine("Введите год издания книги:");
            string userInput = Console.ReadLine();
            bool isSuccessfull = int.TryParse(userInput, out userYearOfIssue);

            if (isSuccessfull)
            {
                Console.WriteLine("Введите цену книги:");
                userInput = Console.ReadLine();
                isSuccessfull = int.TryParse(userInput, out userPrice);

                if (isSuccessfull)
                {
                    AddBook(userTitle, userAuthor, userYearOfIssue, userPrice);
                }
                else
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }

        private void AddBook(string userTitle, string userAuthor, int userYearOfIssue, int userPrice)
        {
            _books.Add(new Book(userTitle, userAuthor, userYearOfIssue, userPrice));
        }

        public void PrepareForDeleteBook()
        {
            Console.WriteLine("Введите название книги, которую хотите удалить:");
            string userTitle = Console.ReadLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Title == userTitle)
                {
                    int bookToDelete = i;
                    DeleteBook(bookToDelete);
                }
            }
        }

        private void DeleteBook(int bookToDelete)
        {
            _books.RemoveAt(bookToDelete);
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("Вот список всех книг:\n");

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"Название книги - {_books[i].Title}, её автор - {_books[i].Author}, год издания - {_books[i].YearOfIisue} и цена - {_books[i].Price}");
            }
        }

        public void ShowPartOfBooks()
        {
            Console.WriteLine("Выберите параметр по которому вы хотите отсортитировать и посмотреть книги:");
            Console.WriteLine("По названию, нажмите 1\nПо автору, нажмите 2\nПо году выпуска, нажмите 3\nПо цене, нажмите 4");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ShowTitle();
                    break;
                case "2":
                    ShowAuthor();
                    break;
                case "3":
                    ShowYearOfIssue();
                    break;
                case "4":
                    ShowPrice();
                    break;
            }
        }

        private void ShowTitle()
        {
            Console.WriteLine("Введите название книги:");
            string userTitle = Console.ReadLine();
            Console.WriteLine("Вот список книг с этим названием:\n");

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Title == userTitle)
                {
                    Console.WriteLine($"Название книги - {_books[i].Title}, её автор - {_books[i].Author}, год издания - {_books[i].YearOfIisue} и цена - {_books[i].Price}");
                }
            }
        }

        private void ShowAuthor()
        {
            Console.WriteLine("Введите автора книги:");
            string userAuthor = Console.ReadLine();
            Console.WriteLine("Вот список книг с этим автором:\n");

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Author == userAuthor)
                {
                    Console.WriteLine($"Название книги - {_books[i].Title}, её автор - {_books[i].Author}, год издания - {_books[i].YearOfIisue} и цена - {_books[i].Price}");
                }
            }
        }

        private void ShowYearOfIssue()
        {
            int userYearOfIssue;
            Console.WriteLine("Введите год издания книги:");
            string userInput = Console.ReadLine();
            bool isSuccessfull = int.TryParse(userInput, out userYearOfIssue);

            if (isSuccessfull)
            {
                Console.WriteLine("Вот список книг этого года:\n");

                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].YearOfIisue == userYearOfIssue)
                    {
                        Console.WriteLine($"Название книги - {_books[i].Title}, её автор - {_books[i].Author}, год издания - {_books[i].YearOfIisue} и цена - {_books[i].Price}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }

        private void ShowPrice()
        {
            bool isSuccessfull;
            string userInput;
            int userPrice;
            Console.WriteLine("Введите цену книги:");
            userInput = Console.ReadLine();
            isSuccessfull = int.TryParse(userInput, out userPrice);

            if (isSuccessfull)
            {
                Console.WriteLine("Вот список книг с такой ценой:\n");

                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Price == userPrice)
                    {
                        Console.WriteLine($"Название книги - {_books[i].Title}, её автор - {_books[i].Author}, год издания - {_books[i].YearOfIisue} и цена - {_books[i].Price}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }
        }
    }

    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearOfIisue { get; private set; }
        public int Price { get; private set; }

        public Book(string title, string author, int yearOfIisue, int price)
        {
            Title = title;
            Author = author;
            YearOfIisue = yearOfIisue;
            Price = price;
        }
    }
}









