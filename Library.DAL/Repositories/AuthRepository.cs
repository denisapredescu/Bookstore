using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }


        public IQueryable<Role> GetRole()
        {
            return _context.Roles;
        }

        public IQueryable<User> GetUser()
        {
            return _context.Users;
        }
        public async Task CreateUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
