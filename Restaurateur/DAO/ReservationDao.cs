using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace Restaurateur.DAO
{
    class ReservationDao : BasicDao
    {
        public static List<ReservationModel> LoadAll()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<ReservationModel>("SELECT * FROM Reservations", new DynamicParameters());
                return output.ToList();
            };
        }

        public static ReservationModel LoadById(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                return conn.QuerySingleOrDefault<ReservationModel>("SELECT * FROM Reservations WHERE Id = " + Id);
            };
        }

        public static void Insert(ReservationModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Reservations (FirstName, LastName, StartDate, EndDate, TableId) VALUES(@FirstName, @LastName, @StartDate, @EndDate, @TableId)", reservation);
            };
        }

        public static void Update(ReservationModel reservation)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("UPDATE Reservations SET FirstName = @FirstName, LastName = @LastName, StartDate = @StartDate, EndDate = @EndDate, TableId = @TableId WHERE Id = @Id", reservation);
            };
        }

        public static void Delete(long Id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Reservations WHERE Id = " + Id);
            };
        }
    }
}
