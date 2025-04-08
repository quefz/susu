using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    public class FictionBook : Book
    {
        private string genre;

        public FictionBook(int id, string title, string author, decimal price)
            : base(id, title, author, price)
        {
            genre = "Художественная литература";
        }

        public string GetGenre()
        {
            return genre;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Genre: {GetGenre()}");
        }
    }
}
