using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Middle_Assignments
{
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("category")]
        public List<Category> CreateCategory(Category category)
        {
            return _categoryService.CreateCategory(category);
        }

        [HttpGet("categories")]
        public List<Category> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet("category/{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpPut("category")]
        public bool EditCategory(Category book)
        {
            return _categoryService.EditCategory(book);
        }

        [HttpDelete("category/{id}")]
        public bool DeleteCategoryById(int id)
        {
            return _categoryService.DeleteCategoryById(id);
        }
    }
}