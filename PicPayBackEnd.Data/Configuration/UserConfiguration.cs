using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(o => o.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(100);
            builder.OwnsOne(o => o.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").IsRequired().HasMaxLength(100);
                email.HasIndex(b => b.Value).IsUnique();

            });

            builder.OwnsOne(o => o.DocumentID, documentID =>
            {
                documentID.Property(e => e.Value).HasColumnName("DocumentID").IsRequired().HasMaxLength(14);
                documentID.Property(e => e.Type).HasConversion<string>().HasColumnName("DocumentType");

                documentID.HasIndex(b=>b.Value).IsUnique();
            });

            builder.OwnsOne(o => o.Balance, balance =>
            {
                balance.Property(e => e.Value).HasColumnName("Balance").HasMaxLength(14);
            });

            builder.HasMany(o => o.PayeeTransactions).WithOne(x => x.Payee);
            builder.HasMany(o => o.PayerTransactions).WithOne(x => x.Payer);

        }
    }

}
