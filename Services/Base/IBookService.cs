using System.Reflection.Metadata;
using System.Collections.Generic;
using Middle_Assignments;

public interface IBookService 
{
    List<Book> GetAllBook();
    Book GetBookById(int id);
    List<Book> CreateBook(Book book);
    bool EditBook(Book book);
    bool DeleteBookById(int id);
}