using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "7 pizza.txt";
            List<Pizza> pizzas = Pizza_Management.LoadPizzas(filepath);
            MenuUI menu = new MenuUI(pizzas);
            menu.Show();
        }
    }
}
