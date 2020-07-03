using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{

    /// <summary>
    /// DAO dla magazynu
    /// </summary>
    class WarehouseDao : BasicDao
    {
        /// <summary>
        /// Pobranie wszystkich produktów z magazynu
        /// </summary>
        /// <returns>
        /// Lista produktów
        /// </returns>
        public static List<WarehouseModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<WarehouseModel>("SELECT * FROM Warehouse", new DynamicParameters());
                return output.ToList();
            };
        }

        /// <summary>
        /// Pobranie produktu z magazynu po jego ID
        /// </summary>
        /// <param name="Id">
        /// Id produktu
        /// </param>
        /// <returns>
        /// Model produktu w magazynie
        /// </returns>
        public static WarehouseModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<WarehouseModel>("SELECT * FROM Warehouse WHERE Id = " + Id);
            };
        }

        /// <summary>
        /// Dodanie nowego produktu do magazynu
        /// </summary>
        /// <param name="table">
        /// Model produktu w magazynie
        /// </param>
        public static void Insert(WarehouseModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Warehouse (Name, Amount) VALUES(@Name, @Amount)", table);
            };
        }

        /// <summary>
        /// Aktalizacja produktu w magazynie
        /// </summary>
        /// <param name="table">
        /// Model produktu w magazynie
        /// </param>
        public static void Update(WarehouseModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Warehouse SET Name = @Name, Amount = @Amount WHERE Id = @Id", table);
            };
        }

        /// <summary>
        /// Usunięcie produktu z magazynu
        /// </summary>
        /// <param name="Id">
        /// Id produktu
        /// </param>
        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Warehouse WHERE Id = " + Id);
            };
        }
    }
}
