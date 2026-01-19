using BlogCommunityAssign.Data.DTO.Comments;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            await SaveDb();
            return comment.Id;
        }

        public async Task Delete(Comment comment)
        {
            _db.Comments.Remove(comment);
            await SaveDb();
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _db.Comments
                    .Include(c => c.User)
                    .Include(c => c.Post)
                    .ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _db.Comments
                .Include(c => c.User)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveDb()
        {
            await _db.SaveChangesAsync();
        }
    }
}
