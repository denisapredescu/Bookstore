using Library.BLL.Interfaces;
using Library.DAL;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager; //prin _ spunem ca e private

        public CategoryController(ICategoryManager categoryManager)  //constructorul controllerului: vom avea nevoie de un context oferit din StartUp
        {
            _categoryManager = categoryManager;   
        }

        //Create, Update, Delete - trebuie facute doar de admin

        //POST
        [HttpPost("AddCategory")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (string.IsNullOrEmpty(category.Name))  //verificam daca se da o categorie
            {
                return BadRequest("Name is null");
            }

            var cat = await _categoryManager.Create(category);  //returnez lista noua cu categorii
            return Ok(cat);
        }

        //UPDATE
        [HttpPut("UpdateCategory")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            if (category.Id == 0)  //verificam daca se da o categorie
            {
                return BadRequest("Id is 0");
            }

            var cat = await _categoryManager.Update(category);   //returnez lista updatata
            return Ok(cat);
        }

        //DELETE
        [HttpDelete("DeleteCategories")]  //sterg categoriile care nu au nicio carte 
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteCategories()
        {
            var cat = await _categoryManager.DeleteNotUsedCategories();

            return Ok(cat);
        }

        //GET
        [HttpGet("GetCategories")]  //intoarce o lista de categorii (pentru fiecare categorie intoarce numele ei si idul)
        public async Task<IActionResult> GetCategories()
        {
            var lista_cat = await _categoryManager.GetAll();
            return Ok(lista_cat);
        }
    }
}
