using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace Restaurateur.DAO
{
    /// <summary>
    /// DAO dla rezerwacji
    /// </summary>
    class ReservationDao : BasicDao
    {
        /// <summary>
        /// Pobranie wszystkich rezerwacji z bazy danych
        /// </summary>
        /// <returns>
        /// Lista rezerwacji
        /// </returns>
        public static List<ReservationModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<ReservationModel>("SELECT * FROM Reservations", new DynamicParameters());
                return output.ToList();
            };
        }

        /// <summary>
        /// Pobranie rezerwacji z bazy danych po ID
        /// </summary>
        /// <param name="Id">
        /// Id rezerwacji
        /// </param>
        /// <returns>
        /// Model rezerwacji
        /// </returns>
        public static ReservationModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<ReservationModel>("SELECT * FROM Reservations WHERE Id = " + Id);
            };
        }

        /// <summary>
        /// Dodanie nowej rezerwacji
        /// </summary>
        /// <param name="reservation">
        /// Model rezerwacji
        /// </param>
        public static void Insert(ReservationModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Reservations (FirstName, LastName, StartDate, EndDate, TableId) VALUES(@FirstName, @LastName, @StartDate, @EndDate, @TableId)", reservation);
            };
        }

        /// <summary>
        /// Aktualizacja rezerwacji
        /// </summary>
        /// <param name="reservation">
        /// Model rezerwacji
        /// </param>
        public static void Update(ReservationModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Reservations SET FirstName = @FirstName, LastName = @LastName, StartDate = @StartDate, EndDate = @EndDate, TableId = @TableId WHERE Id = @Id", reservation);
            };
        }

        /// <summary>
        /// Usunięcie rezerwacji po jej ID
        /// </summary>
        /// <param name="Id">
        /// Id stolika
        /// </param>
        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Reservations WHERE Id = " + Id);
            };
        }
    }
}
