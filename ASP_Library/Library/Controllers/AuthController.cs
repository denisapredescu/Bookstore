using Library.BLL;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register (RegisterModel model)
        {
            var result = await _authManager.Register(model);

            if (result)
                return Ok(1);   // nu accepta sa returnez in frontend un string "Registered" => intra pe eroare; Asa daca intra pe response, inseamna ca userul s-a putut inregistra 
            else
                return BadRequest("Not registered");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authManager.Login(model);

            return Ok(result);
         }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshModel model)
        {
            var result = await _authManager.Refresh(model);

            return Ok(result);
        }

    }
 }
