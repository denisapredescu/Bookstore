using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IBasketManager
    {
        //Get
        PriceModel BasketPrice(int basketId);

        //Create
        Task AddBasketToUser(string email);

        //Update
        Task UpdateSentBasket(string email);

        //GET
        //Task<List<BookBasketModel>> GetAllBasketsByUser(string email);
        List<string> GetStringBookBasketModel(string email);
        List<int> GetBasketId(string email);

 

        //Delete
        //Task Delete();


    }
}
