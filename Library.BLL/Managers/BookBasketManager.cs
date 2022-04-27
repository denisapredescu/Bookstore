using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Managers
{
    public class BookBasketManager: IBookBasketManager
    {

        private readonly IBookBasketRepository _bookbasketRepository;

        public BookBasketManager(IBookBasketRepository bookbasketRepository)
        {
            _bookbasketRepository = bookbasketRepository;
        }

        //create - POST
        //se adauga noua linie doar daca nu exista deja
        //numarul de exemplare creste doar in metoda IncreaseBookBasket
        public async Task AddToBookBasket(int bookId, string email)
        {
            var bookBasket = _bookbasketRepository.GetAllBookBasketsIncludeBaskets()
                .Where(x => x.BookId == bookId && x.Basket.UserEmail == email && x.Basket.Sent == 0).FirstOrDefault();

            if (bookBasket == null)   //daca nu exista, se creeaza
            {
                var basketId = GetBasketId(email);   //determin idul cosului clientului 

                var NewBookBasket = new BookBasket
                {
                    BookId = bookId,
                    BasketId = basketId,
                    NoCopies = 1
                };

                await _bookbasketRepository.CreateBookBasket(NewBookBasket);
            }


        }

        //Increase - PUT
        public async Task<List<BookBasketModel>> IncreaseBookBasket(BookBasketModel bookbasket)
        {
            var bookBasket = _bookbasketRepository.GetAllBookBasketsIncludeBasketsAndBooks()
                .Where(x => x.Book.Id == bookbasket.BookId && x.Basket.Id == bookbasket.BasketId && x.Basket.Sent == 0).FirstOrDefault();

            bookBasket.NoCopies = bookBasket.NoCopies + 1;

            await _bookbasketRepository.UpdateBookBasket(bookBasket);

            var newBookBasket = await GetBookBasketForUser(bookBasket.Basket.UserEmail);
            return newBookBasket;
        }

        //GET  -- metoda este creata pentru a fi folosita in  metoda IncreaseBookBasket
        //determina idul cosului unui client
        public int GetBasketId(string email)
        {
            var idBasket = _bookbasketRepository
                .GetAllBaskets()
                .Where(x => x.UserEmail == email && x.Sent == 0)
                .Select(x => x.Id)
                .FirstOrDefault();

            return idBasket;
        }


        //Decrese -PUT
        //scade numarul de exemplare a unei carti din cos
        public async Task<List<BookBasketModel>> DecreaseBookBasket(BookBasketModel bookbasket)
        {
            var bookBasket = _bookbasketRepository.GetAllBookBasketsIncludeBasketsAndBooks()
                .Where(x => x.Book.Id == bookbasket.BookId && x.Basket.Id == bookbasket.BasketId && x.Basket.Sent == 0)
                .FirstOrDefault();

            if (bookBasket.NoCopies - 1 > 0)    //daca are de unde scadea, scade si updateaza raspunsul
            { 
                bookBasket.NoCopies = bookBasket.NoCopies - 1;
                await _bookbasketRepository.UpdateBookBasket(bookBasket);
            }
            else
                await _bookbasketRepository.Delete(bookBasket);   //altfel sterge acea carte din cos

            var newBookBasket = await GetBookBasketForUser(bookBasket.Basket.UserEmail);   //determin lista noua de carti din cosul curent pentru a o folosi in frontend
            return newBookBasket;

        }


        //DELETE
        //aceasta metoda sterge toate cartile din cos
        public async Task DeleteAllBookFromBasket(string email)
        {
            var basket = await _bookbasketRepository
                .GetAllBookBasketsIncludeBaskets()
                .Where(x => x.Basket.UserEmail == email && x.Basket.Sent == 0).ToListAsync();

            foreach (var comanda in basket)
            {
                await _bookbasketRepository.Delete(comanda);
            }
        }


        //getData - GET
        //determin toate cartile din cosul unui client
        public async Task<List<BookBasketModel>> GetBookBasketForUser(string email)
        {
            var bookBasket = await _bookbasketRepository.GetAllBookBasketsIncludeBasketsAndBooks()
                .Where(x => x.Basket.UserEmail == email && x.Basket.Sent == 0)
                .Select(x => new BookBasketModel
                {
                     BookId = x.BookId,
                     BasketId = x.BasketId,
                     Name = x.Book.Name,
                     Price = x.Book.Price,
                     NoCopiesInBasket = x.NoCopies,
                     PriceOfNoCopies = x.Book.Price * x.NoCopies
                })
                .ToListAsync();
            return bookBasket;
        }

    }
}
