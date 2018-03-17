using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogcore.BLL.Implementations;
using blogcore.BLL.Interfaces;
using blogcore.DAL.Implementations;
using blogcore.DAL.Interfaces;
using blogcore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace blogcore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppConfig.ConnectionString = Configuration["Production:MySqlConnectionString"];
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IArticleDAL, ArticleDAL>();
            services.AddScoped<IArticleBLL, ArticleBLL>();

            services.AddCors();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
