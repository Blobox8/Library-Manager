using System;
using System.Collections.Generic;



namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            // load from storage to inventory
            inventory.fetchFromStorage("storage.txt");
            

            bool running = true;
            while (true)
            {
                Console.Write("\nLibrary Manager\n");
                Console.Write("1. Search book\n2. Add book (for admins only)\n3. Show all books\n4. Exit\n");

                int option;
                if (int.TryParse(Console.ReadLine(), out option) == false)
                {
                    Console.Write("\nInvalid choice...\n");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.Write("\nBook title or author: ");
                        string searchTerm = Console.ReadLine();
                        
                        List<Book> foundBooks = inventory.search(searchTerm);

                        
                        if (foundBooks.Count > 0)
                        {
                            foreach (Book book in foundBooks)
                            {
                                inventory.displayInfo(book);
                            }
                        }
                        Console.Write($"\n{foundBooks.Count} results found\n");
                        break;

                    case 2:

                        Console.Write("Enter PIN: ");
                        int pin = int.Parse(Console.ReadLine());
                        
                        if (LoginService.Authenticate(pin))
                        {
                            inventory.createBook();
                            Console.Write("Added to storage successfully\n");
                        }
                        else
                        {
                            Console.Write("Incorrect PIN.\n");
                        }
                        break;

                    case 3:
                        foreach (Book book in inventory.Books)
                        {
                            inventory.displayInfo(book);
                        }
                        break;
                        
                    case 4:
                        running = false;
                        break;  
                    
                }

                if (running == false) break;
                Console.Write("Press Enter to go back to main menu...");
                Console.ReadLine();
            }
        }
    }
}

