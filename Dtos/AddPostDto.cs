using System.ComponentModel.DataAnnotations;

namespace tagTour_post_info.Dtos;
public class AddPostDto
{
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; } = "";
    public string[]? Media { get; set; }
    [Required]
    public string[] Tags { get; set; }
}