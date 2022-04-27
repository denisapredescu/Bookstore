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
    public class BookBasketConfiguration : IEntityTypeConfiguration<BookBasket>
    {
        public void Configure(EntityTypeBuilder<BookBasket> builder)
        {
            builder.Property(p => p.NoCopies)
               .IsRequired();

            builder.HasOne(p => p.Book)
              .WithMany(p => p.BookBaskets)
              .HasForeignKey(p => p.BookId);

            builder.HasOne(p => p.Basket)
                .WithMany(p => p.BookBaskets)
                .HasForeignKey(p => p.BasketId);
        }
    }
}
