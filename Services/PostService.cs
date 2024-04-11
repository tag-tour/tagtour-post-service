namespace tagTour_post_info.Services;
public class PostService : IPostService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _http;

    public PostService(IMapper mapper, DataContext context, IHttpContextAccessor http)
    {
        _mapper = mapper;
        _context = context;
        _http = http;
    }

    public async Task<ServiceResponse<GetPostDto>> CreateOne(AddPostDto newPost)
    {
        var serviceResponse = new ServiceResponse<GetPostDto>();
        try
        {
            var oId = _http.HttpContext.User.FindFirstValue("Id") ?? throw new Exception("User not found.");
            int.TryParse(oId, out int ownerId);
            var post = _mapper.Map<Post>(newPost);
            post.Author = ownerId;
            post.CreatedAt = DateTime.UtcNow;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            serviceResponse.Success = true;
            serviceResponse.Message = "Post successfully created.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> DeleteOne(int id)
    {
        var serviceResponse = new ServiceResponse<string>();

        try
        {
            var oId = _http.HttpContext.User.FindFirstValue("Id") ?? throw new Exception("User not found.");
            int.TryParse(oId, out int ownerId);
            var post = await _context.Posts.FindAsync(id) ?? throw new Exception("Post not found.");

            if (ownerId != post.Author) { throw new Exception("You are not the owner of the post."); }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            var posts = await _context.Posts.ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Post successfully deleted.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetPostDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetPostDto>>();
        try
        {
            var posts = await _context.Posts.ToListAsync() ?? throw new Exception("Posts not found.");
            serviceResponse.Data = posts.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
            serviceResponse.Success = true;
            serviceResponse.Message = "Posts received successfully.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetPostDto>> GetOne(int id)
    {
        var serviceResponse = new ServiceResponse<GetPostDto>();
        try
        {
            var post = await _context.Posts.FindAsync(id) ?? throw new Exception($"Post not found.");
            serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            serviceResponse.Success = true;
            serviceResponse.Message = "Post received successfully.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetPostDto>> UpdateOne(int id, UpdatePostDto updatedPost)
    {
        var serviceResponse = new ServiceResponse<GetPostDto>();

        try
        {
            var oId = _http.HttpContext.User.FindFirstValue("Id") ?? throw new Exception("User not found.");
            int.TryParse(oId, out int ownerId);
            var postToUpdate = await _context.Posts.FindAsync(id) ?? throw new Exception($"Post not found.");

            if (ownerId != postToUpdate.Author) { throw new Exception("You are not the owner of the post."); }

            foreach (var property in typeof(UpdatePostDto).GetProperties())
            {
                var updatedValue = property.GetValue(updatedPost);
                if (updatedValue != null && !string.IsNullOrEmpty(updatedValue.ToString()))
                {
                    var postProperty = postToUpdate.GetType().GetProperty(property.Name);
                    postProperty.SetValue(postToUpdate, updatedValue);
                }
            }
            _context.Posts.Update(postToUpdate);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetPostDto>(postToUpdate);
            serviceResponse.Success = true;
            serviceResponse.Message = "Post successfully updated.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
