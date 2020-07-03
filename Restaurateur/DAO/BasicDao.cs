using System.Configuration;

namespace Restaurateur.DAO
{
    abstract class BasicDao
    {
        protected static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
