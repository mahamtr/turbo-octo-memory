using Ardalis.EFCore.Extensions;
using BANKEST2.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BANKEST2.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options  )
            : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
            modelBuilder.Entity<Person>().ToTable("Persons");
        }



        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}