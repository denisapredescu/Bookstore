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
    public class BookBasketRepository : IBookBasketRepository
    {

        private readonly AppDbContext _context;

        public BookBasketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookBasket(BookBasket bookBasket)
        {
            await _context.AddAsync(bookBasket);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(BookBasket bookBasket)
        {
            _context.BookBaskets.Remove(bookBasket);
            await _context.SaveChangesAsync();
        }

        public IQueryable<BookBasket> GetAllBookBaskets()
        {
            return _context.BookBaskets;
        }

        public IQueryable<BookBasket> GetAllBookBasketsIncludeBaskets()
        {
            var bookbaskets = GetAllBookBaskets().Include(x => x.Basket);
            return bookbaskets;
        }

        public IQueryable<BookBasket> GetAllBookBasketsIncludeBasketsAndBooks()
        {
            var bookbaskets = GetAllBookBasketsIncludeBaskets().Include(x => x.Book);
            return bookbaskets;
        }
        public IQueryable<Basket> GetAllBaskets()
        {
            return _context.Baskets;
        }

        public async Task UpdateBookBasket(BookBasket bookBasket)
        {
            _context.BookBaskets.Update(bookBasket);
            await _context.SaveChangesAsync();
        }
    }
}
