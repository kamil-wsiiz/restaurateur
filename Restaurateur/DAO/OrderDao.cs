using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{
    /// <summary>
    /// DAO dla zamówień
    /// </summary>
    class OrderDao : BasicDao
    {
        /// <summary>
        /// Pobranie wszystkich zamówień z bazy danych
        /// </summary>
        /// <returns>
        /// Lista zamówień
        /// </returns>
        public static List<OrderModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<OrderModel>("SELECT * FROM Orders", new DynamicParameters());
                return output.ToList();
            };
        }

        /// <summary>
        /// Pobranie zamówienia z bazy danych po ID
        /// </summary>
        /// <param name="Id">
        /// Id zamówienia
        /// </param>
        /// <returns>
        /// Model zamówienia
        /// </returns>
        public static OrderModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<OrderModel>("SELECT * FROM Orders WHERE Id = " + Id);
            };
        }

        /// <summary>
        /// Dodanie nowego zamówienia
        /// </summary>
        /// <param name="reservation">
        /// Model zamówienia
        /// </param>
        public static void Insert(OrderModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Orders (TableId, ProductId, Amount, Status) VALUES (@TableId, @ProductId, @Amount, @Status)", reservation);
            };
        }

        /// <summary>
        /// Aktualizacja zamówienia
        /// </summary>
        /// <param name="reservation">
        /// Model zamówienia
        /// </param>
        public static void Update(OrderModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Orders SET TableId = @TableId, ProductId = @ProductId, Amount = @Amount, Status = @Status WHERE Id = @Id", reservation);
            };
        }

        /// <summary>
        /// Usunięcie zamówienia
        /// </summary>
        /// <param name="Id">
        /// Id zamówienia
        /// </param>
        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Orders WHERE Id = " + Id);
            };
        }
    }
}
