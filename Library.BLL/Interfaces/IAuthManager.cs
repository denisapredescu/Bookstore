using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IAuthManager
    {
        //trebuie sa facem partea de inregistrare si partea de login
        Task<bool> Register(RegisterModel registerModel);  //returneaza bool prin care ne zice daca a mers inregistrarea
        Task<LoginResult> Login(LoginModel loginModel);  //ret. AccessToken
        Task<string> Refresh(RefreshModel refreshModel);
        //int GetRoleIdByName(string name);
        //int GetUserId(RegisterModel registerModel);
        //Task UpdateUserRole(RegisterModel register, string role);
    }
}
