using System.Reflection.Metadata;
using System.Collections.Generic;
using Middle_Assignments;

public interface ICategoryService 
{
    List<Category> GetCategories();
    Category GetCategoryById(int id);
    List<Category> CreateCategory(Category book);
    bool EditCategory(Category book);
    bool DeleteCategoryById(int id);
}