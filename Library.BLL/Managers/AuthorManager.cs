using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Managers
{
    public class AuthorManager : IAuthorManager 
    {
        private readonly IAuthorRepository _authorRepository; 

        public AuthorManager(IAuthorRepository authorRepository)  //constructorul controllerului: vom avea nevoie de un context oferit din StartUp
        {
            _authorRepository = authorRepository;
        }


        //determin daca aveam deja pus in baza de date acel autor => in caz negativ, il inserez acum
        public async Task<List<AuthorWithFirstNameAndLastNameModel>> Create(Author author)
        {
            var ok = _authorRepository
                .GetAll()
                .Where(x => x.FirstName == author.FirstName && x.LastName == author.LastName).FirstOrDefault();  //introduc autorul doar daca nu este deja inserat

            if (ok == null)
            {
                await _authorRepository.Create(author);
            }

            var authors = await GetAllWithoutAuthorInfo();  //returnez noua lista de autori pentru a putea-o folosi in frontend
            return authors;
        }


        //determina lista de scriitori, dar doar datele generale precum id ul si numele, excluzand legaturile cu celelalte tabele
        public async Task<List<AuthorWithFirstNameAndLastNameModel>> GetAllWithoutAuthorInfo()
        {
            var auth = await _authorRepository
                .GetAll()
                .Select(x => new AuthorWithFirstNameAndLastNameModel { Id=x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToListAsync(); 
            return auth;
        }

        //determin datele din tabelul AuthorInfo specifice unui scriitor dat ca parametru(id ul acestuia) -- relatie 1:1
        public async Task<AuthorInfoModel> GetJustAuthorInfo(int id)
        {
           var info = await _authorRepository
                .GetIncludeAuthorInfo()
                .Where(x => x.Id == id)
                .Select(x => new AuthorInfoModel { Nationality = x.AuthorInfo.Nationality, BirthYear = x.AuthorInfo.BirthYear, DeathYear = x.AuthorInfo.DeathYear })
                .FirstOrDefaultAsync();
            
            if (info == null)
            {
                info = new AuthorInfoModel { }; 
            }
            return info;
        }

        //returnez lista de autori updatata pt ca este folosita in frontend
        public async Task<List<AuthorWithFirstNameAndLastNameModel>> Update(Author author)
        {
            await _authorRepository.Update(author);

            var authors = await GetAllWithoutAuthorInfo();
            return authors;
        }

        //sterg un autor si returnez lista
        public async Task<List<AuthorWithFirstNameAndLastNameModel>> Delete(Author author)
        {
           await _authorRepository.Delete(author);

            var authors = await GetAllWithoutAuthorInfo();
            return authors;
        }
    }

}
