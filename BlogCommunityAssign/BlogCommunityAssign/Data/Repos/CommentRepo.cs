using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.Extensions.Hosting;

namespace BlogCommunityAssign.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDbContext _db;
        public CommentRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Create(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Comment?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveDb()
        {
            await _db.SaveChangesAsync();
        }
    }
}
