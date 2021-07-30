using System;
namespace Middle_Assignments.Models.Users
{
    public class CreateBookBorrowRequestModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { set; get; }
        public DateTime BorrowFromDate { get; set; }
        public DateTime BorrowToDate { get; set; }
    }
}