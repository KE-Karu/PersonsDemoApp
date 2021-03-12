using Microsoft.EntityFrameworkCore;
using PersonsDemoApp.Models;

namespace PersonsDemoApp.AppDbContext
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonalRelation> PersonalRelationships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Person>().ToTable(nameof(Persons)).HasIndex(a => a.NatIdNr).IsUnique();
            builder.Entity<PersonalRelation>().ToTable(nameof(PersonalRelationships));
        }
    }
    
}
