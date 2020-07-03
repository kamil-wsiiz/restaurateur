namespace Restaurateur.Models
{
    class TableModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        public long Id { get; set; }
        public string Name { get; set; }
        public string Mode { get; set; } = INSERT;

        public bool IsInsert => Mode == INSERT;
        public string TitleText => (Mode == INSERT) ? "Dodawanie stolika" : "Edycja stolika";
    }
}
