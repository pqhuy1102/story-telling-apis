using Business_Logic_Layer;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Story_Telling_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBLL _authBLL;

        public AuthController(IAuthBLL authBLL)
        {
            _authBLL = authBLL;
        }

        [HttpPost("register")]
        public async Task<ActionResult<CommonResponseModel<object>>> RegisterUser(UserModel userModel)
        {
            try
            {
                await _authBLL.RegisterUser(userModel);

                return Ok(new CommonResponseModel<object>
                {
                    status = "Successful!",
                    message = "Register successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message
                });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(UserModel userModel)
        {
            try
            {
                var token = await _authBLL.Login(userModel);
                return Ok(new
                {
                    userModel.Username,
                    token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseModel<object>
                {
                    status = "Failed!",
                    message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("getUserProfile"), Authorize]
        public ActionResult<object> GetUserProfile()
        {
            var username = User?.Identity?.Name;
            var userrole = User?.FindFirstValue(ClaimTypes.Role);
            return Ok(new { username, userrole });
        }



    }
}
