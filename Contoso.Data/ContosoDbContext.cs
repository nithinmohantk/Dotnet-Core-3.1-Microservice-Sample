using Contoso.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contoso.Data
{
    public class ContosoDbContext : DbContext
    {

        public DbSet<Job> Jobs { get; set; }

        public DbSet<BatchProcessResult> Results { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("JobList");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Job>().OwnsMany(j => j.Batches);

            modelBuilder.Entity<BatchProcess>().OwnsMany(j => j.Results);

        }
    }
}
