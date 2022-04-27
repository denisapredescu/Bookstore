using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly AppDbContext _context;

        public BasketRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Basket> GetAllBaskets()
        {
            return _context.Baskets;
        }

        public IQueryable<BookBasket> GetAllBookBaskets()
        {
            return _context.BookBaskets;
        }
        public IQueryable<BookBasket> GetAllBookBasketsIncludeBookAndBasket()
        {
            return GetAllBookBaskets()
                .Include(x => x.Book)
                .Include(x => x.Basket);
        }
        public IQueryable<Book> GetAllBooks()
        {
            return _context.Books;
        }

        public async Task Create(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();
        }

        public async  Task UpdateBookBasket(Basket basket)
        {
            _context.Entry(basket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task CreateBookBasket(BookBasket bookBasket)
        {
            await _context.BookBaskets.AddAsync(bookBasket);
            await _context.SaveChangesAsync();
        }
    }
}
