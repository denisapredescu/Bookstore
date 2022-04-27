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
     public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            //builder.HasOne(p => p.Book)
            //   .WithMany(p => p.BookAuthors)
            //   .HasForeignKey(p => p.BookId);

            //builder.HasOne(p => p.Author)
            //    .WithMany(p => p.BookAuthors)
            //    .HasForeignKey(p => p.AuthorId);
        }

    }
}
