using AutoMapper;
using blogcore.Entities;
using blogcore.Web.ViewModels;

namespace blogcore.IoC.AutomapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentViewModel, CommentEntity>();
            CreateMap<CommentEntity, CommentViewModel>();
        }
    }
}
