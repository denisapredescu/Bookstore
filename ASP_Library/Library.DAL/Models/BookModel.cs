using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class BookModel
    {
        public int Id { get; set; }   //BookId = pk; stie singur sa faca asta, nu trebuie sa-l pun la constrangeri (se creeaza singur index pentru el)
        public string Name { get; set; }
        public float Price { get; set; }
        public int NoPages { get; set; }
        public int Year { get; set; }
        public int NoVolume { get; set; }
        public string SeriesName { get; set; }
    }
}
