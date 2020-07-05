using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KelnerPlus
{
   public class OrderDetails
    {
        public OrderDetails(MenuItem selected, int cbQuantity)
        {
            MenuItemId = selected.id;
            ItemName = selected.itemName;
            Quantity = cbQuantity;
            Price = selected.price;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }


    }
}
