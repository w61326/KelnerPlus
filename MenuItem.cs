using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelnerPlus
{
    public class MenuItem
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public string ingredients { get; set; }
        public double price { get; set; }
        public bool isActive { get; set; }
        public bool isVege { get; set; }
        public bool isLactose { get; set; }

        public MenuItem(int id, string itemName, string description, int categoryId, string ingredients, double price, bool isActive, bool isVege, bool isLactose)
        {
            this.id = id;
            this.itemName = itemName;
            this.description = description;
            this.categoryId = categoryId;
            this.ingredients = ingredients;
            this.price = price;
            this.isActive = isActive;
            this.isVege = isVege;
            this.isLactose = isLactose; 
        }

        public MenuItem()
        {
        }
    }
}
