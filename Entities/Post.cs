using System.ComponentModel.DataAnnotations;

namespace tagTour_post_info.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Media { get; set; }
        public int Likes { get; set; }
        public int Author { get; set; }
        [Required]
        public string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
