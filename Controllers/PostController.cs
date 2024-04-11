namespace tagTour_post_info.Controllers;
[ApiController]
[Authorize]
[Route("post")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    [HttpGet("test")]
    public string test()
    {
        return "sdfsdf";
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetPostDto>>> CreateOne([FromBody] AddPostDto newPost)
    {
        return Ok(await _postService.CreateOne(newPost));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetPostDto>>> GetOne([FromRoute] int id)
    {
        return Ok(await _postService.GetOne(id));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> GetAll()
    {
        return Ok(await _postService.GetAll());
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ServiceResponse<GetPostDto>>> UpdateOne([FromRoute] int id, [FromBody] UpdatePostDto updatedPost)
    {
        return Ok(await _postService.UpdateOne(id, updatedPost));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> DeleteOne([FromRoute] int id)
    {
        return Ok(await _postService.DeleteOne(id));
    }
    [HttpPost("{id}")]
    public async Task<ActionResult<ServiceResponse<string>>> LikePost(int id)
    {
        return Ok(await _postService.LikePost(id));
    }
}
