using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository //trebuie sa implementeze interfata creata de noi: ICategoryRepository
    {
        //avem nevoie de context pentru a lucra cu baza de doate
        private readonly AppDbContext _context; //nu vrem sa se modifice aici, ci doar in interiorul bdului
        // _ pune cand e private

        //acum facem injection: dam contextul ca parametru
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task Create(Category category)
        {
            //DbSet =  imaginea bazei de date : Categories
            await _context.Categories.AddAsync(category);  //adaug categoria
            await _context.SaveChangesAsync();   //salvez modificarea in dbset
        }

        public async Task Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
             await _context.SaveChangesAsync();
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }
    }
}
