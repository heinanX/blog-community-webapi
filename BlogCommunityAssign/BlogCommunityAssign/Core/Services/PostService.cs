using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _repo;
        private readonly ICategoryRepo _categoryRepo;

        public PostService(IPostRepo repo, ICategoryRepo categoryRepo)
        {
            _repo = repo;
            _categoryRepo = categoryRepo;
        }


        public async Task<Post> CreatePost(CreatePostDTO post, int id)
        {

            Post newPost = new Post
            {
                UserId = id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (post.Categories != null)
            {
                List<Category> categories = await _categoryRepo.GetByNames(post.Categories);

                foreach (var category in categories)
                {
                    newPost.Categories.Add(category);
                }

            }

            return await _repo.Create(newPost);
        }



        public async Task<bool> DeletePost(int id, int userId, bool isAdmin)
        {
            Post? isPost = await _repo.GetById(id);
            if (isPost == null) return false;

            if (isPost.UserId != userId && !isAdmin)
            {
                throw new UnauthorizedAccessException();
            }

            await _repo.Delete(isPost);
            return true;
        }



        public async Task<List<Post>> GetAllPosts()
        {
            return await _repo.GetAll();
        }



        public async Task<Post?> GetPostById(int id)
        {
            return await _repo.GetById(id);
        }



        public async Task<Post?> UpdatePost(int id, bool isAdmin, int? userId, UpdatePostDTO dto)
        {
            Post? isPost = await _repo.GetById(id);
            if (isPost == null) return null;

            if (isPost.UserId != userId && !isAdmin)
            {
                throw new UnauthorizedAccessException();
            }

            if (dto.Title != null) isPost.Title = dto.Title;
            if (dto.Content != null) isPost.Content = dto.Content;
            isPost.UpdatedAt = DateTime.UtcNow;

            if (dto.Categories != null)
            {
                List<Category> categories = await _categoryRepo.GetByNames(dto.Categories);

                isPost.Categories.Clear();
                foreach (var category in categories)
                {
                    isPost.Categories.Add(category);
                }

            }

            return await _repo.Update(isPost);
            
        }
    }
}
