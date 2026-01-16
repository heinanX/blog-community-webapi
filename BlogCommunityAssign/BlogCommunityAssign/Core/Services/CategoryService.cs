using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Categories;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;

        public CategoryService(ICategoryRepo repo)
        {
            _repo = repo;
        }

        public async Task<Category?> AddCategory(CreateCategoryDTO dto)
        {
            Category? newCategory = new Category{CategoryName = dto.CategoryName};

            return await _repo.Create(newCategory);

        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repo.GetAll();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<Category?> UpdateCategory(int id, UpdateCategoryDTO category)
        {
            Category? existing = await _repo.GetById(id);
            if (existing == null) return null;

            existing.CategoryName = category.CategoryName!;

            Category updated = await _repo.Update(existing);
            return updated;
            
        }
    }
}
