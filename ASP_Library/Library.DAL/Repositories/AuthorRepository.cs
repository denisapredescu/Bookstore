using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//legatura cu baza de date
namespace Library.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository //implementam interfata
    {
        private readonly AppDbContext _context; //AppDbContext are legatura cu baza de date

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Author author)  //introduc autorul doar daca nu este deja inserat
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Author> GetAll()
        {
            var author = _context.Authors;
            return author;
        }

        public IQueryable<Author> GetIncludeAuthorInfo()   //include and where
        {
            var info = GetAll().Include(x => x.AuthorInfo);

            return info;
        }

    }
}
