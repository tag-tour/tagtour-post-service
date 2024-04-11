namespace tagTour_post_info.Dtos;
public class UpdatePostDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[]? Media { get; set; }
    public string[]? Tags { get; set; }
}
