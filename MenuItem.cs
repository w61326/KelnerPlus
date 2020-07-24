namespace KelnerPlus
{
    /// <summary>
    /// Klasa przedmiotów w menu
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// id przedmiotu z manu/karty dań
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nazwa przedmiotu w menu
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Opis przedmiotu/dania
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Kategoria w menu, od 1-5, 1- zupy, 2- dania główne, 3- napoje, 4- przekąski, 5- desery
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// składniki, z czego składa się danie/przedmiot
        /// </summary>
        public string Ingredients { get; set; }
        /// <summary>
        /// cena przedmiotu z menu
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// czy przedmiot jest aktywny- czy można go zamowić
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// czy przedmiot jest dla vege
        /// </summary>
        public bool IsVege { get; set; }
        /// <summary>
        /// czy zawiera laktoze
        /// </summary>
        public bool IsLactose { get; set; }
    }
}
