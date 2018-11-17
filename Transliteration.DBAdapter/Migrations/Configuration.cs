using System.Data.Entity.Migrations;

namespace Transliteration.DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TransliterationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TransliterationDBContext";
        }

        protected override void Seed(TransliterationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
