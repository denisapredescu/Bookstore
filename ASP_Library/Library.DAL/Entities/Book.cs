using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }   //BookId = pk; stie singur sa faca asta, nu trebuie sa-l pun la constrangeri (se creeaza singur index pentru el)
        public string Name { get; set; }
        public float Price { get; set; }
        public int NoPages { get; set; }
        public int Year { get; set; }
        public int NoVolume { get; set; }
        public string SeriesName { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public int? AuthorId {get; set;}
        public virtual Author Author { get; set; }
        public virtual ICollection<BookBasket> BookBaskets { get; set; }

    }
}
