namespace tagTour_post_info.Controllers
{
    [ApiController]
    [Route("api/post")]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<ActionResult<GetPostDto>> CreateOne([FromBody] AddPostDto newPost)
        {
            return Ok(await _postService.CreateOne(newPost));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDto>> GetOne([FromRoute] int id)
        {
            return Ok(await _postService.GetOne(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPostDto>>> GetAll()
        {
            return Ok(await _postService.GetAll());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetPostDto>> UpdateOne([FromRoute] int id, [FromBody] UpdatePostDto updatedPost)
        {
            return Ok(await _postService.UpdateOne(id, updatedPost));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetPostDto>>> DeleteOne([FromRoute] int id)
        {
            return Ok(await _postService.DeleteOne(id));
        }
    }
}