using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Middle_Assignments
{
    public class BookController : ControllerBase
    {
         private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("books")]
        public List<Book> GetBooks()
        {
            return _bookService.GetAllBook();
        }

        [HttpGet("book/{id}")]
        public Book GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }

        [HttpPost("book")]
        public List<Book> CreateBook(Book book)
        {
            return _bookService.CreateBook(book);
        }
        
        [HttpPut("book/{id}")]
        public bool EditBook(Book book)
        {
            return _bookService.EditBook(book);
        }

        [HttpDelete("book/{id}")]
        public bool DeleteBookById(int id)
        {
            return _bookService.DeleteBookById(id);
        }
    }
}