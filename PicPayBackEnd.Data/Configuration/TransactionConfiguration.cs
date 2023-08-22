using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayBackEnd.Domain.Entities;

namespace PicPayBackEnd.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date).HasDefaultValueSql("getDate()");

            builder.Property(x => x.FkPayer).IsRequired();

            builder.Property(x => x.FkPayee).IsRequired();

            builder.OwnsOne(x => x.Amount, amount =>
            {
                amount.Property(a => a.Value).IsRequired().HasColumnName("Amount");
            });

            builder
            .HasOne(x => x.Payer)
            .WithMany(x => x.PayerTransactions)
            .HasForeignKey(x => x.FkPayer)
            .OnDelete(DeleteBehavior.NoAction);

            builder
            .HasOne(x => x.Payee)
            .WithMany(x => x.PayeeTransactions)
            .HasForeignKey(x => x.FkPayee)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

