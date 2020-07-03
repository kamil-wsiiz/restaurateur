namespace Restaurateur.Models
{
    /// <summary>
    /// Model dla produktów w magazynie
    /// </summary>
    class WarehouseModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        /// <summary>
        /// Id produktu
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nazwa produktu
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ilość produktu
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Typ operacji
        /// </summary>
        public string Mode { get; set; } = INSERT;

        /// <summary>
        /// Określenie typu operacji
        /// </summary>
        public bool IsInsert => Mode == INSERT;
        /// <summary>
        /// Tytuł operacji
        /// </summary>
        public string TitleText => (Mode == INSERT) ? "Dodawanie produktu" : "Edycja produktu";
    }
}
