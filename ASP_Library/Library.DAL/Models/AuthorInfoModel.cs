using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class AuthorInfoModel
    {
        public string Nationality { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
    }
}
