using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR4
{
    public class DetectiveBook : Book
    {
        private string detectiveType;

        public DetectiveBook(int id, string title, string author, decimal price)
            : base(id, title, author, price)
        {
            detectiveType = "Детектив";
        }

        public string GetDetectiveType()
        {
            return detectiveType;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Type: {GetDetectiveType()}");
        }
    }
}
