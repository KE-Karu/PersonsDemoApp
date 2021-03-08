using Microsoft.EntityFrameworkCore;
using PersonsDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsDemoApp.AppDbContext
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options) { }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Relations> PersonalRelationships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Persons>().ToTable(nameof(Persons)).HasOne(x => x.Name);
            builder.Entity<Relations>().ToTable(nameof(PersonalRelationships));
        }
    }
    
}
