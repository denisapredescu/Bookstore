using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//in interfete nu se pune private, protected, public
//se pune doar numele si ce returneaza metoda
namespace Library.DAL.Interfaces
{
    public interface ICategoryRepository  //aici spun ce metode facem
    {
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
        IQueryable<Category> GetAll();
    }
}
