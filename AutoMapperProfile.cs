namespace tagTour_post_info
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostDto>();
            CreateMap<AddPostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
        }
    }
}
