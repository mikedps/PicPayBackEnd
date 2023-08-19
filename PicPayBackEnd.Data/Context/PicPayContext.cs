using Microsoft.EntityFrameworkCore;
using PicPayBackEnd.Data.Configuration;
using PicPayBackEnd.Domain.Models;
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
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Payer> Payers { get; set; }
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
            modelBuilder.ApplyConfiguration(new PayeeConfiguration());
            modelBuilder.ApplyConfiguration(new PayerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
