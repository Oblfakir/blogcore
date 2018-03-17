using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogcore.BLL.Interfaces;
using blogcore.Entities;
using blogcore.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace blogcore.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Articles")]
    public class ArticlesController : Controller
    {
        private readonly IArticleBLL _articleBll;

        public ArticlesController(IArticleBLL articleBll)
        {
            _articleBll = articleBll;
        }
        
        [HttpGet]
        public IEnumerable<ArticleEntity> Get()
        {
            return _articleBll.GetAllArticles();
        }
        
        [HttpGet("{id}", Name = "Get")]
        public ArticleEntity Get(int id)
        {
            return _articleBll.GetArticleById(id);
        }
        
        [HttpPost]
        public void Post(JObject value)
        {
            var user = value.ToObject<ArticleViewModel>();
            var a = 123;
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
