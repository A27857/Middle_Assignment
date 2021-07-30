using Microsoft.EntityFrameworkCore;

namespace Middle_Assignments
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.UserId).ValueGeneratedOnAdd();

            modelBuilder.Entity<BookBorrowingRequest>().Property(p => p.BookBorrowingRequestId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>().Property(p => p.BookId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>().Property(p => p.CategoryId).ValueGeneratedOnAdd();
        }
        public DbSet<User> DbUser { set; get; }
        public DbSet<Book> DbBook { set; get; }
        public DbSet<Category> DbCategory { set; get; }
        public DbSet<BookBorrowingRequest> DbBookBorrowingRequest { set; get; }
    }
}