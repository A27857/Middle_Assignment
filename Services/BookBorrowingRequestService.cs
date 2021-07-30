using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Middle_Assignments.Models.Users;

namespace Middle_Assignments
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private LibraryContext _libraryContext;
        private IUserService _userService;
        public BookBorrowingRequestService(LibraryContext libraryContext, IUserService userService)
        {
            _libraryContext = libraryContext;
            _userService = userService;
        }
        public bool CreateRequest(CreateBookBorrowRequestModel model)
        {
            var user = _userService.GetUserById(model.UserId);
            var countRequest = _libraryContext.DbBookBorrowingRequest.Count(x => x.UserId == user.UserId && x.CreatedDate.Month == DateTime.Now.Month);
            var totalBookInMonth = _libraryContext.DbBookBorrowingRequest.Where(x => x.UserId == user.UserId && x.CreatedDate.Month == DateTime.Now.Month).Sum(x => x.Quantity);
            if (countRequest > 3 || totalBookInMonth > 5)
            {
                return false;
            }
            var request = new BookBorrowingRequest() {
                BookId = model.BookId,
                BorrowFromDate = model.BorrowFromDate,
                BorrowToDate = model.BorrowFromDate,
                UserId = model.UserId,
                Quantity = model.Quantity,
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                DeleteDate = DateTime.UtcNow
            };
            _libraryContext.DbBookBorrowingRequest.Add(request);
            _libraryContext.SaveChanges();
            return true;
        }

        public bool DeleteRequestById(int id)
        {
            var bookBorrowRequet = _libraryContext.DbBookBorrowingRequest.Find(id);
            _libraryContext.Remove(bookBorrowRequet);
            _libraryContext.SaveChanges();
            return true;
        }

        public List<BookBorrowingRequest> GetAllRequest()
        {
            return _libraryContext.DbBookBorrowingRequest.ToList();
        }

        public BookBorrowingRequest GetRequestById(int id)
        {
            var bookBorrowRequet = _libraryContext.DbBookBorrowingRequest.Find(id);
            return bookBorrowRequet;
        }

        public bool UpdateRequest(UpdateBookBorrowRequestModel model)
        {
            var bookBorrowRequet = _libraryContext.DbBookBorrowingRequest.FirstOrDefault(b => b.BookBorrowingRequestId == model.UpdateBookBorrowRequestModelId);
            if (bookBorrowRequet == null)
                return false;
            bookBorrowRequet.BookId = model.BookId;
            bookBorrowRequet.Quantity = model.Quantity;
            bookBorrowRequet.BorrowFromDate = model.BorrowFromDate;
            bookBorrowRequet.BorrowToDate = model.BorrowToDate;
            bookBorrowRequet.UpdateDate = DateTime.UtcNow;
            _libraryContext.Entry(bookBorrowRequet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _libraryContext.SaveChanges();
            return true;
        }
    }
}