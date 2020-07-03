using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{
    class OrderDao : BasicDao
    {
        public static List<OrderModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<OrderModel>("SELECT * FROM Orders", new DynamicParameters());
                return output.ToList();
            };
        }

        public static OrderModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<OrderModel>("SELECT * FROM Orders WHERE Id = " + Id);
            };
        }

        public static void Insert(OrderModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Orders (TableId, ProductId, Amount, Status) VALUES (@TableId, @ProductId, @Amount, @Status)", reservation);
            };
        }

        public static void Update(OrderModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Orders SET TableId = @TableId, ProductId = @ProductId, Amount = @Amount, Status = @Status WHERE Id = @Id", reservation);
            };
        }

        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Orders WHERE Id = " + Id);
            };
        }
    }
}
