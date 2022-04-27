using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.EntityConfiguration
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(p => p.Sent)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(p => p.UserEmail)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
