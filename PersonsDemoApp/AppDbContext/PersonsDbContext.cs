using Microsoft.EntityFrameworkCore;
using PersonsDemoApp.Models;

namespace PersonsDemoApp.AppDbContext
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options) { }

        public DbSet<Persons> Persons { get; set; }
        public DbSet<PersonalRelations> PersonalRelationships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Persons>().ToTable(nameof(Persons)).HasIndex(a => a.NatIdNr).IsUnique();
            builder.Entity<PersonalRelations>().ToTable(nameof(PersonalRelationships));
        }
    }
    
}
