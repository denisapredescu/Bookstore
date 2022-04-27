using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBasketRepository
    {
        IQueryable<Basket> GetAllBaskets();
        IQueryable<BookBasket> GetAllBookBaskets();
        IQueryable<BookBasket> GetAllBookBasketsIncludeBookAndBasket();
        IQueryable<Book> GetAllBooks();
        Task Create(Basket basket);
        Task UpdateBookBasket(Basket basket);
        Task CreateBookBasket(BookBasket bookBasket);
    }
}
