using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelnerPlus
{
    public class Order
    {
        public int Id { get; set; }
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
