using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class BookBasket
    {
     public int Id { get; set; }
    public int BookId { get; set; } // BookRef
    public int BasketId { get; set; }
    public virtual Book Book { get; set; }
    public virtual Basket Basket { get; set; }
    public int NoCopies { get; set; }  //poate sa puna in cos de mai multe ori aceeasi carte
    }
}

