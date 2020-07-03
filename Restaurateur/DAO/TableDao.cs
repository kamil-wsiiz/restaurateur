using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{
    /// <summary>
    /// DAO dla ustawień stolików
    /// </summary>
    class TableDao : BasicDao
    {
        /// <summary>
        /// Pobranie wszystkich stolików z bazy danych
        /// </summary>
        /// <returns>
        /// Lista stolików
        /// </returns>
        public static List<TableModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<TableModel>("SELECT * FROM Tables", new DynamicParameters());
                return output.ToList();
            };
        }

        /// <summary>
        /// Pobranie stolika po jego numerze
        /// </summary>
        /// <param name="Id">
        /// Numer stolika
        /// </param>
        /// <returns>
        /// Model stolika
        /// </returns>
        public static TableModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<TableModel>("SELECT * FROM Tables WHERE Id = " + Id);
            };
        }

        /// <summary>
        /// Dodanie nowego stolika
        /// </summary>
        /// <param name="table">
        /// Model stolika
        /// </param>
        public static void Insert(TableModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Tables (Name) VALUES(@Name)", table);
            };
        }

        /// <summary>
        /// Aktualizacja stolika
        /// </summary>
        /// <param name="table">
        /// Model stolika
        /// </param>
        public static void Update(TableModel table)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Tables SET Name = @Name WHERE Id = @Id", table);
            };
        }

        /// <summary>
        /// Usunięcie stolika po jego numerze
        /// </summary>
        /// <param name="Id">
        /// Numer stolika
        /// </param>
        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Tables WHERE Id = " + Id);
            };
        }
    }
}
