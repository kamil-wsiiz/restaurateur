using Restaurateur.DAO;
using System;
using System.Collections.Generic;

namespace Restaurateur.Models
{
    /// <summary>
    /// Model rezerwacji
    /// </summary>
    class ReservationModel
    {
        public static readonly string INSERT = "insert";
        public static readonly string UPDATE = "update";

        /// <summary>
        /// Id stolika
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Imię
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Nazwisko
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Data rozpoczęcia rezeracji
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data zakończenia rezerwacji
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Id stolika
        /// </summary>
        public long TableId { get; set; }
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
        /// Typ operacji
        /// </summary>
        public string Mode { get; set; } = INSERT;

        /// <summary>
        /// Wyświetlenie imienia i nazwiska
        /// </summary>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Pobranie nazwy stolika
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
        /// Lista stolików do comboboxa
        /// </summary>
        public List<TableModel> Tables => TableDao.LoadAll();

        /// <summary>
        /// Określenie typu operacji
        /// </summary>
        public bool IsInsert => Mode == INSERT;
        /// <summary>
        /// Tytuł operacji
        /// </summary>
        public string TitleText => (Mode == INSERT) ? "Dodawanie rezerwacji" : "Edytowanie rezerwacji";
    }
}
