namespace tagTour_post_info.Dtos
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string[]? Media { get; set; }
        public int Likes { get; set; }
        public int Author { get; set; }
        public required string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
