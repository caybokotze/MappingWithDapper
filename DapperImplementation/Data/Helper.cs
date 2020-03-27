using Microsoft.Extensions.Configuration;

namespace DapperImplementation.Data
{
    public static class Helper
    {
        public static string CnnVal(IConfiguration configuration, string name)
        {
            return configuration.GetConnectionString(name);
        }
    }
}