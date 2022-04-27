using Library.DAL.Entities;
using Library.DAL.EntityConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//o oglinda a bazei de date in proiect
namespace Library.DAL
{
    //overwrite la niste metode DbContext
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  //constructor
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //cand vom porni aplicatia i se va deschide o consola si ne va scrie el in consola ce queryuri face baza de date
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        //variabile de tip DbSet prin care spunem ce  entitati avem
       
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author> AuthorInfos { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BookBasket> BookBaskets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)   //aici trec constrangerile, configuratiile
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorInfoConfiguration());
            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            modelBuilder.ApplyConfiguration(new BookBasketConfiguration());

        }
    }
}
