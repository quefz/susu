using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    public class ShoppingCart
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(int ID)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Cart is empty. No books to remove.");
                return;
            }
            else
            {
                var bookToRemove = books.Find(b => b.GetId() == ID); // Используем GetId()
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                    Console.WriteLine($"Removed '{bookToRemove.GetTitle()}' from cart."); // Используем GetTitle()
                }
                else
                {
                    Console.WriteLine("Book not found in cart.");
                }
            }
        }

        public void DisplayCart()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          SHOPPING CART");
            Console.WriteLine("========================================");
            Console.WriteLine("ID  | Title                       | Author                | Price");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var book in books)
            {
                book.DisplayInfo(); // Метод для отображения общей информации
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Total: {CalculateTotal()} руб.");
            Console.WriteLine("========================================");
        }

        public void Checkout(BookStore store)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("              CHECKOUT");
            Console.WriteLine("========================================");
            if (books.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Please add books to your cart before checking out.");
                return;
            }
            foreach (var book in books)
            {
                store.RemoveBook(book.GetId()); // Используем GetId()
                Console.WriteLine($"Purchased: {book.GetTitle()} by {book.GetAuthor()} for {book.GetPrice()} руб."); // Используем GetTitle(), GetAuthor(), GetPrice()
            }
            Console.WriteLine($"Total Amount Due: {CalculateTotal()} руб.");
            Console.WriteLine("Thank you for your purchase!");
            Console.WriteLine("========================================");
            books.Clear();
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var book in books)
            {
                total += book.GetPrice(); // Используем GetPrice()
            }
            return total;
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
