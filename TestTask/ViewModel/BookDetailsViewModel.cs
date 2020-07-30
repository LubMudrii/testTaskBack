using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.ViewModel
{
    public class BookDetailsViewModel
    {
        public List<Book> Books { get; set; } 
        public List<BookType> Types { get; set; }
    }
}
