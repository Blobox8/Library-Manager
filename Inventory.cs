using System;
using System.IO;
namespace Library
{
    class Inventory
    {
        private System.Collections.Generic.List<Book> books = new List<Book>();
        public System.Collections.Generic.List<Book> Books
        {
            get { return books; }
        }


        public Book createBook() // take info from the user
        {   
            string title, author;
            double price;

            Console.Write("Book title: ");
            title = Console.ReadLine();

            Console.Write("\nBook author: ");
            author = Console.ReadLine();

            Console.Write("\nSet price: ");
            price = double.Parse(Console.ReadLine());

            Book book = new Book(title, author, price);
            addBook(book);

            // add to file
            File.AppendAllText("storage.txt", $"{book.Title}\n{book.Author}\n{book.Price}\n");

            return book;
            
        }
        public void addBook(Book book)
        {
            // add to list
            books.Add(book);
        }


        public void fetchFromStorage(string storage)
        {
            if (File.Exists(storage))
            {
                string[] lines = File.ReadAllLines(storage);
                for (int i = 0; i <= lines.Length-3; i += 3)
                {
                    string title = lines[i], author = lines[i+1];
                    double price = Convert.ToDouble(lines[i+2]);

                    addBook(new Book(title, author, price));
                }
            }
        }
        public void displayInfo(Book book)
        {
            Console.Write($"----------------\n{book.Title} \nby {book.Author}.\nPrice: {book.Price}\n\n");
        }
        public List<Book> search(string searchTerm)
        {
            List<Book> foundBooks = new List<Book>();
            for (int i = 0; i < books.Count; ++i)
            {
                // search by title and author
                if (books[i].Title.ToLower().Contains(searchTerm.ToLower()) || books[i].Author.ToLower().Contains(searchTerm.ToLower()))
                    foundBooks.Add(books[i]);
            }
            return foundBooks;
        }
    }
}