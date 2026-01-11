using BlogCommunityAssign.Data.Entities;

namespace BlogCommunityAssign.Data.Interfaces
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetAll();


        Task<Comment?> GetById(int id);


        Task<Comment> Create(Comment comment);


        Task<Comment> Update(int id);


        Task<bool> Delete(int id);
    }
}
