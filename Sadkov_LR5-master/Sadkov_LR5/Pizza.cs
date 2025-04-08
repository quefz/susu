using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadkov_LR5
{
    public class Pizza
    {
        private string _name;// Название
        private string _composition;// Основной состав пиццы
        private string _addit_ingredients;// Дополнительные ингридиенты
        private string _diameter;// Диаметр
        private string _doughtype;// Тип теста
        private string _addit_sauce;// Дополнительный соус
        private string _weight;// Вес
        public Pizza(string name, string composition, string diameter, string doughtype, string addit_sauce, string addit_ingredients, string weight)
        {
            _name = name;
            _composition = composition;
            _addit_ingredients = addit_ingredients;
            _diameter = diameter;
            _doughtype = doughtype;
            _addit_sauce = addit_sauce;
            _weight = weight;
        }
        public string Name => _name;
        public string Composition => _composition;
        public string AdditIngredients => _addit_ingredients;
        public string Diameter => _diameter;
        public string DoughType => _doughtype;
        public string AdditSauce => _addit_sauce;
        public string Weight => _weight;
        public override string ToString() { 
            return $"{_name} - {_diameter}, {_weight}, {_doughtype}";
        }
    }
}
