using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IAuthRepository
    {
        IQueryable<Role> GetRole();

        IQueryable<User> GetUser();
        Task CreateUserRole(UserRole userRole);
    }
}
