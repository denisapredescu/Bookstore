using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager (UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenHelper tokenHelper
           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
        }
        public async Task<bool> Register(RegisterModel registerModel)   //tb sa cream o entitate 
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            }; //nu pun aici parola ca sa stie care este parola si sa o cripteze

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);

                return true;
            }

            return false;
        }


        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
                return new LoginResult
                {
                    Success = false
                };  //nu exista userul in baza de date

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);  //false - ca sa ne lase sa incercam la infinit

            if(result.Succeeded)
            {
                var token = await _tokenHelper.CreateAccessToken(user);
                var refreshToken =  _tokenHelper.CreateRefreshToken();

                user.RefreshToken = refreshToken;
                await _userManager.UpdateAsync(user);

                return new LoginResult
                {
                    Success = true,
                    AccessToken = token,
                    RefreshToken = refreshToken
                };
            }
            else
                return new LoginResult
                {
                    Success = false
                };  //nu a fost succesful

        }
         

        public async Task<string> Refresh(RefreshModel refreshModel)
        {
            var principal = _tokenHelper.GetPrincipalFromExpiredToken(refreshModel.AccessToken);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByEmailAsync(username);

            if (user.RefreshToken != refreshModel.RefreshToken)
                return "Bad Refresh";

            var newJwtToken = await _tokenHelper.CreateAccessToken(user);

            return newJwtToken;
        }

    }
}
