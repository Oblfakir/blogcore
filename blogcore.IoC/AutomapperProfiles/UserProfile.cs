using AutoMapper;
using blogcore.Entities;
using blogcore.Web.ViewModels;

namespace blogcore.IoC.AutomapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, UserEntity>();
            CreateMap<UserEntity, UserViewModel>()
                .ForMember(user => user.Password, config => config.Ignore());
        }
    }
}
