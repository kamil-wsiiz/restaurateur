namespace Restaurateur.Models
{
    /// <summary>
    /// Model stolików
    /// </summary>
    class TableModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        /// <summary>
        /// Numer stolika
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nazwa stolika
        /// </summary>
        public string Name { get; set; }
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
        public string TitleText => (Mode == INSERT) ? "Dodawanie stolika" : "Edycja stolika";
    }
}
