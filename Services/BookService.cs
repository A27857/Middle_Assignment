using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Middle_Assignments
{

    public class BookService : IBookService
    {
        private LibraryContext _libraryContext;
        private IUserService _userService;
        public BookService(LibraryContext libraryContext, IUserService userService)
        {
            _libraryContext = libraryContext;
            _userService = userService;
        }
        public List<Book> CreateBook(Book book)
        {
            book.CreatedDate = DateTime.Now;
            _libraryContext.Add(book);
            _libraryContext.SaveChanges();
            return GetAllBook();
        }

        public bool DeleteBookById(int id)
        {
            _libraryContext.Remove(GetBookById(id));
            _libraryContext.SaveChanges();
            return true;
        }

        public bool EditBook(Book book)
        {
            var bookTemp = _libraryContext.DbBook.Find(book.BookId);
            bookTemp.BookName = book.BookName;
            bookTemp.Author = book.Author;
            bookTemp.PublishYear = book.PublishYear;
            bookTemp.CategoryId = book.CategoryId;
            _libraryContext.Entry(bookTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _libraryContext.SaveChanges();
            return true;
        }
        public List<Book> GetAllBook()
        {
            
            return _libraryContext.DbBook.ToList();
        }

        public Book GetBookById(int id)
        {
            var bookTemp = _libraryContext.DbBook.FirstOrDefault(b => b.BookId == id);
            if(bookTemp == null)
            {
                return null;
            }
            return bookTemp;
        }
    }
}