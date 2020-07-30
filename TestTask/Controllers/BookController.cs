using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.ServiceInterfaces;
using TestTask.ViewModel;

namespace TestTask.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("/GetBooksDetails")]
        [HttpGet]
        public IActionResult GetBooks()
        {
            var result = new BookDetailsViewModel();
            result.Books = _bookService.GetBooks();
            result.Types = _bookService.GetBookTypes();
            return Ok(result);
        }

        [Route("/UpdateBooks")]
        [HttpPost]
        public IActionResult UpdateBooks([FromBody] List<Book> books)
        {
            _bookService.Update(books);
            return Ok();
        }
    }
}