using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    public class Book
    {
        // Приватные поля, доступ к которым осуществляется через свойства
        private int id;
        private string title;
        private string author;
        private decimal price;

        // Конструктор для инициализации объекта
        public Book(int id, string title, string author, decimal price)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.price = price;
        }

        // Свойства для предоставления контролируемого доступа к приватным полям
        public int GetId() => id; // Чтение id
        protected void SetId(int value) // Запись id возможна только внутри класса или наследников
        {
            if (value > 0) // Пример проверки
            {
                id = value;
            }
            else
            {
                throw new ArgumentException("ID must be greater than 0.");
            }
        }

        public string GetTitle() => title; // Чтение заголовка
        protected void SetTitle(string value) // Запись заголовка только в классе и наследниках
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                title = value;
            }
            else
            {
                throw new ArgumentException("Title cannot be empty.");
            }
        }

        public string GetAuthor() => author; // Чтение автора
        protected void SetAuthor(string value) // Запись автора
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                author = value;
            }
            else
            {
                throw new ArgumentException("Author cannot be empty.");
            }
        }

        public decimal GetPrice() => price; // Чтение цены
        protected void SetPrice(decimal value) // Запись цены
        {
            if (value >= 0)
            {
                price = value;
            }
            else
            {
                throw new ArgumentException("Price must be non-negative.");
            }
        }

        // Виртуальный метод для отображения информации
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{id,-3} | {title,-30} | {author,-20} | {price} руб.");
        }

        // Виртуальный метод для отображения детальной информации
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Title: {title}\nAuthor: {author}\nPrice: {price} руб.");
        }
    }
}
