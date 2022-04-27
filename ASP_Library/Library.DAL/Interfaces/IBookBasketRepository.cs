using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBookBasketRepository
    {
        IQueryable<BookBasket> GetAllBookBaskets();
        IQueryable<BookBasket> GetAllBookBasketsIncludeBaskets();
        IQueryable<BookBasket> GetAllBookBasketsIncludeBasketsAndBooks();
        IQueryable<Basket> GetAllBaskets();
        Task CreateBookBasket(BookBasket bookBasket);
        Task UpdateBookBasket(BookBasket bookBasket);
        Task Delete(BookBasket bookBasket);
    }
}
