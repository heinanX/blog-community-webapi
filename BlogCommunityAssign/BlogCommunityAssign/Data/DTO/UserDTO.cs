//using BlogCommunityAssign.Data.DTO.Comments;
//using BlogCommunityAssign.Data.Entities;

//namespace BlogCommunityAssign.Data.DTO
//{
//    public class UserDTO
//    {

//        public int Id { get; set; }
//        public string Username { get; set; } = "";
//        public string Email { get; set; } = "";
//        public bool IsAdmin { get; set; }
//        public DateTime CreatedAt { get; set; }

//        public List<CommentSummaryDTO> Comments { get; set; } = new List<CommentSummaryDTO>();

//        public UserDTO(User user)
//        {
//            Id = user.Id;
//            Username = user.Username;
//            Email = user.Email;
//            CreatedAt = user.CreatedAt;
//            IsAdmin = user.IsAdmin;
//            Comments = user.Comments.Select(c => new CommentSummaryDTO(c)).ToList();
//        }
//    }
//}
