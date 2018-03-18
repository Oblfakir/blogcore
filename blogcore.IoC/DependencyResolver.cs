using AutoMapper;
using blogcore.BLL.Implementations;
using blogcore.BLL.Interfaces;
using blogcore.DAL.Implementations;
using blogcore.DAL.Interfaces;
using blogcore.IoC.AutomapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace blogcore.IoC
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IArticleDAL, ArticleDAL>();
            services.AddScoped<IArticleBLL, ArticleBLL>();

            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IUserBLL, UserBLL>();

            services.AddScoped<ICommentDAL, CommentDAL>();
            services.AddScoped<ICommentBLL, CommentBLL>();

            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services)
        {
            var mapperConfiguration = CreateConfiguration();
            services.AddSingleton(mapperConfiguration);
            services.AddScoped<IMapper>(context => new Mapper(mapperConfiguration, type => context.GetType()));

            return services;
        }

        private static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile<ArticleProfile>();
                config.AddProfile<UserProfile>();
                config.AddProfile<CommentProfile>();
            });
        }
    }
}