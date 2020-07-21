namespace KelnerPlus
{
   /// <summary>
   /// Klasa przechowująca szczegóły naszego zamówienia
   /// </summary>
   public class OrderDetails
    {
        public OrderDetails()
        {
        }

        public OrderDetails(MenuItem selected, int cbQuantity)
        {
            MenuItemId = selected.Id;
            ItemName = selected.ItemName;
            Quantity = cbQuantity;
            Price = selected.Price;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }


    }
}
