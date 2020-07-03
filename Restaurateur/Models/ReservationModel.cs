using Restaurateur.DAO;
using System;
using System.Collections.Generic;

namespace Restaurateur.Models
{
    class ReservationModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public long TableId { get; set; }
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
        public string Mode { get; set; } = INSERT;

        public string FullName => FirstName + " " + LastName;

        public string TableName
        {
            get
            {
                TableModel model = TableDao.LoadById(TableId);
                return model == null ? "-" : model.Name;
            }
        }

        public List<TableModel> Tables => TableDao.LoadAll();

        public bool IsInsert => Mode == INSERT;
        public string TitleText => (Mode == INSERT) ? "Dodawanie rezerwacji" : "Edytowanie rezerwacji";
    }
}
