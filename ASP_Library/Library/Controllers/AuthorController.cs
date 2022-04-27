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

//cere functii din interfata: functiile sunt implementate in repositori
namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager; 

        public AuthorController(IAuthorManager authorManager)  //constructorul controllerului: vom avea nevoie de un context oferit din StartUp
        {
            _authorManager = authorManager;
        }
        //Create, Update, Delete - trebuie facute doar de admin

        //POST
        //adaugarea unui scriitor
        [HttpPost("AddAuthor")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)//async = se va deschide un thread separat si se va rula acel proces pe acel thread
        {
            if (string.IsNullOrEmpty(author.LastName))  //verificam daca se da o categorie
            {
                return BadRequest("Name is null");
            }

            var newAuthors = await _authorManager.Create(author);
            return Ok(newAuthors);
        }


        //UPDATE
        [HttpPut("UpdateAuthor")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author author)
        {
            var newAuthors = await _authorManager.Update(author);
            return Ok(newAuthors);
        }

        //DELETE
        [HttpDelete("DeleteAuthor")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAuthor([FromBody] Author author)   //se sterg automat si datele din AuthorInfo
        {
            var newAuthors = await _authorManager.Delete(author);
            return Ok(newAuthors);
        }

        //GET
        //determina selectarea tuturor scriitorilor
        [HttpGet("GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorManager.GetAllWithoutAuthorInfo();
            return Ok(authors);
        }


        //GET
        //iau doar informatiile din AuthorInfo
        [HttpGet("GetAuthorInfo/{id}")]
        public async Task<IActionResult> GetAuthorInfo([FromRoute] int id)
        {
            var authorInfo = await _authorManager.GetJustAuthorInfo(id);
            return Ok(authorInfo);
        }   
    }
}
