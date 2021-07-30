using System;
namespace Middle_Assignments.Models.Users
{
    public class UpdateBookBorrowRequestModel
    {
        public int UpdateBookBorrowRequestModelId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { set; get; }
        public DateTime BorrowFromDate { get; set; }
        public DateTime BorrowToDate { get; set; }
    }
}