using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IBookManager
    {
        Task<List<BookModel>> Create(Book book);
        Task<List<BookModel>> Update(Book book);
        Task<List<BookModel>> Delete(Book book);
        Task<List<BookModel>> GetAllBooks();
        Task<List<BookModel>> GetBooksWithGivenCategory(string category);
        Task<List<BookModel>> GetBooksWithGivenAuthor(int idAuthor);
        Task<List<NoBooksWithCategoryModel>> GetGroupBy();   

    }
}
