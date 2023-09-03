using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Context
{
    public class AppConfiguration
    {
        public string? SqlConnectionString { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path);
            var root = configBuilder.Build();
            var appSettings = root.GetSection("ConnectionStrings:DefaultConnection");
            SqlConnectionString = appSettings.Value;
        }
    }
}
