using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        public async Task<Category> Create(Category Category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Category?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
