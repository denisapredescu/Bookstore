using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBookRepository
    {
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(Book book);
        IQueryable<Book> GetBooks();
        IQueryable<Book> GetBooksWithAuthor();    /////IQueryable object (not accessing database yet)  !!!!!!!!!!
        IQueryable<BookCategory> GetBooksWithCategory();
    }
}
