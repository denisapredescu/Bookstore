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
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasOne(p => p.Book)
               .WithMany(p => p.BookCategories)
               .HasForeignKey(p => p.BookId);

            builder.HasOne(p => p.Category)
                .WithMany(p => p.BookCategories)
                .HasForeignKey(p => p.CategoryId);
        }

    }
}

