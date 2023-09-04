using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Context
{
    public class StoryTellingContext : DbContext
    {
        public StoryTellingContext(DbContextOptions<StoryTellingContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=StoryTelling; Integrated Security=True; TrustServerCertificate=True;");
            }
        }

        #region DbSet
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StoryEntity> Stories { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ChapterEntity> Chapters { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        #endregion

        public static OptionsBuild OptsBuild = new OptionsBuild();

        public class OptionsBuild
        {
            public DbContextOptionsBuilder<StoryTellingContext> OptionsBuilder { get; set; }

            public DbContextOptions<StoryTellingContext> Options { get; set; }

            public AppConfiguration Configuration { get; set; }

            public OptionsBuild()
            {
                Configuration = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<StoryTellingContext>();
                OptionsBuilder.UseSqlServer(Configuration.SqlConnectionString);
                Options = OptionsBuilder.Options;
            }
        }
    }
}
