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
    public class AuthorInfoConfiguration : IEntityTypeConfiguration<AuthorInfo>
    {
        public void Configure(EntityTypeBuilder<AuthorInfo> builder)
        {
            builder.Property(p => p.Nationality)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);
        }
    }
}
