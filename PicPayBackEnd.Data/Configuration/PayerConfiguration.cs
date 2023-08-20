using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPayBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Configuration;
public class PayerConfiguration : IEntityTypeConfiguration<Payer>
{
    public void Configure(EntityTypeBuilder<Payer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.User, user =>
        {
            user.Property(o => o.Name).HasColumnName("Name").HasMaxLength(100);
            user.Property(o => o.Surename).HasColumnName("Surename").HasMaxLength(100);
            user.OwnsOne(o => o.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").HasMaxLength(100);
            });

            user.OwnsOne(o => o.Cpf, cpf =>
            {
                cpf.Property(e => e.Value).HasColumnName("Cpf").HasMaxLength(14);
            });
        });

        builder.OwnsOne(o => o.Balance, balance =>
        {
            balance.Property(e => e.Value).HasColumnName("Balance").HasMaxLength(14);
        });

        builder.HasMany(o => o.Transactions).WithOne(x => x.Payer);
    }


}