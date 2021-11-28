using DBBenchmark.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark
{
    public class RandomDBContext : DbContext
    {
        public DbSet<RandomValue> RandomValues { get; set; }
        public DbSet<DBTest> DBTests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=RandomDB; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RandomValue>()
                .HasKey(v => v.Id);
            modelBuilder.Entity<RandomValue>()
                .Property(v => v.FirstValue)
                .IsRequired();
            modelBuilder.Entity<RandomValue>()
                .Property(v => v.SecondValue)
                .IsRequired();
            modelBuilder.Entity<RandomValue>()
                .Property(v => v.ThirdValue)
                .IsRequired();
            modelBuilder.Entity<RandomValue>()
                .Property(v => v.FourthValue)
                .IsRequired();

            modelBuilder.Entity<DBTest>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<DBTest>()
                .Property(t => t.Start)
                .IsRequired();
            modelBuilder.Entity<DBTest>()
                .Property(t => t.Resolver)
                .IsRequired();
            modelBuilder.Entity<DBTest>()
                .Property(t => t.TestType)
                .IsRequired();
            modelBuilder.Entity<DBTest>()
                .Property(t => t.Timing)
                .IsRequired();
        }
    }
}
