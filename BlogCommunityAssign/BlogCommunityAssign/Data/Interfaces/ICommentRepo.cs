using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetAll();


        Task<Comment?> GetById(int id);


        Task<int> Create(Comment comment);


        Task SaveDb();


        Task<bool> Delete(int id);
    }
}
