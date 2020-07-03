using System.Configuration;

namespace Restaurateur.DAO
{
    /// <summary>
    /// Klasa abstrakcyjna dostarczająca podstawowe funkcjonalności DAO
    /// </summary>
    abstract class BasicDao
    {
        /// <summary>
        /// Pobieranie ConnectionString z konfiguracji
        /// </summary>
        /// <param name="id">
        /// Identyfikator ConnectionString
        /// </param>
        /// <returns>
        /// ConnectionString
        /// </returns>
        protected static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
