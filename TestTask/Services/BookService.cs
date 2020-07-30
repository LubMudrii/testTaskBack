using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.ServiceInterfaces;
using TestTask.ViewModel;

namespace TestTask.Services
{
    public class BookService : IBookService
    {
        private IMemoryCache _memoryCache;

        public BookService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Update(List<Book> currBookList)
        {
            _memoryCache.Remove("Books");
            _memoryCache.Set("Books", currBookList,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
        }
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            if (!_memoryCache.TryGetValue("Books", out books))
            {
                if (books == null)
                {
                    books = InitialBooks();
                }
                _memoryCache.Set("Books", books,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            }
            return books;
        }
        public List<BookType> GetBookTypes()
        {
            var types = new List<BookType>();
            if (!_memoryCache.TryGetValue("Types", out types))
            {
                if (types == null)
                {
                    types = InitialBookTypes();
                }
                _memoryCache.Set("Types", types,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            }
            return types;
        }

        public List<Book> InitialBooks()
        {
            var books = new List<Book>();
            books.Add(new Book { ISBN = "5-02-013850-1", Title = "TestTitle1", Author = "TestAthor1", Language = "TestLanguage1", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 1 });
            books.Add(new Book { ISBN = "5-02-013850-2", Title = "TestTitle2", Author = "TestAthor2", Language = "TestLanguage2", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 2 });
            books.Add(new Book { ISBN = "5-02-013850-3", Title = "TestTitle3", Author = "TestAthor1", Language = "TestLanguage1", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 1 });
            books.Add(new Book { ISBN = "5-02-013850-4", Title = "TestTitle4", Author = "TestAthor2", Language = "TestLanguage2", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 2 });
            books.Add(new Book { ISBN = "5-02-013850-5", Title = "TestTitle5", Author = "TestAthor1", Language = "TestLanguage1", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 1 });
            books.Add(new Book { ISBN = "5-02-013850-6", Title = "TestTitle6", Author = "TestAthor2", Language = "TestLanguage2", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 2 });
            books.Add(new Book { ISBN = "5-02-013850-7", Title = "TestTitle7", Author = "TestAthor1", Language = "TestLanguage1", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 1 });
            books.Add(new Book { ISBN = "5-02-013850-8", Title = "TestTitle8", Author = "TestAthor2", Language = "TestLanguage2", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 2 });
            books.Add(new Book { ISBN = "5-02-013850-9", Title = "TestTitle9", Author = "TestAthor1", Language = "TestLanguage1", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 1 });
            books.Add(new Book { ISBN = "5-02-013851-0", Title = "TestTitle10", Author = "TestAthor2", Language = "TestLanguage2", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 2 });
            books.Add(new Book { ISBN = "5-02-013851-1", Title = "TestTitle11", Author = "TestAthor1", Language = "TestLanguage1", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 1 });
            books.Add(new Book { ISBN = "5-02-013851-2", Title = "TestTitle12", Author = "TestAthor2", Language = "TestLanguage2", CountOfPages = 100, PublicationDate = new DateTime(), BookTypeID = 2 });
            return books;
        }
        public List<BookType> InitialBookTypes()
        {
            var types = new List<BookType>();
            types.Add(new BookType { TypeID = 1, Name = "t" });
            types.Add(new BookType { TypeID = 2, Name = "ty" });
            types.Add(new BookType { TypeID = 3, Name = "typ" });
            types.Add(new BookType { TypeID = 4, Name = "type" });
            types.Add(new BookType { TypeID = 5, Name = "type1" });
            return types;
        }
    }
}
