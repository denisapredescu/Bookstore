using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL.Managers
{
    public class BookManager: IBookManager
    {
        private readonly IBookRepository _bookRepository; //prin _ spunem ca e private

        public BookManager(IBookRepository bookRepository)  
        {
            _bookRepository = bookRepository;
        }

        //Adaug o noua carte
        public async Task<List<BookModel>> Create(Book book)
        {
            await _bookRepository.Create(book);
            
            var newList = await GetAllBooks();
            return newList;
        }

        //updatez o carte
        public async Task<List<BookModel>> Update(Book book)
        {
            await _bookRepository.Update(book);
            
            var newList = await GetAllBooks();
            return newList;
        }

        //sterg o carte din baza de date
        public async Task<List<BookModel>> Delete(Book book)
        {
            await _bookRepository.Delete(book);

            var newList = await GetAllBooks();
            return newList;
        }

        //se iau doar cartile care sunt incluse 
        public async Task<List<BookModel>> GetBooksWithGivenCategory(string category)
        {
            var books = await _bookRepository
                .GetBooksWithCategory()
                .Where(x => x.Category.Name == category)
                .Select(x => new BookModel
                {
                    Id = x.Book.Id,
                    Name = x.Book.Name,
                    Price = x.Book.Price,
                    NoPages = x.Book.NoPages,
                    Year = x.Book.Year,
                    NoVolume = x.Book.NoVolume,
                    SeriesName = x.Book.SeriesName
                })
                .ToListAsync();

            return books;
        }

        //iau doar cartile scrise de autorul respectiv
        public async Task<List<BookModel>> GetBooksWithGivenAuthor(int idAuthor)
        {
            var books = await _bookRepository
                .GetBooksWithAuthor()
                .Where(x => x.Author.Id == idAuthor)
                .Select(x => new BookModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    NoPages = x.NoPages,
                    Year = x.Year,
                    NoVolume = x.NoVolume,
                    SeriesName = x.SeriesName
                })
                .ToListAsync();
            return books;
        }

        //selectez toate cartile din BD
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = await _bookRepository.GetBooks()
                .Select(x => new BookModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    NoPages = x.NoPages,
                    Year = x.Year,
                    NoVolume = x.NoVolume,
                    SeriesName = x.SeriesName
                })
                .OrderBy(x => x.Name)
                .ToListAsync();
            return books;
        }


        //determin cate carti se pot incadra in fiecare categorie
        public async Task<List<NoBooksWithCategoryModel>> GetGroupBy()
        {
            var grouped = await _bookRepository.GetBooksWithCategory()
                .GroupBy(x => x.Category.Name)
                .Select(x => new NoBooksWithCategoryModel
                {
                    Name = x.Key,
                    Num = x.Count()
                })
                .OrderByDescending(x => x.Num)
                .ToListAsync();

             return grouped;
        }
    }
}
