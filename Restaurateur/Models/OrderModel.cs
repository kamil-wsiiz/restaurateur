using Restaurateur.DAO;
using System;
using System.Collections.Generic;

namespace Restaurateur.Models
{
    /// <summary>
    /// Model zamówień
    /// </summary>
    class OrderModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        /// <summary>
        /// Id zamówienia
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Id stolika
        /// </summary>
        public long TableId { get; set; }
        /// <summary>
        /// Id produktu
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Ilość produktu
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Status zamówienia
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Słownik statusów
        /// </summary>
        public Dictionary<int, string> Statuses
        {
            get
            {
                return new Dictionary<int, string>{
                   {0, "Nowe"},
                   {1, "Wydane"}
                };
            }
        }
        /// <summary>
        /// Czy można edytować zamówienie
        /// </summary>
        public Boolean IsMutable
        {
            get
            {
                return Status == 0;
            }
        }
        /// <summary>
        /// Obsługa comboboxa
        /// </summary>
        public TableModel Table
        {
            get
            {
                return TableDao.LoadById(TableId);
            }
            set
            {
                TableId = value.Id;
            }
        }
        /// <summary>
        /// Obsługa comboboxa
        /// </summary>
        public WarehouseModel Product
        {
            get
            {
                return WarehouseDao.LoadById(ProductId);
            }
            set
            {
                ProductId = value.Id;
            }
        }
        /// <summary>
        /// Tryb operacji
        /// </summary>
        public string Mode { get; set; } = INSERT;

        /// <summary>
        /// Pobranie nazwy stolika po jego ID
        /// </summary>
        public string TableName
        {
            get
            {
                TableModel model = TableDao.LoadById(TableId);
                return model == null ? "-" : model.Name;
            }
        }

        /// <summary>
        /// Pobranie nazwy produktu po jego ID
        /// </summary>
        public string ProductName
        {
            get
            {
                WarehouseModel model = WarehouseDao.LoadById(ProductId);
                return model == null ? "-" : model.Name;
            }
        }

        /// <summary>
        /// Pobranie nazwy statusu po jego ID
        /// </summary>
        public string StatusName
        {
            get
            {
                return Statuses[Status];
            }
        }

        /// <summary>
        /// Pobranie stolików do comboboxa
        /// </summary>
        public List<TableModel> Tables => TableDao.LoadAll();
        /// <summary>
        /// Pobranie produktów do comboboxa
        /// </summary>
        public List<WarehouseModel> Products => WarehouseDao.LoadAll();

        /// <summary>
        /// Określenie typu operacji
        /// </summary>
        public bool IsInsert => Mode == INSERT;
        /// <summary>
        /// Tytuł operacji
        /// </summary>
        public string TitleText => (Mode == INSERT) ? "Dodawanie zamówienia" : "Edycja zamówienia";
    }
}
