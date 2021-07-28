using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Middle_Assignments
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { set; get; }
        public int BookId { set; get; }

        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { set; get; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DeleteDate { get; set; }
        public List<Book> Books { set; get; }
    }
}