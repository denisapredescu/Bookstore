using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookRepository :IBookRepository
    {
        private readonly AppDbContext _context; 

        public BookRepository(AppDbContext context)  
        {
            _context = context;
        }

        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Book> GetBooks()
        {
            var books = _context.Books;
            return books;
        }

        public IQueryable<Book> GetBooksWithAuthor()
        {
            var books = _context.Books
                .Include(x => x.Author);

            return books;
        }

        public IQueryable<BookCategory> GetBooksWithCategory()
        {
            var books = _context.BookCategories
            .Include(x => x.Book)
            .Include(x => x.Category);

            return books;
        }
    }
}


            