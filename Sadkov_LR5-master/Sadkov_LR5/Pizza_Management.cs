using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR5
{
    public class Pizza_Management
    {
        public static List<Pizza> LoadPizzas(string filepath)
        {
            List<Pizza> pizzas = new List<Pizza>();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Trim();
                }
                Pizza pizza = new Pizza(
                    parts[1], // Название
                    parts[2], // Основной состав пиццы
                    parts[3], // Дополнительные ингридиенты
                    parts[4], // Диаметр
                    parts[5], // Тип теста
                    parts[6], // Дополнительный соус
                    parts[7] // Вес
                );
                pizzas.Add( pizza );
            }
            fs.Close();
            return pizzas;
        }
    }
}
