using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Interfaces;
using Zoho.Domain;
using Zoho.DTOs;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Zoho.API.Controllers.Dapper
{
    [ApiController]
    [Route("controller")]
    
    public class AuthController : ControllerBase
    {
        public readonly UnitOfWorkDemo.Core.Interfaces.IUserRepository userRepository;
        private readonly ITokenHandler handler;

        public AuthController(IUserRepository userRepository, ITokenHandler handler)
        {
            this.userRepository = userRepository;
            this.handler = handler;
        }

        [HttpPost]
        [Route("get_token")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO login)
        {
            User result = await userRepository.GetUser(login.UserName, login.Password);
            bool isAuthenticated = BCrypt.Net.BCrypt.Verify(login.Password, result.Password);
            if(isAuthenticated)
            {
                // Generate a JWT Token
                var token = await handler.CreateTokenAsync(result);
                return Ok(token);
            }
            

            return BadRequest("Username or Password is incorrect.");
        }

        //[HttpPost("create_user")]
        //[Authorize(Roles = "SuperAdmin")]
        //public async Task<IActionResult> CreateUser(CreateUserDTO userDetail)
        //{
        //    string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDetail.Password);
        //    User user = new User()
        //    {
        //        Name = userDetail.Name,
        //        Email = userDetail.Email,   
        //        Password= passwordHash,
        //        RoleName = userDetail.RoleName,
        //        IsDeleted = false
        //    };

        //    var result = await userRepository.Create(user);

        //    if (result)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        
        //[HttpGet("isvalid_user")]
        //[Authorize(Roles = "SuperAdmin")]
        //public async Task<IActionResult> GetUserDetail(string userName, string password)
        //{
        //    var result = await userRepository.GetUser(userName, password);
        //    bool verified = BCrypt.Net.BCrypt.Verify(password , result.Password);
        //    if (verified)
        //        return Ok("valid user!!!");
        //    return Ok("not valid user!!!");
        //}
    }
}
