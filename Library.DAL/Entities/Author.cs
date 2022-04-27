using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual AuthorInfo AuthorInfo { get; set; }  //cheia sa primara este fk pentru un alt tabel AuthorInfo
        //public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}

