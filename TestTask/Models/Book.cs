using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int CountOfPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public int BookTypeID { get; set; }
    }
}
