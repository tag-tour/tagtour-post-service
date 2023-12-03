using System.Diagnostics.CodeAnalysis;

namespace tagTour_post_info.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string[]? Media { get; set; } = ["empty"];
        public int Likes { get; set; }
        public int Author { get; set; }
        public required string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
