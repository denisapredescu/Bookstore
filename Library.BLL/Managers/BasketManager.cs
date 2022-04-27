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
    public class BasketManager : IBasketManager
    {
        private readonly IBasketRepository _basketRepository;

        public BasketManager(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        //POST
        public async Task AddBasketToUser(string email)
        {
            var basket =  _basketRepository
              .GetAllBaskets()
              .Where(x => x.UserEmail == email && x.Sent == 0).FirstOrDefault();  //introduc un cos doar daca nu este deja inserata (exista cos daca avem deja elemente in cos)

            if (basket == null)
            {
                basket = new Basket { Sent = 0, UserEmail = email };
                await _basketRepository.Create(basket);
            }
        }

        //GET
        //determin id-urile comenzilor facute de un client (comanda: sent == 1)
        public List<int> GetBasketId(string email)
        {
            var idBasket = _basketRepository
                .GetAllBaskets()
                .Where(x => x.UserEmail == email && x.Sent == 1)
                .Select(x => x.Id)
                .ToList();

            return idBasket;
        }


        //GET
        //determin pretul total al unui cos/comanda dat prin id => este nevoie sa creaez un obiect pentru a-l putea transmite controllerului
        public PriceModel BasketPrice(int basketId)
        {
            var PretComanda = _basketRepository.GetAllBookBasketsIncludeBookAndBasket()
                .Where(x => x.Basket.Id == basketId)
                .Sum(y => y.Book.Price * y.NoCopies);

            var str = new PriceModel
            { 
                Price = $"Total price: {PretComanda}" 
            };

            return str;
        }


        //GET
        //ni se da un email => determina o lista cu toate comenzile facute in trecut de un user
        public List<string> GetStringBookBasketModel(string email)
        {   
            var ids = GetBasketId(email);    //determin toate codurile comenzilor

            var strings = new List<string>();   
             
            foreach (var id in ids)
            {
                var model = _basketRepository.GetAllBookBaskets()               //determin datele despre fiecare carte dintr-un cos
                    .Where(x => x.BasketId == id)
                    .Join(_basketRepository.GetAllBooks(), b => b.BookId, a => a.Id, (b, a) =>
                     new BookBasketModel
                     {
                         Name = a.Name,
                         Price = a.Price,
                         NoCopiesInBasket = b.NoCopies,
                         PriceOfNoCopies = a.Price * b.NoCopies
                     });

                string modelString = "";

                foreach (var str in model)    //transform toate datele in string
                {
                    modelString = modelString + $"Nume carte: {str.Name}; \nPret per bucata: {str.Price} lei;\n" +
                        $"Numar de bucati cumparate: {str.NoCopiesInBasket}; \n" +
                        $"Pret: {str.PriceOfNoCopies} lei \n" ;
                }
                modelString = modelString  + BasketPrice(id).Price + " \n";
                strings.Add(modelString);
            }

            return strings;
        }

        //fac comanda => se anunta ca este comanda facuta (Sent = 1)
        //Update
        public async Task UpdateSentBasket(string email)
        {
            var basket = _basketRepository.GetAllBaskets()
                .Where(x => x.UserEmail == email && x.Sent == 0)
                .FirstOrDefault();

            if (basket != null)
            {
                basket.Sent = 1;
                await _basketRepository.UpdateBookBasket(basket);
            }
        }
    }
}
