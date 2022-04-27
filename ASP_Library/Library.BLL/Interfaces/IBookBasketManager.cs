using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IBookBasketManager
    {
        Task AddToBookBasket(int bookId, string email);

        //Increase - PUT
        Task<List<BookBasketModel>> IncreaseBookBasket(BookBasketModel bookbasket);

        //Decrese -PUT
        Task<List<BookBasketModel>> DecreaseBookBasket(BookBasketModel bookbasket);

        //delete -DELETE
        Task DeleteAllBookFromBasket(string email);

        //getData - GET
        Task<List<BookBasketModel>> GetBookBasketForUser(string email);

        int GetBasketId(string email);
    }
}
