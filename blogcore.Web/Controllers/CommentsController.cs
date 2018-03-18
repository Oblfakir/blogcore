using System.Globalization;
using System.Linq;
using AutoMapper;
using blogcore.BLL.Interfaces;
using blogcore.DAL.Interfaces;
using blogcore.Entities;
using blogcore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace blogcore.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private readonly ICommentBLL _commentBll;
        private readonly IMapper _mapper;

        public CommentsController(ICommentBLL commentBll, IMapper mapper)
        {
            _commentBll = commentBll;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userIdParam = HttpContext.Request.Query["userId"].ToList().FirstOrDefault();
            var articleIdParam = HttpContext.Request.Query["articleId"].ToList().FirstOrDefault();

            if (userIdParam == null && articleIdParam == null)
            {
                return BadRequest(new {error = "userId or articleId must be specified"});
            }

            if (int.TryParse(userIdParam, NumberStyles.Any, CultureInfo.InvariantCulture, out int userId))
            {
                var comments = _commentBll.GetCommentsByUserId(userId);
                var commentVms = comments.Select(comment => _mapper.Map<CommentViewModel>(comment));
                return Ok(commentVms);
            }

            if (int.TryParse(articleIdParam, NumberStyles.Any, CultureInfo.InvariantCulture, out int articleId))
            {
                var comments = _commentBll.GetCommentsByArticleId(articleId);
                var commentVms = comments.Select(comment => _mapper.Map<CommentViewModel>(comment));
                return Ok(commentVms);
            }

            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetCommentById")]
        public IActionResult Get(int id)
        {
            var comment = _commentBll.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            var commentVm = _mapper.Map<CommentViewModel>(comment);

            return Ok(commentVm);
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
                var commentVm = value.ToObject<CommentViewModel>();
                var comment = _mapper.Map<CommentEntity>(commentVm);

                var id = _commentBll.AddComment(comment);

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
                var commentVm = value.ToObject<CommentViewModel>();
                var comment = _mapper.Map<CommentEntity>(commentVm);

                var result = _commentBll.ChangeComment(id, comment);

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
            var result = _commentBll.DeleteComment(id);
            return Ok(new { result });
        }
    }
}