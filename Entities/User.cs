using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Middle_Assignments
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { set; get; }

        public int BookBorrowingRequestId { set; get; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string  Location { get; set; }

        [Column(TypeName = "datetime")]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string PhoneNumber { get; set; }
        public string UserRole { get; set; }
    
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<BookBorrowingRequest> BookBorrowingRequests { set; get; }
    }
}