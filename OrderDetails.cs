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

        /// <summary>
        /// id szczegółów zamówienia
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// id zamówienia do którego odnoszą się szczegóły zamówienia
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// id przedmiotu z karty dań
        /// </summary>
        public int MenuItemId { get; set; }
        /// <summary>
        /// krotność zamówienia danego przedmiotu
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// nazwa zamówionego przedmiotu
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// cena zamowionego przedmiotu
        /// </summary>
        public double Price { get; set; }


    }
}
