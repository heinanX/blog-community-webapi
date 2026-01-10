namespace BlogCommunityAssign.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
