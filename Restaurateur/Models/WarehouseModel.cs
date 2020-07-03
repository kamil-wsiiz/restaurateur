namespace Restaurateur.Models
{
    class WarehouseModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        public long Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Mode { get; set; } = INSERT;

        public bool IsInsert => Mode == INSERT;
        public string TitleText => (Mode == INSERT) ? "Dodawanie produktu" : "Edycja produktu";
    }
}
