using Items.DataAccess;
using Items.DataAccess.Models;
using Items.DataAccess.Repositories.Interface;
using Items.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using StationaryShop.Dto;
using StationaryShop.Helpers;

namespace StationaryShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserInterface _userService;
        private readonly JwtHelper _jwtHelper;

        public UserController(IUserInterface userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddUser(User user)
        {
            await _userService.AddUser(user);
            return Ok("User Added!");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] LoginReqDto dto)
        {
            var user = _userService.Login(dto.Email, dto.Password);

            if (user == null)
            {
                return NotFound("Please check your email & password");
            }

            var token = _jwtHelper.GetJwtToken(user);

            return Ok(new LoginResDto() { Email = user.Email, Name = user.Email, Role = user.Role, Token = token });
        }

        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetAllUsers([FromBody] FilterVM filterRequest)
        {
            var data = await _userService.GetAllUsers(filterRequest);
            return Ok(data);
        }
    }
}
