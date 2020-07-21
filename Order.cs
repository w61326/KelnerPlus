using System.Collections.Generic;

namespace KelnerPlus
{
    public class Order
    {
        public int Id { get; set; }
        /// <summary>
        /// Status zamówienia- 1 to W trakcie przygotowania
        /// </summary>
        public int Status { get; set; }
        public string OrderTime { get; set; }
        public string ReadyTime { get; set; }
        public double TotalPrice { get; set; }
        public string Note { get; set; }
        public List<OrderDetails> Items { get; set; }
        

        public string DisplayStatus
        {
            get
            {
                if (Status == 1)
                    return "W trakcie przygotowania";
                else
                {
                    return "Zakończono";
                }
                
            }
        }
    }
}
