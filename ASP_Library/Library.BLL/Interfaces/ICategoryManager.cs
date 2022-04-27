using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface ICategoryManager
    {
        Task<List<CategoryModel>> Create(Category category);
        Task<List<CategoryModel>> Update(Category category);
        Task<List<CategoryModel>> GetAll();   //intoarce o lista de categorii (nume + id)
        Task<List<CategoryModel>> DeleteNotUsedCategories();
    }
}
