using AutoMapper;
using HandleContent;

namespace HandleContent
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserContentDetails, ContentDto>();
            CreateMap<ContentDto, UserContentDetails>();
            CreateMap<UserContentDetails,ContentIdDto>();
            CreateMap<ContentIdDto,UserContentDetails>();
            CreateMap<UserFileDetails,FileDto>();
            CreateMap<FileDto,UserFileDetails>();
            CreateMap<UserFileDetails,FileIdDto>();
            CreateMap<FileIdDto,UserFileDetails>();
           
        }
    }
}