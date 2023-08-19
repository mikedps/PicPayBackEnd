using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayBackEnd.Domain.Models;

namespace PicPayBackEnd.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date).HasDefaultValueSql("getDate()");

            builder.OwnsOne(x => x.Amount, amount =>
            {
                amount.Property(a => a.Value).HasColumnName("Amount");
            });

            builder.HasOne(x => x.Payer).WithMany(x => x.Transactions).HasForeignKey(x => x.FkPayer);
            builder.HasOne(x => x.Payee).WithMany(x => x.Transactions).HasForeignKey(x => x.FkPayee);
        }
    }
}
