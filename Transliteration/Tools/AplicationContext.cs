using System.Data.Entity;
using Transliteration.Models;

namespace Transliteration.Tools
{
    public class AplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Translit> Translits { get; set; }

        public AplicationContext() : base("DefaultConnection")
        { }
    }
}
