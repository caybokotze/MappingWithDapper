using System.Configuration;
using Microsoft.Extensions.Configuration;
using static System.Configuration.ConfigurationManager;

namespace DapperImplementation.Data
{
    public static class Helper
    {
        public static string CnnVal(string name = "DefaultConnection")
        {
            var cString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return cString;
        }
    }
}