using Restaurateur.DAO;
using System;
using System.Collections.Generic;

namespace Restaurateur.Models
{
    class OrderModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        public long Id { get; set; }
        public long TableId { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
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
        public string Mode { get; set; } = INSERT;

        public string TableName
        {
            get
            {
                TableModel model = TableDao.LoadById(TableId);
                return model == null ? "-" : model.Name;
            }
        }

        public string ProductName
        {
            get
            {
                WarehouseModel model = WarehouseDao.LoadById(ProductId);
                return model == null ? "-" : model.Name;
            }
        }

        public string StatusName
        {
            get
            {
                return Statuses[Status];
            }
        }

        public List<TableModel> Tables => TableDao.LoadAll();
        public List<WarehouseModel> Products => WarehouseDao.LoadAll();

        public bool IsInsert => Mode == INSERT;
        public string TitleText => (Mode == INSERT) ? "Dodawanie zamówienia" : "Edycja zamówienia";
    }
}
