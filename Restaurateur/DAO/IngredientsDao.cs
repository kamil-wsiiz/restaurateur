using Dapper;
using System.Data.SQLite;
using Restaurateur.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Restaurateur.DAO
{
    class IngredientsDao : BasicDao
    {
        public static List<IngredientModel> LoadIngredients()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<IngredientModel>("SELECT * FROM Ingredients", new DynamicParameters());
                return output.ToList();
            };
        }

    }
}
