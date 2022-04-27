using Library.BLL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketManager _basketManager; //prin _ spunem ca e private

        public BasketController(IBasketManager basketManager)  //constructorul controllerului: vom avea nevoie de un context oferit din StartUp
        {
            _basketManager = basketManager;
        }

        //Nu are logica sa fac metoda pe delete pentru acest controller pentru ca nu pot teoretic sa sterg un cos, doar sa il golesc
        //Asadar se creeaza o metoda in care se sterg toate cartile dintr-un cos; aceasta metoda se gaseste in controllerul BookBasket
        //pentru ca acolo se gasesc toate idurile cartilor ce se afla intr-un cos.

        //POST
        [HttpPost("AddBasketToUser/{email}")]
        public async Task<IActionResult> AddBasketToUser([FromRoute] string email)
        {
            await _basketManager.AddBasketToUser(email);
            return NoContent();
        }

        //GET
        [HttpGet("BasketPrice/{basketId}")]
        public async Task<IActionResult> BasketPrice([FromRoute] int basketId)
        {
            if (basketId == 0)
                return BadRequest("Id is 0.");

            var str =  _basketManager.BasketPrice(basketId);

            return Ok(str);
        }

        //GET
        //determin cartile cumparate de un user: comanda cu numarul #basketId
        [HttpGet("GetStringBookBasket/{email}")]
        public async Task<List<string>> GetStringBookBasket([FromRoute] string email)
        {
            var listaString =  _basketManager.GetStringBookBasketModel(email);
            return listaString;
        }

        //Update
        //acesta metoda se apeleaza in cazul in care se face o comanda: se transforma variabila "sent" din 0 in 1
        [HttpPut("UpdateSentBasket/{email}")]
        public async Task<IActionResult> UpdateSentBasket([FromRoute] string email)
        {
            await _basketManager.UpdateSentBasket(email);
            return NoContent();
        }

        //GET
        //determin codurile comenzilor facute de un client
        [HttpGet("GetBasketId/{email}")]
        public async Task<IActionResult> GetBasketId([FromRoute] string email)
        {
            var str =  _basketManager.GetBasketId(email);
            return Ok(str);
        }


    }   
}
