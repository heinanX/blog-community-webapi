using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO;
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

        public async Task<CategoryDTO> AddCategory(CreateCategoryDTO dto)
        {
            Category newCategory = new Category{CategoryName = dto.CategoryName};

            Category returnedCategory = await _repo.Create(newCategory);

            CategoryDTO newDto = new CategoryDTO
            {
                Id = returnedCategory.Id,
                CategoryName = returnedCategory.CategoryName
            };
            return newDto;

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

        public Task<CategoryDTO> UpdateCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
