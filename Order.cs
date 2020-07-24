using System.Collections.Generic;

namespace KelnerPlus
{
    /// <summary>
    /// Klasa odpowiadająca zamówieniu
    /// </summary>
    public class Order
    {
        /// <summary>
        /// id zamówienia
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Status zamówienia, wartosc 1 oznacza rozpoczecia zamowienia
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Data oraz godzina zlozenia zamowienia (rozpoczecia)
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// data oraz godzina zrealizowania zamowienia
        /// </summary>
        public string ReadyTime { get; set; }
        /// <summary>
        /// całkowita kwota zamowienia
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// notatka do zamowienia, wprowadzona przez kelnera
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// lista przedmiotów wchodzących w skład zamówienia
        /// </summary>
        public List<OrderDetails> Items { get; set; }
        

        /// <summary>
        /// Pole klasy zwracające status zamowienia jako zrozumiany tekst
        /// </summary>
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
