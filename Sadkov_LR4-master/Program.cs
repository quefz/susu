using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookStore store = new BookStore();
            ShoppingCart cart = new ShoppingCart();
            BookStoreUI ui = new BookStoreUI(store, cart);

            int id = 1;
            store.AddBook(new FictionBook(id++, "1984", "George Orwell", 999m));
            store.AddBook(new FictionBook(id++, "To Kill a Mockingbird", "Harper Lee", 799m));
            store.AddBook(new FictionBook(id++, "The Great Gatsby", "F. Scott Fitzgerald", 1099m));
            store.AddBook(new FictionBook(id++, "Pride and Prejudice", "Jane Austen", 849m));
            store.AddBook(new FictionBook(id++, "The Catcher in the Rye", "J.D. Salinger", 799m));
            store.AddBook(new DetectiveBook(id++, "The Hound of the Baskervilles", "Arthur Conan Doyle", 849m));
            store.AddBook(new DetectiveBook(id++, "Gone Girl", "Gillian Flynn", 999m));
            store.AddBook(new DetectiveBook(id++, "The Girl with the Dragon Tattoo", "Stieg Larsson", 1099m));
            store.AddBook(new DetectiveBook(id++, "Big Little Lies", "Liane Moriarty", 899m));
            store.AddBook(new DetectiveBook(id++, "In the Woods", "Tana French", 999m));
            store.AddBook(new ScienceFictionBook(id++, "Dune", "Frank Herbert", 1299m));
            store.AddBook(new ScienceFictionBook(id++, "Neuromancer", "William Gibson", 899m));
            store.AddBook(new ScienceFictionBook(id++, "Foundation", "Isaac Asimov", 1099m));
            store.AddBook(new ScienceFictionBook(id++, "Snow Crash", "Neal Stephenson", 999m));
            store.AddBook(new ScienceFictionBook(id++, "The Left Hand of Darkness", "Ursula K. Le Guin", 899m));

            while (true)
            {
                ui.DisplayMainMenu();
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            ui.DisplayInventory();
                            break;
                        case 2:
                            Console.Write("Enter the ID of the book to add to cart: ");
                            if (int.TryParse(Console.ReadLine(), out int bookIdToAdd))
                            {
                                ui.AddBookToCart(bookIdToAdd);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            break;
                        case 3:
                            Console.Write("Enter the ID of the book to remove from cart: ");
                            if (int.TryParse(Console.ReadLine(), out int bookIdToRemove))
                            {
                                ui.RemoveBookFromCart(bookIdToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            break;
                        case 4:
                            ui.DisplayCart();
                            break;
                        case 5:
                            Console.Write("Enter the ID of the book to view details: ");
                            if (int.TryParse(Console.ReadLine(), out int detailBookId))
                            {
                                ui.ViewBookDetails(detailBookId);
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID.");
                            }
                            break;
                        case 6:
                            ui.Checkout();
                            break;
                        case 7:
                            Console.WriteLine("Exiting the program.");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
