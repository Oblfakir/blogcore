using System.Globalization;
using System.Linq;
using AutoMapper;
using blogcore.BLL.Interfaces;
using blogcore.Entities;
using blogcore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json.Linq;

namespace blogcore.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Articles")]
    public class ArticlesController : Controller
    {
        private readonly IArticleBLL _articleBll;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleBLL articleBll, IMapper mapper)
        {
            _articleBll = articleBll;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userIdParam = HttpContext.Request.Query["userId"].ToList().FirstOrDefault();

            if (userIdParam == null)
            {
                return Ok(_articleBll.GetAllArticles());
            }

            if (int.TryParse(userIdParam, NumberStyles.Any, CultureInfo.InvariantCulture, out int userId))
            {
                return Ok(_articleBll.GetArticlesByUserId(userId));
            }

            return BadRequest();
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var article = _articleBll.GetArticleById(id);

            if (article == null)
            {
                return NotFound();
            }

            var articleVm = _mapper.Map<ArticleViewModel>(article);

            return Ok(articleVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            try
            {
                var userVm = value.ToObject<ArticleViewModel>();
                var user = _mapper.Map<ArticleEntity>(userVm);

                var id = _articleBll.AddArticle(user);

                if (id == -1)
                {
                    return BadRequest();
                }

                return Created("", new { id });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            try
            {
                var userVm = value.ToObject<ArticleViewModel>();
                var user = _mapper.Map<ArticleEntity>(userVm);

                var result = _articleBll.ChangeArticle(id, user);

                if (id == -1)
                {
                    return BadRequest();
                }

                return Ok(new { result });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _articleBll.DeleteArticle(id);
            return Ok(new { result });
        }
    }
}
