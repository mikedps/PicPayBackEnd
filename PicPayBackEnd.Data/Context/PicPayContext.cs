using Microsoft.EntityFrameworkCore;
using PicPayBackEnd.Data.Configuration;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Context
{
    public class PicPayContext : DbContext
    {
        public PicPayContext(){ }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public PicPayContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PicPayBackEnd;Integrated Security=true")
                 .EnableSensitiveDataLogging()
                 .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>();
            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
