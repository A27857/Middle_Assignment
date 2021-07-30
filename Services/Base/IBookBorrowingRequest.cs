using System.Reflection.Metadata;
using System.Collections.Generic;
using Middle_Assignments;
using Middle_Assignments.Models.Users;

public interface IBookBorrowingRequestService
{
    bool CreateRequest(CreateBookBorrowRequestModel model);
    List<BookBorrowingRequest> GetAllRequest();
    BookBorrowingRequest GetRequestById(int id);
    bool UpdateRequest(UpdateBookBorrowRequestModel model);
    bool DeleteRequestById(int id);
}