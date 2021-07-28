using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Middle_Assignments
{
    [Table("BookBorrowingRequest")]
    public class BookBorrowingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookBorrowingRequestId { set; get; }
        public int UserId { set; get; }
        public int BookId { set; get; }
        public int Quantity { set; get; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DeleteDate { get; set; }

        public User User { set; get; }

        public List<Book> Books { set; get; }
    }
}
