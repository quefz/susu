using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR5
{
    public class MenuUI
    {
        private List<Pizza> pizzas;
        private int si;
        public MenuUI(List<Pizza> pizzas, int si = 0)
        {
            this.pizzas = pizzas;
            this.si = 0;
        }
        private void ShowPizzaDetails(Pizza pizza)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                     Детали пиццы:                    ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════╝");
            Console.WriteLine($"║ Название:                 {pizza.Name}");
            Console.WriteLine($"║ Основной состав:          {pizza.Composition}");
            Console.WriteLine($"║ Дополнительные ингредиенты: {pizza.AdditIngredients}");
            Console.WriteLine($"║ Диаметр:                 {pizza.Diameter}");
            Console.WriteLine($"║ Тип теста:               {pizza.DoughType}");
            Console.WriteLine($"║ Дополнительный соус:      {pizza.AdditSauce}");
            Console.WriteLine($"║ Вес:                     {pizza.Weight}");
            Console.WriteLine("╠══════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Нажмите любую клавишу для возврата в меню...         ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ReadKey();
        }
        public void Show()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите интересующую вас пиццу с помощью клавиши enter:");
                Console.WriteLine();
                for (int i = 0; i < pizzas.Count; i++)
                {
                    if (i == si)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(pizzas[i].ToString());
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("Для выхода из программы нажмите esc.");
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (si > 0)
                    {
                        si--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (si < pizzas.Count - 1)
                    {
                        si++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    ShowPizzaDetails(pizzas[si]);
                }
            }
            while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
