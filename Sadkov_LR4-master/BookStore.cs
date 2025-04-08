using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    public class BookStore
    {
        private List<Book> inventory = new List<Book>();

        public void AddBook(Book book)
        {
            inventory.Add(book);
        }

        public List<Book> GetInventory()
        {
            return inventory;
        }

        public void RemoveBook(int ID)
        {
            inventory.RemoveAll(b => b.GetId() == ID); // Используем GetId()
        }

        public void DisplayInventory()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          BOOK STORE INVENTORY");
            Console.WriteLine("========================================");
            Console.WriteLine("ID  | Title                       | Author                | Price");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var book in inventory)
            {
                book.DisplayInfo(); // Метод для отображения общей информации
            }
            Console.WriteLine("========================================");
        }
    }
}
