using Library.BLL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBasketController : ControllerBase
    {

        private readonly IBookBasketManager _bookbasketManager; //prin _ spunem ca e private

        public BookBasketController(IBookBasketManager bookbasketManager)  
        {
            _bookbasketManager = bookbasketManager;
        }

        //POST
        //se adauga o carte (data prin id) in cosul userului  => se creeaza o noua linie un tabelul asociativ
        [HttpPost("AddBookBasket/{bookId}/{email}")]
        public async Task<IActionResult> AddBookBasket([FromRoute] int bookId, string email)
        {
            await _bookbasketManager.AddToBookBasket(bookId, email);
            return NoContent();
        }

        //UPDATE
        //creste numarul de exemplare a unui carti dintr-un cos
        [HttpPut("IncreaseNoCopies")]
        public async Task<IActionResult> IncreaseNoCopies([FromBody] BookBasketModel bookBasket)
        {
            var newBookBasket =  await _bookbasketManager.IncreaseBookBasket(bookBasket);
            return Ok(newBookBasket);
        }

        //UPDATE
        //scade numarul de exemplare a unui carti dintr-un cos
        [HttpPut("DecreaseNoCopies")]
        public async Task<IActionResult> DecreaseNoCopies([FromBody] BookBasketModel bookBasket)
        {
            var newBookBasket =  await _bookbasketManager.DecreaseBookBasket(bookBasket);
            return Ok(newBookBasket);
        }

        //GET
        //determin cartile din cosul unui client (cos adica sent == 0)
        [HttpGet("GetBookBasketForUser/{email}")]
        public async Task<List<BookBasketModel>> GetBookBasketForUser([FromRoute] string email)
        {
            var lista = await _bookbasketManager.GetBookBasketForUser(email);
            return lista;
        }

        //DELETE
        //se sterg toate cartile dintr-un cos
        [HttpDelete("DeleteAllBookBasketByEmail/{email}")]
        public async Task<IActionResult> DeleteAllBookBasketByEmail([FromRoute] string email)
        {
            await _bookbasketManager.DeleteAllBookFromBasket(email);
            return NoContent();
        }
    }
}

