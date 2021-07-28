using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Middle_Assignments
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { set; get; }
        [Required]
        public int CategoryId { set; get; }
        public int BookBorrowingRequestId { set; get; }


        [Column(TypeName = "nvarchar(50)")]
        public string Author { set; get; }

        [Column(TypeName = "varchar(4)")]
        public string PublishYear { set; get; }

        [Column(TypeName = "nvarchar(50)")]
        public string BookName { set; get; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        public List<BookBorrowingRequest> BookBorrowingRequests { set; get; }

        public Category Category { set; get; }
    }
}