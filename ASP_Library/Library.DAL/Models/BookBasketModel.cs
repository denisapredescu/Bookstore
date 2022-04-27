using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class BookBasketModel
    {
        public int BookId { get; set; } 
        public int BasketId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NoCopiesInBasket { get; set; }
        public float PriceOfNoCopies { get; set; }
    }
}
