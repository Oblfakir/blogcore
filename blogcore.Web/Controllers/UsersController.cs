using System.Linq;
using AutoMapper;
using blogcore.BLL.Interfaces;
using blogcore.Entities;
using blogcore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace blogcore.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserBLL _userBll;
        private readonly IMapper _mapper;

        public UsersController(IUserBLL userBll, IMapper mapper)
        {
            _userBll = userBll;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userBll.GetAllUsers().Select(user => _mapper.Map<UserViewModel>(user)));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult Get(int id)
        {
            var user = _userBll.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var userVm = _mapper.Map<UserViewModel>(user);

            return Ok(userVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            try
            {
                var userVm = value.ToObject<UserViewModel>();
                var user = _mapper.Map<UserEntity>(userVm);

                var id = _userBll.AddUser(user);

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
        public IActionResult Put(int id, [FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            try
            {
                var userVm = value.ToObject<UserViewModel>();
                var user = _mapper.Map<UserEntity>(userVm);

                var result = _userBll.ChangeUser(id, user);

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
            var result = _userBll.DeleteUser(id);
            return Ok(new { result });
        }
    }
}
