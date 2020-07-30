using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.ViewModel;

namespace TestTask.ServiceInterfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<BookType> GetBookTypes();
        List<Book> InitialBooks();
        List<BookType> InitialBookTypes();
        void Update(List<Book> currBookList);
    }
}
