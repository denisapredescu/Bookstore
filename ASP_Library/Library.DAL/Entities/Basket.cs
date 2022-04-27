using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Basket
    {
        public int Id { get; set; }

        public virtual ICollection<BookBasket> BookBaskets { get; set; }  //un cos contine mai multe carti

        public int Sent { get; set; } //daca cosul are sent = 1 (True) inseamna ca acea comanda a fost trimisa, nu mai poate fi modificat codul respectiv
        public string UserEmail { get; set; }
    }
}