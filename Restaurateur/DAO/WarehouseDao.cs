using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{
    class WarehouseDao : BasicDao
    {
        public static List<WarehouseModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<WarehouseModel>("SELECT * FROM Warehouse", new DynamicParameters());
                return output.ToList();
            };
        }

        public static WarehouseModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<WarehouseModel>("SELECT * FROM Warehouse WHERE Id = " + Id);
            };
        }

        public static void Insert(WarehouseModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Warehouse (Name, Amount) VALUES(@Name, @Amount)", table);
            };
        }

        public static void Update(WarehouseModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Warehouse SET Name = @Name, Amount = @Amount WHERE Id = @Id", table);
            };
        }

        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Warehouse WHERE Id = " + Id);
            };
        }
    }
}
