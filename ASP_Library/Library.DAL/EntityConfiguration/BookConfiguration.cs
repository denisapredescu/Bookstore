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
    public class BookConfiguration : IEntityTypeConfiguration<Book> //interfata pe care trebuie sa o implementata este Configure
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(200)")
                .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
            builder.Property(p => p.NoPages)
                .IsRequired();
            
            builder.Property(p => p.SeriesName)
                 .HasColumnType("nvarchar(100)")
                 .HasMaxLength(100);
        }
    }
}
