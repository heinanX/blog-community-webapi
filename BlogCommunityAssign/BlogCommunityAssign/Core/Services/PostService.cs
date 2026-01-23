using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Data.DTO.Posts;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;

namespace BlogCommunityAssign.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepo _repo;

        public PostService(IPostRepo repo)
        {
            _repo = repo;
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
                IEnumerable<string> categoryNames = post.Categories.Select(n => n.Trim().ToLower());

                List<Category> categories = await _repo.GetCategoriesByNames(categoryNames);

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

        public async Task<List<PostDTO>?> SearchPost(string? searchTerm, string? queryItem)
        {
            List<Post> posts = new List<Post>();
            var searchActions = new Dictionary<string, Func<string, Task<List<Post>>>>()
            {
                { "title", async term => await _repo.SearchByTitle(term) },
                { "category", async term => await _repo.SearchByCategory(term) }
            };

            if (string.IsNullOrEmpty(searchTerm)) throw new InvalidOperationException("Search field cannot be empty!");
            if (string.IsNullOrEmpty(queryItem)) throw new InvalidOperationException("Item field must provide a query item!");

            if (searchActions.ContainsKey(queryItem!))
            {
                posts = await searchActions[queryItem!](searchTerm);
                if (posts.Count == 0) return null;

                return posts
                 .Select(p => new PostDTO(p))
                 .ToList();
            } else
            {
                return null;
            }
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
                List<Category> categories = await _repo.GetCategoriesByNames(dto.Categories);

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
