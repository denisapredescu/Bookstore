using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class BasketModel
    {
        public List<string> BookModels { get; set; }
        public string BasketPrice { get; set; }
    }
}
