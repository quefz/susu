using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    public class ScienceFictionBook : Book
    {
        private string sciFiTheme = "Научная фантастика";

        public ScienceFictionBook(int id, string title, string author, decimal price)
            : base(id, title, author, price)
        {
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Theme: {sciFiTheme}");
        }

        public void UpdateTitle(string newTitle)
        {
            // Используем защищенный метод SetTitle() для изменения названия книги
            SetTitle(newTitle);
        }
    }
}
