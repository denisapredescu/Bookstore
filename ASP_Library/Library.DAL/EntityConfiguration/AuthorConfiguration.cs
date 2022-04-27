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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
                
            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
