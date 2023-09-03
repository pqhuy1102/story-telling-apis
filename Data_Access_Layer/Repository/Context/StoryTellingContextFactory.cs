using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Context
{
    public class StoryTellingContextFactory : IDesignTimeDbContextFactory<StoryTellingContext>
    {
        public StoryTellingContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new();
            var optionsBuilder = new DbContextOptionsBuilder<StoryTellingContext>();
            optionsBuilder.UseSqlServer(appConfig.SqlConnectionString);
            return new StoryTellingContext(optionsBuilder.Options);
        }
    }
}
