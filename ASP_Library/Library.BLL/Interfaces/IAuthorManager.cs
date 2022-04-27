using Library.DAL.Entities;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IAuthorManager
    {
        Task<List<AuthorWithFirstNameAndLastNameModel>> Create(Author author);
        Task<List<AuthorWithFirstNameAndLastNameModel>> Update(Author author);
        Task<List<AuthorWithFirstNameAndLastNameModel>> GetAllWithoutAuthorInfo();
        Task<AuthorInfoModel> GetJustAuthorInfo(int id);
        Task<List<AuthorWithFirstNameAndLastNameModel>> Delete(Author author);
        
    }
}
