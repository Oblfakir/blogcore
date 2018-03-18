using AutoMapper;
using blogcore.Entities;
using blogcore.Web.ViewModels;

namespace blogcore.IoC.AutomapperProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleViewModel, ArticleEntity>();
            CreateMap<ArticleEntity, ArticleViewModel>();
        }
    }
}
