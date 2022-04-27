using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class AuthorInfo
    {
        public int Id { get; set; }
        public string Nationality { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; } //accesam mai usor obiectul din alt tabel
                    //folosesc include
    }
}
