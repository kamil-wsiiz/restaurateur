using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{
    class TableDao : BasicDao
    {
        public static List<TableModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<TableModel>("SELECT * FROM Tables", new DynamicParameters());
                return output.ToList();
            };
        }

        public static TableModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<TableModel>("SELECT * FROM Tables WHERE Id = " + Id);
            };
        }

        public static void Insert(TableModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Tables (Name) VALUES(@Name)", table);
            };
        }

        public static void Update(TableModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Tables SET Name = @Name WHERE Id = @Id", table);
            };
        }

        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Tables WHERE Id = " + Id);
            };
        }
    }
}
