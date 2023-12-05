namespace tagTour_post_info.Dtos
{
    public class UpdatePostDto
    {
        public required string Title { get; set; }
        public string[]? Media { get; set; }
        public required string[] Tags { get; set; }
    }
}
