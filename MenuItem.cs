namespace KelnerPlus
{
    /// <summary>
    /// Klasa przedmiotów w menu
    /// </summary>
    public class MenuItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Kategoria w menu, od 1-5, 1- zupy, 2- dania główne, 3- napoje, 4- przekąski, 5- desery
        /// </summary>
        public int CategoryId { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsVege { get; set; }
        public bool IsLactose { get; set; }
    }
}
