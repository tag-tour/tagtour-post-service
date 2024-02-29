namespace tagTour_post_info.Services
{
    public interface IPostService
    {
        Task<ServiceResponse<GetPostDto>> CreateOne(AddPostDto newPost);
        Task<ServiceResponse<GetPostDto>> GetOne(int id);
        Task<ServiceResponse<List<GetPostDto>>> GetAll();
        Task<ServiceResponse<GetPostDto>> UpdateOne(int id,UpdatePostDto updatedPost);
        Task<ServiceResponse<string>> DeleteOne(int id);
    }
}
