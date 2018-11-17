using System.Data.Entity;
using Transliteration.DBAdapter.Migrations;
using Transliteration.DBModels;

namespace Transliteration.DBAdapter
{
    public class TransliterationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Translit> Translits { get; set; }

        public TransliterationDBContext() : base("NewTranslitDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TransliterationDBContext, Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Translit.TranslitEntityConfiguration());
        }
    }
}
