using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    class BookStoreUI
    {
        private BookStore store;
        private ShoppingCart cart;

        public BookStoreUI(BookStore store, ShoppingCart cart)
        {
            this.store = store;
            this.cart = cart;
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("            BOOK STORE");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Add Book to Cart");
            Console.WriteLine("3. Remove Book from Cart");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. View Book Details");
            Console.WriteLine("6. Checkout");
            Console.WriteLine("7. Exit");
            Console.WriteLine("========================================");
            Console.Write("Please select an option: ");
        }

        public void DisplayInventory()
        {
            store.DisplayInventory();
        }

        public void DisplayCart()
        {
            cart.DisplayCart();
        }

        public void AddBookToCart(int bookId)
        {
            var book = store.GetInventory().Find(b => b.GetId() == bookId); // Используем GetId()
            if (book != null)
            {
                cart.AddBook(book);
                Console.WriteLine($"Added '{book.GetTitle()}' to the cart."); // Используем GetTitle()
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void RemoveBookFromCart(int bookId)
        {
            cart.RemoveBook(bookId);
        }

        public void ViewBookDetails(int bookId)
        {
            var book = store.GetInventory().Find(b => b.GetId() == bookId); // Используем GetId()
            if (book != null)
            {
                book.DisplayDetails(); // Метод для отображения детальной информации
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void Checkout()
        {
            cart.Checkout(store);
        }
    }
}
