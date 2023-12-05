namespace tagTour_post_info.Dtos
{
    public class AddPostDto
    {
        public required string Title { get; set; }
        public string[]? Media { get; set; } = ["empty"];
        public required string[] Tags { get; set; }
    }
}
