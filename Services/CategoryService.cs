using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Middle_Assignments
{

    public class CategoryService : ICategoryService
    {
        private LibraryContext _libraryContext;
        public CategoryService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public List<Category> CreateCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            _libraryContext.Add(category);
            _libraryContext.SaveChanges();
            return GetCategories();
        }

        public bool DeleteCategoryById(int id)
        {
            _libraryContext.Remove(GetCategoryById(id));
            _libraryContext.SaveChanges();
            return true;
        }

        public bool EditCategory(Category category)
        {
            var categoryTemp = _libraryContext.DbCategory.Find(category.CategoryId);
            categoryTemp.CategoryName = category.CategoryName;
            categoryTemp.CategoryId = category.CategoryId;
            categoryTemp.CreatedDate = category.CreatedDate;

            _libraryContext.Entry(categoryTemp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _libraryContext.SaveChanges();
            return true;
        }
        public List<Category> GetCategories()
        {
            return _libraryContext.DbCategory.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var CategoryTemp = _libraryContext.DbCategory.FirstOrDefault(b => b.CategoryId == id);
            if(CategoryTemp == null)
            {
                return null;
            }
            return CategoryTemp;
        }
    }
}