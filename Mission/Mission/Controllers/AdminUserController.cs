using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Dto;
using Mission.Services;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUserController(IAdminUserService _adminUserService) : Controller
    {

        [HttpGet]
        [Route("UserDetailList")]
        public ActionResult UserDetailList()
        {
            try
            {
                var res = _adminUserService.UserDetailsList();
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get user list" });
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser( int userId)
        {
            try
            {
                var res = _adminUserService.UserDelete(userId);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user" });
            }
        }
        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult UpdateUser([FromForm] UpdateUserDto userData)
        {
            try
            {
                var updatedUser = _adminUserService.UpdateUser(userData);
                return Ok(new ResponseResult
                {
                    Data = updatedUser,
                    Result = ResponseStatus.Success,
                    Message = "User updated successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult
                {
                    Data = null,
                    Result = ResponseStatus.Error,
                    Message = ex.Message
                });
            }
        }

    }
}
