using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager; 

        public BookController(IBookManager bookManager)  
        {
            _bookManager = bookManager;
        }

        //Create, Update, Delete - trebuie facute doar de admin
        //POST
        [HttpPost("AddBook")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (string.IsNullOrEmpty(book.Name))
                return BadRequest("Name is null");
            if (book.Price == 0)
                return BadRequest("Price is 0");
            if (book.NoPages == 0)
                return BadRequest("NoPages is 0");

            var books = await _bookManager.Create(book);

            return Ok(books);
        }

        //UPDATE
        [HttpPut("UpdateBook")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            var books = await _bookManager.Update(book);
            return Ok(books);
        }

        //DELETE
        [HttpDelete("DeleteBook")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteBook([FromBody] Book book)
        {
            var books = await _bookManager.Delete(book);
            return Ok(books);
        }

        //GET
        //ia toate cartile care se gasesc in baza de date
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookManager.GetAllBooks();
            return Ok(books);
        }

        //GET
        //determina numarul cartilor impartite pe categorii
        [HttpGet("NoBooksWithCategory")]
        public async Task<IActionResult> NoBooksWithCategory()
        {
            var books = await _bookManager.GetGroupBy();
            return Ok(books);
        }

        //GET
        //determina cartile care se incadreaza intr-o categorie data
        [HttpGet("GetBooksWithCategory/{category}")]
        public async Task<IActionResult> GetBooksWithCategory([FromRoute] string category)
        {
            var books = await _bookManager.GetBooksWithGivenCategory(category);
            return Ok(books);
        }

        //GET
        //determina cartile ce sunt scrise de un autor dat
        [HttpGet("GetBooksWithAuthor/{idAuthor}")]
        public async Task<IActionResult> GetBooksWithAuthor([FromRoute] int idAuthor)
        {
            var books = await _bookManager.GetBooksWithGivenAuthor(idAuthor);
            return Ok(books);
        }

    }
}
